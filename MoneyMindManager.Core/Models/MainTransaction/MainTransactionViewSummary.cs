using System;

namespace MoneyMindManager.Core.Models.MainTransaction
{
    public class MainTransactionViewSummary
    {
        public int? MainTransactionID { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
        public string Purpose { get; set; }
        public string TransactionTypeName { get; set; }

        public MainTransactionViewSummary(int? transactionID, decimal amount, DateTime createdDate,
            string purpose, DateTime transactionDate, string createdByUserName, string transactionTypeName)
        {
            this.MainTransactionID = transactionID;
            this.Amount = amount;
            this.CreatedDate = createdDate;
            this.Purpose = purpose;
            this.TransactionDate = transactionDate;
            this.CreatedByUserName = createdByUserName;
            this.TransactionTypeName = transactionTypeName;
        }
    }
}
