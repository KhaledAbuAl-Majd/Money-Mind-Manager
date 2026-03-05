using System;

namespace MoneyMindManager.Core.Models.FinTransaction
{
    public class FinTransactionViewSummary
    {
        public int? MainTransactionID { get; set; }
        public string CategoryName { get; set; }
        public Decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
        public string Purpose { get; set; }

        public FinTransactionViewSummary(int transactionID, string categoryName, decimal amount, string createdByUserName,
            DateTime createdDate, string purpose)
        {
            this.MainTransactionID = transactionID;
            this.CategoryName = categoryName;
            this.Amount = amount;
            this.CreatedDate = createdDate;
            this.CreatedByUserName = createdByUserName;
            this.Purpose = purpose;
        }
    }
}
