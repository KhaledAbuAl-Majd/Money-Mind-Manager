using System;
using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Domain.Criteria.Debt
{
    public class DebtSearchCriteria
    {
        public int? DebtID { get; set; }
        public bool? IsLending { get; set; }
        public string PersonName { get; set; }
        public string UserName { get; set; }
        public DateTime? FromCreatedDate { get; set; }
        public DateTime? ToCreatedDate { get; set; }
        public DateTime? FromDebtDate { get; set; }
        public DateTime? ToDebtDate { get; set; }
        public bool? IsPaid { get; set; }
        public byte TextSearchMode { get; set; }

        public DebtSearchCriteria(enTextSearchMode textSearchMode)
        {
            this.TextSearchMode = (byte)textSearchMode;
        }

        public DebtSearchCriteria()
        {
            this.TextSearchMode = (byte)enTextSearchMode.WordsPrefix_Fast;
        }
    }
}
