using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Core.Paged_Result_DTOs;
using MoneyMindManager.Shared.DTOs.Permissions;
using MoneyMindManager.Shared.DTOs.User;

namespace MoneyMindManager.APIClient.Api_Client_Implementation
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IUserService _userService;

        public UserApiClient(IUserService userService)
        {
            this._userService = userService;
        }

        public async Task<IResult<UserDTO>> Add(CreateUserDTO user, int currentUserID)
        {
            return await _userService.Add(user, currentUserID);
        }

        public async Task<IResult<bool>> Update(UserDTO user, int currentUserID)
        {
            return await _userService.Update(user, currentUserID);
        }

        public async Task<IResult<UserDTO>> Login(LoginRequestDTO loginRequestDTO)
        {
            return await _userService.Login(loginRequestDTO);
        }

        public async Task<IResult<UserDTO>> GetByUserID(int userID)
        {
            return await _userService.GetByUserID(userID);
        }

        public async Task<IResult<UserDTO>> GetByUserName(string userName)
        {
            return await _userService.GetByUserName(userName);
        }

        public async Task<IResult<UserDTO>> GetByPersonID(int personID)
        {
            return await _userService.GetByPersonID(personID);
        }

        public async Task<IResult<bool>> Delete(int userID, int currentUserID)
        {
            return await _userService.Delete(userID, currentUserID);
        }

        public async Task<IResult<bool>> ChangePassword(int userID, string oldPassword, string newPassword, int currentUserID)
        {
            return await _userService.ChangePassword(userID, oldPassword, newPassword, currentUserID);
        }

        public async Task<IResult<PagedResultDTO<UserSummary>>> GetAll(UserFilterDTO userFilterDTO, int currentUserID)
        {
            return await _userService.GetAll(userFilterDTO, currentUserID);
        }

        public async Task<IResult<bool>> IsExistByUserID(int userID, bool includeDeleted = true)
        {
            return await _userService.IsExistByUserID(userID, includeDeleted);
        }

        public async Task<IResult<bool>> IsExistByUserName(string userName, bool includeDeleted = true)
        {
            return await _userService.IsExistByUserName(userName, includeDeleted);
        }

        public async Task<IResult<bool>> IsExistByPersonID(int personID, bool includeDeleted = true)
        {
            return await _userService.IsExistByPersonID(personID, includeDeleted);
        }

        public async Task<IResult<bool>> IsHasPermission(int userID, enPermissions checkedPermission)
        {
            return await _userService.IsHasPermission(userID, checkedPermission);
        }

        public async Task<IResult<List<PermissionInfo>>> GetPermissions(int userID)
        {
            return await _userService.GetPermissions(userID);
        }

        public async Task<IResult<List<PermissionInfo>>> GetPermissionsMetadata()
        {
            return await _userService.GetPermissionsMetadata();
        }
    }
}
