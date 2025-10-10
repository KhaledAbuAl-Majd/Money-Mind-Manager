using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using MoneyMindManagerGlobal;
using static MoneyMindManager_Business.clsIncomeAndExpenseVoucher;
using static MoneyMindManagerGlobal.clsDataColumns.clsIncomeAndExpenseVoucherClasses;
using static MoneyMindManagerGlobal.clsDataColumns.clsMainTransactionClasses;

namespace MoneyMindManager_Business
{
    public class clsMainTransaction : clsMainTransactionColumns
    {
        public enum enTransactionType { واردات = 1, مصروفات = 2, ديون = 3, مرتجع_مصروفات = 5 };
        public clsAccount AccountInfo { get; private set; }
        public clsUser CreatedByUserInfo { get; private set; }
        public clsTransactionType TransactionTypeInfo { get; private set; }
        protected clsMainTransaction(int transactionID, decimal amount, DateTime createdDate, short accountID, int createdByUserID,
                    byte tranasactionTypeID,string purpose,bool isLocked,DateTime transactionDate, clsAccount accountInfo, clsUser createdByUserInfo,
                    clsTransactionType transactionTypeInfo) :
            base(transactionID, amount, createdDate, accountID, createdByUserID, tranasactionTypeID,purpose,isLocked,transactionDate)
        {
            this.AccountInfo = accountInfo;
            this.CreatedByUserInfo = createdByUserInfo;
            this.TransactionTypeInfo = transactionTypeInfo;
        }

        protected clsMainTransaction()
        {
            AccountInfo = null;
            CreatedByUserInfo = null;
            TransactionTypeInfo = null;
        }

        protected async Task<bool> _RefresheCompositionObjects(int currentUserID)
        {
            this.CreatedByUserInfo = await clsUser.FindUserByUserID(Convert.ToInt32(CreatedByUserID), currentUserID);
            this. AccountInfo = CreatedByUserInfo?.AccountInfo;
            this.AccountID = CreatedByUserInfo?.AccountID;
            this.TransactionTypeInfo = await clsTransactionType.FindTransactionTypeByTransactionTypeID(Convert.ToByte(TransactionTypeID));

            return (CreatedByUserInfo != null && AccountInfo != null && TransactionTypeInfo != null);
        }

        public static async Task<clsMainTransaction> FindMainTransactionInfoByID(int transactionID, int currentUserID)
        {
            var result = await clsMainTransactionData.GetMainTransactionInfoByID(transactionID);

            if (result == null)
                return null;

            var createdByUserInfo = await clsUser.FindUserByUserID(Convert.ToInt32(result.CreatedByUserID), currentUserID);
            var accountInfo = createdByUserInfo?.AccountInfo;
            var transactionTypeInfo = await clsTransactionType.FindTransactionTypeByTransactionTypeID(Convert.ToByte(result.TransactionTypeID));

            if (accountInfo == null || createdByUserInfo == null || transactionTypeInfo == null)
                return null;

            return new clsMainTransaction(Convert.ToInt32(result.MainTransactionID), result.Amount, result.CreatedDate,
                Convert.ToInt16(result.AccountID), Convert.ToInt32(result.CreatedByUserID), Convert.ToByte(result.TransactionTypeID),
                result.Purpose,result.IsLocked,result.TransactionDate, accountInfo, createdByUserInfo,transactionTypeInfo);
        }

        protected async Task<bool> RefreshData(int currentUserID)
        {
            clsMainTransaction fresh = await clsMainTransaction.FindMainTransactionInfoByID(Convert.ToInt32(this.MainTransactionID), currentUserID);

            if (fresh == null)
                return false;

            this.Amount = fresh.Amount;
            this.CreatedDate = fresh.CreatedDate;
            this.AccountID = fresh.AccountID;
            this.CreatedByUserID = fresh.CreatedByUserID;
            this.TransactionTypeID = fresh.TransactionTypeID;
            this.Purpose = fresh.Purpose;
            this.IsLocked = fresh.IsLocked;

            this.AccountInfo = fresh.AccountInfo;
            this.CreatedByUserInfo = fresh.CreatedByUserInfo;
            this.TransactionTypeInfo = fresh.TransactionTypeInfo;

            return true;
        }

        private static async Task<clsGetAllMainTransactions> _GetAllTransactions(int? transactionID, string createdByUserName,  List<int>transactionTypes ,
            bool byCreatedDate, string fromDateString,  string toDateString, int currentUserID, short pageNumber)
        {
            DateTime? fromCreatedDate = null, toCreatedDate = null,
                fromTransactionDate = null, toTransactionDate = null;

            if (byCreatedDate)
            {
                fromCreatedDate = clsFormat.TryConvertToDateTime(fromDateString);
                toCreatedDate = clsFormat.TryConvertToDateTime(toDateString);

                fromTransactionDate = null;
                toTransactionDate = null;
            }
            else
            {
                fromTransactionDate = clsFormat.TryConvertToDateTime(fromDateString);
                toTransactionDate = clsFormat.TryConvertToDateTime(toDateString);

                fromCreatedDate = null;
                toCreatedDate = null;
            }

            string transactionTypesString = string.Join(",", transactionTypes);


            return await clsMainTransactionData.GetAllMainTransactions(transactionID, createdByUserName,transactionTypesString, fromCreatedDate,
                toCreatedDate, fromTransactionDate, toTransactionDate, currentUserID, pageNumber);
        }

        /// <summary>
        /// Get All MainTransactions, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>Object of all MainTransactions if exists, if not returns null</returns>
        public static async Task<clsGetAllMainTransactions> GetAllTransactions(List<int> transactionTypes ,bool byCreatedDate, string fromDateString, string toDateString,
            int currentUserID, short pageNumber)
        {
            return await _GetAllTransactions(null, null,transactionTypes, byCreatedDate, fromDateString, toDateString, currentUserID, pageNumber);
        }

        /// <summary>
        /// Get All MainTransactions by TransactionID, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>Object of all MainTransactions if exists, if not returns null</returns>
        public static async Task<clsGetAllMainTransactions> GetAllTransactions(int? transactionID,List<int> transactionTypes,
            bool byCreatedDate, string fromDateString, string toDateString,int currentUserID, short pageNumber)
        {
            return await _GetAllTransactions(transactionID, null, transactionTypes, byCreatedDate, fromDateString, toDateString, currentUserID, pageNumber);
        }


        /// <summary>
        /// Get All MainTransactions by CreatedByUserName, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>Object of all MainTransactions if exists, if not returns null</returns>
        public static async Task<clsGetAllMainTransactions> GetAllTransactions(string createdByUserName, List<int> transactionTypes,
            bool byCreatedDate, string fromDateString, string toDateString, int currentUserID, short pageNumber)
        {
            return await _GetAllTransactions(null, createdByUserName, transactionTypes, byCreatedDate, fromDateString, toDateString, currentUserID, pageNumber);
        }

        //

        private static async Task<DataTable> _GetAllTransactionsWithoutPaging(int? transactionID, string createdByUserName, List<int> transactionTypes,
           bool byCreatedDate, string fromDateString, string toDateString, int currentUserID)
        {
            DateTime? fromCreatedDate = null, toCreatedDate = null,
                fromTransactionDate = null, toTransactionDate = null;

            if (byCreatedDate)
            {
                fromCreatedDate = clsFormat.TryConvertToDateTime(fromDateString);
                toCreatedDate = clsFormat.TryConvertToDateTime(toDateString);

                fromTransactionDate = null;
                toTransactionDate = null;
            }
            else
            {
                fromTransactionDate = clsFormat.TryConvertToDateTime(fromDateString);
                toTransactionDate = clsFormat.TryConvertToDateTime(toDateString);

                fromCreatedDate = null;
                toCreatedDate = null;
            }

            string transactionTypesString = string.Join(",", transactionTypes);


            return await clsMainTransactionData.GetAllMainTransactionsWithoutPaging(transactionID, createdByUserName, transactionTypesString, fromCreatedDate,
                toCreatedDate, fromTransactionDate, toTransactionDate, currentUserID);
        }

        /// <summary>
        /// Get All MainTransactions WithoutPaging, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>DataTable of MainTransactions if exists, if not returns null</returns>
        public static async Task<DataTable> GetAllTransactionsWithoutPaging(List<int> transactionTypes, bool byCreatedDate, string fromDateString, string toDateString,
            int currentUserID)
        {
            return await _GetAllTransactionsWithoutPaging(null, null, transactionTypes, byCreatedDate, fromDateString, toDateString, currentUserID);
        }

        /// <summary>
        /// Get All MainTransactions WithoutPaging by TransactionID, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>DataTable of MainTransactions if exists, if not returns null</returns>
        public static async Task<DataTable> GetAllTransactionsWithoutPaging(int? transactionID, List<int> transactionTypes,
            bool byCreatedDate, string fromDateString, string toDateString, int currentUserID)
        {
            return await _GetAllTransactionsWithoutPaging(transactionID, null, transactionTypes, byCreatedDate, fromDateString, toDateString, currentUserID);
        }


        /// <summary>
        /// Get All MainTransactions WithoutPaging by CreatedByUserName, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>DataTable of MainTransactions if exists, if not returns null</returns>
        public static async Task<DataTable> GetAllTransactionsWithoutPaging(string createdByUserName, List<int> transactionTypes,
            bool byCreatedDate, string fromDateString, string toDateString, int currentUserID)
        {
            return await _GetAllTransactionsWithoutPaging(null, createdByUserName, transactionTypes, byCreatedDate, fromDateString, toDateString, currentUserID);
        }
    }
}
