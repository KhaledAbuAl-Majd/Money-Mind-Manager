using System;
using MoneyMindManager.Shared.DTOs.User;

namespace MoneyMindManager.Shared.DTOs.FinVoucher
{
    public class FinVoucherDTO
    {
        public int? VoucherID { get; set; }
        public string VoucherName { get; set; }
        public string Notes { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime VoucherDate { get; set; }
        public short? AccountID { get; set; }
        public int? CreatedByUserID { get; set; }
        public bool IsIncome { get; set; }
        public bool IsReturn { get; set; }
        public Decimal VoucherValue { get; set; }
        public UserDTO UserInfo { get; set; }

        public FinVoucherDTO(int? voucherID, string voucherName, string notes, bool isLocked,
            DateTime createdDate, DateTime voucherDate, short? accountID, int? createdByUserID, bool isIncome, bool isReturn, decimal voucherValue)
        {
            this.VoucherID = voucherID;
            this.VoucherName = voucherName;
            this.Notes = notes;
            this.IsLocked = isLocked;
            this.CreatedDate = createdDate;
            this.VoucherDate = voucherDate;
            this.AccountID = accountID;
            this.CreatedByUserID = createdByUserID;
            this.IsIncome = isIncome;
            this.IsReturn = isReturn;
            this.VoucherValue = voucherValue;
        }

        public FinVoucherDTO()
        {
            this.VoucherID = null;
            this.VoucherName = null;
            this.Notes = null;
            this.IsLocked = false;
            this.CreatedDate = DateTime.MaxValue;
            this.VoucherDate = DateTime.MaxValue;
            this.AccountID = null;
            this.CreatedByUserID = null;
            this.IsIncome = false;
            this.IsReturn = false;
            this.VoucherValue = 0;
        }
    }
}
