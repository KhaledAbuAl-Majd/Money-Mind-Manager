using System;

namespace MoneyMindManager.Shared.DTOs.MainTransaction
{
    public class MainTransactionDTO
    {
        public int? MainTransactionID { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public short? AccountID { get; set; }
        public int? CreatedByUserID { get; set; }
        public string CreatedByUserName { get; set; }
        public byte? TransactionTypeID { get; set; }
        public string TransactionTypeName { get; set; }
        public string Purpose { get; set; }
        public bool IsLocked { get; set; }
        public DateTime TransactionDate { get; set; }

        public MainTransactionDTO(int? transactionID, decimal amount, DateTime createdDate, short? accountID,
            int? createdByUserID, byte? tranasactionTypeID, string purpose, bool isLocked, DateTime transactionDate, string transactionTypeName, string createdByUserName)
        {
            this.MainTransactionID = transactionID;
            this.Amount = amount;
            this.CreatedDate = createdDate;
            this.AccountID = accountID;
            this.CreatedByUserID = createdByUserID;
            this.TransactionTypeID = tranasactionTypeID;
            this.Purpose = purpose;
            this.IsLocked = isLocked;
            this.TransactionDate = transactionDate;
            this.TransactionTypeName = transactionTypeName;
            this.CreatedByUserName = createdByUserName;
        }
    }
}
