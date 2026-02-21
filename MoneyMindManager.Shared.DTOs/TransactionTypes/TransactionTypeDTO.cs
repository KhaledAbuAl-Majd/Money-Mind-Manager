namespace MoneyMindManager.Shared.DTOs.TransactionTypes
{
    public class TransactionTypeDTO
    {
        public byte TransactionTypeID { get; }
        public string TransactionTypeName { get; }

        public TransactionTypeDTO(byte transactionTypeID, string transactionTypeName)
        {
            this.TransactionTypeID = transactionTypeID;
            this.TransactionTypeName = transactionTypeName;
        }
    }
}
