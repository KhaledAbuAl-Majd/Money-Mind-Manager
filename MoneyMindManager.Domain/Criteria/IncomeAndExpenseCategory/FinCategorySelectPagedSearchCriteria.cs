using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Domain.Criteria.IncomeAndExpenseCategory
{
    public class FinCategorySelectPagedSearchCriteria
    {
        public string CategoryName { get; set; }
        public bool? IsIncome { get; set; }
        public byte TextSearchMode { get; set; }
        public int PageNumber { get; set; }
        public int RowsPerPage { get; set; }
        public FinCategorySelectPagedSearchCriteria(enTextSearchMode textSearchMode)
        {
            this.TextSearchMode = (byte)textSearchMode;
            this.PageNumber = 1;
            this.RowsPerPage = 15;
        }

        public FinCategorySelectPagedSearchCriteria()
        {
            this.TextSearchMode = (byte)enTextSearchMode.WordsPrefix_Fast;
            this.PageNumber = 1;
            this.RowsPerPage = 15;
        }
    }
}
