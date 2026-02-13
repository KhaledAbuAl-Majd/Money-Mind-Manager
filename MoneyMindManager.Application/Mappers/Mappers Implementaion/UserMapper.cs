using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.User;

namespace MoneyMindManager.Application.Mappers.Mappers_Implementaion
{
    public class UserMapper : IUserMapper
    {
        public User DTOToEntity(UserDTO userDTO)
        {
            if (userDTO is null)
                return null;

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
                Permissions = userDTO.Permissions,
                PersonID = userDTO.PersonID
            };
        }

        public UserDTO EntityToDTO(User user)
        {
            if (user is null)
                return null;

            return new UserDTO(user.UserID, user.UserName, user.PersonID, user.Permissions, user.IsActive, user.Notes, user.AccountID, user.IsDeleted,
                user.CreatedByUserID, user.CreatedDate);
        }
    }
}
