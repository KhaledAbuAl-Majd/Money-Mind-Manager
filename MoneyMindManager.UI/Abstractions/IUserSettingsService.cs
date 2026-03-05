using System.Threading.Tasks;
using MoneyMindManager.UI.Models;

namespace MoneyMindManager.UI.Abstractions
{
    public interface IUserSettingsService
    {
        Task<UserSettings> Get(int userID, bool defaultIfFailed = true);
        Task<bool> Save(UserSettings userSettings);
        UserSettings GetDefault(int userID);
        UserSettings Clone(UserSettings userSettings);
    }
}
