using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Application.Abstractions.Services
{
    public interface IAuthorizationService
    {
        Task<IResult<bool>> CheckAccess(int userID, enPermissions permission);
    }
}
