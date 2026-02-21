using System;
using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Domain.Criteria
{
    public class MainTransactionSearchCriteria
    {
        public int? TransactionID { get; set; }
        public string CreatedByUserName { get; set; }
        public string Purpose { get; set; }
        public string TransactionTypes { get; set; }
        public DateTime? FromCreatedDate { get; set; }
        public DateTime? ToCreatedDate { get; set; }
        public DateTime? FromTransactionDate { get; set; }
        public DateTime? ToTransactionDate { get; set; }
        public byte TextSearchMode { get; set; }

        public MainTransactionSearchCriteria(enTextSearchMode textSearchMode)
        {
            this.TextSearchMode = (byte)textSearchMode;
        }

        public MainTransactionSearchCriteria()
        {
            TextSearchMode = (byte)enTextSearchMode.WordsPrefix_Fast;
        }
    }
}
