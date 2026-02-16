using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Core;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Core.Paged_Result_DTOs;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Abstractions.Services;
using MoneyMindManager.Shared.DTOs.Permissions;
using MoneyMindManager.Shared.DTOs.User;

namespace MoneyMindManager.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IResultFactory _resultFactory;
        private readonly IUserMapper _userMapper;
        private readonly IAuthorizationService _authorizationService;
        private readonly IPermissionService _permissionService;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IResultFactory resultFactory, IUserMapper userMapper,
            IAuthorizationService authorizationService, IPermissionService permissionService, IPasswordHasher passwordHasher)
        {
            this._userRepository = userRepository;
            this._resultFactory = resultFactory;
            this._userMapper = userMapper;
            this._authorizationService = authorizationService;
            this._permissionService = permissionService;
            this._passwordHasher = passwordHasher;
        }

        public async Task<IResult<UserDTO>> Add(UserDTO userDTO, int currentUserID)
        {
            var handler = _resultFactory.Create<UserDTO>();

            if (userDTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.Admin);
            if (accessResult is null)
                return handler.Failure("failed to check permissions");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية إضافة/تعديل مستخدم.");

            userDTO.CreatedDate = DateTime.Now;
            userDTO.CreatedByUserID = currentUserID;

            var result = await _userRepository.Add(_userMapper.DTOToEntity(userDTO));

            if (result is null)
                return handler.Failure("failed to add user");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to add user");

            userDTO.UserID = result.Data;

            return handler.Success(userDTO);
        }

        public async Task<IResult<bool>> Update(UserDTO userDTO, int currentUserID)
        {
            var handler = _resultFactory.Create<bool>();

            if (userDTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.Admin);
            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية إضافة/تعديل مستخدم.");

            var user = _userMapper.DTOToEntity(userDTO);

            var result = await _userRepository.Update(user, currentUserID);

            if (result is null)
                return handler.Failure("failed to update user!");

            return result;
        }

        public async Task<IResult<UserDTO>> Login(LoginRequestDTO loginRequestDTO)
        {
            var handler = _resultFactory.Create<UserDTO>();

            var saltResult = await _userRepository.GetSaltByUserName(loginRequestDTO.UserName);
            if (saltResult is null)
                return handler.Failure("failed to get user salt");

            if (!saltResult.IsSuccess)
                return handler.Failure(saltResult.ErrorMessage);

            if (saltResult.Data is null)
                return handler.Failure("failed to get user salt");

            var salt = saltResult.Data;
            var hashedPassword = _passwordHasher.HashPassword(loginRequestDTO.Password, salt);

            var result = await _userRepository.Login(loginRequestDTO.UserName, hashedPassword);

            if (result is null)
                return handler.Failure("failed to login!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to login");

            var userDTO = _userMapper.EntityToDTO(result.Data);
            return handler.Success(userDTO);
        }

        public async Task<IResult<UserDTO>> GetByUserID(int userID)
        {
            var result = await _userRepository.GetByUserID(userID);

            var handler = _resultFactory.Create<UserDTO>();

            if (result is null)
                return handler.Failure("failed to get user!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to get user");

            var userDTO = _userMapper.EntityToDTO(result.Data);
            return handler.Success(userDTO);
        }

        public async Task<IResult<UserDTO>> GetByUserName(string userName)
        {
            var result = await _userRepository.GetByUserName(userName);

            var handler = _resultFactory.Create<UserDTO>();

            if (result is null)
                return handler.Failure("failed to get user!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to get user");

            var userDTO = _userMapper.EntityToDTO(result.Data);
            return handler.Success(userDTO);
        }

        public async Task<IResult<UserDTO>> GetByPersonID(int personID)
        {
            var result = await _userRepository.GetByPersonID(personID);

            var handler = _resultFactory.Create<UserDTO>();

            if (result is null)
                return handler.Failure("failed to get user!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to get user");

            var userDTO = _userMapper.EntityToDTO(result.Data);
            return handler.Success(userDTO);
        }

        public async Task<IResult<bool>> Delete(int userID, int currentUserID)
        {
            var handler = _resultFactory.Create<bool>();

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.Admin);
            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية حذف مستخدم.");

            var result = await _userRepository.DeleteByUserID(userID);

            if (result is null)
                return handler.Failure("failed to delete user!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            return handler.Success(result.Data);
        }

        public async Task<IResult<bool>> ChangePassword(int userID, string oldPassword, string newPassword, int currentUserID)
        {
            var handler = _resultFactory.Create<bool>();
            if (userID != currentUserID)
                return handler.Failure("غير مسموح بتغيير كلمة السر لمستخدم آخر");

            if (oldPassword != newPassword)
                return handler.Failure("كلمة السر الجديدة يجب أن تكون مختلفة عن كلمة السر القديمة ! ");

            var saltResult = await _userRepository.GetSaltByUserID(userID);
            if (saltResult is null)
                return handler.Failure("failed to get user salt");

            if (!saltResult.IsSuccess)
                return handler.Failure(saltResult.ErrorMessage);

            if (saltResult.Data is null)
                return handler.Failure("failed to get user salt");

            var oldSalt = saltResult.Data;
            var oldHashedPassword = _passwordHasher.HashPassword(oldPassword, oldSalt);
            string newSalt;
            var newHashedPassword = _passwordHasher.HashPasswordOutSalt(newPassword, out newSalt);

            var result = await _userRepository.ChangePassword(userID, oldHashedPassword, newHashedPassword, newSalt, currentUserID);

            if (result is null)
                return handler.Failure("failed to change password!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            return handler.Success(result.Data);
        }

        public async Task<IResult<PagedResultDTO<UserSummary>>> GetAll(UserFilterDTO userFilterDTO, int currentUserID)
        {
            var handler = _resultFactory.Create<PagedResultDTO<UserSummary>>();
            if (userFilterDTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var userSearchCriteria = _userMapper.UserFilterDTOTOUserSearchCriteria(userFilterDTO);
            userSearchCriteria.RowsPerPage = 15;
            var result = await _userRepository.GetAll(userSearchCriteria, currentUserID);

            if (result is null)
                return handler.Failure("failed to get all users");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result is null)
                return handler.Failure("failed to get all users");

            //var returnResult = new PagedResultDTO<UserDTO>(result.Data.Data.Select(entity => _userMapper.EntityToDTO(entity)),
            //    result.Data.TotalPages, result.Data.TotalRecords);

            return result;
        }

        public async Task<IResult<bool>> IsExistByUserID(int userID, bool includeDeleted = true)
        {
            var handler = _resultFactory.Create<bool>();

            var result = await _userRepository.IsExistByUserID(userID, includeDeleted);

            if (result is null)
                return handler.Failure("failed to check user existence");

            return result;
        }

        public async Task<IResult<bool>> IsExistByUserName(string userName, bool includeDeleted = true)
        {
            var handler = _resultFactory.Create<bool>();

            var result = await _userRepository.IsExistByUserName(userName, includeDeleted);

            if (result is null)
                return handler.Failure("failed to check user existence");

            return result;
        }

        public async Task<IResult<bool>> IsExistByPersonID(int personID, bool includeDeleted = true)
        {
            var handler = _resultFactory.Create<bool>();

            var result = await _userRepository.IsExistByPersonID(personID, includeDeleted);

            if (result is null)
                return handler.Failure("failed to check user existence");

            return result;
        }

        public async Task<IResult<bool>> IsHasPermission(int userID, enPermissions checkedPermission)
        {
            return await _authorizationService.CheckAccess(userID, checkedPermission);
        }

        public async Task<IResult<List<PermissionInfo>>> GetPermissions(int userID)
        {
            var handler = _resultFactory.Create<List<PermissionInfo>>();
            var userPermissionsResult = await _userRepository.GetPermissions(userID);

            if (userPermissionsResult is null)
                return handler.Failure("failed to get user permissions!");

            if (!userPermissionsResult.IsSuccess)
                return handler.Failure(userPermissionsResult.ErrorMessage);

            var result = _permissionService.GetPermissionMetadata(userPermissionsResult.Data);

            if (result is null)
                return handler.Failure("فشل جلب قائمة الصلاحيات");

            return handler.Success(result);
        }
    }
}
