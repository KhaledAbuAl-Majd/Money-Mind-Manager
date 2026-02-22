using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Shared.DTOs.IncomeAndExpenseCategory
{
    public class FinCategorySelectPagedFilterDTO
    {
        public string CategoryName { get; set; }
        public bool? IsIncome { get; set; }
        public enTextSearchMode TextSearchMode { get; set; }
        public int PageNumber { get; set; }

        public FinCategorySelectPagedFilterDTO(enTextSearchMode textSearchMode)
        {
            this.TextSearchMode = textSearchMode;
            this.PageNumber = 1;
        }

        public FinCategorySelectPagedFilterDTO()
        {
            this.TextSearchMode = enTextSearchMode.WordsPrefix_Fast;
            this.PageNumber = 1;
        }
    }
}
