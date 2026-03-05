using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Shared.DTOs.FinVoucher
{
    public class FinVoucherFilterDTO
    {
        public int? VoucherID { get; set; }
        public string VoucherName { get; set; }
        public string UserName { get; set; }
        public bool IsByCreatedDate { get; set; }
        public string FromDateString { get; set; }
        public string ToDateString { get; set; }
        public enVoucherType VoucherType { get; set; }
        public enTextSearchMode TextSearchMode { get; set; }

        public FinVoucherFilterDTO(enTextSearchMode textSearchMode)
        {
            this.TextSearchMode = textSearchMode;
        }

        public FinVoucherFilterDTO()
        {
            this.TextSearchMode = enTextSearchMode.WordsPrefix_Fast;
        }
    }
}
