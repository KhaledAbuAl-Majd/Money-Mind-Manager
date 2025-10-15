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

                public decimal Balance { get; protected set; }

                public int AccountOwnerUserID { get; protected set; }
                public clsAccountColumns(short accountID, string accountName, DateTime createdDate, bool isActive, byte defaultCurrencyID,
                    string description,decimal balance,int accountOwnerUserID)
                {
                    this.AccountID = accountID;
                    this.AccountName = accountName;
                    this.CreatedDate = createdDate;
                    this.IsActive = isActive;
                    this.DefaultCurrencyID = defaultCurrencyID;
                    this.Description = description;
                    this.Balance = balance;
                    this.AccountOwnerUserID = accountOwnerUserID;
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
                public byte? TransactionTypeID { get; protected set; }
                public string Purpose { get; set; }
                public bool IsLocked { get; protected set; }
                public DateTime TransactionDate { get; set; }


                public clsMainTransactionColumns(int transactionID,decimal amount,DateTime createdDate,short accountID,
                    int createdByUserID,byte tranasactionTypeID,string purpose, bool isLocked,DateTime transactionDate)
                {
                    this.MainTransactionID = transactionID;
                    this.Amount = amount;
                    this.CreatedDate = createdDate;
                    this.AccountID = accountID;
                    this.CreatedByUserID = createdByUserID;
                    this.TransactionTypeID = tranasactionTypeID;
                    this.Purpose = purpose;
                    this.IsLocked = isLocked;
                    this.TransactionDate = transactionDate;
                }

                public clsMainTransactionColumns()
                {
                    this.MainTransactionID = null;
                    this.Amount = 0;
                    this.CreatedDate = DateTime.MaxValue; ;
                    this.AccountID = null;
                    this.CreatedByUserID = null;
                    this.TransactionTypeID = null;
                    this.Purpose = null;
                    this.TransactionDate = DateTime.MaxValue; ; 
                }
            }

            public class clsGetAllMainTransactions
            {
                public DataTable dtTransactions;

                public short NumberOfPages = 0;

                public int RecordsCount = 0;

                public decimal TotalAmount;

                public decimal CurrentPageAmount;

                public clsGetAllMainTransactions(DataTable dtTransactions, short numberOfPages, int recordsCount, decimal totalAmount,
                    decimal currentPageAmount)
                {
                    this.dtTransactions = dtTransactions;
                    this.NumberOfPages = numberOfPages;
                    this.RecordsCount = recordsCount;
                    this.TotalAmount = totalAmount;
                    this.CurrentPageAmount = currentPageAmount;
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
                public string CategoryHierarchical { get; protected set; }
                public string Notes { get; set; }
                public string MainCategoryName { get; protected set; }

                public clsIncomeAndExpenseCategoriesColumns(int categoryID, string categoryName, DateTime createdDate, decimal? monthlyBudget, bool isIncome,
                    int? parentCategoryID, short accountID, int createdByUserID, bool isActive,string categoryHierarchical,string notes,string mainCategoryName)
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
                    this.CategoryHierarchical = categoryHierarchical;
                    this.Notes = notes;
                    this.MainCategoryName = mainCategoryName;
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
                    this.CategoryHierarchical = null;
                    this.Notes = null;
                    this.MainCategoryName = null;
                }

            }

            public class clsGetAllCategories
            {
                public DataTable dtCategories;

                public short NumberOfPages = 0;

                public int RecordsCount = 0;


                public clsGetAllCategories(DataTable dtCategories, short numberOfPages, int recordsCount)
                {
                    this.dtCategories = dtCategories;
                    this.NumberOfPages = numberOfPages;
                    this.RecordsCount = recordsCount;
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
                public bool IsLocked { get;protected set; }

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

                /// <summary>
                /// For Expenses Return
                /// </summary>
                public bool IsReturn { get; protected set; }

                /// <summary>
                /// Get Sum Of Voucher Transactions, ensure that is Consistant => to refresh it use [RefreshVoucherValue]
                /// </summary>
                public Decimal VoucherValue { get; protected set; }

                public clsIncomeAndExpenseVoucherColumns(int voucherID,string voucherName,string notes,bool isLocked,
                    DateTime createdDate,DateTime voucherDate,short accountID,int createdByUserID,bool isIncome,bool isReturn,decimal voucherValue)
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
                    this.IsReturn = isReturn;
                    this.VoucherValue = voucherValue;
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
                    this.IsReturn = false;
                    this.VoucherValue = 0;
                }

            }

            public class clsGetAllVouchers
            {
                public DataTable dtVouchers;

                public short NumberOfPages = 0;

                public int RecordsCount = 0;

                public decimal TotalVouchersValue;

                public decimal CurrentPageVouchersValue;

                public clsGetAllVouchers(DataTable dtVouchers, short numberOfPages, int recordsCount,decimal totalVouchersValue,decimal currentPageVouchersValue)
                {
                    this.dtVouchers = dtVouchers;
                    this.NumberOfPages = numberOfPages;
                    this.RecordsCount = recordsCount;
                    this.TotalVouchersValue = totalVouchersValue;
                    this.CurrentPageVouchersValue = currentPageVouchersValue;
                }
            }
        }

        public static class clsIncomeAndExpenseTransactionsClasses
        {
            public class clsGetAllIncomeAndExpenseTransactions
            {
                public DataTable dtTransactions;
                public short NumberOfPages = 0;
                public int RecordsCount = 0;
                public decimal VoucherValue;
                public clsGetAllIncomeAndExpenseTransactions(DataTable dtTransactions, short numberOfPages, int recordsCount,decimal voucherValue)
                {
                    this.dtTransactions = dtTransactions;
                    this.NumberOfPages = numberOfPages;
                    this.RecordsCount = recordsCount;
                    this.VoucherValue = voucherValue;
                }
            }
        }

        public static class clsDebtsClasses
        {
            public class clsDebtsColumns
            {
                public int? DebtID { get; protected set; }

                public bool IsLending { get; protected set; }

                public int? PersonID { get; protected set; }

                public DateTime? PaymentDueDate { get; set; }

                public int? DebtTransactionID { get;protected set; }

                public short? AccountID { get; protected set; }

                public int? CreatedByUserID { get; protected set; }

                public bool IsLocked { get; protected set; }

                public decimal RemainingAmount { get; protected set; }

                public clsDebtsColumns(int debtID,bool isLending,int personID,DateTime? paymentDueDate,int debtTransactionID,
                    short accountID,int createdByUserID,bool isLocked,decimal remaintAmount)
                {
                    this.DebtID = debtID;
                    this.IsLending = isLending;
                    this.PersonID = personID;
                    this.PaymentDueDate = paymentDueDate;
                    this.DebtTransactionID = debtTransactionID;
                    this.AccountID = accountID;
                    this.CreatedByUserID = createdByUserID;
                    this.IsLocked = isLocked;
                    this.RemainingAmount = remaintAmount;
                }

                public clsDebtsColumns()
                {
                    this.DebtID = null;
                    this.IsLending = false;
                    this.PersonID = null;
                    this.PaymentDueDate = null;
                    this.DebtTransactionID = null;
                    this.AccountID = null;
                    this.CreatedByUserID = null;
                    this.IsLocked = false;
                    this.RemainingAmount = -9999999999;
                }

            }

            public class clsGetAllDebts
            {
                public DataTable dtDebts;

                public short NumberOfPages = 0;

                public int RecordsCount = 0;

                public decimal TotalDebtsValue;

                public decimal CurrentPageDebtsValue;

                public clsGetAllDebts(DataTable dtDebts, short numberOfPages, int recordsCount, decimal totalDebtsValue, decimal currentPageDebtsValue)
                {
                    this.dtDebts = dtDebts;
                    this.NumberOfPages = numberOfPages;
                    this.RecordsCount = recordsCount;
                    this.TotalDebtsValue = totalDebtsValue;
                    this.CurrentPageDebtsValue = currentPageDebtsValue;
                }
            }
        }

        public static class clsDebtPaymentClasses
        {
            public class clsGetAllDebtPayments
            {
                public DataTable dtDebtPayment;
                public short NumberOfPages = 0;
                public int RecordsCount = 0;
                public decimal RemainingAmount;
                public clsGetAllDebtPayments(DataTable dtTransactions, short numberOfPages, int recordsCount, decimal remainingAmount)
                {
                    this.dtDebtPayment = dtTransactions;
                    this.NumberOfPages = numberOfPages;
                    this.RecordsCount = recordsCount;
                    this.RemainingAmount = remainingAmount;
                }
            }
        }

        //

        public static class clsReportClassess
        {
            public class clsMonthlyFlow
            {
                public byte mon { get; set; }
                public short Year { get; set; }
                public decimal Income { get; set; }
                public decimal NetExpense { get; set; }
                public decimal NetCashFlow { get; set; }


                public clsMonthlyFlow(byte month, short year, decimal income, decimal netExpense, decimal netCashFlow)
                {
                    this.mon = month;
                    this.Year = year;
                    this.Income = income;
                    this.NetExpense = netExpense;
                    this.NetCashFlow = netCashFlow;
                }

            }

            public class clsMainKpis
            {
                public decimal Balance { get; set; }
                public decimal TotalReceivables { get; set; }
                public decimal TotalPayables { get; set; }
                public decimal Next30DayDebtsDue { get; set; }
                public decimal DayPerformance { get; set; }
                public decimal MonthPerformance { get; set; }
                public decimal YearPerformance { get; set; }
                public decimal AvgNetProfitLast6Months { get; set; }


                public clsMainKpis(decimal balance, decimal totalReceivables, decimal totalPayables,decimal next30DayDebtsDue,
                    decimal dayPerformance,decimal monthPerformance,decimal yearPerformance,decimal avgNetProfitLast6Months)
                {
                    this.Balance = balance;
                    this.TotalReceivables = totalReceivables;
                    this.TotalPayables = totalPayables;
                    this.Next30DayDebtsDue = next30DayDebtsDue;
                    this.DayPerformance = dayPerformance;
                    this.MonthPerformance = monthPerformance;
                    this.YearPerformance = yearPerformance;
                    this.AvgNetProfitLast6Months = avgNetProfitLast6Months;
                }
            }

            public class clsDebtRepaymentSchedule
            {
                public byte? mon { get; set; }
                public short? Year { get; set; }
                public decimal Receivable { get; set; }
                public decimal Payables { get; set; }
                public decimal NetCashFlow { get; set; }


                public clsDebtRepaymentSchedule(byte? month, short? year, decimal receivable, decimal payables, decimal netCashFlow)
                {
                    this.mon = month;
                    this.Year = year;
                    this.Receivable = receivable;
                    this.Payables = payables;
                    this.NetCashFlow = netCashFlow;
                }

            }

            public class clsTopDebtorsRanking
            {
                public int PersonID { get; set; }
                public string PersonName { get; set; }
                public decimal PersonRemaining { get; set; }
                public byte PersonOrder { get; set; }


                public clsTopDebtorsRanking(int personID, string personName, decimal personRemaining, byte personOrder)
                {
                    this.PersonID = personID;
                    this.PersonName = personName;
                    this.PersonRemaining = personRemaining;
                    this.PersonOrder = personOrder;
                }

            }

            public class clsTopPeopleDebtsSumRanking
            {
                public int PersonID { get; set; }
                public string PersonName { get; set; }
                public decimal PersonDebtsSum { get; set; }
                public byte PersonOrder { get; set; }


                public clsTopPeopleDebtsSumRanking(int personID, string personName, decimal personDebtsSum, byte personOrder)
                {
                    this.PersonID = personID;
                    this.PersonName = personName;
                    this.PersonDebtsSum = personDebtsSum;
                    this.PersonOrder = personOrder;
                }

            }
        }
    }
}
