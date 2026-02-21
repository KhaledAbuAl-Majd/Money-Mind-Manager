using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Shared.DTOs.MainTransaction
{
    public class MainTransactionPagedFilterDTO : MainTransactionFilterDTO
    {
        public int PageNumber { get; set; }

        public MainTransactionPagedFilterDTO(enTextSearchMode textSearchMode, int pageNumber) : base(textSearchMode)
        {
            this.PageNumber = pageNumber;
        }

        public MainTransactionPagedFilterDTO()
        {
            this.PageNumber = 15;
        }
    }
}
