using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManagerGlobal
{
    public static class clsDataColumns
    {
        public static class PersonClassess
        {
            public class clsPersonColumns
            {
                public Nullable<int> PersonID { get; protected set; }
                public string PersonName { get; set; }
                public string Address { get; set; }
                public string Email { get; set; }
                public string Phone { get; set; }
                public Nullable<short> AccountID { get; set; }
                public string Notes { get; set; }

                public clsPersonColumns(int? personID, string personName, string address, string email, string phone, short? accountID, string notes)
                {
                    this.PersonID = personID;
                    this.PersonName = personName;
                    this.Address = address;
                    this.Email = email;
                    this.Phone = phone;
                    this.AccountID = accountID;
                    this.Notes = notes;
                }

                public clsPersonColumns()
                {
                    this.PersonID = null;
                    this.PersonName = null;
                    this.Address = null;
                    this.Email = null;
                    this.Phone = null;
                    this.AccountID = null;
                    this.Notes = null;
                }
            }

            public class clsGetAllPeople
            {
                public DataTable dtPeople;
                public short NumberOfPages = 0;
                public short CurrentPageNumber = 0;
                public int RecordsCount = 0;

                public clsGetAllPeople(DataTable dtPeople,short numberOfPages,short currentPageNumber,int recordsCount)
                {
                    this.dtPeople = dtPeople;
                    this.NumberOfPages = numberOfPages;
                    this.CurrentPageNumber = currentPageNumber;
                    this.RecordsCount = recordsCount;
                }
            }
        }

        public class clsUserColumns
        {
            public Nullable<int> UserID { get; protected set; }
            public string UserName { get; set; }
            public Nullable<int> PersonID { get; set; }
            public Nullable<int> Permissions { get; set; }

            /// <summary>
            /// Hashed Password [Hash(Password + Salt) ]
            /// </summary>
            public string Password { get; protected set; }
            public string Salt { get; set; }
            public bool IsActive { get; set; }
            public string Notes { get; set; }
            public Nullable<short> AccountID { get; set; }
            public bool IsDeleted { get; set; }

            public clsUserColumns(int? userID, string userName, int? personID, int? permissions, string password, string salt
                , bool isActive, string notes, short? accountID, bool isDeleted)
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
            }

            public clsUserColumns()
            {
                this.UserID = null;
                this.UserName = null;
                this.PersonID = null;
                this.Permissions = null;
                this.Password = null;
                this.Salt = null;
                this.IsActive = true;
                this.Notes = null;
                this.AccountID = null;
                this.IsDeleted = false;
            }
        }
    }
}
