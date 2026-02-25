using System;
using MoneyMindManager.Shared.DTOs.MainTransaction;

namespace MoneyMindManager.Shared.DTOs.Debt
{
    public class DebtDTO : MainTransactionDTO
    {
        public int? DebtID { get; set; }
        public bool IsLending { get; set; }
        public int? PersonID { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public decimal RemainingAmount { get; set; }

        //composition
        public PersonDTO PersonInfo { get; set; }

        public DebtDTO(int? transactionID, decimal amount, DateTime createdDate, short? accountID, int? createdByUserID, byte? tranasactionTypeID, string purpose,
             bool isLocked, DateTime transactionDate, string transactionTypeName, string createdByUserName,
             int? debtID, bool isLending, int? personID, DateTime? paymentDueDate, decimal remaintAmount)
             : base(transactionID, amount, createdDate, accountID, createdByUserID, tranasactionTypeID, purpose, isLocked, transactionDate, transactionTypeName, createdByUserName)
        {
            this.DebtID = debtID;
            this.IsLending = isLending;
            this.PersonID = personID;
            this.PaymentDueDate = paymentDueDate;
            this.RemainingAmount = remaintAmount;
        }
    }
}
