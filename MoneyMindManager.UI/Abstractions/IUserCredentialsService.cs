using System.Threading.Tasks;

namespace MoneyMindManager.UI.Abstractions
{
    public interface IUserCredentialsService
    {
        Task<bool> RememberUsernameAndPassword(string Username, string Password);
        Task<(bool Result, string UserName, string Password)> GetStoredCredential();
    }
}
