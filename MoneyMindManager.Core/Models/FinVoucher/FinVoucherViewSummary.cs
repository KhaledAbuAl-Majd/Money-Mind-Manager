using System;

namespace MoneyMindManager.Core.Models.FinVoucher
{
    public class FinVoucherViewSummary
    {
        public int? VoucherID { get; set; }
        public string VoucherName { get; set; }
        public Decimal VoucherValue { get; set; }
        public int TransactionsCount { get; set; }
        public DateTime VoucherDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }

        public FinVoucherViewSummary(int voucherID, string voucherName, int transactionsCount, string createdByUserName,
            DateTime createdDate, DateTime voucherDate, decimal voucherValue)
        {
            this.VoucherID = voucherID;
            this.VoucherName = voucherName;
            this.TransactionsCount = transactionsCount;
            this.CreatedByUserName = createdByUserName;
            this.CreatedDate = createdDate;
            this.VoucherDate = voucherDate;
            this.VoucherValue = voucherValue;
        }
    }
}
