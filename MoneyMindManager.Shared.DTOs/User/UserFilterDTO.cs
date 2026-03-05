using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Shared.DTOs.User
{
    public class UserFilterDTO
    {
        public int? UserID { get; set; }
        public string UserName { get; set; }
        public string PersonName { get; set; }
        public bool? IsActive { get; set; }
        public enTextSearchMode TextSearchMode { get; set; }
        public int PageNumber { get; set; }

        public UserFilterDTO(int pageNumber )
        {
            this.PageNumber = pageNumber;
            this.UserID = null;
            this.UserName = null;
            this.PersonName = null;
            this.IsActive = null;
            this.TextSearchMode = enTextSearchMode.WordsPrefix_Fast;
        }

        public UserFilterDTO()
        {
            this.PageNumber = 1;
            this.TextSearchMode = enTextSearchMode.WordsPrefix_Fast;
        }
    }
}
