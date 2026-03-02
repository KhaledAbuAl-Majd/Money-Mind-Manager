using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Shared.DTOs.Debt
{
    public class DebtFilterDTO
    {
        public int? DebtID { get; set; }
        public bool? IsLending { get; set; }
        public string PersonName { get; set; }
        public string UserName { get; set; }
        public bool IsByCreatedDate { get; set; }
        public string FromDateString { get; set; }
        public string ToDateString { get; set; }
        public bool? IsPaid { get; set; }
        public enTextSearchMode TextSearchMode { get; set; }

        public DebtFilterDTO(enTextSearchMode textSearchMode)
        {
            this.TextSearchMode = textSearchMode;
        }

        public DebtFilterDTO()
        {
            this.TextSearchMode = enTextSearchMode.WordsPrefix_Fast;
        }
    }
}
