using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Domain.Criteria.FinVoucher
{
    public class FinVoucherPagedSearchCriteria : FinVoucherSearchCriteria
    {
        public int PageNumber { get; set; }
        public int RowsPerPage { get; set; }

        public FinVoucherPagedSearchCriteria(enTextSearchMode textSearchMode, int pageNumber) : base(textSearchMode)
        {
            this.PageNumber = pageNumber;
            this.RowsPerPage = 15;
        }

        public FinVoucherPagedSearchCriteria(FinVoucherSearchCriteria filterDTO)
        {
            VoucherID = filterDTO.VoucherID;
            VoucherName = filterDTO.VoucherName;
            UserName = filterDTO.UserName;
            FromVoucherDate = filterDTO.FromVoucherDate;
            ToVoucherDate = filterDTO.ToVoucherDate;
            ToCreatedDate = filterDTO.ToCreatedDate;
            TextSearchMode = filterDTO.TextSearchMode;
            IsIncome = filterDTO.IsIncome;
            IsReturn = filterDTO.IsReturn;
        }

        public FinVoucherPagedSearchCriteria()
        {
            this.PageNumber = 1;
            this.RowsPerPage = 15;
        }
    }
}
