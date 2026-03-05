using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Domain.Criteria.IncomeAndExpenseCategory
{
    public class FinCategoryPagedSearchCriteria
    {
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ParentCategoryName { get; set; }
        public string MainCategoryName { get; set; }
        public bool? IsIncome { get; set; }
        public bool? IsActive { get; set; }
        public bool IncludeMainCategories { get; set; }
        public bool IncludeSubCategories { get; set; }
        public byte TextSearchMode { get; set; }
        public int PageNumber { get; set; }
        public int RowsPerPage { get; set; }
        public FinCategoryPagedSearchCriteria(enTextSearchMode textSearchMode)
        {
            this.TextSearchMode = (byte)textSearchMode;
            this.PageNumber = 1;
            this.RowsPerPage = 15;
        }

        public FinCategoryPagedSearchCriteria()
        {
            this.TextSearchMode = (byte)enTextSearchMode.WordsPrefix_Fast;
            this.PageNumber = 1;
            this.RowsPerPage = 15;
        }
    }
}
