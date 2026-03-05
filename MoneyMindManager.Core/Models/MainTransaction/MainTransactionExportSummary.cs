using System;

namespace MoneyMindManager.Core.Models.MainTransaction
{
    public class MainTransactionExportSummary
    {
        public int? MainTransactionID { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
        public string Purpose { get; set; }
        public byte? TransactionTypeID { get; set; }
        public int? CreatedByUserID { get; set; }
        public short? AccountID { get; set; }
        public string TransactionTypeName { get; set; }

        public MainTransactionExportSummary(int? transactionID, decimal amount, DateTime createdDate, short? accountID,
            int? createdByUserID, byte? tranasactionTypeID, string purpose, DateTime transactionDate, string createdByUserName, string transactionTypeName)
        {
            this.MainTransactionID = transactionID;
            this.Amount = amount;
            this.CreatedDate = createdDate;
            this.AccountID = accountID;
            this.CreatedByUserID = createdByUserID;
            this.TransactionTypeID = tranasactionTypeID;
            this.Purpose = purpose;
            this.TransactionDate = transactionDate;
            this.CreatedByUserName = createdByUserName;
            this.TransactionTypeName = transactionTypeName;
        }
    }
}
