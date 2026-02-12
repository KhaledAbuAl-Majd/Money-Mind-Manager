using System;
using System.Threading.Tasks;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs;
using MoneyMindManager.Shared.DTOs.User;

namespace MoneyMindManager.Domain.Abstractions
{
    public interface IUserRepository
    {
        /// <returns>New UserID if Success, if failed return null</returns>
        Task<Nullable<int>> Add(User user);

        /// <returns>Updating Result</returns>
        Task<bool> Update(User user, int currentUserID);

        /// <param name="oldPassword">the old hashed password</param>
        /// <param name="newPassword">the new hashed password</param>
        /// <param name="newSalt">the new salt of the new hashed password</param>
        /// <returns>Updating Result</returns>
        Task<bool> ChangePassword(int userID, string oldPassword, string newPassword,
            string newSalt, int currentUserID);

        /// <returns>Deleting Result</returns>
        Task<bool> DeleteByUserID(int userID);

        /// <returns>Object of User, if user is not found it will return null</returns>
        Task<User> GetByUserNameAndPassword_Login(string userName, string password);

        /// <returns>Object of User, if user is not found it will return null</returns>
        Task<User> GetByUserID(int userID);


        /// <returns>Object of User, if user is not found it will return null</returns>
        Task<User> GetByUserName(string userName);


        /// <returns>Object of User, if user is not found it will return null</returns>
        Task<User> GetByPersonID(int personID);

        /// <param name="userID">UserID of user you want to find</param>
        /// <returns>true if user exist, false if user not exist</returns>
        Task<bool> IsExistByUserID(int userID, bool includeDeleted);

        /// <param name="personID">PersonID of user you want to find</param>
        /// <returns>true if user exist, false if user not exist</returns>
        Task<bool> IsExistByPersonID(int personID, bool includeDeleted);

        /// <param name="userName">userName of user you want to find</param>
        /// <returns>true if user exist, false if user not exist</returns>
        Task<bool> IsExistByUserName(string userName, bool includeDeleted);

        /// <returns>UserSalt, if failed return null</returns>
        Task<string> GetUserSaltByUserName(string userName);

        /// <summary>
        /// Get All Users For Account Using Paging , if variable is null will not filter by it
        /// </summary>
        /// <returns>object of <PagedResultDTO<User> : if error happend, return null</returns>
        Task<PagedResultDTO<User>> GetAll(UserFilterDTO userFilterDTO, byte rowsPerPage, int currentUserID);
    }
}
