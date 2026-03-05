using System;

namespace MoneyMindManager.Core.Models.FinVoucher
{
    public class FinVoucherExportSummary : FinVoucherViewSummary
    {
        public int? CreatedByUserID { get; set; }
        public short? AccountID { get; set; }

        public FinVoucherExportSummary(int voucherID, string voucherName, int transactionsCount, string createdByUserName,
            DateTime createdDate, DateTime voucherDate, short accountID, int createdByUserID, decimal voucherValue)
            : base(voucherID, voucherName, transactionsCount, createdByUserName, createdDate, voucherDate, voucherValue)
        {
            this.AccountID = accountID;
            this.CreatedByUserID = createdByUserID;
        }
    }
}
