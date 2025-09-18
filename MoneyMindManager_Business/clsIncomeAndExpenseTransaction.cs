using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;

namespace MoneyMindManager_Business
{
    public class clsIncomeAndExpenseTransaction : clsMainTransaction
    {
        public enum enMode { AddNew,Update};
        public enMode Mode { get; private set; }
        public int? VoucherID { get;protected set; }
        public int? CategoryID { get; set; }

        /// <summary>
        /// Nullable
        /// </summary>
        public string Purpose { get; set; }

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
            int balanceAccountID, byte tranasactionTypeID,string purpose, clsAccount accountInfo, clsUser createdByUserInfo,  clsBalanceAccount balanceAccountInfo,
            clsTransactionType transactionTypeInfo,clsIncomeAndExpenseVoucher voucherInfo,clsIncomeAndExpenseCategory categoryInfo)
            : base (transactionID,amount,createdDate,accountID,createdByUserID,balanceAccountID,tranasactionTypeID,accountInfo,
                  createdByUserInfo, balanceAccountInfo, transactionTypeInfo)
        {
            this.Mode = enMode.Update;
            this.VoucherID = voucherID;
            this.CategoryID = categoryID;
            this.Purpose = purpose;
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

            this.MainTransactionID = await clsclsIncomeAndExpenseTransactionData.AddNewIncomeAndExpenseTransaction(Convert.ToInt32(VoucherID)
                , Convert.ToInt32(CategoryID), Amount,Purpose, currentUserID);

            return this.MainTransactionID != null;
        }

        async Task<bool> _UpdateTransaction(int currentUserID)
        {
            return await clsclsIncomeAndExpenseTransactionData.UpdateIncomeAndExpenseTransactoinByID
                (Convert.ToInt32(MainTransactionID),Amount, Convert.ToInt32(CategoryID),Purpose, currentUserID);
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

        public static async Task<clsIncomeAndExpenseTransaction> FindTransactionByTransactionID(int transactionID, int currentUserID)
        {
            var VoucherID_CategoryID = await clsclsIncomeAndExpenseTransactionData.GetIncomeAndExpenseTransactionInfoByID(transactionID, currentUserID);

            var result = await  clsMainTransaction.FindMainTransactionInfoByID(transactionID, currentUserID);

            var voucherInfo = await clsIncomeAndExpenseVoucher.FindVoucherByVoucherID(VoucherID_CategoryID.VoucherID, currentUserID);
            var categoryInfo = await clsIncomeAndExpenseCategory.FindCategoryByCategoryID(VoucherID_CategoryID.CategoryID, currentUserID);

            if (result == null || voucherInfo == null || categoryInfo == null)
                return null;

            return new clsIncomeAndExpenseTransaction(VoucherID_CategoryID.VoucherID, VoucherID_CategoryID.CategoryID,
                transactionID, result.Amount, result.CreatedDate, Convert.ToInt16(result.AccountID),
                Convert.ToInt32(result.CreatedByUserID), Convert.ToInt32(result.BalanceAccountID), Convert.ToByte(result.TransactionTypeID),
                VoucherID_CategoryID.Purpose , result.AccountInfo, result.CreatedByUserInfo , result.BalanceAccountInfo, result.TransactionTypeInfo
                ,voucherInfo, categoryInfo);
        }

        public static async Task<bool> DeleteIncomeAndExpenseTransactionByID(int transactionID,int currentUserID)
        {
            return await clsclsIncomeAndExpenseTransactionData.DeleteIncomeAndExpenseTransactoinByID(transactionID, currentUserID);
        }
    }
}
