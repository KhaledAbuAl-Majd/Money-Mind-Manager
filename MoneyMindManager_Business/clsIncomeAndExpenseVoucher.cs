using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using static MoneyMindManagerGlobal.clsDataColumns.clsIncomeAndExpenseVoucherClasses;

namespace MoneyMindManager_Business
{
    public class clsIncomeAndExpenseVoucher : clsIncomeAndExpenseVoucherColumns
    {
        public enum enMode { AddNew, Update };
        public enMode Mode { get; private set; }
        public clsAccount AccountInfo { get; private set; }
        public clsUser CreatedByUserInfo { get; private set; }

        public bool AssignIsIncome_CategoryType_AtAddMode(bool isIncome)
        {
            if (Mode == enMode.Update)
                return false;

            this.IsIncome = isIncome;
            
            return true;
        }

        private clsIncomeAndExpenseVoucher(int voucherID, string voucherName, string notes, bool isLocked, DateTime createdDate, 
                    DateTime voucherDate, short accountID, int createdByUserID, bool isIncome,clsAccount accountInfo,clsUser createdByUserInfo)
            : base (voucherID,voucherName,notes,isLocked,createdDate,voucherDate,accountID,createdByUserID,isIncome)
        {
            this.Mode = enMode.Update;
            this.AccountInfo = accountInfo;
            this.CreatedByUserInfo = createdByUserInfo;
        }
        public clsIncomeAndExpenseVoucher()
        {
            Mode = enMode.AddNew;
            AccountInfo = null;
            CreatedByUserInfo = null;
        }

        async Task<bool> _AddNewVoucher(int currentUserID)
        {
            this.CreatedDate = DateTime.Now;
            this.CreatedByUserID = currentUserID;

            this.VoucherID = await clsIncomeAndExpenseVoucherData.AddNewIncomeAndExpenseVoucher(VoucherName, Notes, IsLocked,
                VoucherDate, currentUserID,IsIncome);

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
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if(await _AddNewVoucher(currentUserID))
                        {
                            Mode = enMode.Update;
                            return await _RefeshCompositionObjects(currentUserID);
                        }
                        break;
                    }

                case enMode.Update:
                    return await _UpdateVoucher(currentUserID);
            }

            return true;
        }

        public static async Task<clsIncomeAndExpenseVoucher> FindVoucherByVoucherID(int voucherID,int currentUserID)
        {
            var result = await clsIncomeAndExpenseVoucherData.GetVoucherInfoByID(voucherID, currentUserID);

            if (result == null)
                return null;

           var createdByUserInfo = await clsUser.FindUserByUserID(Convert.ToInt32(result.CreatedByUserID),currentUserID);
            var accountInfo = createdByUserInfo?.AccountInfo;

            if (createdByUserInfo == null || accountInfo == null)
                return null;

            return new clsIncomeAndExpenseVoucher(Convert.ToInt32(result.VoucherID), result.VoucherName, result.Notes,
                result.IsLocked, result.CreatedDate, result.VoucherDate,Convert.ToInt16(result.AccountID),
                Convert.ToInt32(result.CreatedByUserID),  result.IsIncome, accountInfo, createdByUserInfo);
        }
        


        public static async Task<bool> DeleteVoucherByVoucherID(int voucherID,int currentUserID)
        {
            return await clsIncomeAndExpenseVoucherData.DeleteVoucherByID(voucherID, currentUserID);
        }

    }
}
