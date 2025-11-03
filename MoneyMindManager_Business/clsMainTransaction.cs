using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using MoneyMindManagerGlobal;
using static MoneyMindManager_Business.clsBLLGlobal;
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

        protected async Task<bool> _RefresheCompositionObjects()
        {
            this.CreatedByUserInfo = await clsUser.FindUserByUserID(Convert.ToInt32(CreatedByUserID));
            this. AccountInfo = CreatedByUserInfo?.AccountInfo;
            this.AccountID = CreatedByUserInfo?.AccountID;
            this.TransactionTypeInfo = await clsTransactionType.FindTransactionTypeByTransactionTypeID(Convert.ToByte(TransactionTypeID));

            return (CreatedByUserInfo != null && AccountInfo != null && TransactionTypeInfo != null);
        }

        public static async Task<clsMainTransaction> FindMainTransactionInfoByID(int transactionID )
        {
            int currentUserID = Convert.ToInt32(clsGlobalSession.CurrentUserID);
            var result = await clsMainTransactionData.GetMainTransactionInfoByID(transactionID,currentUserID);

            if (result == null)
                return null;

            var createdByUserInfo = await clsUser.FindUserByUserID(Convert.ToInt32(result.CreatedByUserID));
            var accountInfo = createdByUserInfo?.AccountInfo;
            var transactionTypeInfo = await clsTransactionType.FindTransactionTypeByTransactionTypeID(Convert.ToByte(result.TransactionTypeID));

            if (accountInfo == null || createdByUserInfo == null || transactionTypeInfo == null)
                return null;

            return new clsMainTransaction(Convert.ToInt32(result.MainTransactionID), result.Amount, result.CreatedDate,
                Convert.ToInt16(result.AccountID), Convert.ToInt32(result.CreatedByUserID), Convert.ToByte(result.TransactionTypeID),
                result.Purpose,result.IsLocked,result.TransactionDate, accountInfo, createdByUserInfo,transactionTypeInfo);
        }

        protected async Task<bool> RefreshData()
        {
            clsMainTransaction fresh = await clsMainTransaction.FindMainTransactionInfoByID(Convert.ToInt32(this.MainTransactionID));

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

        private static async Task<clsGetAllMainTransactions> _GetAllTransactions(int? transactionID, string createdByUserName, 
            string purpose,List<int>transactionTypes ,  bool byCreatedDate, string fromDateString, 
            string toDateString, enTextSearchMode textSearchMode, int pageNumber)
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

            byte rowsPerPage = 15;

            return await clsMainTransactionData.GetAllMainTransactions(transactionID, createdByUserName, purpose,
                transactionTypesString, fromCreatedDate, toCreatedDate, fromTransactionDate, toTransactionDate,
                Convert.ToInt32(clsGlobalSession.CurrentUserID), (byte)textSearchMode, pageNumber, rowsPerPage);
        }

        /// <summary>
        /// Get All MainTransactions, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>Object of all MainTransactions if exists, if not returns null</returns>
        public static async Task<clsGetAllMainTransactions> GetAllTransactions(List<int> transactionTypes ,bool byCreatedDate, string fromDateString, string toDateString,
            enTextSearchMode textSearchMode, int pageNumber)
        {
            return await _GetAllTransactions(null, null,null,transactionTypes, byCreatedDate, fromDateString,
                toDateString,textSearchMode, pageNumber);
        }

        /// <summary>
        /// Get All MainTransactions by TransactionID, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>Object of all MainTransactions if exists, if not returns null</returns>
        public static async Task<clsGetAllMainTransactions> GetAllTransactionsByTransactionID(int? transactionID,List<int> transactionTypes,
            bool byCreatedDate, string fromDateString, string toDateString, enTextSearchMode textSearchMode, int pageNumber)
        {
            return await _GetAllTransactions(transactionID, null,null, transactionTypes, byCreatedDate, fromDateString,
                toDateString,textSearchMode, pageNumber);
        }


        /// <summary>
        /// Get All MainTransactions by CreatedByUserName, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>Object of all MainTransactions if exists, if not returns null</returns>
        public static async Task<clsGetAllMainTransactions> GetAllTransactionsByUserName(string createdByUserName, List<int> transactionTypes,
            bool byCreatedDate, string fromDateString, string toDateString, enTextSearchMode textSearchMode, int pageNumber)
        {
            return await _GetAllTransactions(null, createdByUserName,null, transactionTypes, byCreatedDate, 
                fromDateString, toDateString,textSearchMode, pageNumber);
        }

        /// <summary>
        /// Get All MainTransactions by Purpose, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>Object of all MainTransactions if exists, if not returns null</returns>
        public static async Task<clsGetAllMainTransactions> GetAllTransactionsByPurpose(string purpose, List<int> transactionTypes,
            bool byCreatedDate, string fromDateString, string toDateString, enTextSearchMode textSearchMode, int pageNumber)
        {
            return await _GetAllTransactions(null, null, purpose, transactionTypes, byCreatedDate,
                fromDateString, toDateString, textSearchMode, pageNumber);
        }

        //

        private static async Task<DataTable> _GetAllTransactionsWithoutPaging(int? transactionID, string createdByUserName, string purpose,
            List<int> transactionTypes, bool byCreatedDate, string fromDateString, string toDateString, enTextSearchMode textSearchMode)
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


            return await clsMainTransactionData.GetAllMainTransactionsWithoutPaging(transactionID, createdByUserName, purpose,
                transactionTypesString, fromCreatedDate, toCreatedDate, fromTransactionDate, toTransactionDate,
                Convert.ToInt32(clsGlobalSession.CurrentUserID), (byte)textSearchMode);
        }

        /// <summary>
        /// Get All MainTransactions WithoutPaging, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>DataTable of MainTransactions if exists, if not returns null</returns>
        public static async Task<DataTable> GetAllTransactionsWithoutPaging(List<int> transactionTypes, bool byCreatedDate,
            string fromDateString, string toDateString, enTextSearchMode textSearchMode)
        {
            return await _GetAllTransactionsWithoutPaging(null, null,null, transactionTypes, byCreatedDate,
                fromDateString, toDateString,textSearchMode);
        }

        /// <summary>
        /// Get All MainTransactions WithoutPaging by TransactionID, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>DataTable of MainTransactions if exists, if not returns null</returns>
        public static async Task<DataTable> GetAllTransactionsWithoutPagingByTransactionID(int? transactionID, List<int> transactionTypes,
            bool byCreatedDate, string fromDateString, string toDateString, enTextSearchMode textSearchMode)
        {
            return await _GetAllTransactionsWithoutPaging(transactionID, null,null, transactionTypes, byCreatedDate, fromDateString,
                toDateString,textSearchMode);
        }


        /// <summary>
        /// Get All MainTransactions WithoutPaging by CreatedByUserName, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>DataTable of MainTransactions if exists, if not returns null</returns>
        public static async Task<DataTable> GetAllTransactionsWithoutPagingByUserName(string createdByUserName, List<int> transactionTypes,
            bool byCreatedDate, string fromDateString, string toDateString, enTextSearchMode textSearchMode)
        {
            return await _GetAllTransactionsWithoutPaging(null, createdByUserName,null, transactionTypes, byCreatedDate,
                fromDateString, toDateString,textSearchMode);
        }

        /// <summary>
        /// Get All MainTransactions WithoutPaging by purpose, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>DataTable of MainTransactions if exists, if not returns null</returns>
        public static async Task<DataTable> GetAllTransactionsWithoutPagingByPurpose(string purpose, List<int> transactionTypes,
            bool byCreatedDate, string fromDateString, string toDateString, enTextSearchMode textSearchMode)
        {
            return await _GetAllTransactionsWithoutPaging(null, null,purpose, transactionTypes, byCreatedDate,
                fromDateString, toDateString, textSearchMode);
        }
    }
}
