using System;

namespace MoneyMindManager.Domain.Entities.DebtEntry
{
    public class DebtEntry : MainTransaction
    {
        public int? DebtID { get; set; }

        public DebtEntry(int? transactionID, decimal amount, DateTime createdDate, short? accountID, int? createdByUserID, byte? tranasactionTypeID, string purpose,
            bool isLocked, DateTime transactionDate, string transactionTypeName, string createdByUserName, int? debtID)
            : base(transactionID, amount, createdDate, accountID, createdByUserID, tranasactionTypeID, purpose, isLocked, transactionDate, transactionTypeName, createdByUserName)
        {
            this.DebtID = debtID;
        }

        public DebtEntry(MainTransaction mainTransaction, int debtID) : base(mainTransaction.MainTransactionID, mainTransaction.Amount,
            mainTransaction.CreatedDate, mainTransaction.AccountID, mainTransaction.CreatedByUserID, mainTransaction.TransactionTypeID, mainTransaction.Purpose,
            mainTransaction.IsLocked, mainTransaction.TransactionDate, mainTransaction.TransactionTypeName, mainTransaction.CreatedByUserName)
        {
            this.DebtID = debtID;
        }

        public DebtEntry()
        {

        }

    }
}
