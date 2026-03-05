using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Shared.DTOs.IncomeAndExpenseCategory
{
    public class FinCategoryPagedFilterDTO
    {
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ParentCategoryName { get; set; }
        public string MainCategoryName { get; set; }
        public bool? IsIncome { get; set; }
        public bool? IsActive { get; set; }
        public bool IncludeMainCategories { get; set; }
        public bool IncludeSubCategories { get; set; }
        public enTextSearchMode TextSearchMode { get; set; }
        public int PageNumber { get; set; }

        public FinCategoryPagedFilterDTO(enTextSearchMode textSearchMode)
        {
            this.TextSearchMode = textSearchMode;
            this.PageNumber = 1;
        }

        public FinCategoryPagedFilterDTO()
        {
            this.TextSearchMode = enTextSearchMode.WordsPrefix_Fast;
            this.PageNumber = 1;
        }
    }
}
