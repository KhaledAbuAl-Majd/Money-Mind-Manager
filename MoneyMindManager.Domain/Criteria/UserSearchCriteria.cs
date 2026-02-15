using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Domain.Criteria
{
    public class UserSearchCriteria
    {
        public int? UserID { get; set; }
        public string UserName { get; set; }
        public string PersonName { get; set; }
        public bool? IsActive { get; set; }
        public byte TextSearchMode { get; set; }
        public int PageNumber { get; set; }

        public byte RowsPerPage { get; set; }

        public UserSearchCriteria(int pageNumber)
        {
            this.PageNumber = pageNumber;
            this.UserID = null;
            this.UserName = null;
            this.PersonName = null;
            this.IsActive = null;
            this.TextSearchMode = (byte)enTextSearchMode.WordsPrefix_Fast;
            RowsPerPage = 15;
        }

        public UserSearchCriteria()
        {
            this.PageNumber = 1;
            this.TextSearchMode = (byte)enTextSearchMode.WordsPrefix_Fast;
            RowsPerPage = 15;
        }
    }
}
