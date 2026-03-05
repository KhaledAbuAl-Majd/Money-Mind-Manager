using MoneyMindManager.UI.Abstractions;

namespace MoneyMindManager.UI.Services
{
    public class WindowsRegistrysettings : IWindowsRegisterysettings
    {
        public string SubKeyName { get; } = @"Software\MonyMindManager";
        public string UserNameValueName { get; } = "UserName";
        public string PasswordValueName { get; } = "Password";

    }
}
