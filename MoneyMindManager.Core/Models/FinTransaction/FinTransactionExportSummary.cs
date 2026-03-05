using System;

namespace MoneyMindManager.Core.Models.FinTransaction
{
    public class FinTransactionExportSummary : FinTransactionViewSummary
    {
        public int? CategoryID { get; set; }
        public DateTime TransactionDate { get; set; }
        public int? CreatedByUserID { get; set; }
        public short? AccountID { get; set; }

        public FinTransactionExportSummary(int transactionID, string categoryName, decimal amount, string createdByUserName,
            DateTime createdDate, string purpose, int categoryID, DateTime transactionDate, int createdByUserID, short accountID) :
            base(transactionID, categoryName, amount, createdByUserName, createdDate, purpose)
        {
            this.CategoryID = categoryID;
            this.TransactionDate = transactionDate;
            this.CreatedByUserID = createdByUserID;
            this.AccountID = accountID;
        }
    }
}
