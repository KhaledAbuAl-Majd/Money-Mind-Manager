using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using static MoneyMindManager_Business.clsIncomeAndExpenseVoucher;
using static MoneyMindManagerGlobal.clsDataColumns.clsDebtsClasses;

namespace MoneyMindManager_Business
{
    public class clsDebt : clsDebtsColumns
    {
        public enum enMode { AddNew, Update };
        public enMode Mode { get; private set; }

        //

        public clsPerson PersonInfo { get; private set; }
        public clsMainTransaction DebtTransactionInfo { get; private set; }
        public clsAccount AccountInfo { get; private set; }
        public clsUser CreatedByUserInfo { get; private set; }

        //

        public bool AssingIsLendingAddMode(bool isLending)
        {
            if (Mode == enMode.Update)
                return false;

            this.IsLending = isLending;
            return true;
        }
        public bool AssingIsLockingAddMode(bool isLocked)
        {
            if (Mode == enMode.Update)
                return false;

            this.IsLocked = isLocked;
            return true;
        }

        public clsDebt()
        {
            Mode = enMode.AddNew;
            PersonInfo = null;
            //DebtTransactionInfo = new clsMainTransaction(); 
            AccountInfo = null;
            CreatedByUserInfo = null;
        }

        private clsDebt(int debtID, bool isLending, int personID, DateTime? paymentDueDate, int debtTransactionID,
                    short accountID, int createdByUserID, bool isLocked, decimal remaintAmount, clsPerson personInfo,
                    clsMainTransaction debtTransactionInfo,clsAccount accountInfo, clsUser createdByUserInfo)
            : base(debtID, isLending, personID, paymentDueDate, debtTransactionID, accountID, createdByUserID, isLocked, remaintAmount)
        {
            this.Mode = enMode.Update;
            this.PersonInfo = personInfo;
            this.DebtTransactionInfo = debtTransactionInfo;
            this.AccountInfo = accountInfo;
            this.CreatedByUserInfo = createdByUserInfo;
        }

        async Task<bool> _AddNewDebt(decimal amount,string purpose,DateTime debtDate,int currentUserID)
        {
            var result = await clsDebtData.AddNewDebt(this.IsLending, Convert.ToInt32(PersonID), PaymentDueDate,
                amount, purpose, IsLocked, debtDate, currentUserID);

            this.DebtID = result.NewDebtID;
            this.DebtTransactionID = result.NewDebtTransactionID;

            return (this.DebtID != null);
        }

        async Task<bool> _UpdateDebt(decimal amount, string purpose, DateTime debtDate, int currentUserID)
        {
            DebtTransactionInfo.Amount = amount;
            DebtTransactionInfo.Purpose = purpose;
            DebtTransactionInfo.TransactionDate = debtDate;

            var result = await clsDebtData.UpdateDebtByID(Convert.ToInt32(this.DebtID), PaymentDueDate, amount, purpose, debtDate, currentUserID);

            this.RemainingAmount = result.RemainingAmount;
            return result.UpdateResult;
        }

        public async Task<bool> RefreshData(int currentUserID)
        {
            var freshDate = await clsDebt.FindDebtByDebtID(Convert.ToInt32(this.DebtID), currentUserID);

            if (freshDate == null)
                return false;

            this.IsLending = freshDate.IsLending;
            this.PersonID = freshDate.PersonID;
            this.PaymentDueDate = freshDate.PaymentDueDate;
            this.DebtTransactionID = freshDate.DebtTransactionID;
            this.AccountID = freshDate.AccountID;
            this.CreatedByUserID = freshDate.CreatedByUserID;
            this.IsLocked = freshDate.IsLocked;
            this.RemainingAmount = freshDate.RemainingAmount;
            this.PersonInfo = freshDate.PersonInfo;
            this.DebtTransactionInfo = freshDate.DebtTransactionInfo;
            this.AccountInfo = freshDate.AccountInfo;
            this.CreatedByUserInfo = freshDate.CreatedByUserInfo;

            return true;
        }

        public async Task<bool> Save(decimal amount, string purpose, DateTime debtDate, int currentUserID)
        {
           
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (await _AddNewDebt(amount,purpose,debtDate,currentUserID))
                        {
                            Mode = enMode.Update;
                            await RefreshData(currentUserID);
                            return true;
                        }
                        else
                            return false;
                    }

                case enMode.Update:
                    return await _UpdateDebt(amount, purpose, debtDate, currentUserID);
            }

            return true;
        }

        public async Task<bool> ChangeLocking(bool isLocked, int currentUserID)
        {
            if (Mode == enMode.AddNew)
                return false;

            bool result = await clsDebtData.ChangeDebtLockingByID(Convert.ToInt32(DebtID), isLocked, currentUserID);

            if (!result)
                return false;

            this.IsLocked = isLocked;
            return true;
        }

        public static async Task<clsDebt> FindDebtByDebtID(int debtID, int currentUserID)
        {
            var result = await clsDebtData.GetDebtInfoByID(debtID, currentUserID);

            if (result == null)
                return null;

            var personInfo = await clsPerson.FindPersonByID(Convert.ToInt32(result.PersonID), currentUserID);
            var debtTransactionInfo = await clsMainTransaction.FindMainTransactionInfoByID(Convert.ToInt32(result.DebtTransactionID), currentUserID);
            var createdByUserInfo = await clsUser.FindUserByUserID(Convert.ToInt32(result.CreatedByUserID), currentUserID);
            var accountInfo = createdByUserInfo?.AccountInfo;

            if (personInfo == null || debtTransactionInfo == null || createdByUserInfo == null || accountInfo == null)
                return null;

            return new clsDebt(Convert.ToInt32(result.DebtID), result.IsLending, Convert.ToInt32(result.PersonID), result.PaymentDueDate,
                Convert.ToInt32(result.DebtTransactionID),Convert.ToInt16(result.AccountID), Convert.ToInt32(result.CreatedByUserID)
                , result.IsLocked, result.RemainingAmount, personInfo, debtTransactionInfo, accountInfo, createdByUserInfo);
        }

        public static async Task<bool> DeleteDebtByDebtID(int debtID, int currentUserID)
        {
            return await clsDebtData.DeleteDebtByID(debtID, currentUserID);
        }
    }
}
