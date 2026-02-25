using System;

namespace MoneyMindManager.Domain.Entities
{
    public class Debt : MainTransaction
    {
        public int? DebtID { get; set; }
        public bool IsLending { get; set; }
        public int? PersonID { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public decimal RemainingAmount { get; set; }

        public Debt(int? transactionID, decimal amount, DateTime createdDate, short? accountID, int? createdByUserID, byte? tranasactionTypeID, string purpose, bool isLocked,
            DateTime transactionDate, string transactionTypeName, string createdByUserName, int debtID, bool isLending, int personID, DateTime? paymentDueDate, decimal remaintAmount)
             : base(transactionID, amount, createdDate, accountID, createdByUserID, tranasactionTypeID, purpose, isLocked,
                   transactionDate, transactionTypeName, createdByUserName)
        {
            this.DebtID = debtID;
            this.IsLending = isLending;
            this.PersonID = personID;
            this.PaymentDueDate = paymentDueDate;
            this.RemainingAmount = remaintAmount;
        }

        public Debt(MainTransaction mainTransaction, int debtID, bool isLending, int personID, DateTime? paymentDueDate, decimal remaintAmount) : base(mainTransaction.MainTransactionID, mainTransaction.Amount,
           mainTransaction.CreatedDate, mainTransaction.AccountID, mainTransaction.CreatedByUserID, mainTransaction.TransactionTypeID, mainTransaction.Purpose,
           mainTransaction.IsLocked, mainTransaction.TransactionDate, mainTransaction.TransactionTypeName, mainTransaction.CreatedByUserName)
        {
            this.DebtID = debtID;
            this.IsLending = isLending;
            this.PersonID = personID;
            this.PaymentDueDate = paymentDueDate;
            this.RemainingAmount = remaintAmount;
        }

        public Debt()
        {
            this.DebtID = null;
            this.IsLending = false;
            this.PersonID = null;
            this.PaymentDueDate = null;
            this.RemainingAmount = -9999999999;
        }
    }
}
