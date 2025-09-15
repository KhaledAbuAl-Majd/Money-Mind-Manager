using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManager_Business
{
    public class clsIncomeAndExpenseTransaction : clsMainTransaction
    {
        public enum enMode { AddNew,Update};
        public enMode Mode { get; private set; }
        public int? VoucherID { get;protected set; }
        public int? CategoryID { get; set; }

        public bool AssingVoucherIDAtAddMode(int voucherID)
        {
            if (Mode == enMode.Update)
                return false;

            this.VoucherID = voucherID;

            return true;
        }

        public clsIncomeAndExpenseVoucher VouhcerInfo { get; private set; }
        public clsIncomeAndExpenseCategory CategoryInfo { get; private set; }

        private clsIncomeAndExpenseTransaction(int voucherID,int categoryID,int transactionID, decimal amount, DateTime createdDate, short accountID, int createdByUserID,
            int balanceAccountID, byte tranasactionTypeID, clsAccount accountInfo, clsUser createdByUserInfo,  clsBalanceAccount balanceAccountInfo,
            clsTransactionType transactionTypeInfo,clsIncomeAndExpenseVoucher voucherInfo,clsIncomeAndExpenseCategory categoryInfo)
            : base (transactionID,amount,createdDate,accountID,createdByUserID,balanceAccountID,tranasactionTypeID,accountInfo,
                  createdByUserInfo, balanceAccountInfo, transactionTypeInfo)
        {
            this.Mode = enMode.Update;
            this.VoucherID = voucherID;
            this.CategoryID = categoryID;
            this.VouhcerInfo = voucherInfo;
            this.CategoryInfo = categoryInfo;
        }
        public clsIncomeAndExpenseTransaction()
        {
            this.Mode = enMode.AddNew;
            this.VoucherID = null;
            this.CategoryID = null;
            this.VouhcerInfo = null;
            this.CategoryInfo = null;
        }

        async Task<bool> _AddNewTransaction(int currentUserID)
        {
            this.CreatedDate = DateTime.Now;
            this.CreatedByUserID = currentUserID;

            this.MainTransactionID = await clsclsIncomeAndExpenseTransactionData.AddNewIncomeAndExpenseVoucher(Convert.ToInt32(VoucherID)
                , Convert.ToInt32(CategoryID), Amount, currentUserID);

            return this.MainTransactionID != null;
        }

        async Task<bool> _UpdateTransaction(int currentUserID)
        {
            return await clsclsIncomeAndExpenseTransactionData.UpdateIncomeAndExpenseTransactoinByID
                (Convert.ToInt32(MainTransactionID),Amount, Convert.ToInt32(CategoryID), currentUserID);
        }

        new private async Task<bool> _RefresheCompositionObjects(int currentUserID)
        {
            this.VouhcerInfo = await clsIncomeAndExpenseVoucher.FindVoucherByVoucherID(Convert.ToInt32(VoucherID), currentUserID);
            this.CategoryInfo = await clsIncomeAndExpenseCategory.FindCategoryByCategoryID(Convert.ToInt32(CategoryID), currentUserID);

            return (VouhcerInfo != null && CategoryInfo != null && await base.RefreshData(currentUserID));
        }

        public async Task<bool> Save(int currentUserID)
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (await _AddNewTransaction(currentUserID))
                        {
                            Mode = enMode.Update;
                            return await this._RefresheCompositionObjects(currentUserID);
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    return await _UpdateTransaction(currentUserID);
            }

            return false;
        }

        public static async Task<bool> DeleteIncomeAndExpenseTransactionByID(int transactionID,int currentUserID)
        {
            return await clsclsIncomeAndExpenseTransactionData.DeleteIncomeAndExpenseTransactoinByID(transactionID, currentUserID);
        }
    }
}
