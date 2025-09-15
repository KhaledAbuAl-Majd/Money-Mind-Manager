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
        public clsAccount AccountInfo { get; }
        public clsUser CreatedByUserInfo { get; }
        public clsBalanceAccount BalanceAccountInfo { get; }
        public clsTransactionType TransactionTypeInfo { get; }
        private clsMainTransaction(int transactionID, decimal amount, DateTime createdDate, short accountID, int createdByUserID, int balanceAccountID,
                    byte tranasactionTypeID, clsAccount accountInfo, clsUser createdByUserInfo, clsBalanceAccount balanceAccountInfo,
                    clsTransactionType transactionTypeInfo) : base(transactionID, amount, createdDate, accountID, createdByUserID, balanceAccountID, tranasactionTypeID)
        {
            this.AccountInfo = accountInfo;
            this.CreatedByUserInfo = createdByUserInfo;
            this.BalanceAccountInfo = balanceAccountInfo;
            this.TransactionTypeInfo = transactionTypeInfo;
        }

        public static async Task<clsMainTransaction> FindMainTransactionInfoByID(int transactionID, int currentUserID)
        {
            var result = await clsMainTransactionData.GetMainTransactionInfoByID(transactionID);

            if (result == null)
                return null;

            var createdByUserInfo = await clsUser.FindUserByUserID(result.CreatedByUserID,currentUserID);
            var accountInfo = createdByUserInfo?.AccountInfo;
            var balanceAccountinfo = await clsBalanceAccount.FindBalanceAccountByID(result.BalanceAccountID);
            var transactionTypeInfo = await clsTransactionType.FindTransactionTypeByTransactionTypeID(result.TransactionTypeID);

            if (accountInfo == null || createdByUserInfo == null || balanceAccountinfo == null || transactionTypeInfo == null)
                return null;

            return new clsMainTransaction(result.MainTransactionID, result.Amount, result.CreatedDate, result.AccountID, result.CreatedByUserID, result.BalanceAccountID,
                result.TransactionTypeID, accountInfo, createdByUserInfo, balanceAccountinfo, transactionTypeInfo);
        }
         
    }
}
