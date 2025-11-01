using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using MoneyMindManagerGlobal;
using static MoneyMindManager_Business.clsBLLGlobal;
using static MoneyMindManager_Business.clsIncomeAndExpenseVoucher;
using static MoneyMindManagerGlobal.clsDataColumns.clsIncomeAndExpenseTransactionsClasses;
using static MoneyMindManagerGlobal.clsDataColumns.clsIncomeAndExpenseVoucherClasses;

namespace MoneyMindManager_Business
{
    public class clsIncomeAndExpenseVoucher : clsIncomeAndExpenseVoucherColumns
    {
        public enum enVoucherType { Incomes, Expenses, ExpensesReturn,UnKnown };

        public enVoucherType VoucherType { get;private set; }

        //
        public enum enMode { AddNew, Update };
        public enMode Mode { get; private set; }
        public clsAccount AccountInfo { get; private set; }
        public clsUser CreatedByUserInfo { get; private set; }

        /// <summary>
        /// Refresh Voucher Value [Sum of transactions of voucher] from DB
        /// </summary>
        public async Task<bool> RefreshVoucherValue()
        {
            decimal? newValue = await clsIncomeAndExpenseVoucherData.GetVoucherValueByID(Convert.ToInt32(VoucherID), Convert.ToInt32(clsGlobalSession.CurrentUserID));

            if (newValue == null)
                return false;

            this.VoucherValue = Convert.ToDecimal(newValue);
            return true;
        }

        public bool AssingVoucherTypeAtAddMode(enVoucherType voucherType)
        {
            if (Mode == enMode.Update || voucherType == enVoucherType.UnKnown)
                return false;

            this.VoucherType = voucherType;

            if (voucherType == enVoucherType.Incomes)
            {
                IsIncome = true;
                IsReturn = false;
            }
            else if (voucherType == enVoucherType.Expenses)
            {
                IsIncome = false;
                IsReturn = false;
            }
            else if (voucherType == enVoucherType.ExpensesReturn)
            {
                IsIncome = false;
                IsReturn = true;
            }

            return true;
        }
        public bool AssingIsLockingAddMode(bool isLocked)
        {
            if (Mode == enMode.Update)
                return false;

            this.IsLocked = isLocked;
            return true;
        }

        private clsIncomeAndExpenseVoucher(int voucherID, string voucherName, string notes, bool isLocked, DateTime createdDate, 
                    DateTime voucherDate, short accountID, int createdByUserID, bool isIncome,bool isReturn,decimal voucherValue
            ,clsAccount accountInfo, clsUser createdByUserInfo,enVoucherType voucherType)
            : base (voucherID,voucherName,notes,isLocked,createdDate,voucherDate,accountID,createdByUserID,isIncome,isReturn,voucherValue)
        {
            this.Mode = enMode.Update;
            this.AccountInfo = accountInfo;
            this.CreatedByUserInfo = createdByUserInfo;
            this.VoucherType = voucherType;
        }
        public clsIncomeAndExpenseVoucher()
        {
            Mode = enMode.AddNew;
            AccountInfo = null;
            CreatedByUserInfo = null;
            VoucherType = enVoucherType.UnKnown;
        }

        async Task<bool> _AddNewVoucher()
        {
            this.CreatedDate = DateTime.Now;
            this.CreatedByUserID = Convert.ToInt32(clsGlobalSession.CurrentUserID);
            this.VoucherValue = 0;

            this.VoucherID = await clsIncomeAndExpenseVoucherData.AddNewIncomeAndExpenseVoucher(VoucherName, Notes, IsLocked,
                VoucherDate, Convert.ToInt32(clsGlobalSession.CurrentUserID), IsIncome,IsReturn);

            return (this.VoucherID != null);
        }

        async Task<bool> _UpdateVoucher()
        {
            return await clsIncomeAndExpenseVoucherData.UpdateVoucherByID(Convert.ToInt32(VoucherID), VoucherName, Notes, VoucherDate, 
                Convert.ToInt32(clsGlobalSession.CurrentUserID));
        }

        async Task<bool> _RefeshCompositionObjects()
        {
            CreatedByUserInfo = await clsUser.FindUserByUserID(Convert.ToInt32(this.CreatedByUserID));
            AccountInfo = CreatedByUserInfo?.AccountInfo;
            this.AccountID = CreatedByUserInfo?.AccountID;

            return ((CreatedByUserInfo != null) && (AccountInfo != null));
        }

        public async Task<bool> Save()
        {
            if (VoucherType == enVoucherType.UnKnown)
                return false;

            if (!clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.AddUpdateIETVoucher_Transactions,
             "ليس لديك صلاحية إضافة/تعديل مستندات - معاملات (واردات - مصروفات - مرتجعات مصروفات)"))
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if(await _AddNewVoucher())
                        {
                            Mode = enMode.Update;
                            await _RefeshCompositionObjects();
                            return true;
                        }
                        else
                            return false;
                    }

                case enMode.Update:
                    return await _UpdateVoucher();
            }

            return true;
        }

        public async Task<bool> ChangeLocking(bool isLocked)
        {
            if (Mode == enMode.AddNew)
                return false;

            if (!clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.ChangeIETVoucherLocking,
                "ليس لديك صلاحية غلق/فتح مستندات - معاملات (واردات - مصروفات - مرتجعات مصروفات)"))
                return false;

                bool result = await clsIncomeAndExpenseVoucherData.ChangeVoucherLockingByID(Convert.ToInt32(VoucherID), isLocked,
                Convert.ToInt32(clsGlobalSession.CurrentUserID));

            if (!result)
                return false;

            this.IsLocked = isLocked;
            return true;
        }

        public static async Task<clsIncomeAndExpenseVoucher> FindVoucherByVoucherID(int voucherID)
        {
            var result = await clsIncomeAndExpenseVoucherData.GetVoucherInfoByID(voucherID, Convert.ToInt32(clsGlobalSession.CurrentUserID));

            if (result == null)
                return null;

            var createdByUserInfo = await clsUser.FindUserByUserID(Convert.ToInt32(result.CreatedByUserID));
            var accountInfo = createdByUserInfo?.AccountInfo;
            enVoucherType voucherType = GetVoucherType(result.IsIncome, result.IsReturn);

            if (createdByUserInfo == null || accountInfo == null || voucherType == enVoucherType.UnKnown)
                return null;

            return new clsIncomeAndExpenseVoucher(Convert.ToInt32(result.VoucherID), result.VoucherName, result.Notes,
                result.IsLocked, result.CreatedDate, result.VoucherDate, Convert.ToInt16(result.AccountID),
                Convert.ToInt32(result.CreatedByUserID), result.IsIncome, result.IsReturn,result.VoucherValue, accountInfo,
                createdByUserInfo, voucherType);
        }
        
        public static async Task<bool> DeleteVoucherByVoucherID(int voucherID)
        {
            if (!clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.DeleteIETVoucher_Transactions,
            "ليس لديك صلاحية حذف مستندات - معاملات (واردات - مصروفات - مرتجعات مصروفات)"))
                return false;

            return await clsIncomeAndExpenseVoucherData.DeleteVoucherByID(voucherID, Convert.ToInt32(clsGlobalSession.CurrentUserID));
        }

        public async Task<clsGetAllIncomeAndExpenseTransactions> GetVoucheTransactions( short pageNumber)
        {
          var result =  await GetVoucheTransactions(Convert.ToInt32(VoucherID), pageNumber);

            if (result != null)
                this.VoucherValue = result.VoucherValue;

            return result;
        }

        public static async Task<clsGetAllIncomeAndExpenseTransactions> GetVoucheTransactions(int voucherID, short pageNumber)
        {
           return await clsIncomeAndExpenseTransaction.GetAllIncomeAndExpensTransactionsForVoucher(voucherID, pageNumber);
        }

        //

        public async Task<DataTable> GetVoucheTransactionsWithoutPaging()
        {
            return await GetVoucheTransactionsWithoutPaging(Convert.ToInt32(VoucherID));
        }

        public static async Task<DataTable> GetVoucheTransactionsWithoutPaging(int voucherID)
        {
            return await clsIncomeAndExpenseTransaction.GetAllIncomeAndExpensTransactionsForVoucherWithoutPaging(voucherID);
        }

        public static enVoucherType GetVoucherType(bool isIncome, bool isReturn)
        {
            if (isIncome)
            {
                if (isReturn)
                    return enVoucherType.UnKnown;
                else
                    return enVoucherType.Incomes;

            }
            else
            {
                if (isReturn)
                    return enVoucherType.ExpensesReturn;
                else
                    return enVoucherType.Expenses;
            }

        }

        private static async Task<clsGetAllVouchers> _GetAllVouchers(int? voucherID,string voucherName,string userName ,bool byCreatedDate, 
            string fromDateString, string toDateString, enVoucherType voucherType, enTextSearchMode textSearchMode, short pageNumber)
        {
            bool isIncome = false, isReturn = false;

            switch (voucherType)
            {
                case enVoucherType.Incomes:
                    isIncome = true;
                    isReturn = false;
                    break;

                case enVoucherType.Expenses:
                    isIncome = false;
                    isReturn = false;
                    break;

                case enVoucherType.ExpensesReturn:
                    isIncome = false;
                    isReturn = true;
                    break;

                default:
                    return null;
            }

            DateTime? fromCreatedDate = null, toCreatedDate = null,
                fromVoucherDate = null, toVoucherDate = null;

            if (byCreatedDate)
            {
                fromCreatedDate = clsFormat.TryConvertToDateTime(fromDateString);
                toCreatedDate = clsFormat.TryConvertToDateTime(toDateString);

                fromVoucherDate = null;
                toVoucherDate = null;
            }
            else
            {
                fromVoucherDate = clsFormat.TryConvertToDateTime(fromDateString);
                toVoucherDate = clsFormat.TryConvertToDateTime(toDateString);

                fromCreatedDate = null;
                toCreatedDate = null;
            }

            byte rowsPerPage = 15;

            return await clsIncomeAndExpenseVoucherData.GetAllVouchers(voucherID, isIncome, isReturn, voucherName, userName,
                    fromCreatedDate, toCreatedDate, fromVoucherDate, toVoucherDate, Convert.ToInt32(clsGlobalSession.CurrentUserID),
                    (byte)textSearchMode, pageNumber, rowsPerPage);
        }

        /// <summary>
        /// Get All Vouchers, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>Object of all vouchers if exists, if not returns null</returns>
        public static async Task<clsGetAllVouchers> GetAllVouchers(bool byCreatedDate, string fromDateString, string toDateString,
            enVoucherType voucherType, enTextSearchMode textSearchMode, short pageNumber)
        {
            return await _GetAllVouchers(null, null,null, byCreatedDate, fromDateString, toDateString, voucherType,textSearchMode, pageNumber);
        }

        /// <summary>
        /// Get All Vouchers By VoucherID, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>Object of all vouchers if exists, if not returns null</returns>
        public static async Task<clsGetAllVouchers> GetAllVouchersByVoucherID(int voucherID,bool byCreatedDate, string fromDateString, string toDateString,
            enVoucherType voucherType, enTextSearchMode textSearchMode, short pageNumber)
        {
            return await _GetAllVouchers(voucherID, null,null, byCreatedDate, fromDateString, toDateString, voucherType,textSearchMode, pageNumber);
        }

        /// <summary>
        /// Get All Vouchers by voucher name, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>Object of all vouchers if exists, if not returns null</returns>
        public static async Task<clsGetAllVouchers> GetAllVouchersByVoucherName(string voucherName,bool byCreatedDate, string fromDateString, string toDateString,
            enVoucherType voucherType, enTextSearchMode textSearchMode, short pageNumber)
        {
            return await _GetAllVouchers(null, voucherName,null, byCreatedDate, fromDateString, toDateString, voucherType,textSearchMode, pageNumber);
        }

        /// <summary>
        /// Get All Vouchers by Created By UserName, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>Object of all vouchers if exists, if not returns null</returns>
        public static async Task<clsGetAllVouchers> GetAllVouchersByUserName(string userName,bool byCreatedDate, string fromDateString, string toDateString,
            enVoucherType voucherType, enTextSearchMode textSearchMode, short pageNumber)
        {
            return await _GetAllVouchers(null,null,userName, byCreatedDate, fromDateString, toDateString, voucherType,textSearchMode, pageNumber);
        }

        //

        private static async Task<DataTable> _GetAllVouchersWithoutPaging(int? voucherID, string voucherName, string userName
            , bool byCreatedDate, string fromDateString, string toDateString, enVoucherType voucherType, enTextSearchMode textSearchMode)
        {
            bool isIncome = false, isReturn = false;

            switch (voucherType)
            {
                case enVoucherType.Incomes:
                    isIncome = true;
                    isReturn = false;
                    break;

                case enVoucherType.Expenses:
                    isIncome = false;
                    isReturn = false;
                    break;

                case enVoucherType.ExpensesReturn:
                    isIncome = false;
                    isReturn = true;
                    break;

                default:
                    return null;
            }

            DateTime? fromCreatedDate = null, toCreatedDate = null,
                fromVoucherDate = null, toVoucherDate = null;

            if (byCreatedDate)
            {
                fromCreatedDate = clsFormat.TryConvertToDateTime(fromDateString);
                toCreatedDate = clsFormat.TryConvertToDateTime(toDateString);

                fromVoucherDate = null;
                toVoucherDate = null;
            }
            else
            {
                fromVoucherDate = clsFormat.TryConvertToDateTime(fromDateString);
                toVoucherDate = clsFormat.TryConvertToDateTime(toDateString);

                fromCreatedDate = null;
                toCreatedDate = null;
            }

            return await clsIncomeAndExpenseVoucherData.GetAllVouchersWithoutPaging(voucherID, isIncome, isReturn, voucherName, userName, fromCreatedDate,
                toCreatedDate, fromVoucherDate, toVoucherDate, Convert.ToInt32(clsGlobalSession.CurrentUserID),(byte)textSearchMode);
        }

        /// <summary>
        /// Get All Vouchers WithoutPaging, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>Object of all vouchers if exists, if not returns null</returns>
        public static async Task<DataTable> GetAllVouchersWithoutPaging(bool byCreatedDate, string fromDateString, string toDateString,
            enVoucherType voucherType, enTextSearchMode textSearchMode)
        {
            return await _GetAllVouchersWithoutPaging(null, null, null, byCreatedDate, fromDateString, toDateString,
                voucherType, textSearchMode);
        }

        /// <summary>
        /// Get All Vouchers By VoucherID WithoutPaging, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>Object of all vouchers if exists, if not returns null</returns>
        public static async Task<DataTable> GetAllVouchersByVoucherIDWithoutPaging(int voucherID, bool byCreatedDate, string fromDateString, string toDateString,
            enVoucherType voucherType, enTextSearchMode textSearchMode)
        {
            return await _GetAllVouchersWithoutPaging(voucherID, null, null, byCreatedDate, fromDateString, toDateString, 
                voucherType, textSearchMode);
        }

        /// <summary>
        /// Get All Vouchers by voucher name WithoutPaging, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>Object of all vouchers if exists, if not returns null</returns>
        public static async Task<DataTable> GetAllVouchersByVoucherNameWithoutPaging(string voucherName, bool byCreatedDate, string fromDateString, string toDateString,
            enVoucherType voucherType, enTextSearchMode textSearchMode)
        {
            return await _GetAllVouchersWithoutPaging(null, voucherName, null, byCreatedDate, fromDateString,
                toDateString, voucherType, textSearchMode);
        }

        /// <summary>
        /// Get All Vouchers by Created By UserName WithoutPaging, if variable is null will not filter by it
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>Object of all vouchers if exists, if not returns null</returns>
        public static async Task<DataTable> GetAllVouchersByUserNameWithoutPaging(string userName, bool byCreatedDate, string fromDateString, string toDateString,
            enVoucherType voucherType, enTextSearchMode textSearchMode)
        {
            return await _GetAllVouchersWithoutPaging(null, null, userName, byCreatedDate, fromDateString, toDateString, 
                voucherType,textSearchMode);
        }
    }
}
