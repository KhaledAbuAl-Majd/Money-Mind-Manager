using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Domain.Criteria
{
    public class MainTransactionPagedSearchCriteria : MainTransactionSearchCriteria
    {
        public int PageNumber { get; set; }
        public byte RowsPerPage { get; set; }

        public MainTransactionPagedSearchCriteria(enTextSearchMode textSearchMode, int pageNumber) : base(textSearchMode)
        {
            this.PageNumber = pageNumber;
            this.RowsPerPage = 15;
        }

        public MainTransactionPagedSearchCriteria(MainTransactionSearchCriteria filterDTO)
        {
            CreatedByUserName = filterDTO.CreatedByUserName;
            FromCreatedDate = filterDTO.FromCreatedDate;
            FromTransactionDate = filterDTO.FromTransactionDate;
            ToTransactionDate = filterDTO.ToTransactionDate;
            ToCreatedDate = filterDTO.ToCreatedDate;
            TransactionTypes = filterDTO.TransactionTypes;
            Purpose = filterDTO.Purpose;
            TextSearchMode = (byte)filterDTO.TextSearchMode;
            TransactionID = filterDTO.TransactionID;
        }

        public MainTransactionPagedSearchCriteria()
        {
            this.PageNumber = 1;
            this.RowsPerPage = 15;
        }
    }
}
