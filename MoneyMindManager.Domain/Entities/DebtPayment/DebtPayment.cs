using System;

namespace MoneyMindManager.Domain.Entities.DebtPayment
{
    public class DebtPayment : MainTransaction
    {
        public int? DebtID { get; set; }

        public DebtPayment(int? transactionID, decimal amount, DateTime createdDate, short? accountID, int? createdByUserID, byte? tranasactionTypeID, string purpose,
            bool isLocked, DateTime transactionDate, string transactionTypeName, string createdByUserName, int? debtID)
            : base(transactionID, amount, createdDate, accountID, createdByUserID, tranasactionTypeID, purpose, isLocked, transactionDate, transactionTypeName, createdByUserName)
        {
            this.DebtID = debtID;
        }

        public DebtPayment(MainTransaction mainTransaction, int debtID) : base(mainTransaction.MainTransactionID, mainTransaction.Amount,
            mainTransaction.CreatedDate, mainTransaction.AccountID, mainTransaction.CreatedByUserID, mainTransaction.TransactionTypeID, mainTransaction.Purpose,
            mainTransaction.IsLocked, mainTransaction.TransactionDate, mainTransaction.TransactionTypeName, mainTransaction.CreatedByUserName)
        {
            this.DebtID = debtID;
        }

        public DebtPayment()
        {

        }

    }
}
