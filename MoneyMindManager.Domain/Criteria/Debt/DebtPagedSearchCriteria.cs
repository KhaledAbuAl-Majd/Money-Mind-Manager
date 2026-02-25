using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Domain.Criteria.Debt
{
    public class DebtPagedSearchCriteria : DebtSearchCriteria
    {
        public int PageNumber { get; set; }
        public int RowsPerPage { get; set; }

        public DebtPagedSearchCriteria(enTextSearchMode textSearchMode, int pageNumber) : base(textSearchMode)
        {
            this.PageNumber = pageNumber;
            this.RowsPerPage = 15;
        }

        public DebtPagedSearchCriteria(DebtSearchCriteria filterDTO)
        {
            this.DebtID = filterDTO.DebtID;
            this.IsLending = filterDTO.IsLending;
            this.PersonName = filterDTO.PersonName;
            this.UserName = filterDTO.UserName;
            this.FromCreatedDate = filterDTO.FromCreatedDate;
            this.ToCreatedDate = filterDTO.ToCreatedDate;
            this.FromDebtDate = filterDTO.FromDebtDate;
            this.ToDebtDate = filterDTO.ToDebtDate;
            this.IsPaid = filterDTO.IsPaid;
            this.TextSearchMode = filterDTO.TextSearchMode;
        }

        public DebtPagedSearchCriteria()
        {
            this.PageNumber = 1;
            this.RowsPerPage = 15;
        }
    }
}
