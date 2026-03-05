using System;

namespace MoneyMindManager.Domain.Entities.FinTransaction
{
    public class FinTransaction : MainTransaction
    {
        public int? VoucherID { get; set; }
        public int? CategoryID { get; set; }

        public FinTransaction(int? transactionID, decimal amount, DateTime createdDate, short? accountID, int? createdByUserID, byte? tranasactionTypeID, string purpose,
            bool isLocked, DateTime transactionDate, string transactionTypeName, string createdByUserName, int? voucherID, int? categoryID)
            : base(transactionID, amount, createdDate, accountID, createdByUserID, tranasactionTypeID, purpose, isLocked, transactionDate, transactionTypeName, createdByUserName)
        {
            this.VoucherID = voucherID;
            this.CategoryID = categoryID;
        }

        public FinTransaction(MainTransaction mainTransaction, int voucherID, int categoryID): base(mainTransaction.MainTransactionID, mainTransaction.Amount,
            mainTransaction.CreatedDate, mainTransaction.AccountID, mainTransaction.CreatedByUserID, mainTransaction.TransactionTypeID, mainTransaction.Purpose,
            mainTransaction.IsLocked, mainTransaction.TransactionDate, mainTransaction.TransactionTypeName, mainTransaction.CreatedByUserName)
        {
            this.VoucherID = voucherID;
            this.CategoryID = categoryID;
        }

        public FinTransaction()
        {

        }
    }
}
