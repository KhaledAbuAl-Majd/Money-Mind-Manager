using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManager.Domain.Entities
{
    public class User
    {
        public Nullable<int> UserID { get; set; }

        /// <Note>
        /// unqiue
        /// </Note>
        public string UserName { get; set; }

        /// <summary>
        /// At Add Mode Only, Unique
        /// </summary>
        public Nullable<int> PersonID { get; set; }
        public int Permissions { get; set; }

        /// <summary>
        /// Hashed Password [Hash(Password + Salt) ]
        /// </summary>
        public string Password { get; set; }
        public string Salt { get; set; }
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

        public User(int? userID, string userName, int? personID, int permissions, string password, string salt
            , bool isActive, string notes, short? accountID, bool isDeleted, int? createdByUserID, DateTime createdDate)
        {
            this.UserID = userID;
            this.UserName = userName;
            this.PersonID = personID;
            this.Permissions = permissions;
            this.Password = password;
            this.Salt = salt;
            this.IsActive = isActive;
            this.Notes = notes;
            this.AccountID = accountID;
            this.IsDeleted = isDeleted;
            this.CreatedByUserID = createdByUserID;
            this.CreatedDate = createdDate;
        }

        public User()
        {
            this.UserID = null;
            this.UserName = null;
            this.PersonID = null;
            this.Permissions = 0;
            this.Password = null;
            this.Salt = null;
            this.IsActive = true;
            this.Notes = null;
            this.AccountID = null;
            this.IsDeleted = false;
            this.CreatedByUserID = null;
            this.CreatedDate = DateTime.Now;
        }
    }
}
