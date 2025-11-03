using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using MoneyMindManagerGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.clsDebtPaymentClasses;

namespace MoneyMindManager_Business
{
    public class clsDebtPayment : clsMainTransaction
    {
        public enum enMode { AddNew,Update};
        public enMode Mode { get; private set; }
        public int? DebtID { get;protected set; }

        public bool AssignDebtIDAtAddMode(int debtID)
        {
            if (Mode == enMode.Update)
                return false;

            this.DebtID = debtID;

            return true;
        }

        public clsDebt DebtInfo { get; private set; }

        private clsDebtPayment(int debtID,int transactionID, decimal amount, DateTime createdDate, short accountID, int createdByUserID,
             byte tranasactionTypeID,string purpose,bool isLocked,DateTime transactionDate, clsAccount accountInfo, clsUser createdByUserInfo,
            clsTransactionType transactionTypeInfo,clsDebt debtInfo)
            : base (transactionID,amount,createdDate,accountID,createdByUserID,tranasactionTypeID,purpose,isLocked,transactionDate
                  ,accountInfo, createdByUserInfo, transactionTypeInfo)
        {
            this.Mode = enMode.Update;
            this.DebtID = debtID;
            this.DebtInfo = debtInfo;
        }
        public clsDebtPayment()
        {
            this.Mode = enMode.AddNew;
            this.DebtID = null;
            this.DebtInfo = null;
        }

        async Task<bool> _AddNewDebtPyament()
        {
            this.CreatedDate = DateTime.Now;
            this.CreatedByUserID = Convert.ToInt32(clsGlobalSession.CurrentUserID);

            this.MainTransactionID = await clsDebtPaymentData.AddNewDebtPayment(Convert.ToInt32(DebtID)
                , Amount, TransactionDate, Purpose, Convert.ToInt32(CreatedByUserID));

            return this.MainTransactionID != null;
        }

        async Task<bool> _UpdateDebtPayment()
        {
            return await clsDebtPaymentData.UpdateDebtPaymentByID
                (Convert.ToInt32(MainTransactionID), Amount, Purpose, TransactionDate, Convert.ToInt32(clsGlobalSession.CurrentUserID));
        }

        new private async Task<bool> _RefresheCompositionObjects()
        {
            this.DebtInfo = await clsDebt.FindDebtByDebtID(Convert.ToInt32(DebtID));

            return (DebtInfo != null && await base.RefreshData());
        }

        public async Task<bool> Save()
        {
            if (!clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.AddUpdateDebt_Payments,
               "ليس لديك صلاحية إضافة/تعديل (سندات - معاملات سداد) الديون."))
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (await _AddNewDebtPyament())
                        {
                            Mode = enMode.Update;
                            await this._RefresheCompositionObjects();
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    return await _UpdateDebtPayment();
            }

            return false;
        }

        public static async Task<clsDebtPayment> FindDebtPaymentByTransactionID(int transactionID)
        {
            int debtID = await clsDebtPaymentData.GetDebtPaymentByID(transactionID, Convert.ToInt32(clsGlobalSession.CurrentUserID));

            var result = await clsMainTransaction.FindMainTransactionInfoByID(transactionID);

            var debtInfo = await clsDebt.FindDebtByDebtID(debtID);

            if (result == null || debtInfo == null)
                return null;

            return new clsDebtPayment(debtID, transactionID, result.Amount, result.CreatedDate, Convert.ToInt16(result.AccountID),
                Convert.ToInt32(result.CreatedByUserID), Convert.ToByte(result.TransactionTypeID), result.Purpose, result.IsLocked,
               result.TransactionDate, result.AccountInfo, result.CreatedByUserInfo, result.TransactionTypeInfo, debtInfo);
        }

        public static async Task<bool> DeleteDebtPaymentByID(int transactionID)
        {
            if (!clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.DeleteDebt_Payments,
               "ليس لديك صلاحية حذف (سندات - معاملات سداد) الديون."))
                return false;

            return await clsDebtPaymentData.DeleteDebtPaymentByID(transactionID, Convert.ToInt32(clsGlobalSession.CurrentUserID));
        }

        public static async Task<clsGetAllDebtPayments> GetAllDebtPyamentsForDebt(int debtID, int pageNumber)
        {
            byte rowsPerPage = 15;
            return await clsDebtPaymentData.GetAllDebtPaymentsForDebt(debtID, Convert.ToInt32(clsGlobalSession.CurrentUserID)
                , pageNumber,rowsPerPage);
        }

        public static async Task<DataTable> GetAllDebtPyamentsForDebtWithoutPaging(int debtID)
        {
            return await clsDebtPaymentData.GetAllDebtPaymentsForDebtWithoutPaging(debtID, Convert.ToInt32(clsGlobalSession.CurrentUserID));
        }
    }
}
