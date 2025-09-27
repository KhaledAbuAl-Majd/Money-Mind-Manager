using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
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
        public async Task<bool> RefreshVoucherValue(int currentUserID)
        {
            decimal? newValue = await clsIncomeAndExpenseVoucherData.GetVoucherValueByID(Convert.ToInt32(VoucherID), currentUserID);

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

        async Task<bool> _AddNewVoucher(int currentUserID)
        {
            this.CreatedDate = DateTime.Now;
            this.CreatedByUserID = currentUserID;
            this.VoucherValue = 0;

            this.VoucherID = await clsIncomeAndExpenseVoucherData.AddNewIncomeAndExpenseVoucher(VoucherName, Notes, IsLocked,
                VoucherDate, currentUserID,IsIncome,IsReturn);

            return (this.VoucherID != null);
        }

        async Task<bool> _UpdateVoucher(int currentUserID)
        {
            return await clsIncomeAndExpenseVoucherData.UpdateVoucherByID(Convert.ToInt32(VoucherID), VoucherName, Notes, IsLocked, VoucherDate, currentUserID);
        }

        async Task<bool> _RefeshCompositionObjects(int currentUserID)
        {
            CreatedByUserInfo = await clsUser.FindUserByUserID(Convert.ToInt32(this.CreatedByUserID), currentUserID);
            AccountInfo = CreatedByUserInfo?.AccountInfo;
            this.AccountID = CreatedByUserInfo?.AccountID;

            return ((CreatedByUserInfo != null) && (AccountInfo != null));
        }

        public async Task<bool> Save(int currentUserID)
        {
            if (VoucherType == enVoucherType.UnKnown)
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if(await _AddNewVoucher(currentUserID))
                        {
                            Mode = enMode.Update;
                            await _RefeshCompositionObjects(currentUserID);
                            return true;
                        }
                        break;
                    }

                case enMode.Update:
                    return await _UpdateVoucher(currentUserID);
            }

            return true;
        }

        public static async Task<clsIncomeAndExpenseVoucher> FindVoucherByVoucherID(int voucherID, int currentUserID)
        {
            var result = await clsIncomeAndExpenseVoucherData.GetVoucherInfoByID(voucherID, currentUserID);

            if (result == null)
                return null;

            var createdByUserInfo = await clsUser.FindUserByUserID(Convert.ToInt32(result.CreatedByUserID), currentUserID);
            var accountInfo = createdByUserInfo?.AccountInfo;
            enVoucherType voucherType = GetVoucherType(result.IsIncome, result.IsReturn);

            if (createdByUserInfo == null || accountInfo == null || voucherType == enVoucherType.UnKnown)
                return null;

            return new clsIncomeAndExpenseVoucher(Convert.ToInt32(result.VoucherID), result.VoucherName, result.Notes,
                result.IsLocked, result.CreatedDate, result.VoucherDate, Convert.ToInt16(result.AccountID),
                Convert.ToInt32(result.CreatedByUserID), result.IsIncome, result.IsReturn,result.VoucherValue, accountInfo,
                createdByUserInfo, voucherType);
        }
        
        public static async Task<bool> DeleteVoucherByVoucherID(int voucherID,int currentUserID)
        {
            return await clsIncomeAndExpenseVoucherData.DeleteVoucherByID(voucherID, currentUserID);
        }

        public async Task<clsGetAllIncomeAndExpenseTransactions> GetVoucheTransactions(int currentUserID, short pageNumber)
        {
            return await GetVoucheTransactions(Convert.ToInt32(VoucherID), currentUserID, pageNumber);
        }

        public static async Task<clsGetAllIncomeAndExpenseTransactions> GetVoucheTransactions(int voucherID,int currentUserID, short pageNumber)
        {
            return await clsclsIncomeAndExpenseTransactionData.GetAllIncomeAndExpensTransactions(voucherID, currentUserID, pageNumber);
        }

        public static enVoucherType GetVoucherType(bool isIncome, bool isReturn)
        {
            if (isIncome)
            {
                if (!isReturn)
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

        private static async Task<clsGetAllVouchers> _GetAllVouchers(int? voucherID,string voucherName,bool byCreatedDate, string fromDateString,
            string toDateString, enVoucherType voucherType, int currentUserID,short pageNumber)
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
                fromCreatedDate = string.IsNullOrWhiteSpace(fromDateString) ? null : Convert.ToDateTime(fromDateString) as DateTime?;
                toCreatedDate = string.IsNullOrWhiteSpace(toDateString) ? null : Convert.ToDateTime(toDateString) as DateTime?;

                fromVoucherDate = null;
                toVoucherDate = null;
            }
            else
            {
                fromVoucherDate = string.IsNullOrWhiteSpace(fromDateString) ? null : Convert.ToDateTime(fromDateString) as DateTime?;
                toVoucherDate = string.IsNullOrWhiteSpace(toDateString) ? null : Convert.ToDateTime(toDateString) as DateTime?;

                fromCreatedDate = null;
                toCreatedDate = null;
            }


                return await clsIncomeAndExpenseVoucherData.GetAllVouchers(voucherID, isIncome, isReturn, voucherName,fromCreatedDate,
                    toCreatedDate,fromVoucherDate,toVoucherDate,currentUserID,pageNumber);
        }

        /// <summary>
        /// Get All Vouchers
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>Object of all vouchers if exists, if not returns null</returns>
        public static async Task<clsGetAllVouchers> GetAllVouchers(bool byCreatedDate, string fromDateString, string toDateString,
            enVoucherType voucherType, int currentUserID, short pageNumber)
        {
            return await _GetAllVouchers(null, null, byCreatedDate, fromDateString, toDateString, voucherType, currentUserID, pageNumber);
        }

        /// <summary>
        /// Get All Vouchers By VoucherID
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>Object of all vouchers if exists, if not returns null</returns>
        public static async Task<clsGetAllVouchers> GetAllVouchers(int voucherID,bool byCreatedDate, string fromDateString, string toDateString,
            enVoucherType voucherType, int currentUserID, short pageNumber)
        {
            return await _GetAllVouchers(voucherID, null, byCreatedDate, fromDateString, toDateString, voucherType, currentUserID, pageNumber);
        }

        /// <summary>
        /// Get All Vouchers by voucher name
        /// </summary>
        /// <param name="byCreatedDate">filter by createdDate or not (voucherDate)</param>
        /// <returns>Object of all vouchers if exists, if not returns null</returns>
        public static async Task<clsGetAllVouchers> GetAllVouchers(string voucherName,bool byCreatedDate, string fromDateString, string toDateString,
            enVoucherType voucherType, int currentUserID, short pageNumber)
        {
            return await _GetAllVouchers(null, voucherName, byCreatedDate, fromDateString, toDateString, voucherType, currentUserID, pageNumber);
        }

    }
}
