namespace MoneyMindManager.Domain.Entities
{
    public class TransactionType
    {
        public byte TransactionTypeID { get; set; }
        public string TransactionTypeName { get; set; }

        public TransactionType(byte transactionTypeID, string transactionTypeName)
        {
            this.TransactionTypeID = transactionTypeID;
            this.TransactionTypeName = transactionTypeName;
        }

        public TransactionType()
        {

        }
    }
}
