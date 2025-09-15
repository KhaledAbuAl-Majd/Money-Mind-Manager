using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using MoneyMindManagerGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.clsAccountClasses;

namespace MoneyMindManager_Business
{
    public class clsAccount : clsAccountColumns
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
            //this.CurrentBalanceAccountID = freshAccount.CurrentBalanceAccountID;
            //this.SavingBalanceAccountID = freshAccount.SavingBalanceAccountID;

            this.DefaultCurrencyInfo = freshAccount.DefaultCurrencyInfo;
            this.CurrentBalanceAccountInfo = freshAccount.CurrentBalanceAccountInfo;
            this.SavingBalanceAccountInfo = freshAccount.SavingBalanceAccountInfo;

            return true;
        }

        public static async Task<clsAccount> FindAccountByAccountID(short accountID)
        {
            clsAccountColumns accountColumns = await clsAccountData.GetAccountInfoByAccountID(accountID);

            if (accountColumns == null)
                return null;

            clsCurrency defaultCurrencyInfo = await clsCurrency.FindCurrencyByCurrencyID(accountColumns.DefaultCurrencyID);

            if (defaultCurrencyInfo == null)
                return null;

            clsBalanceAccount currentBalanceAccountInfo = await clsBalanceAccount.FindBalanceAccountByID(accountColumns.CurrentBalanceAccountID);

            if (currentBalanceAccountInfo == null)
                return null;

            clsBalanceAccount savingBalanceAccountInfo = await clsBalanceAccount.FindBalanceAccountByID(accountColumns.SavingBalanceAccountID);

            if (savingBalanceAccountInfo == null)
                return null;

            return new clsAccount(accountColumns.AccountID, accountColumns.AccountName, accountColumns.CreatedDate, accountColumns.IsActive,
                accountColumns.DefaultCurrencyID, accountColumns.Description, accountColumns.CurrentBalanceAccountID,
                accountColumns.SavingBalanceAccountID, defaultCurrencyInfo, currentBalanceAccountInfo, savingBalanceAccountInfo);
        }

        /// <returns>New AccountID if Success and CreatringResult is true, if failed return null and CreatingResult is false</returns>
        public static async Task<int?> CreateAccount(string accountName, byte defaultCurrencyID,
            string description, string personName, string address, string email, string phone, string notes, string userName,
           string enteredpassword)
        {
            var HashedPasswordAndSalat = clsHashing.HashPasswordWithSalt(enteredpassword);
            string hashedPassword = HashedPasswordAndSalat.HashedPassword;
            string salt = HashedPasswordAndSalat.Salt;

            int? newAccountID = await clsAccountData.CreateAccount(accountName, defaultCurrencyID, description, personName, address, email,
                phone, notes, userName, hashedPassword, salt);

            return (newAccountID);
        }

        /// <returns>true if account exist, false if account not exist</returns>
        public static async Task<bool> IsAccountExistByAccountNameAsync(string accountName)
        {
            return await clsAccountData.IsAccountExistByAccountNameAsync(accountName);
        }

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>true if account exist, false if account not exist</returns>
        public static bool IsAccountExistByAccountName(string accountName)
        {
            return clsAccountData.IsAccountExistByAccountName(accountName);
        }
    }
}
