using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;

namespace MoneyMindManager_Business
{
    public class clsAccount : clsAccountData.clsAccountColumns
    {
        public enum enMode { Update };
        public enMode Mode { get; private set; } = enMode.Update;

        public clsCurrency DefaultCurrencyInfo { get; private set; }
        public clsBalanceAccount CurrentBalanceAccountInfo { get; private set; }
        public clsBalanceAccount SavingBalanceAccountInfo { get; private set; }

        private clsAccount(short accountID, string accountName, DateTime createdDate, bool isActive, byte defaultCurrencyID,
                string description, int currentBalanceAccountID, int savingBalanceAccountID, clsCurrency defaultCurrencyInfo,
                clsBalanceAccount currentBalanceAccountInfo, clsBalanceAccount savingBalanceAccountInfo)
            : base(accountID, accountName, createdDate, isActive, defaultCurrencyID, description, currentBalanceAccountID, savingBalanceAccountID)
        {
            this.Mode = enMode.Update;
            this.DefaultCurrencyInfo = defaultCurrencyInfo;
            this.CurrentBalanceAccountInfo = currentBalanceAccountInfo;
            this.SavingBalanceAccountInfo = savingBalanceAccountInfo;
        }

        private async Task<bool> _UpdateAccount()
        {
            return await clsAccountData.UpdateAccount(AccountID, AccountName, IsActive, Description);
        }

        public async Task<bool> Save()
        {
            switch (Mode)
            {
                case enMode.Update:
                    return await _UpdateAccount();
            }

            return false;
        }

        public async Task<bool> RefreshData()
        {
            clsAccount freshAccount = await clsAccount.FindAccountByAccountID(this.AccountID);

            if (freshAccount == null)
                return false;

            //this.AccountID = freshAccount.AccountID;
            this.AccountName = freshAccount.AccountName;
            this.CreatedDate = freshAccount.CreatedDate;
            this.IsActive = freshAccount.IsActive;
            this.DefaultCurrencyID = freshAccount.DefaultCurrencyID;
            this.Description = freshAccount.Description;
            this.CurrentBalanceAccountID = freshAccount.CurrentBalanceAccountID;
            this.SavingBalanceAccountID = freshAccount.SavingBalanceAccountID;

            this.DefaultCurrencyInfo = freshAccount.DefaultCurrencyInfo;
            this.CurrentBalanceAccountInfo = freshAccount.CurrentBalanceAccountInfo;
            this.SavingBalanceAccountInfo = freshAccount.SavingBalanceAccountInfo;

            return true;
        }

        public static async Task<clsAccount> FindAccountByAccountID(short accountID)
        {
            clsAccountData.clsAccountColumns accountColumns = await clsAccountData.GetAccountInfoByAccountID(accountID);

            if (accountColumns == null)
                return null;

            clsCurrency defaultCurrencyInfo = await clsCurrency.FindCurrencyByCurrencyID(accountColumns.DefaultCurrencyID);

            if (defaultCurrencyInfo == null)
                return null;

            clsBalanceAccount currentBalanceAccountInfo = await clsBalanceAccount.FindBalanceAccount(accountColumns.CurrentBalanceAccountID);

            if (currentBalanceAccountInfo == null)
                return null;

            clsBalanceAccount savingBalanceAccountInfo = await clsBalanceAccount.FindBalanceAccount(accountColumns.SavingBalanceAccountID);

            if (savingBalanceAccountInfo == null)
                return null;

            return new clsAccount(accountColumns.AccountID, accountColumns.AccountName, accountColumns.CreatedDate, accountColumns.IsActive,
                accountColumns.DefaultCurrencyID, accountColumns.Description, accountColumns.CurrentBalanceAccountID,
                accountColumns.SavingBalanceAccountID, defaultCurrencyInfo, currentBalanceAccountInfo, savingBalanceAccountInfo);
        }

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>New AccountID if Success and CreatringResult is true, if failed return null and CreatingResult is false</returns>
        public static async Task<(Nullable<int> newAccountID, bool CreatingResult)> CreateAccount(string accountName, byte defaultCurrencyID,
            string description, string personName, string address, string email, string phone, string notes, string userName,
           string password, string salt, bool RaiseEventOnErrorOccured = true)
        {
            int? newAccountID = await clsAccountData.CreateAccount(accountName, defaultCurrencyID, description, personName, address, email,
                phone, notes, userName, password, salt);

            return (newAccountID, newAccountID != null);
        }
    }
}
