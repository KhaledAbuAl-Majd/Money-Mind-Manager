using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using static MoneyMindManagerGlobal.clsDataColumns.clsMainTransactionClasses;

namespace MoneyMindManager_Business
{
    public class clsMainTransaction : clsMainTransactionColumns
    {
        public enum enTransactionType { واردات = 1, مصروفات = 2, ديون = 3, تحويل_داخلي = 4, مرتجع_مصروفات = 5 };
        public clsAccount AccountInfo { get; private set; }
        public clsUser CreatedByUserInfo { get; private set; }
        public clsBalanceAccount BalanceAccountInfo { get; private set; }
        public clsTransactionType TransactionTypeInfo { get; private set; }
        protected clsMainTransaction(int transactionID, decimal amount, DateTime createdDate, short accountID, int createdByUserID, int balanceAccountID,
                    byte tranasactionTypeID,bool isLocked, clsAccount accountInfo, clsUser createdByUserInfo, clsBalanceAccount balanceAccountInfo,
                    clsTransactionType transactionTypeInfo) :
            base(transactionID, amount, createdDate, accountID, createdByUserID, balanceAccountID, tranasactionTypeID,isLocked)
        {
            this.AccountInfo = accountInfo;
            this.CreatedByUserInfo = createdByUserInfo;
            this.BalanceAccountInfo = balanceAccountInfo;
            this.TransactionTypeInfo = transactionTypeInfo;
        }

        protected clsMainTransaction()
        {
            AccountInfo = null;
            CreatedByUserInfo = null;
            BalanceAccountInfo = null;
            TransactionTypeInfo = null;
        }

        protected async Task<bool> _RefresheCompositionObjects(int currentUserID)
        {
            this.CreatedByUserInfo = await clsUser.FindUserByUserID(Convert.ToInt32(CreatedByUserID), currentUserID);
            this. AccountInfo = CreatedByUserInfo?.AccountInfo;
            this.AccountID = CreatedByUserInfo?.AccountID;
            this. BalanceAccountInfo = await clsBalanceAccount.FindBalanceAccountByID(Convert.ToInt32(BalanceAccountID));
            this.TransactionTypeInfo = await clsTransactionType.FindTransactionTypeByTransactionTypeID(Convert.ToByte(TransactionTypeID));

            return (CreatedByUserInfo != null && AccountInfo != null && BalanceAccountInfo != null && TransactionTypeInfo != null);
        }

        public static async Task<clsMainTransaction> FindMainTransactionInfoByID(int transactionID, int currentUserID)
        {
            var result = await clsMainTransactionData.GetMainTransactionInfoByID(transactionID);

            if (result == null)
                return null;

            var createdByUserInfo = await clsUser.FindUserByUserID(Convert.ToInt32(result.CreatedByUserID), currentUserID);
            var accountInfo = createdByUserInfo?.AccountInfo;
            var balanceAccountinfo = await clsBalanceAccount.FindBalanceAccountByID(Convert.ToInt32(result.BalanceAccountID));
            var transactionTypeInfo = await clsTransactionType.FindTransactionTypeByTransactionTypeID(Convert.ToByte(result.TransactionTypeID));

            if (accountInfo == null || createdByUserInfo == null || balanceAccountinfo == null || transactionTypeInfo == null)
                return null;

            return new clsMainTransaction(Convert.ToInt32(result.MainTransactionID), result.Amount, result.CreatedDate,
                Convert.ToInt16(result.AccountID), Convert.ToInt32(result.CreatedByUserID), Convert.ToInt32(result.BalanceAccountID),
                Convert.ToByte(result.TransactionTypeID),result.IsLocked, accountInfo, createdByUserInfo, balanceAccountinfo, transactionTypeInfo);
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
            this.BalanceAccountID = fresh.BalanceAccountID;
            this.TransactionTypeID = fresh.TransactionTypeID;
            this.IsLocked = fresh.IsLocked;

            this.AccountInfo = fresh.AccountInfo;
            this.CreatedByUserInfo = fresh.CreatedByUserInfo;
            this.BalanceAccountInfo = fresh.BalanceAccountInfo;
            this.TransactionTypeInfo = fresh.TransactionTypeInfo;

            return true;
        }
         
    }
}
