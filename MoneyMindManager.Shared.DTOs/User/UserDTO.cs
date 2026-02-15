using System;
using System.Collections.Generic;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Shared.DTOs.Account;
using MoneyMindManager.Shared.DTOs.Permissions;

namespace MoneyMindManager.Shared.DTOs.User
{
    public class UserDTO
    {
        public int? UserID { get; set; }

        /// <Note>
        /// unqiue
        /// </Note>
        public string UserName { get; set; }

        /// <summary>
        /// At Add Mode Only, Unique
        /// </summary>
        public Nullable<int> PersonID { get; set; }

        public IEnumerable<PermissionInfo> PermissionsList { get; set; }

        public int Permissions { get; }

        public bool IsActive { get; set; }

        public string Notes { get; set; }

        /// <summary>
        /// At Add Mode Only
        /// </summary>
        public Nullable<short> AccountID { get; set; }
        public bool IsDeleted { get; set; }

        /// <summary>
        /// At Add Mode Only
        /// </summary>
        public int? CreatedByUserID { get; set; }

        /// <summary>
        /// At Add Mode Only
        /// </summary>
        public DateTime CreatedDate { get; set; }

        public bool IsAdmin
        {
            get
            {
                return Permissions == (int)enPermissions.Admin;
            }
        }

        // composition
        public PersonDTO PersonInfo { get; private set; }
        public AccountBaseDTO AccountInfo { get; set; }
        public UserDTO(int? userID, string userName, int? personID, IEnumerable<PermissionInfo> permissionsList, int permissions
            , bool isActive, string notes, short? accountID, bool isDeleted, int? createdByUserID, DateTime createdDate)
        {
            this.UserID = userID;
            this.UserName = userName;
            this.PersonID = personID;
            this.PermissionsList = permissionsList;
            this.Permissions = permissions;
            this.IsActive = isActive;
            this.Notes = notes;
            this.AccountID = accountID;
            this.IsDeleted = isDeleted;
            this.CreatedByUserID = createdByUserID;
            this.CreatedDate = createdDate;
        }

        public UserDTO()
        {
            this.UserID = null;
            this.UserName = null;
            this.PersonID = null;
            this.PermissionsList = new List<PermissionInfo>();
            this.Permissions = 0;
            this.IsActive = true;
            this.Notes = null;
            this.AccountID = null;
            this.IsDeleted = false;
            this.CreatedByUserID = null;
            this.CreatedDate = DateTime.Now;
            this.PersonInfo = null;
            this.AccountInfo = null;
        }
    }
}
