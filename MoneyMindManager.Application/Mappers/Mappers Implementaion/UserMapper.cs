using System.Linq;
using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Domain.Abstractions.Services;
using MoneyMindManager.Domain.Criteria;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.User;

namespace MoneyMindManager.Application.Mappers.Mappers_Implementaion
{
    public class UserMapper : IUserMapper
    {
        private readonly IPermissionService _permissionService;

        public UserMapper(IPermissionService permissionService)
        {
            this._permissionService = permissionService;
        }

        public User DTOToEntity(UserDTO userDTO)
        {
            if (userDTO is null || userDTO.PermissionsList is null)
                return null;

            int permissions = _permissionService.CalculatePermissions(userDTO.PermissionsList.Select(permission => permission.ItemValue));

            return new User()
            {
                UserID = userDTO.UserID,
                AccountID = userDTO.AccountID,
                UserName = userDTO.UserName,
                CreatedByUserID = userDTO.CreatedByUserID,
                CreatedDate = userDTO.CreatedDate,
                IsActive = userDTO.IsActive,
                IsDeleted = userDTO.IsDeleted,
                Notes = userDTO.Notes,
                Permissions = permissions,
                PersonID = userDTO.PersonID
            };
        }

        public UserDTO EntityToDTO(User user)
        {
            if (user is null)
                return null;

            var permissionsList = _permissionService.GetPermissionMetadata(user.Permissions);
            return new UserDTO(user.UserID, user.UserName, user.PersonID, permissionsList,user.Permissions, user.IsActive, user.Notes, user.AccountID, user.IsDeleted,
                user.CreatedByUserID, user.CreatedDate);
        }

        public UserSearchCriteria UserFilterDTOTOUserSearchCriteria(UserFilterDTO userFilterDTO)
        {
            if (userFilterDTO is null)
                return null;

            return new UserSearchCriteria()
            {
                IsActive = userFilterDTO.IsActive,
                PageNumber = userFilterDTO.PageNumber,
                PersonName = userFilterDTO.PersonName,
                UserID = userFilterDTO.UserID,
                UserName = userFilterDTO.UserName,
                TextSearchMode = (byte)userFilterDTO.TextSearchMode
            };
        }
    }
}
