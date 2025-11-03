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
    public static class clsPL_Global
    {
        private static System.Timers.Timer _refreshTimer;
        public static clsUser CurrentUser { get;private set; }
        public static clsUserSettings CurrentUserSettings { get;private set; }
        public static frmMain MainForm { get; private set; }
        public static Form ActiveForm { get; set; }

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

        public static async Task<bool> RefreshCurrentUser()
        {
            _refreshTimer.Stop();

            string oldUserName = CurrentUser.UserName;

            CurrentUser = await clsUser.FindUserByUserID(Convert.ToInt32(CurrentUser?.UserID));

            if (CurrentUser == null)
            {
                clsPL_MessageBoxs.ShowErrorMessage("المستخدم الحالي غير موجود سيتم تسجيل خروجك !");
                Logout();
                return false;
            }

            if (CurrentUser?.IsActive == false)
            {
                clsPL_MessageBoxs.ShowErrorMessage("المستخدم الحالي موقوف, سيتم تسجيل خروجك !");
                Logout();
                return false;
            }

            clsGlobalSession.Login(Convert.ToInt32(CurrentUser.UserID), Convert.ToInt32(CurrentUser.Permissions));

            if (oldUserName != CurrentUser.UserName)
                MainForm.LoadMainFormLabels();

            _refreshTimer.Start();

            return true;
        }

        public static async Task<bool> Login(int userID,frmMain frmMain)
        {
            clsUser user = await clsUser.FindUserByUserID(userID);

            if (user == null)
            {
                Logout();
                return false;
            }


            CurrentUser = user;

            clsGlobalSession.Login(Convert.ToInt32(CurrentUser.UserID), Convert.ToInt32(CurrentUser.Permissions));

            CurrentUserSettings = await clsUserSettings.GetUserSettings(Convert.ToInt32(user.UserID), true);

            if (CurrentUserSettings == null)
            {
                Logout();
                return false;
            }

            MainForm = frmMain;
            ActiveForm = frmMain;
            _StartTimer();

            return true;
        }

        public static async Task<bool> Login(clsUser user, frmMain frmMain)
        {
            if (user == null)
            {
                Logout();
                return false;
            }

            CurrentUser = user;

            clsGlobalSession.Login(Convert.ToInt32(CurrentUser.UserID), Convert.ToInt32(CurrentUser.Permissions));

            CurrentUserSettings = await clsUserSettings.GetUserSettings(Convert.ToInt32(user.UserID), true);

            if (CurrentUserSettings == null)
            {
                Logout();
                return false;
            }

            MainForm = frmMain;
            ActiveForm = frmMain;
            _StartTimer();

            return true;
        }

        public static void Logout()
        {
            _StopTimer();
            CurrentUser = null;
            CurrentUserSettings = null;

            if(MainForm !=null && !MainForm.IsDisposed)
            {
                MainForm.Invoke(new Action(() =>
                {
                    ActiveForm = null;
                    MainForm?.Close();
                    MainForm = null;
                }
                ));
            }

            clsGlobalSession.Logout();
        }
        public static void SubscribeToErrorOcrruedEvent()
        {
            clsGlobalEvents.OnErrorOccured +=  clsPL_MessageBoxs.ShowErrorMessage;
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
        public static async Task<bool> RememberUsernameAndPassword(string Username, string Password)
        {
            return await Task<bool>.Run(() =>
             {
                 try
                 {
                     using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                     {
                         using (RegistryKey key = baseKey.CreateSubKey(clsRegisteryConstants.SubKeyName, true))
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
                     clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
                     return false;
                 }

             });
        }

        public static async Task<(bool Result, string UserName, string Password)> GetStoredCredential()
        {
            string userName = null, password = null;
            bool result = false;

            result = await Task<bool>.Run(() =>
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

                                userName = clsSymmetricEncryption.Decrypt(EncryptedUsername);
                                password = clsSymmetricEncryption.Decrypt(EncryptedPassword);
                            }
                        }

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    userName = null;
                    password = null;
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
                    return false;
                }
            });

            return (result, userName, password);
        }
    }
}
