using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Shared.DTOs.FinVoucher
{
    public class FinVoucherPagedFilterDTO : FinVoucherFilterDTO
    {
        public int PageNumber { get; set; }

        public FinVoucherPagedFilterDTO(enTextSearchMode textSearchMode, int pageNumber) : base(textSearchMode)
        {
            this.PageNumber = 1;
        }

        public FinVoucherPagedFilterDTO()
        {
            this.TextSearchMode = enTextSearchMode.WordsPrefix_Fast;
            this.PageNumber = 1;
        }
    }
}
