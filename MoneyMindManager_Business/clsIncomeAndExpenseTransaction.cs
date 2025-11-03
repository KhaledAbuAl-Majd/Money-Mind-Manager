using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using MoneyMindManagerGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.clsIncomeAndExpenseTransactionsClasses;

namespace MoneyMindManager_Business
{
    public class clsIncomeAndExpenseTransaction : clsMainTransaction
    {
        public enum enMode { AddNew,Update};
        public enMode Mode { get; private set; }
        public int? VoucherID { get;protected set; }
        public int? CategoryID { get; set; }

        public bool AssignVoucherIDAtAddMode(int voucherID)
        {
            if (Mode == enMode.Update)
                return false;

            this.VoucherID = voucherID;

            return true;
        }

        public clsIncomeAndExpenseVoucher VouhcerInfo { get; private set; }
        public clsIncomeAndExpenseCategory CategoryInfo { get; private set; }

        private clsIncomeAndExpenseTransaction(int voucherID,int categoryID,int transactionID, decimal amount, DateTime createdDate, short accountID, int createdByUserID,
             byte tranasactionTypeID,string purpose,bool isLocked,DateTime transactionDate, clsAccount accountInfo, clsUser createdByUserInfo,
            clsTransactionType transactionTypeInfo,clsIncomeAndExpenseVoucher voucherInfo,clsIncomeAndExpenseCategory categoryInfo)
            : base (transactionID,amount,createdDate,accountID,createdByUserID,tranasactionTypeID,purpose,isLocked,transactionDate
                  ,accountInfo, createdByUserInfo, transactionTypeInfo)
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

        async Task<bool> _AddNewTransaction()
        {
            this.CreatedDate = DateTime.Now;
            this.CreatedByUserID = Convert.ToInt32(clsGlobalSession.CurrentUserID);

            this.MainTransactionID = await clsIncomeAndExpenseTransactionData.AddNewIncomeAndExpenseTransaction(Convert.ToInt32(VoucherID)
                , Convert.ToInt32(CategoryID), Amount,Purpose, Convert.ToInt32(clsGlobalSession.CurrentUserID));

            return this.MainTransactionID != null;
        }

        async Task<bool> _UpdateTransaction()
        {
            return await clsIncomeAndExpenseTransactionData.UpdateIncomeAndExpenseTransactoinByID
                (Convert.ToInt32(MainTransactionID),Amount, Convert.ToInt32(CategoryID),Purpose, Convert.ToInt32(clsGlobalSession.CurrentUserID));
        }

        new private async Task<bool> _RefresheCompositionObjects()
        {
            this.VouhcerInfo = await clsIncomeAndExpenseVoucher.FindVoucherByVoucherID(Convert.ToInt32(VoucherID));
            this.CategoryInfo = await clsIncomeAndExpenseCategory.FindCategoryByCategoryID(Convert.ToInt32(CategoryID));

            return (VouhcerInfo != null && CategoryInfo != null && await base.RefreshData());
        }

        public async Task<bool> Save(bool isExceededBudget)
        {
            if (!clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.AddUpdateIETVoucher_Transactions,
            "ليس لديك صلاحية إضافة/تعديل مستندات - معاملات (واردات - مصروفات - مرتجعات مصروفات)"))
                return false;

            if (isExceededBudget && !clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.ExceedsCategoryBudget,
           "ليس لديك صلاحية تخطي الميزانية الشهرية لفئات المصروفات."))
                return false;

          

            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (await _AddNewTransaction())
                        {
                            Mode = enMode.Update;
                            await this._RefresheCompositionObjects();
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    return await _UpdateTransaction();
            }

            return false;
        }

        public static async Task<clsIncomeAndExpenseTransaction> FindTransactionByTransactionID(int transactionID)
        {
            var VC = await clsIncomeAndExpenseTransactionData.GetIncomeAndExpenseTransactionInfoByID(transactionID, Convert.ToInt32(clsGlobalSession.CurrentUserID));

            var result = await  clsMainTransaction.FindMainTransactionInfoByID(transactionID);

            var voucherInfo = await clsIncomeAndExpenseVoucher.FindVoucherByVoucherID(VC.VoucherID);
            var categoryInfo = await clsIncomeAndExpenseCategory.FindCategoryByCategoryID(VC.CategoryID);

            if (result == null || voucherInfo == null || categoryInfo == null)
                return null;

            return new clsIncomeAndExpenseTransaction(VC.VoucherID, VC.CategoryID,
                transactionID, result.Amount, result.CreatedDate, Convert.ToInt16(result.AccountID),
                Convert.ToInt32(result.CreatedByUserID), Convert.ToByte(result.TransactionTypeID),
               result.Purpose,result.IsLocked,result.TransactionDate , result.AccountInfo, result.CreatedByUserInfo , result.TransactionTypeInfo
                ,voucherInfo, categoryInfo);
        }

        public static async Task<bool> DeleteIncomeAndExpenseTransactionByID(int transactionID)
        {
            if (!clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.DeleteIETVoucher_Transactions,
            "ليس لديك صلاحية حذف مستندات - معاملات (واردات - مصروفات - مرتجعات مصروفات)"))
                return false;

            return await clsIncomeAndExpenseTransactionData.DeleteIncomeAndExpenseTransactoinByID(transactionID, Convert.ToInt32(clsGlobalSession.CurrentUserID));
        }

        public static async Task<clsGetAllIncomeAndExpenseTransactions> GetAllIncomeAndExpensTransactionsForVoucher(int voucherID, int pageNumber)
        {
            byte rowsPerPage = 30;
            return await clsIncomeAndExpenseTransactionData.GetAllIncomeAndExpensTransactionsForVoucher(voucherID,
                Convert.ToInt32(clsGlobalSession.CurrentUserID), pageNumber,rowsPerPage);
        }

        public static async Task<DataTable> GetAllIncomeAndExpensTransactionsForVoucherWithoutPaging(int voucherID)
        {
            return await clsIncomeAndExpenseTransactionData.GetAllIncomeAndExpensTransactionsForVoucherWithoutPaging(voucherID, Convert.ToInt32(clsGlobalSession.CurrentUserID));
        }

        public async Task<bool> IsExceedCategoryMonthlyBudget(bool isReturn)
        {
            return await clsIncomeAndExpenseCategoryData.IsExceedMonthlyBudget(Convert.ToInt32(this.CategoryID), MainTransactionID,
                Convert.ToDecimal(Amount),TransactionDate, isReturn, Convert.ToInt32(clsGlobalSession.CurrentUserID));
        }
    }
}
