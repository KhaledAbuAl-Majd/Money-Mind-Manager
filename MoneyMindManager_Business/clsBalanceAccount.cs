using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using static MoneyMindManagerGlobal.clsDataColumns.clsBalanceAccountClasses;

namespace MoneyMindManager_Business
{
    public class clsBalanceAccount : clsBalanceAccountColumns
    {
        public enum enMode { AddNew, Update };

        public enMode Mode { get; private set; }

        private clsBalanceAccount(int balanceAccountID, string balanceAccountName, decimal balance,
            bool isCurrentAccount, DateTime createdDate, string AccountTypeName) :
            base(balanceAccountID, balanceAccountName, balance, isCurrentAccount, createdDate, AccountTypeName)
        {
            Mode = enMode.Update;
        }

        private async Task<bool> _Update()
        {
            return await clsBalanceAccountData.UpdateBalanceAccountByBalanceAccountID(Convert.ToInt32(this.BalanceAccountID), BalanceAccountName);
        }

        public async Task<bool> Save()
        {
            switch (Mode)
            {
                case enMode.Update:
                    return await _Update();
            }

            return false;
        }

        public static async Task<clsBalanceAccount> FindBalanceAccount(int balanceAccountID)
        {
            clsBalanceAccountColumns balanceAccountColumns = await clsBalanceAccountData.GetBalanceAccountInfoByBalanceAccountID(balanceAccountID);

            if (balanceAccountColumns == null)
                return null;

            return new clsBalanceAccount(Convert.ToInt32(balanceAccountColumns.BalanceAccountID), balanceAccountColumns.BalanceAccountName, balanceAccountColumns.Balance,
                balanceAccountColumns.IsCurrentAccount, balanceAccountColumns.CreatedDate, balanceAccountColumns.AccountTypeName);
        }
    }
}
