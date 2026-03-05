namespace MoneyMindManager.Domain.Entities.FinTransaction
{
    public class FinTransactionShort
    {
        public int? TransactionID { get; set; }
        public int? VoucherID { get; set; }
        public int? CategoryID { get; set; }

        public FinTransactionShort(int transactionID, int voucherID, int categoryID)
        {
            this.TransactionID = transactionID;
            this.VoucherID = voucherID;
            this.CategoryID = categoryID;
        }
    }
}
