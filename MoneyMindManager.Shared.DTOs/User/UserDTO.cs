using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Shared.DTOs.User
{
    public class UserDTO
    {
        public Nullable<int> UserID { get; protected set; }

        /// <Note>
        /// unqiue
        /// </Note>
        public string UserName { get; set; }

        /// <summary>
        /// At Add Mode Only, Unique
        /// </summary>
        public Nullable<int> PersonID { get; set; }

        public int Permissions { get; set; }

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
        //public clsAccount AccountInfo { get; private set; }

        public UserDTO(int? userID, string userName, int? personID, int permissions
            , bool isActive, string notes, short? accountID, bool isDeleted, int? createdByUserID, DateTime createdDate,PersonDTO personDTO)
        {
            this.UserID = userID;
            this.UserName = userName;
            this.PersonID = personID;
            this.Permissions = permissions;
            this.IsActive = isActive;
            this.Notes = notes;
            this.AccountID = accountID;
            this.IsDeleted = isDeleted;
            this.CreatedByUserID = createdByUserID;
            this.CreatedDate = createdDate;
            this.PersonInfo = personDTO;
        }

        public UserDTO()
        {
            this.UserID = null;
            this.UserName = null;
            this.PersonID = null;
            this.Permissions = 0;
            this.IsActive = true;
            this.Notes = null;
            this.AccountID = null;
            this.IsDeleted = false;
            this.CreatedByUserID = null;
            this.CreatedDate = DateTime.Now;
            this.PersonInfo = null;
        }
    }
}
