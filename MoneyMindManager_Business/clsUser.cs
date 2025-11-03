using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using MoneyMindManagerGlobal;
using static MoneyMindManager_Business.clsBLLGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.clsUserClasses;

namespace MoneyMindManager_Business
{
    public class clsUser : clsUserColumns
    {
        public enum enMode { AddNew, Update };
        public enMode Mode { get; private set; } = enMode.AddNew;
        public clsPerson PersonInfo { get; private set; }
        public clsAccount AccountInfo { get; private set; }

        public bool IsAdmin
        {
            get
            {
                return Permissions == (int)enPermissions.Admin;
            }
        }

        //
        [Flags]
        public enum enPermissions
        {
            [Description("(جميع الصلاحيات (أدمن")]
            Admin = -1,

            [Description("قائمة الأشخاص")]
            PeopleList = 1,//done

            [Description("إضافة/تعديل شخص")]
            AddUpdatePerson = 2,//done

            [Description("حذف شخص")]
            DeletePerson = 4,//done

            [Description("قائمة المستخدمين")]
            UsersList = 8,//done

            [Description("قائمة مستندات الواردات")]
            IncomeVouchersList = 16,//done

            [Description("قائمة مستندات المصروفات")]
            ExpenseVouchersList = 32,//done

            [Description("قائمة مستندات مرتجعات المصروفات")]
            ExpenseReturnVouchersList = 64,//done

            [Description("غلق/فتح المستندات (واردات - مصروفات - مرتجعات مصروفات)")]
            ChangeIETVoucherLocking = 128,//done

            [Description("إضافة/تعديل مستندات - معاملات (واردات - مصروفات - مرتجعات مصروفات)")]
            AddUpdateIETVoucher_Transactions = 256,//done

            [Description("حذف مستندات - معاملات (واردات - مصروفات - مرتجعات مصروفات)")]
            DeleteIETVoucher_Transactions = 512,//done

            [Description("قائمة سندات الديون")]
            DebtsList = 1024,//done

            [Description("غلق/فتح سندات الديون")]
            ChangeDebtsLocking = 2048,//done

            [Description("إضافة/تعديل (سندات - معاملات سداد) الديون")]
            AddUpdateDebt_Payments = 4096,//done

            [Description("حذف (سندات - معاملات سداد) الديون")]
            DeleteDebt_Payments = 8192,//done

            [Description("قائمة الفئات")]//done
            CategoriesList = 16384,

            [Description("إضافة/تعديل فئة")]
            AddUpdateCategory = 32768,//done

            [Description("حذف فئة")]
            DeleteCategory = 65536,//done

            [Description("تغيير فعالية فئة")]//done
            ChangeCategoryActivation = 131072,

            [Description("تخطي الميزانية الشهرية لفئات المصروفات")]
            ExceedsCategoryBudget = 262144,//done

            [Description("قائمة المعاملات")]
            MainTransactionsList = 524288,//done

            [Description("شاشة اللمحة العامة")]
            OverView = 1048576,//done

            [Description("رؤية رصيد الحساب")]
            AccountBalance = 2097152 //done
        }

        public static bool IsHasPermission(int userPermission,enPermissions checkedPermission)
        {
            int permissionFor = (int)checkedPermission;
            return (userPermission == (int)enPermissions.Admin) || ((permissionFor & userPermission) == permissionFor);
        }

        public bool IsHasPermission( enPermissions checkedPermission)
        {
            return IsHasPermission(Permissions, checkedPermission);
        }

        public static bool CheckLogedInUserPermissions(enPermissions checkedPermission)
        {
            return IsHasPermission(clsGlobalSession.CurrentUserPermissions, checkedPermission);
        }

        public static bool IsHasPermission_RaiseErrorEvent(int userPermission, enPermissions checkedPermission,string errorMessage)
        {
            bool result = IsHasPermission(userPermission, checkedPermission);

            if (!result)
            {
                errorMessage += $"\n معرف المستخدم الحالي [{clsGlobalSession.CurrentUserID}]";
                clsGlobalEvents.RaiseErrorEvent(errorMessage, true);
            }

            return result;
        }

        public bool IsHasPermission_RaiseErrorEvent(enPermissions checkedPermission, string errorMessage)
        {
            return IsHasPermission_RaiseErrorEvent(Permissions, checkedPermission, errorMessage);
        }

        public static bool CheckLogedInUserPermissions_RaiseErrorEvent(enPermissions checkedPermission, string errorMessage)
        {
            return IsHasPermission_RaiseErrorEvent(clsGlobalSession.CurrentUserPermissions, checkedPermission, errorMessage);
        }

        public class clsPermissionItems
        {
            public string ItemName { get; }
            public int ItemValue { get; }
            public bool Checked { get; }

            public clsPermissionItems(string name, int value, bool isChecked)
            {
                this.ItemName = name;
                this.ItemValue = value;
                this.Checked = isChecked;
            }
        }

        public static List<clsPermissionItems>GetUserPermissionItems(int userPermission)
        {
            List<clsPermissionItems> items = new List<clsPermissionItems>();

            var fileds = typeof(enPermissions).GetFields(System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Static).Where(x => x.Name != nameof(enPermissions.Admin));

            int val;
            bool isChecked = false;
            string name;

            foreach(var field in fileds)
            {
                val = Convert.ToInt32(field.GetRawConstantValue());
                isChecked = IsHasPermission(userPermission, (enPermissions)val);
                var descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>();

                name = (descriptionAttribute != null) ? descriptionAttribute.Description : field.Name;

                items.Add(new clsPermissionItems(name, val, isChecked));
            }

            return items;
        }

        public  List<clsPermissionItems> GetUserPermissionItems()
        {
            return GetUserPermissionItems(Permissions);
        }

        public void AssingUserPermissions(List<int> checkedItemsValue)
        {
            int permission = 0;

            foreach(var item in checkedItemsValue)
            {
                permission |= item;
            }

            this.Permissions = permission;
        }

        //

        public bool EnterPersonIDAtAddMode(int personID  )
        {
            if (Mode == enMode.Update)
                return false;

            this.PersonID = personID;

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

        //public bool EnterCreatedByUserIDAtAddMode(int createdByUserID)
        //{
        //    if (Mode == enMode.Update)
        //        return false;

        //    this.CreatedByUserID = createdByUserID;

        //    return true;
        //}

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

        private clsUser(int? userID, string userName, int? personID, int permissions, string password,
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
            this.CreatedByUserID = Convert.ToInt32(clsGlobalSession.CurrentUserID);
            this.CreatedDate = DateTime.Now;

            UserID = await clsUserData.AddNewUser(UserName, Convert.ToInt32(PersonID), Permissions, Password, Salt,
                IsActive, Notes,Convert.ToInt32(CreatedByUserID));

            return (UserID != null);
        }

        private async Task<bool> _UpdateUser()
        {
            if (IsDeleted)
            {
                clsGlobalEvents.RaiseErrorEvent("هذا الشخص محذوف لا يمكن التعديل عليه !"
                    + $"\n معرف المستخدم الحالي [{clsGlobalSession.CurrentUserID}]", true);

                return false;
            }

            return await clsUserData.UpdateUser(Convert.ToInt32(UserID), UserName, Convert.ToInt32(PersonID),
            Permissions, IsActive, Notes, Convert.ToInt32(clsGlobalSession.CurrentUserID));
        }

        async Task<bool> _RefeshCompositionObjects()
        {
            PersonInfo = await clsPerson.FindPersonByID(Convert.ToInt32(this.PersonID));
            this.AccountID = PersonInfo.AccountID;
            AccountInfo = PersonInfo.AccountInfo ;

            return ((PersonInfo != null) && (AccountInfo != null));
        }

        public async Task<bool> Save()
        {
            if (!clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.Admin,
                "ليس لديك صلاحية إضافة/تعديل مستخدم."))
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (await _AddNewUser())
                        {
                            Mode = enMode.Update;
                            await _RefeshCompositionObjects();
                            return true;
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

            bool result = await clsUserData.ChangeUserPassword(Convert.ToInt32(this.UserID), oldHashedPassword, 
                newHashedPassword, newSalt, Convert.ToInt32(clsGlobalSession.CurrentUserID));

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
        /// <param name="userName">the entered personName</param>
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

            clsPerson personInfo = await clsPerson.FindPersonByID(Convert.ToInt32(userColumns.PersonID),Convert.ToInt32(userColumns.UserID));
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

        public async Task<bool> DeleteUserByUserID()
        {
            if (IsDeleted)
            {
                clsGlobalEvents.RaiseErrorEvent("هذا الشخص محذوف بالفعل لا يمكن حذفه مجددا !"
                    + $"\n معرف المستخدم الحالي [{clsGlobalSession.CurrentUserID}]", true);

                return false;
            }
            return await DeleteUserByUserID(Convert.ToInt32(UserID));
        }
        public static async Task<bool> DeleteUserByUserID(int userID)
        {
            if (!clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.Admin,
                "ليس لديك صلاحية حذف مستخدم."))
                return false;

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

        private static async Task<clsGetAllUsers> _GetAllUsers(int? userID, string userName, string personName, bool? isActive,
            enTextSearchMode textSearchMode, int pageNumber)
        {
            byte rowsPerPage = 15;
            return await clsUserData.GetAllUsers(userID,userName,personName,isActive,(byte)textSearchMode,pageNumber,
                rowsPerPage, Convert.ToInt32(clsGlobalSession.CurrentUserID));
        }


        /// <summary>
        /// Get All Users For Account Using Paging , if variable is null will not filter by it
        /// </summary>
        /// <returns>object of clsGetAllUsers : if error happend, return null</returns>
        public static async Task<clsGetAllUsers> GetAllUsers(bool? isActive, enTextSearchMode textSearchMode, int pageNumber)
        {
            return await _GetAllUsers(null, null, null, isActive, textSearchMode, pageNumber);
        }

        /// <summary>
        /// Get All Users By UserID For Account Using Paging [10 rows per page] , if variable is null will not filter by it
        /// </summary>
        /// <returns>object of clsGetAllUsers : if error happend, return null</returns>
        public static async Task<clsGetAllUsers> GetAllUsersByUserID(int userID,  bool? isActive, enTextSearchMode textSearchMode, int pageNumber)
        {
            return await _GetAllUsers(userID, null, null, isActive, textSearchMode, pageNumber);
        }

        /// <summary>
        /// Get All Users By UserName For Account Using Paging [10 rows per page], if variable is null will not filter by it
        /// </summary>
        /// <returns>object of clsGetAllUsers : if error happend, return null</returns>
        public static async Task<clsGetAllUsers> GetAllUsersByUserName(string userName, bool? isActive, enTextSearchMode textSearchMode, int pageNumber)
        {
            return await _GetAllUsers(null, userName, null, isActive, textSearchMode, pageNumber);
        }

        /// <summary>
        /// Get All Users By personName For Account Using Paging [10 rows per page], if variable is null will not filter by it
        /// </summary>
        /// <returns>object of clsGetAllUsers : if error happend, return null</returns>
        public static async Task<clsGetAllUsers> GetAllUsersByPersonName(string personName, bool? isActive, enTextSearchMode textSearchMode, int pageNumber)
        {
            return await _GetAllUsers(null, null, personName, isActive, textSearchMode, pageNumber);
        }

        /// <param name="userID">UserID of user you want to find</param>
        /// <returns>true if user exist, false if user not exist</returns>
        public static async Task<bool> IsUserExistByUserIDAsync(int userID, bool includeDeleted = true)
        {
            return await clsUserData.IsUserExistByUserID(userID,includeDeleted);
        }

        /// <param name="personID">PersonID of user you want to find</param>
        /// <returns>true if user exist, false if user not exist</returns>
        public static async Task<bool> IsUserExistByPersonIDAsync(int personID, bool includeDeleted = true)
        {
            return await clsUserData.IsUserExistByPersonID(personID,includeDeleted);
        }

        /// <param name="userName">personName of user you want to find</param>
        /// <returns>true if user exist, false if user not exist</returns>
        public static async Task<bool> IsUserExistByUserNameAsync(string userName, bool includeDeleted = true)
        {
            return await clsUserData.IsUserExistByUserNameAsync(userName,includeDeleted);
        }

        /// <param name="userName">personName of user you want to find</param>
        /// <returns>true if user exist, false if user not exist</returns>
        public static bool IsUserExistByUserName(string userName, bool includeDeleted = true)
        {
            return clsUserData.IsUserExistByUserName(userName,includeDeleted);
        }
    }
}
