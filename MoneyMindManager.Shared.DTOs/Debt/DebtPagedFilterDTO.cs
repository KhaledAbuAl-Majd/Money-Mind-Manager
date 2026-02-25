using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Shared.DTOs.Debt
{
    public class DebtPagedFilterDTO : DebtFilterDTO
    {
        public int PageNumber { get; set; }

        public DebtPagedFilterDTO(enTextSearchMode textSearchMode, int pageNumber) : base(textSearchMode)
        {
            this.PageNumber = 1;
        }

        public DebtPagedFilterDTO()
        {
            this.TextSearchMode = enTextSearchMode.WordsPrefix_Fast;
            this.PageNumber = 1;
        }
    }
}
