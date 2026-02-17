using System;
using System.Threading.Tasks;
using Microsoft.Win32;
using MoneyMindManager.Core;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.UI.Abstractions;

namespace MoneyMindManager.UI.Services
{
    public class WindowsRegistryUserCredentialsService : IUserCredentialsService
    {
        private readonly IWindowsRegisterysettings _windowsRegisterysettings;
        private readonly ILogger _logger;
        private readonly ISymmetricEncryption _symmetricEncryption;
        public WindowsRegistryUserCredentialsService(IWindowsRegisterysettings windowsRegisterysettings, ILogger logger, ISymmetricEncryption symmetricEncryption)
        {
            this._windowsRegisterysettings = windowsRegisterysettings;
            this._logger = logger;
            this._symmetricEncryption = symmetricEncryption;
        }

        public async Task<bool> RememberUsernameAndPassword(string Username, string Password)
        {
            return await Task<bool>.Run(() =>
            {
                try
                {
                    using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                    {
                        using (RegistryKey key = baseKey.CreateSubKey(_windowsRegisterysettings.SubKeyName, true))
                        {
                            if (key != null)
                            {
                                if (Username == null || Password == null)
                                {
                                    if (key.GetValue(_windowsRegisterysettings.UserNameValueName) != null)
                                        key.DeleteValue(_windowsRegisterysettings.UserNameValueName);

                                    if (key.GetValue(_windowsRegisterysettings.PasswordValueName) != null)
                                        key.DeleteValue(_windowsRegisterysettings.PasswordValueName);
                                }
                                else
                                {
                                    string EncryptedUserName = _symmetricEncryption.Encrypt(Username);
                                    string EncryptedPassword = _symmetricEncryption.Encrypt(Password);

                                    key.SetValue(_windowsRegisterysettings.UserNameValueName, EncryptedUserName, RegistryValueKind.String);

                                    key.SetValue(_windowsRegisterysettings.PasswordValueName, EncryptedPassword, RegistryValueKind.String);
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
                    _logger.LogError(ex.Message);
                    //_messageBoxService.DisplayError($"failed to save remeber me: {ex.Message}");
                    return false;
                }

            });
        }
        public async Task<(bool Result, string UserName, string Password)> GetStoredCredential()
        {
            string userName = null, password = null;
            bool result = false;

            result = await Task<bool>.Run(() =>
            {
                try
                {
                    using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                    {
                        using (RegistryKey key = baseKey.OpenSubKey(_windowsRegisterysettings.SubKeyName, true))
                        {
                            if (key != null)
                            {
                                string EncryptedUsername = key.GetValue(_windowsRegisterysettings.UserNameValueName) as string;

                                string EncryptedPassword = key.GetValue(_windowsRegisterysettings.PasswordValueName) as string;

                                if (EncryptedUsername == null || EncryptedPassword == null)
                                    return false;

                                userName = _symmetricEncryption.Decrypt(EncryptedUsername);
                                password = _symmetricEncryption.Decrypt(EncryptedPassword);
                            }
                        }

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    userName = null;
                    password = null;
                    _logger.LogError(ex.Message);
                    //_messageBoxService.DisplayError($"failed to get stored credentails{ex.Message}");
                    return false;
                }
            });

            return (result, userName, password);
        }
    }
}
