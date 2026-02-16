using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Core.Paged_Result_DTOs;
using MoneyMindManager.Shared.DTOs.Permissions;
using MoneyMindManager.Shared.DTOs.User;

namespace MoneyMindManager.Client.Abstractions.ApiClient
{
    public interface IUserApiClient
    {
        Task<IResult<UserDTO>> Add(UserDTO user, int currentUserID);
        Task<IResult<bool>> Update(UserDTO user, int currentUserID);
        Task<IResult<UserDTO>> Login(LoginRequestDTO loginRequestDTO);
        Task<IResult<UserDTO>> GetByUserID(int userID);
        Task<IResult<UserDTO>> GetByUserName(string userName);
        Task<IResult<UserDTO>> GetByPersonID(int personID);
        Task<IResult<bool>> Delete(int userID, int currentUserID);
        Task<IResult<bool>> ChangePassword(int userID, string oldPassword, string newPassword, int currentUserID);
        Task<IResult<PagedResultDTO<UserSummary>>> GetAll(UserFilterDTO userFilterDTO, int currentUserID);
        Task<IResult<bool>> IsExistByUserID(int userID, bool includeDeleted = true);
        Task<IResult<bool>> IsExistByUserName(string userName, bool includeDeleted = true);
        Task<IResult<bool>> IsExistByPersonID(int personID, bool includeDeleted = true);
        Task<IResult<bool>> IsHasPermission(int userID, enPermissions checkedPermission);
        Task<IResult<List<PermissionInfo>>> GetPermissions(int userID);
    }
}
