using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Microsoft.Win32;
using MoneyMindManager_Business;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Main;
using MoneyMindManagerGlobal;

namespace MoneyMindManager_Presentation
{
    public static class clsGlobal_UI
    {
        private static System.Timers.Timer _refreshTimer;
        public static clsUser CurrentUser { get;private set; }

        public static frmMain MainForm { get; private set; }

        private static void _StartTimer()
        {
            _refreshTimer = new System.Timers.Timer(300000);
            _refreshTimer.Elapsed += async (s,e) => await RefreshCurrentUser();
            _refreshTimer.AutoReset = true;
            _refreshTimer.Enabled = true;
            _refreshTimer.Start();
        }

        private static void _StopTimer()
        {
            _refreshTimer?.Stop();
            _refreshTimer?.Dispose();
            _refreshTimer = null;
        }

        public static async Task RefreshCurrentUser()
        {
            CurrentUser = await clsUser.FindUserByUserID(Convert.ToInt32(CurrentUser?.UserID), Convert.ToInt32(CurrentUser?.UserID));

            if (CurrentUser == null)
            {
                clsGlobalMessageBoxs.ShowErrorMessage("المستخدم الحالي غير موجود سيتم تسجيل خروجك !");
                Logout();
                return;
            }

            if (CurrentUser?.IsActive == false)
            {
                clsGlobalMessageBoxs.ShowErrorMessage("المستخدم الحالي موقوف, سيتم تسجيل خروجك !");
                Logout();
                return;
            }

            _refreshTimer.Stop();
            _refreshTimer.Start();
        }

        public static async Task Login(int userID,frmMain frmmain)
        {
            clsUser user = await clsUser.FindUserByUserID(userID, userID);

            if (user == null)
            {
                Logout();
                return;
            }

            CurrentUser = user;
            MainForm = frmmain;
            _StartTimer();
        }

        public static void Logout()
        {
            _StopTimer();
            CurrentUser = null;

            if(MainForm !=null && !MainForm.IsDisposed)
            {
                MainForm.Invoke(new Action(() =>
                {
                    MainForm?.Close();
                    MainForm = null;
                }
                ));
            }
        }
        public static void SubscribeToErrorOcrruedEvent()
        {
            clsGlobalEvents.OnErrorOccured += clsGlobalMessageBoxs.ShowErrorMessage;

            //SynchronizationContext uiContext = SynchronizationContext.Current;

            //clsGlobalEvents.OnErrorOccured += message =>
            //{
            //    uiContext.Post(_ =>
            //    {
            //        MessageBoxOptions options = 0;

            //        // التشييك لو الرسالة فيها حروف عربية
            //        if (message.Any(c => c >= 0x0600 && c <= 0x06FF))
            //        {
            //            options = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
            //        }

            //        MessageBox.Show(message, "حدث خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
            //    }, null);

            //};
        }

        private static class clsRegisteryConstants
        {
            public static string SubKeyName = @"Software\MonyMindManager";

            public static string UserNameValueName = "UserName";

            public static string PasswordValueName = "Password";

        }

        /// <summary>
        /// Store UserName & Password After Encrypt it at Windows Registery 
        /// If UserName Or Password = null, it will remove the old value from registery
        /// </summary>
        /// <returns>Success Value</returns>
        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            try
            {
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey key = baseKey.CreateSubKey(clsRegisteryConstants.SubKeyName,true))
                    {
                        if (key != null)
                        {
                            if (Username == null || Password == null)
                            {
                                if (key.GetValue(clsRegisteryConstants.UserNameValueName) != null)
                                    key.DeleteValue(clsRegisteryConstants.UserNameValueName);

                                if (key.GetValue(clsRegisteryConstants.PasswordValueName) != null)
                                    key.DeleteValue(clsRegisteryConstants.PasswordValueName);
                            }
                            else
                            {
                                string EncryptedUserName = clsSymmetricEncryption.Encrypt(Username);
                                string EncryptedPassword = clsSymmetricEncryption.Encrypt(Password);

                                key.SetValue(clsRegisteryConstants.UserNameValueName, EncryptedUserName, RegistryValueKind.String);

                                key.SetValue(clsRegisteryConstants.PasswordValueName, EncryptedPassword, RegistryValueKind.String);
                            }
                        }
                        else
                            return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                clsGlobalEvents.RaiseEvent(ex.Message, true);
                return false;
            }
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            try
            {
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey key = baseKey.OpenSubKey(clsRegisteryConstants.SubKeyName, true))
                    {
                        if (key != null)
                        {
                            string EncryptedUsername = key.GetValue(clsRegisteryConstants.UserNameValueName) as string;

                            string EncryptedPassword = key.GetValue(clsRegisteryConstants.PasswordValueName) as string;

                            if (EncryptedUsername == null || EncryptedPassword == null)
                                return false;

                            Username = clsSymmetricEncryption.Decrypt(EncryptedUsername);
                            Password = clsSymmetricEncryption.Decrypt(EncryptedPassword);
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                clsGlobalEvents.RaiseEvent(ex.Message, true);
                return false;
            }
        }
    }
}
