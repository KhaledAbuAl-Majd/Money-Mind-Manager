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
        public static class PersonClasses
        {
            public class clsPersonColumns
            {
                public Nullable<int> PersonID { get; protected set; }
                public string PersonName { get; set; }
                public string Address { get; set; }
                public string Email { get; set; }
                public string Phone { get; set; }

                /// <summary>
                /// At Add Mode Only
                /// </summary>
                public Nullable<short> AccountID { get;protected set; }
                public string Notes { get; set; }

                /// <summary>
                /// At Add Mode Only
                /// </summary>
                public int? CreatedByUserID { get;protected set; }

                /// <summary>
                /// At Add Mode Only
                /// </summary>
                public DateTime CreatedDate { get; protected set; }

                public clsPersonColumns(int? personID, string personName, string address, string email, string phone,
                    short? accountID, string notes, int? createdByUserID, DateTime createdDate)
                {
                    this.PersonID = personID;
                    this.PersonName = personName;
                    this.Address = address;
                    this.Email = email;
                    this.Phone = phone;
                    this.AccountID = accountID;
                    this.Notes = notes;
                    this.CreatedByUserID = createdByUserID;
                    this.CreatedDate = createdDate;
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
                    this.CreatedByUserID = null;
                    this.CreatedDate = DateTime.Now;
                }
            }

            public class clsGetAllPeople
            {
                public DataTable dtPeople;
                public short NumberOfPages = 0;
                //public short CurrentPageNumber = 0;
                public int RecordsCount = 0;

                public clsGetAllPeople(DataTable dtPeople,short numberOfPages,int recordsCount)
                {
                    this.dtPeople = dtPeople;
                    this.NumberOfPages = numberOfPages;
                    //this.CurrentPageNumber = currentPageNumber;
                    this.RecordsCount = recordsCount;
                }
            }
        }

        public static class clsUserClasses
        {
            public class clsUserColumns
            {
                public Nullable<int> UserID { get; protected set; }

                /// <Note>
                /// unqiue
                /// </Note>
                public string UserName { get; set; }

                /// <summary>
                /// At Add Mode Only, Unique
                /// </summary>
                public Nullable<int> PersonID { get;protected set; }
                public Nullable<int> Permissions { get; set; }

                /// <summary>
                /// Hashed Password [Hash(Password + Salt) ]
                /// </summary>
                public string Password { get; protected set; }
                public string Salt { get;protected set; }
                public bool IsActive { get; set; }
                public string Notes { get; set; }

                /// <summary>
                /// At Add Mode Only
                /// </summary>
                public Nullable<short> AccountID { get;protected set; }
                public bool IsDeleted { get;protected set; }

                /// <summary>
                /// At Add Mode Only
                /// </summary>
                public int? CreatedByUserID { get;protected set; }

                /// <summary>
                /// At Add Mode Only
                /// </summary>
                public DateTime CreatedDate { get; protected set; }

                public clsUserColumns(int? userID, string userName, int? personID, int? permissions, string password, string salt
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
                    this.CreatedByUserID = null;
                    this.CreatedDate = DateTime.Now;
                }
            }

            public class clsGetAllUsers
            {
                public DataTable dtUsers;
                public short NumberOfPages = 0;
                //public short CurrentPageNumber = 0;
                public int RecordsCount = 0;

                public clsGetAllUsers(DataTable dtUsers, short numberOfPages, int recordsCount)
                {
                    this.dtUsers = dtUsers;
                    this.NumberOfPages = numberOfPages;
                    //this.CurrentPageNumber = currentPageNumber;
                    this.RecordsCount = recordsCount;
                }
            }

        }

        public static class clsBalanceAccountClasses
        {
            public class clsBalanceAccountColumns
            {
                public int? BalanceAccountID { get; }
                public string BalanceAccountName { get; set; }
                public decimal Balance { get; }
                public bool IsCurrentAccount { get; }
                public DateTime CreatedDate { get; }
                public string AccountTypeName { get; }

                public clsBalanceAccountColumns(int balanceAccountID, string balanceAccountName, decimal balance,
                    bool isCurrentAccount, DateTime createdDate, string AccountTypeName)
                {
                    this.BalanceAccountID = balanceAccountID;
                    this.BalanceAccountName = balanceAccountName;
                    this.Balance = balance;
                    this.IsCurrentAccount = isCurrentAccount;
                    this.CreatedDate = createdDate;
                    this.AccountTypeName = AccountTypeName;
                }

                //public clsBalanceAccountColumns()
                //{
                //    this.BalanceAccountID = null;
                //    this.BalanceAccountName = null;
                //    this.Balance = 0;
                //    this.IsCurrentAccount = false;
                //    this.CreatedDate = DateTime.Now;
                //}
            }
        }

        public static class clsCurrencyClasses
        {
            public class clsCurrencyColumns
            {
                public byte CurrencyID { get; }
                public string CurrencyName { get; }
                public string CurrencySymbol { get; }

                public clsCurrencyColumns(byte currencyID, string currencyName, string currencySymbol)
                {
                    this.CurrencyID = currencyID;
                    this.CurrencyName = currencyName;
                    this.CurrencySymbol = currencySymbol;
                }

                //public clsCurrencyColumns()
                //{
                //    this.CurrencyID = null;
                //    this.CurrencyName = null;
                //    this.CurrencySymbol = null;
                //}
            }
        }

        public static class clsAccountClasses
        {
            public class clsAccountColumns
            {
                public short AccountID { get; }

                /// <Note>
                /// unqiue
                /// </Note>
                public string AccountName { get; set; }

                /// <summary>
                /// At Add Mode Only
                /// </summary>
                public DateTime CreatedDate { get; protected set; }
                public bool IsActive { get; set; }

                /// <summary>
                /// At Add Mode Only
                /// </summary>
                public byte DefaultCurrencyID { get; protected set; }
                public string Description { get; set; }

                public int CurrentBalanceAccountID { get; }
                public int SavingBalanceAccountID { get;}

                public clsAccountColumns(short accountID, string accountName, DateTime createdDate, bool isActive, byte defaultCurrencyID,
                    string description, int currentBalanceAccountID, int savingBalanceAccountID)
                {
                    this.AccountID = accountID;
                    this.AccountName = accountName;
                    this.CreatedDate = createdDate;
                    this.IsActive = isActive;
                    this.DefaultCurrencyID = defaultCurrencyID;
                    this.Description = description;
                    this.CurrentBalanceAccountID = currentBalanceAccountID;
                    this.SavingBalanceAccountID = savingBalanceAccountID;
                }
            }
        }

        public static class clsTransactionTypeClasses
        {
            public class clsTransactionTypeColumns
            {
                public byte TransactionTypeID { get; }
                public string TransactionTypeName { get; }

                public clsTransactionTypeColumns(byte transactionTypeID,string transactionTypeName)
                {
                    this.TransactionTypeID = transactionTypeID;
                    this.TransactionTypeName = transactionTypeName;
                }
            }
        }

        public static class clsMainTransactionClasses
        {
            public class clsMainTransactionColumns
            {
               public int? MainTransactionID { get; protected set; }
                public decimal Amount { get; set; }
                public DateTime CreatedDate { get; protected set; }
                public short? AccountID { get; protected set; }
                public int? CreatedByUserID { get; protected set; }
                public int? BalanceAccountID { get; protected set; }
                public byte? TransactionTypeID { get; protected set; }

                public clsMainTransactionColumns(int transactionID,decimal amount,DateTime createdDate,short accountID,
                    int createdByUserID,int balanceAccountID,byte tranasactionTypeID)
                {
                    this.MainTransactionID = transactionID;
                    this.Amount = amount;
                    this.CreatedDate = createdDate;
                    this.AccountID = accountID;
                    this.CreatedByUserID = createdByUserID;
                    this.BalanceAccountID = balanceAccountID;
                    this.TransactionTypeID = tranasactionTypeID;
                }

                public clsMainTransactionColumns()
                {
                    this.MainTransactionID = null;
                    this.Amount = 0;
                    this.CreatedDate = DateTime.MaxValue; ;
                    this.AccountID = null;
                    this.CreatedByUserID = null;
                    this.BalanceAccountID = null;
                    this.TransactionTypeID = null;
                }
            }
        }

        public static class clsIncomeAndExpenseCategoriesClasses
        {
            public class clsIncomeAndExpenseCategoriesColumns
            {
                public int? CategoryID { get; protected set; }

                /// <Note>
                /// unqiue
                /// </Note>
                public string CategoryName { get; set; }

                public DateTime CreatedDate { get; protected set; }

                /// <summary>
                /// For Category which is main category [Parent category is null] only, null => don't have budget
                /// </summary>
                public Decimal? MonthlyBudget { get; set; }

                /// <summary>
                /// At Add Mode Only fro category type
                /// </summary>
                public bool IsIncome { get; protected set; }

                /// <summary>
                /// At Add Mode Only (category level), if it null => it's main Category, else it's sub category
                /// </summary>
                /// 
                public int? ParentCategoryID { get; protected set; }

                /// <summary>
                /// at add mode only
                /// </summary>
                public short? AccountID { get; protected set; }

                /// <summary>
                /// at add mode only
                /// </summary>
                public int? CreatedByUserID { get; protected set; }
                public bool IsActive { get; set; }

                public clsIncomeAndExpenseCategoriesColumns(int categoryID, string categoryName, DateTime createdDate, decimal? monthlyBudget, bool isIncome,
                    int? parentCategoryID, short accountID, int createdByUserID, bool isActive)
                {
                    this.CategoryID = categoryID;
                    this.CategoryName = categoryName;
                    this.CreatedDate = createdDate;
                    this.MonthlyBudget = monthlyBudget;
                    this.IsIncome = isIncome;
                    this.ParentCategoryID = parentCategoryID;
                    this.AccountID = accountID;
                    this.CreatedByUserID = createdByUserID;
                    this.IsActive = isActive;
                }

                public clsIncomeAndExpenseCategoriesColumns()
                {
                    this.CategoryID = null;
                    this.CategoryName = null;
                    this.CreatedDate = DateTime.Now;
                    this.MonthlyBudget = null;
                    this.IsIncome = false;
                    this.ParentCategoryID = null;
                    this.AccountID = null;
                    this.CreatedByUserID = null;
                    this.IsActive = false;
                }

            }
        }

        public static class clsIncomeAndExpenseVoucherClasses
        {
            public class clsIncomeAndExpenseVoucherColumns
            {
              public int? VoucherID { get; protected set; }

                public string VoucherName { get; set; }

                /// <summary>
                /// Nullable
                /// </summary>
                public string Notes { get; set; }

                /// <summary>
                /// is voucher locked , if true => voucher is read only and can't open it
                /// </summary>
                public bool IsLocked { get; set; }

                /// <summary>
                /// At Add Mode Only
                /// </summary>
                public DateTime CreatedDate { get; protected set; }
                public DateTime VoucherDate { get; set; }

                /// <summary>
                /// at add mode only
                /// </summary>
                public short? AccountID { get; protected set; }

                /// <summary>
                /// at add mode only
                /// </summary>
                public int? CreatedByUserID { get; protected set; }

                /// <summary>
                /// at add mode only
                /// </summary>
                public bool IsIncome { get; protected set; }

                public clsIncomeAndExpenseVoucherColumns(int voucherID,string voucherName,string notes,bool isLocked,
                    DateTime createdDate,DateTime voucherDate,short accountID,int createdByUserID,bool isIncome)
                {
                    this.VoucherID = voucherID;
                    this.VoucherName = voucherName;
                    this.Notes = notes;
                    this.IsLocked = isLocked;
                    this.CreatedDate = createdDate;
                    this.VoucherDate = voucherDate;
                    this.AccountID = accountID;
                    this.CreatedByUserID = createdByUserID;
                    this.IsIncome = isIncome;
                }

                public clsIncomeAndExpenseVoucherColumns()
                {
                    this.VoucherID = null;
                    this.VoucherName = null;
                    this.Notes = null;
                    this.IsLocked = false;
                    this.CreatedDate = DateTime.MaxValue;
                    this.VoucherDate = DateTime.MaxValue;
                    this.AccountID = null;
                    this.CreatedByUserID = null;
                    this.IsIncome = false;
                }

            }
        }

        //public static class clsIIncomeAndExpenseTransactionsClasses
        //{
        //    public class clsIncomeAndExpenseTransactionsColumns
        //    {
            
        //        public int? VoucherID { get; set; }
        //        public int? CategoryID { get; set; }
        //        public clsIncomeAndExpenseTransactionsColumns(int voucherID,int categoryID)
        //        {
        //            this.VoucherID = voucherID;
        //            this.CategoryID = categoryID;
        //        }
                    

        //        public clsIncomeAndExpenseTransactionsColumns()
        //        {
        //            this.VoucherID = null;
        //            this.CategoryID = null;
        //        }

        //    }
        //}
    }
}
