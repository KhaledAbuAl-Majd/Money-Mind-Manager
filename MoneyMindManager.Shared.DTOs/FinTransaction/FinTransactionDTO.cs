using System;
using MoneyMindManager.Shared.DTOs.MainTransaction;

namespace MoneyMindManager.Shared.DTOs.FinTransaction
{
    public class FinTransactionDTO : MainTransactionDTO
    {
        public int? VoucherID { get; set; }
        public int? CategoryID { get; set; }
        public FinTransactionDTO(int? transactionID, decimal amount, DateTime createdDate, short? accountID, int? createdByUserID, byte? tranasactionTypeID, string purpose,
            bool isLocked, DateTime transactionDate, string transactionTypeName, string createdByUserName, int? voucherID, int? categoryID)
            : base(transactionID, amount, createdDate, accountID, createdByUserID, tranasactionTypeID, purpose, isLocked, transactionDate, transactionTypeName, createdByUserName)
        {
            this.VoucherID = voucherID;
            this.CategoryID = categoryID;
        }
    }
}
