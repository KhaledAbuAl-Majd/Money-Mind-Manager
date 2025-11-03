using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using MoneyMindManagerGlobal;
using static MoneyMindManager_Business.clsBLLGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.clsDebtPaymentClasses;
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

        public string Notes
        {
            get
            {
                return DebtTransactionInfo?.Purpose;
            }
        }

        public DateTime? DebtDate
        {
            get
            {
                return DebtTransactionInfo?.TransactionDate;
            }
        }
        public DateTime? CreatedDate
        {
            get
            {
                return DebtTransactionInfo?.CreatedDate;
            }
        }
        public Decimal? DebtValue
        {
            get
            {
                return DebtTransactionInfo?.Amount;
            }
        }
        //

        public bool AssingPersonIDAtAddMode(int personID)
        {
            if (Mode == enMode.Update)
                return false;

            this.PersonID = personID;
            return true;
        }
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

        async Task<bool> _AddNewDebt(decimal amount,string purpose,DateTime debtDate)
        {
            var result = await clsDebtData.AddNewDebt(this.IsLending, Convert.ToInt32(PersonID), PaymentDueDate,
                amount, purpose, IsLocked, debtDate, Convert.ToInt32(clsGlobalSession.CurrentUserID));

            this.DebtID = result.NewDebtID;
            this.DebtTransactionID = result.NewDebtTransactionID;

            return (this.DebtID != null);
        }

        async Task<bool> _UpdateDebt(decimal amount, string purpose, DateTime debtDate)
        {
            DebtTransactionInfo.Amount = amount;
            DebtTransactionInfo.Purpose = purpose;
            DebtTransactionInfo.TransactionDate = debtDate;

            var result = await clsDebtData.UpdateDebtByID(Convert.ToInt32(this.DebtID), PaymentDueDate, amount, purpose, debtDate, Convert.ToInt32(clsGlobalSession.CurrentUserID));

            this.RemainingAmount = result.RemainingAmount;
            return result.UpdateResult;
        }

        public async Task<bool> RefreshData()
        {
            var freshDate = await clsDebt.FindDebtByDebtID(Convert.ToInt32(this.DebtID));

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

        public async Task<bool> Save(decimal amount, string purpose, DateTime debtDate)
        {
            if (!clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.AddUpdateDebt_Payments,
                "ليس لديك صلاحية إضافة/تعديل (سندات - معاملات سداد) الديون."))
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (await _AddNewDebt(amount,purpose,debtDate))
                        {
                            Mode = enMode.Update;
                            await RefreshData();
                            return true;
                        }
                        else
                            return false;
                    }

                case enMode.Update:
                    return await _UpdateDebt(amount, purpose, debtDate);
            }

            return true;
        }

        public async Task<bool> ChangeLocking(bool isLocked)
        {
            if (Mode == enMode.AddNew)
                return false;

            if (!clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.ChangeDebtsLocking,
                "ليس لديك صلاحية غلق/فتح سندات الديون."))
                return false;

            bool result = await clsDebtData.ChangeDebtLockingByID(Convert.ToInt32(DebtID), isLocked, Convert.ToInt32(clsGlobalSession.CurrentUserID));

            if (!result)
                return false;

            this.IsLocked = isLocked;
            return true;
        }

        public static async Task<clsDebt> FindDebtByDebtID(int debtID)
        {
            var result = await clsDebtData.GetDebtInfoByID(debtID, Convert.ToInt32(clsGlobalSession.CurrentUserID));

            if (result == null)
                return null;

            var personInfo = await clsPerson.FindPersonByID(Convert.ToInt32(result.PersonID));
            var debtTransactionInfo = await clsMainTransaction.FindMainTransactionInfoByID(Convert.ToInt32(result.DebtTransactionID));
            var createdByUserInfo = await clsUser.FindUserByUserID(Convert.ToInt32(result.CreatedByUserID));
            var accountInfo = createdByUserInfo?.AccountInfo;

            if (personInfo == null || debtTransactionInfo == null || createdByUserInfo == null || accountInfo == null)
                return null;

            return new clsDebt(Convert.ToInt32(result.DebtID), result.IsLending, Convert.ToInt32(result.PersonID), result.PaymentDueDate,
                Convert.ToInt32(result.DebtTransactionID),Convert.ToInt16(result.AccountID), Convert.ToInt32(result.CreatedByUserID)
                , result.IsLocked, result.RemainingAmount, personInfo, debtTransactionInfo, accountInfo, createdByUserInfo);
        }

        public static async Task<bool> DeleteDebtByDebtID(int debtID)
        {
            if (!clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.DeleteDebt_Payments,
                "ليس لديك صلاحية حذف (سندات - معاملات سداد) الديون."))
                return false;

            return await clsDebtData.DeleteDebtByID(debtID, Convert.ToInt32(clsGlobalSession.CurrentUserID));
        }

        public async Task<clsGetAllDebtPayments> GetDebtPayments( int pageNumber)
        {
            var result = await GetDebtPayments(Convert.ToInt32(DebtID), pageNumber);

            if (result != null)
                this.RemainingAmount = result.RemainingAmount;

            return result;
        }

        public static async Task<clsGetAllDebtPayments> GetDebtPayments(int debtID, int pageNumber)
        {
            return await clsDebtPayment.GetAllDebtPyamentsForDebt(debtID, pageNumber);
        }

        //
        public async Task<DataTable> GetDebtPaymentsWithoutPaging()
        {
            return await GetDebtPaymentsWithoutPaging(Convert.ToInt32(DebtID));
        }
        public static async Task<DataTable> GetDebtPaymentsWithoutPaging(int debtID)
        {
            return await clsDebtPayment.GetAllDebtPyamentsForDebtWithoutPaging(debtID);
        }

        private static async Task<clsGetAllDebts> _GetAllDebts(int? debtID,bool? isLending,string personName,string userName, bool byCreatedDate,
            string fromDateString, string toDateString,bool? isPaid, enTextSearchMode textSearchMode, int pageNumber)
        {

            DateTime? fromCreatedDate = null, toCreatedDate = null,
                fromDebtDate = null, toDebtDate = null;

            if (byCreatedDate)
            {
                fromCreatedDate = clsFormat.TryConvertToDateTime(fromDateString);
                toCreatedDate = clsFormat.TryConvertToDateTime(toDateString);

                fromDebtDate = null;
                toDebtDate = null;
            }
            else
            {
                fromDebtDate = clsFormat.TryConvertToDateTime(fromDateString);
                toDebtDate = clsFormat.TryConvertToDateTime(toDateString);

                fromCreatedDate = null;
                toCreatedDate = null;
            }

            byte rowsPerPage = 15;

            return await clsDebtData.GetAllDebts(debtID, isLending, personName, userName, fromCreatedDate, toCreatedDate, fromDebtDate,
                toDebtDate, isPaid, Convert.ToInt32(clsGlobalSession.CurrentUserID), (byte)textSearchMode, pageNumber, rowsPerPage);
        }

        /// <summary>
        /// Get All Debts, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (DebtData)</param>
        /// <returns>Object of all debts if exists, if not returns null</returns>
        public static async Task<clsGetAllDebts> GetAllDebts( bool? isLending, bool byCreatedDate,
           string fromDateString, string toDateString, bool? isPaid, enTextSearchMode textSearchMode, int pageNumber)
        {

            return await _GetAllDebts(null, isLending, null,null, byCreatedDate, fromDateString, toDateString, 
                isPaid,textSearchMode, pageNumber);
        }

        /// <summary>
        /// Get All Debts By DebtID, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (DebtData)</param>
        /// <returns>Object of all debts if exists, if not returns null</returns>
        public static async Task<clsGetAllDebts> GetAllDebts(int debtID,bool? isLending, bool byCreatedDate,
           string fromDateString, string toDateString, bool? isPaid, enTextSearchMode textSearchMode, int pageNumber)
        {

            return await _GetAllDebts(debtID, isLending, null,null, byCreatedDate, fromDateString, toDateString,
                isPaid,textSearchMode, pageNumber);
        }

        /// <summary>
        /// Get All Debts By PersonName, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (DebtData)</param>
        /// <returns>Object of all debts if exists, if not returns null</returns>
        public static async Task<clsGetAllDebts> GetAllDebts(string personName, bool? isLending, bool byCreatedDate,
           string fromDateString, string toDateString, bool? isPaid, enTextSearchMode textSearchMode, int pageNumber)
        {

            return await _GetAllDebts(null, isLending, personName,null, byCreatedDate, fromDateString, toDateString,
                isPaid,textSearchMode, pageNumber);
        }

        /// <summary>
        /// Get All Debts By UserName, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (DebtData)</param>
        /// <returns>Object of all debts if exists, if not returns null</returns>
        public static async Task<clsGetAllDebts> GetAllDebtsByUserName(string userName, bool? isLending, bool byCreatedDate,
           string fromDateString, string toDateString, bool? isPaid, enTextSearchMode textSearchMode, int pageNumber)
        {

            return await _GetAllDebts(null, isLending, null,userName, byCreatedDate, fromDateString,
                toDateString, isPaid,textSearchMode, pageNumber);
        }

        //

        private static async Task<DataTable> _GetAllDebtsWithoutPaging(int? debtID, bool? isLending, string personName,
            string userName, bool byCreatedDate,
           string fromDateString, string toDateString, bool? isPaid, enTextSearchMode textSearchMode)
        {

            DateTime? fromCreatedDate = null, toCreatedDate = null,
                fromDebtDate = null, toDebtDate = null;

            if (byCreatedDate)
            {
                fromCreatedDate = clsFormat.TryConvertToDateTime(fromDateString);
                toCreatedDate = clsFormat.TryConvertToDateTime(toDateString);

                fromDebtDate = null;
                toDebtDate = null;
            }
            else
            {
                fromDebtDate = clsFormat.TryConvertToDateTime(fromDateString);
                toDebtDate = clsFormat.TryConvertToDateTime(toDateString);

                fromCreatedDate = null;
                toCreatedDate = null;
            }

            return await clsDebtData.GetAllDebtsWithoutPaging(debtID, isLending, personName,userName, fromCreatedDate, toCreatedDate, fromDebtDate,
                toDebtDate, isPaid, Convert.ToInt32(clsGlobalSession.CurrentUserID),(byte)textSearchMode);
        }

        /// <summary>
        /// Get All Debts WithoutPaging, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (DebtData)</param>
        /// <returns>DataTable of all debts if exists, if not returns null</returns>
        public static async Task<DataTable> GetAllDebtsWithoutPaging(bool? isLending, bool byCreatedDate,
           string fromDateString, string toDateString, bool? isPaid, enTextSearchMode textSearchMode)
        {

            return await _GetAllDebtsWithoutPaging(null, isLending, null,null, byCreatedDate, fromDateString,
                toDateString, isPaid, textSearchMode);
        }

        /// <summary>
        /// Get All Debts WithoutPaging, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (DebtData)</param>
        /// <returns>DataTable of all debts if exists, if not returns null</returns>
        public static async Task<DataTable> GetAllDebtsWithoutPaging(int debtID, bool? isLending, bool byCreatedDate,
           string fromDateString, string toDateString, bool? isPaid, enTextSearchMode textSearchMode)
        {

            return await _GetAllDebtsWithoutPaging(debtID, isLending, null,null, byCreatedDate, fromDateString,
                toDateString, isPaid, textSearchMode);
        }

        /// <summary>
        /// Get All Debts WithoutPaging, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (DebtData)</param>
        /// <returns>DataTable of all debts if exists, if not returns null</returns>
        public static async Task<DataTable> GetAllDebtsWithoutPaging(string personName, bool? isLending, bool byCreatedDate,
           string fromDateString, string toDateString, bool? isPaid, enTextSearchMode textSearchMode)
        {

            return await _GetAllDebtsWithoutPaging(null, isLending, personName,null, byCreatedDate, fromDateString, 
                toDateString, isPaid, textSearchMode);
        }

        /// <summary>
        /// Get All Debts WithoutPaging, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (DebtData)</param>
        /// <returns>DataTable of all debts if exists, if not returns null</returns>
        public static async Task<DataTable> GetAllDebtsByUserNameWithoutPaging(string userName, bool? isLending, bool byCreatedDate,
           string fromDateString, string toDateString, bool? isPaid, enTextSearchMode textSearchMode)
        {

            return await _GetAllDebtsWithoutPaging(null, isLending, null,userName, byCreatedDate, fromDateString,
                toDateString, isPaid,textSearchMode);
        }
    }
}
