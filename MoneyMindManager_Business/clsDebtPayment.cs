using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
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

        async Task<bool> _AddNewDebtPyament(int currentUserID)
        {
            this.CreatedDate = DateTime.Now;
            this.CreatedByUserID = currentUserID;

            this.MainTransactionID = await clsDebtPaymentData.AddNewDebtPayment(Convert.ToInt32(DebtID)
                , Amount, TransactionDate, Purpose, currentUserID);

            return this.MainTransactionID != null;
        }

        async Task<bool> _UpdateDebtPayment(int currentUserID)
        {
            return await clsDebtPaymentData.UpdateDebtPaymentByID
                (Convert.ToInt32(MainTransactionID), Amount, Purpose, TransactionDate, currentUserID);
        }

        new private async Task<bool> _RefresheCompositionObjects(int currentUserID)
        {
            this.DebtInfo = await clsDebt.FindDebtByDebtID(Convert.ToInt32(DebtID), currentUserID);

            return (DebtInfo != null && await base.RefreshData(currentUserID));
        }

        public async Task<bool> Save(int currentUserID)
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (await _AddNewDebtPyament(currentUserID))
                        {
                            Mode = enMode.Update;
                            await this._RefresheCompositionObjects(currentUserID);
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    return await _UpdateDebtPayment(currentUserID);
            }

            return false;
        }

        public static async Task<clsDebtPayment> FindDebtPaymentByTransactionID(int transactionID, int currentUserID)
        {
            int debtID = await clsDebtPaymentData.GetDebtPaymentByID(transactionID, currentUserID);

            var result = await clsMainTransaction.FindMainTransactionInfoByID(transactionID, currentUserID);

            var debtInfo = await clsDebt.FindDebtByDebtID(debtID, currentUserID);

            if (result == null || debtInfo == null)
                return null;

            return new clsDebtPayment(debtID, transactionID, result.Amount, result.CreatedDate, Convert.ToInt16(result.AccountID),
                Convert.ToInt32(result.CreatedByUserID), Convert.ToByte(result.TransactionTypeID), result.Purpose, result.IsLocked,
               result.TransactionDate, result.AccountInfo, result.CreatedByUserInfo, result.TransactionTypeInfo, debtInfo);
        }

        public static async Task<bool> DeleteDebtPaymentByID(int transactionID,int currentUserID)
        {
            return await clsDebtPaymentData.DeleteDebtPaymentByID(transactionID, currentUserID);
        }

        public static async Task<clsGetAllDebtPayments> GetAllDebtPyamentsByDebtID(int debtID, int currentUserID, short pageNumber)
        {
            return await clsDebtPaymentData.GetAllDebtPaymentsForDebtID(debtID, currentUserID, pageNumber);
        }

        public static async Task<DataTable> GetAllDebtPyamentsByDebtIDWithoutPaging(int debtID, int currentUserID)
        {
            return await clsDebtPaymentData.GetAllDebtPaymentsForDebtIDWithoutPaging(debtID, currentUserID);
        }
    }
}
