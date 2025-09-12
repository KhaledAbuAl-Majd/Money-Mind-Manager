using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using MoneyMindManagerGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.clsUserClasses;
using static MoneyMindManagerGlobal.clsDataColumns.PersonClasses;

namespace MoneyMindManager_Business
{
    public class clsUser : clsUserColumns
    {
        public enum enMode { AddNew, Update };
        public enMode Mode { get; private set; } = enMode.AddNew;
        public clsPerson PersonInfo { get; private set; }
        public clsAccount AccountInfo { get; private set; }

        public bool EnterPersonIDAtAddMode(int personID  )
        {
            if (Mode == enMode.Update)
                return false;

            this.PersonID = personID;

            return true;
        }

        public bool EnterAccountIDAtAddMode(short accountID)
        {
            if (Mode == enMode.Update)
                return false;

            this.AccountID = accountID;

            return true;
        }

        /// <summary>
        /// Generate Salt for firstTime and hash password and store them at this object
        /// </summary>
        /// <param name="enteredPassword">the entered password (Normal - NotHashed)</param>
        /// <returns>false if Mode is Update, true if operation successed</returns>
        public bool EnterPasswordAtAddMode(string enteredPassword)
        {
            if (Mode == enMode.Update)
                return false;

            this.Salt = clsHashing.GenerateSalt();
            this.Password = HashingPassowrd(enteredPassword, this.Salt);

            return true;
        }

        public bool EnterCreatedByUserIDAtAddMode(int createdByUserID)
        {
            if (Mode == enMode.Update)
                return false;

            this.CreatedByUserID = createdByUserID;

            return true;
        }

        public async Task<clsUser> GetCreatedbyUserInfo()
        {
            return await clsUser.FindUserByUserID(Convert.ToInt32(CreatedByUserID));
        }

        public clsUser() : base()
        {
            Mode = enMode.AddNew;
            PersonInfo = null;
            AccountInfo = null;
        }

        private clsUser(int? userID, string userName, int? personID, int? permissions, string password,
            string salt, bool isActive, string notes, int? accountID, bool isDeleted, clsPerson personInfo,
            clsAccount accountInfo, int? createdByUserID, DateTime createdDate)
            : base(userID, userName, personID, permissions, password, salt, isActive, notes, Convert.ToInt16(accountID),
                  isDeleted,createdByUserID,createdDate)
        {
            this.Mode = enMode.Update;
            this.PersonInfo = personInfo;
            this.AccountInfo = accountInfo;
        }

        private async Task<bool> _AddNewUser()
        {
            this.CreatedDate = DateTime.Now;

            UserID = await clsUserData.AddNewUser(UserName, Convert.ToInt32(PersonID), Permissions, Password, Salt,
                IsActive, Convert.ToInt16(AccountID), Notes,Convert.ToInt32(CreatedByUserID));

            return (UserID != null);
        }

        private async Task<bool> _UpdateUser()
        {
            return await clsUserData.UpdateUser(Convert.ToInt32(UserID), UserName, Convert.ToInt32(PersonID), Permissions, IsActive, Notes);
        }

        async Task<bool> _RefeshCompositionObjects()
        {
            PersonInfo = await clsPerson.FindPersonByID(Convert.ToInt32(this.PersonID));
            AccountInfo = await clsAccount.FindAccountByAccountID(Convert.ToInt16(AccountID));

            return ((PersonInfo != null) && (AccountInfo != null));
        }

        public async Task<bool> Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (await _AddNewUser())
                        {
                            Mode = enMode.Update;
                            return await _RefeshCompositionObjects();
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    return await _UpdateUser();
            }

            return false;
        }

        /// <summary>
        /// Verify if entered password after hashing is equal to the stored password (don't go to DB)
        /// </summary>
        /// <param name="enteredPassword">the entered password (Normal - NotHashed)</param>
        /// <returns>Verifying result, true if it mathched, false if not</returns>
        public bool VerifyPassword(string enteredPassword)
        {
            return clsHashing.VerifyPassword(enteredPassword, this.Password, this.Salt);
        }

        /// <summary>
        /// Change User Password
        /// </summary>
        /// <param name="oldPassword">the old password (Normal - NotHashed)</param>
        /// <param name="newPassword">the new password (Normal - NotHashed)</param>
        /// <returns>Changing password result</returns>
        public async Task<bool> ChangePassword(string oldPassword, string newPassword)
        {
            string oldHashedPassword = HashingPassowrd(oldPassword, this.Salt);
            var newHashedPasswordWithSalt = clsHashing.HashPasswordWithSalt(newPassword);
            string newHashedPassword = newHashedPasswordWithSalt.HashedPassword;
            string newSalt = newHashedPasswordWithSalt.Salt;

            bool result = await clsUserData.ChangeUserPassword(Convert.ToInt32(this.UserID), oldHashedPassword, newHashedPassword, newSalt);

            if (result)
            {
                this.Password = newHashedPassword;
                this.Salt = newSalt;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userName">the entered userName</param>
        /// <param name="password">the entered password (Normal - NotHashed)</param>
        /// <returns>Object of clsUserColumns, if user is not found it will return null</returns>
        public static async Task<clsUser> FindUserByUserNameAndPassword_Login(string userName, string enteredpassword)
        {
            string salt = await GetUserSaltByUserName(userName);

            if (salt == null)
                return null;

            string hashedPassword = HashingPassowrd(enteredpassword, salt);

            clsUserColumns userColumns = await clsUserData.GetUserInfoByUserNameAndPassword_Login(userName, hashedPassword);

            if (userColumns == null)
                return null;

            clsPerson personInfo = await clsPerson.FindPersonByID(Convert.ToInt32(userColumns.PersonID));
            clsAccount accountInfo = await clsAccount.FindAccountByAccountID(Convert.ToInt16(userColumns.AccountID));

            if ((personInfo == null) || (accountInfo == null))
                return null;

            return new clsUser(userColumns.UserID, userColumns.UserName, userColumns.PersonID, userColumns.Permissions,
                userColumns.Password, userColumns.Salt, userColumns.IsActive, userColumns.Notes, userColumns.AccountID,
                userColumns.IsDeleted, personInfo, accountInfo,userColumns.CreatedByUserID,userColumns.CreatedDate);
        }

        /// <returns>Object of clsUserColumns, if user is not found it will return null</returns>
        public static async Task<clsUser> FindUserByUserID(int userID)
        {
            var userColumns = await clsUserData.GetUserInfoByUserID(userID);

            if (userColumns == null)
                return null;

            clsPerson personInfo = await clsPerson.FindPersonByID(Convert.ToInt32(userColumns.PersonID));

            clsAccount accountInfo = await clsAccount.FindAccountByAccountID(Convert.ToInt16(userColumns.AccountID));

            if ((personInfo == null) || (accountInfo == null))
                return null;

            return new clsUser(userColumns.UserID, userColumns.UserName, userColumns.PersonID, userColumns.Permissions,
                userColumns.Password, userColumns.Salt, userColumns.IsActive, userColumns.Notes, userColumns.AccountID,
                userColumns.IsDeleted, personInfo, accountInfo, userColumns.CreatedByUserID, userColumns.CreatedDate);
        }

        /// <returns>Object of clsUserColumns, if user is not found it will return null</returns>
        public static async Task<clsUser> FindUserByUserName(string userName)
        {
            clsUserColumns userColumns = await clsUserData.GetUserInfoByUserName(userName);

            if (userColumns == null)
                return null;

            clsPerson personInfo = await clsPerson.FindPersonByID(Convert.ToInt32(userColumns.PersonID));
            clsAccount accountInfo = await clsAccount.FindAccountByAccountID(Convert.ToInt16(userColumns.AccountID));

            if ((personInfo == null) || (accountInfo == null))
                return null;

            return new clsUser(userColumns.UserID, userColumns.UserName, userColumns.PersonID, userColumns.Permissions,
                userColumns.Password, userColumns.Salt, userColumns.IsActive, userColumns.Notes, userColumns.AccountID,
                userColumns.IsDeleted, personInfo, accountInfo, userColumns.CreatedByUserID, userColumns.CreatedDate);
        }

        /// <returns>Object of clsUserColumns, if user is not found it will return null</returns>
        public static async Task<clsUser> FindUserByPersonID(int personID)
        {
            clsUserColumns userColumns = await clsUserData.GetUserInfoByPersonID(personID);

            if (userColumns == null)
                return null;

            clsPerson personInfo = await clsPerson.FindPersonByID(Convert.ToInt32(userColumns.PersonID));
            clsAccount accountInfo = await clsAccount.FindAccountByAccountID(Convert.ToInt16(userColumns.AccountID));

            if ((personInfo == null) || (accountInfo == null))
                return null;

            return new clsUser(userColumns.UserID, userColumns.UserName, userColumns.PersonID, userColumns.Permissions,
                userColumns.Password, userColumns.Salt, userColumns.IsActive, userColumns.Notes, userColumns.AccountID,
                userColumns.IsDeleted, personInfo, accountInfo, userColumns.CreatedByUserID, userColumns.CreatedDate);
        }

        public static async Task<bool> DeleteUserByUserID(int userID)
        {
            return await clsUserData.DeleteUserByUserID(userID);
        }

        public async Task<bool> RefreshData()
        {
            clsUser freshUser = await clsUser.FindUserByUserID(Convert.ToInt32(this.UserID));

            if (freshUser == null)
                return false;

            this.UserID = freshUser.UserID;
            this.UserName = freshUser.UserName;
            this.PersonID = freshUser.PersonID;
            this.Permissions = freshUser.Permissions;
            this.Password = freshUser.Password;
            this.Salt = freshUser.Salt;
            this.IsActive = freshUser.IsActive;
            this.Notes = freshUser.Notes;
            this.AccountID = freshUser.AccountID;
            this.IsDeleted = freshUser.IsDeleted;
            this.CreatedByUserID = freshUser.CreatedByUserID;
            this.CreatedDate = freshUser.CreatedDate;

            this.PersonInfo = freshUser.PersonInfo;
            this.AccountInfo = freshUser.AccountInfo;

            return true;
        }

        /// <returns>UserSalt, if failed return null</returns>
        public static async Task<string> GetUserSaltByUserName(string userName)
        {
            return await clsUserData.GetUserSaltByUserName(userName);
        }

        /// <summary>
        /// Hashing passowrd
        /// </summary>
        /// <param name="enteredPassword">the entered password (Normal - NotHashed)</param>
        /// <param name="salt">the user salt</param>
        /// <returns>return hashed password</returns>
        public static string HashingPassowrd(string enteredPassword,string salt)
        {
            return clsHashing.ComputeHash(clsHashing.GetSaltedPassword(enteredPassword, salt));
        }

        /// <summary>
        /// Get All Users For Account Using Paging [10 rows per page]
        /// </summary>
        /// <param name="accountID">The current AccountID</param>
        /// <param name="pageNumber">The page Number you want to get rows of it</param>
        /// <returns>object of clsGetAllUsers : if error happend, return null</returns>
        public static async Task<clsGetAllUsers> GetAllUsers(short accountID, short pageNumber)
        {
            return await clsUserData.GetAllUsers(accountID, pageNumber);
        }

        /// <summary>
        /// Get All Users By UserID For Account Using Paging [10 rows per page]
        /// </summary>
        /// <param name="accountID">The current AccountID</param>
        /// <param name="pageNumber">The page Number you want to get rows of it</param>
        /// <returns>object of clsGetAllUsers : if error happend, return null</returns>
        public static async Task<clsGetAllUsers> GetAllUsersByUserID(short accountID, short pageNumber, int userID, bool RaiseEventOnErrorOccured = true)
        {
            return await clsUserData.GetAllUsersByUserID(accountID, pageNumber, userID);
        }

        /// <summary>
        /// Get All Users By UserName For Account Using Paging [10 rows per page]
        /// </summary>
        /// <param name="accountID">The current AccountID</param>
        /// <param name="pageNumber">The page Number you want to get rows of it</param>
        /// <returns>object of clsGetAllUsers : if error happend, return null</returns>
        public static async Task<clsGetAllUsers> GetAllUsersByUserName(short accountID, short pageNumber, string userName, bool RaiseEventOnErrorOccured = true)
        {
            return await clsUserData.GetAllUsersByUserName(accountID, pageNumber, userName);
        }

        /// <summary>
        /// Get All Users By personName For Account Using Paging [10 rows per page]
        /// </summary>
        /// <param name="accountID">The current AccountID</param>
        /// <param name="pageNumber">The page Number you want to get rows of it</param>
        /// <returns>object of clsGetAllUsers : if error happend, return null</returns>
        public static async Task<clsGetAllUsers> GetAllUsersByPersonName(short accountID, short pageNumber, string personName, bool RaiseEventOnErrorOccured = true)
        {
            return await clsUserData.GetAllUsersByPersonName(accountID, pageNumber, personName);
        }

        /// <summary>
        /// Get All Users By IsActive For Account Using Paging [10 rows per page]
        /// </summary>
        /// <param name="accountID">The current AccountID</param>
        /// <param name="pageNumber">The page Number you want to get rows of it</param>
        /// <returns>object of clsGetAllUsers : if error happend, return null</returns>
        public static async Task<clsGetAllUsers> GetAllUsersByIsActive(short accountID, short pageNumber, bool isActive, bool RaiseEventOnErrorOccured = true)
        {
            return await clsUserData.GetAllUsersByIsActive(accountID, pageNumber, isActive);
        }

        /// <param name="userID">UserID of user you want to find</param>
        /// <returns>true if user exist, false if user not exist</returns>
        public static async Task<bool> IsUserExistByUserIDAsync(int userID)
        {
            return await clsUserData.IsUserExistByUserID(userID, false);
        }

        /// <param name="personID">PersonID of user you want to find</param>
        /// <returns>true if user exist, false if user not exist</returns>
        public static async Task<bool> IsUserExistByPersonIDAsync(int personID)
        {
            return await clsUserData.IsUserExistByPersonID(personID, false);
        }

        /// <param name="userName">userName of user you want to find</param>
        /// <returns>true if user exist, false if user not exist</returns>
        public static async Task<bool> IsUserExistByUserNameAsync(string userName)
        {
            return await clsUserData.IsUserExistByUserNameAsync(userName,false);
        }

        /// <param name="userName">userName of user you want to find</param>
        /// <returns>true if user exist, false if user not exist</returns>
        public static bool IsUserExistByUserName(string userName)
        {
            return clsUserData.IsUserExistByUserName(userName, false);
        }
    }
}
