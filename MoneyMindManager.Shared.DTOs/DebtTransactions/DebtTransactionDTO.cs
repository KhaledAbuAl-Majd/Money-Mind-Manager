using System;
using MoneyMindManager.Shared.DTOs.MainTransaction;

namespace MoneyMindManager.Shared.DTOs.DebtPayment
{
    public class DebtTransactionDTO : MainTransactionDTO
    {
        public int? DebtID { get; set; }
        public DebtTransactionDTO(int? transactionID, decimal amount, DateTime createdDate, short? accountID, int? createdByUserID, byte? tranasactionTypeID, string purpose,
            bool isLocked, DateTime transactionDate, string transactionTypeName, string createdByUserName, int? debtID)
            : base(transactionID, amount, createdDate, accountID, createdByUserID, tranasactionTypeID, purpose, isLocked, transactionDate, transactionTypeName, createdByUserName)
        {
            this.DebtID = debtID;
        }

        public DebtTransactionDTO() : base(null, default, default, default, null, null, null, default, default, default, default)
        {

        }
    }
}
