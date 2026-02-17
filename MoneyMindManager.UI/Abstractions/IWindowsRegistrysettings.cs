namespace MoneyMindManager.UI.Abstractions
{
    public interface IWindowsRegisterysettings
    {
        string SubKeyName { get; }
        string UserNameValueName { get; }
        string PasswordValueName { get; }
    }
}
