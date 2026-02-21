using System;

namespace MoneyMindManager.Shared.DTOs.MainTransaction
{
    public class MainTransactionDTO
    {
        public int? MainTransactionID { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public short? AccountID { get; private set; }
        public int? CreatedByUserID { get; private set; }
        public string CreatedByUserName { get; set; }
        public byte? TransactionTypeID { get; set; }
        public string TransactionTypeName { get; set; }
        public string Purpose { get; private set; }
        public bool IsLocked { get; private set; }
        public DateTime TransactionDate { get; private set; }

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

        public MainTransactionDTO()
        {
            this.MainTransactionID = null;
            this.Amount = 0;
            this.CreatedDate = DateTime.MaxValue; ;
            this.AccountID = null;
            this.CreatedByUserID = null;
            this.TransactionTypeID = null;
            this.Purpose = null;
            this.TransactionDate = DateTime.MaxValue; ;
        }
    }
}
