using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Domain.Criteria;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs;
using MoneyMindManager.Shared.DTOs.User;

namespace MoneyMindManager.Domain.Abstractions
{
    public interface IUserRepository
    {
        Task<IResult<int?>> Add(User user);
        Task<IResult<bool>> Update(User user, int currentUserID);
        Task<IResult<bool>> ChangePassword(int userID, string oldPassword, string newPassword, string newSalt, int currentUserID);
        Task<IResult<bool>> DeleteByUserID(int userID);
        Task<IResult<User>> Login(string userName, string password);
        Task<IResult<User>> GetByUserID(int userID);
        Task<IResult<User>> GetByUserName(string userName);
        Task<IResult<User>> GetByPersonID(int personID);
        Task<IResult<bool>> IsExistByUserID(int userID, bool includeDeleted);
        Task<IResult<bool>> IsExistByPersonID(int personID, bool includeDeleted);
        Task<IResult<bool>> IsExistByUserName(string userName, bool includeDeleted);
        Task<IResult<string>> GetSaltByUserID(int userID);
        Task<IResult<string>> GetSaltByUserName(string userName);
        Task<IResult<PagedResultDTO<User>>> GetAll(UserSearchCriteria userFilterDTO, int currentUserID);
        Task<IResult<int>> GetPermissions(int userID);
    }
}
