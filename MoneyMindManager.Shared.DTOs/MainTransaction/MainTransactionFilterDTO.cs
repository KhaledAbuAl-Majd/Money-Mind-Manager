using System.Collections.Generic;
using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Shared.DTOs.MainTransaction
{
    public class MainTransactionFilterDTO
    {
        public int? TransactionID { get; set; }
        public string CreatedByUserName { get; set; }
        public string Purpose { get; set; }
        public List<int> TransactionTypes { get; set; }
        public bool IsByCreatedDate { get; set; }
        public string FromDateString { get; set; }
        public string ToDateString { get; set; }
        public enTextSearchMode TextSearchMode { get; set; }

        public MainTransactionFilterDTO(enTextSearchMode textSearchMode)
        {
            this.TextSearchMode = textSearchMode;
        }

        public MainTransactionFilterDTO()
        {
            TextSearchMode = enTextSearchMode.WordsPrefix_Fast;
        }
    }
}
