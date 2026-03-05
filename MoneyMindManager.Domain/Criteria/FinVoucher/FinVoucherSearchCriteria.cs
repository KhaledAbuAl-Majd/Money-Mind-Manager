using System;
using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Domain.Criteria.FinVoucher
{
    public class FinVoucherSearchCriteria
    {
        public int? VoucherID { get; set; }
        public string VoucherName { get; set; }
        public string UserName { get; set; }
        public DateTime? FromCreatedDate { get; set; }
        public DateTime? ToCreatedDate { get; set; }
        public DateTime? FromVoucherDate { get; set; }
        public DateTime? ToVoucherDate { get; set; }
        public bool? IsIncome { get; set; }
        public bool? IsReturn { get; set; }
        public byte TextSearchMode { get; set; }

        public FinVoucherSearchCriteria(enTextSearchMode textSearchMode)
        {
            this.TextSearchMode = (byte)textSearchMode;
        }

        public FinVoucherSearchCriteria()
        {
            this.TextSearchMode = (byte)enTextSearchMode.WordsPrefix_Fast;
        }
    }
}
