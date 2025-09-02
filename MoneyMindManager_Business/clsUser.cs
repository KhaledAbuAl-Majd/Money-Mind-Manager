using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using MoneyMindManagerGlobal;

namespace MoneyMindManager_Business
{
    public class clsUser : clsUserData.clsUserColumns
    {
        public enum enMode { AddNew, Update };
        public enMode Mode { get; private set; } = enMode.AddNew;
        clsPerson PersonInfo { get; set; }

        public clsUser() : base()
        {
            Mode = enMode.AddNew;
            PersonInfo = null;
        }

        private clsUser(int? userID, string userName, int? personID, int? permissions, string password,
            string salt, bool isActive, string notes, int? accountID, bool isDeleted, clsPerson personInfo)
            : base(userID, userName, personID, permissions, password, salt, isActive, notes, accountID, isDeleted)
        {
            Mode = enMode.Update;
            PersonInfo = personInfo;
        }
        
        private async Task<bool> _AddNewUser()
        {
            UserID = await clsUserData.AddNewUser(UserName, Convert.ToInt32(PersonID), Permissions, Password, Salt,
                IsActive, Convert.ToInt32(AccountID), Notes);

            return (UserID != null);
        }

        private async Task<bool> _UpdateUser()
        {
            return await clsUserData.UpdateUser(Convert.ToInt32(UserID), UserName, Convert.ToInt32(PersonID), Permissions, IsActive, Notes);
        }

        async Task<bool> _RefeshCompositionObjects()
        {
            PersonInfo = await clsPerson.FindPersonByID(Convert.ToInt32(this.PersonID));

            return (PersonInfo != null);
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
            string oldHashedPassword = clsHashing.ComputeHash(clsHashing.GetSaltedPassword(oldPassword, this.Salt));
            var newHashedPasswordWithSalt = clsHashing.HashPasswordWithSalt(newPassword);
            string newHashedPassword = newHashedPasswordWithSalt.HashedPassword;
            string newSalt = newHashedPasswordWithSalt.Salt;

            bool result = await clsUserData.ChangeUserPassword(Convert.ToInt32(this.UserID),oldHashedPassword,newHashedPassword,newSalt);

            if (result)
            {
                this.Password = newHashedPassword;
                this.Salt = newSalt;
                return true;
            }
            else
                return false;
        }

        /// <returns>Object of clsUserColumns, if user is not found it will return null</returns>
        public static async Task<clsUser> FindUserByUserID(int userID)
        {
            clsUserData.clsUserColumns userColumns = await clsUserData.GetUserInfoByUserID(userID);

            if (userColumns == null)
                return null;

            clsPerson personInfo = await clsPerson.FindPersonByID(Convert.ToInt32(userColumns.PersonID));

            if (personInfo == null)
                return null;

            return new clsUser(userColumns.UserID, userColumns.UserName, userColumns.PersonID, userColumns.Permissions, userColumns.Password,
                userColumns.Salt, userColumns.IsActive, userColumns.Notes, userColumns.AccountID, userColumns.IsDeleted, personInfo);
        }

        /// <returns>Object of clsUserColumns, if user is not found it will return null</returns>
        public static async Task<clsUser> FindUserByUserName(string userName)
        {
            clsUserData.clsUserColumns userColumns = await clsUserData.GetUserInfoByUserName(userName);

            if (userColumns == null)
                return null;

            clsPerson personInfo = await clsPerson.FindPersonByID(Convert.ToInt32(userColumns.PersonID));

            if (personInfo == null)
                return null;

            return new clsUser(userColumns.UserID, userColumns.UserName, userColumns.PersonID, userColumns.Permissions, userColumns.Password,
                userColumns.Salt, userColumns.IsActive, userColumns.Notes, userColumns.AccountID, userColumns.IsDeleted, personInfo);
        }

        /// <returns>Object of clsUserColumns, if user is not found it will return null</returns>
        public static async Task<clsUser> FindUserByPersonID(int personID)
        {
            clsUserData.clsUserColumns userColumns = await clsUserData.GetUserInfoByPersonID(personID);

            if (userColumns == null)
                return null;

            clsPerson personInfo = await clsPerson.FindPersonByID(Convert.ToInt32(userColumns.PersonID));

            if (personInfo == null)
                return null;

            return new clsUser(userColumns.UserID, userColumns.UserName, userColumns.PersonID, userColumns.Permissions, userColumns.Password,
                userColumns.Salt, userColumns.IsActive, userColumns.Notes, userColumns.AccountID, userColumns.IsDeleted, personInfo);
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
            this.PersonInfo = freshUser.PersonInfo;

            return true;
        }

        /// <returns>UserSalt, if failed return null</returns>
        public static async Task<string> GetUserSaltByUserName(string userName)
        {
            return await clsUserData.GetUserSaltByUserName(userName);
        }
    }
}
