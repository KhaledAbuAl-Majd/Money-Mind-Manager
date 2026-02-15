using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Domain.NewFolder1
{
    public class PersonSearchCriteria
    {
        public int? PersonID { get; set; }
        public string PersonName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte TextSearchMode { get; set; }
        public int PageNumber { get; set; }
        public byte rowsPerPage { get; set; }

        public PersonSearchCriteria(int pageNumber)
        {
            this.PageNumber = pageNumber;
            this.PersonName = null;
            this.Email = null;
            this.Phone = null;
            this.TextSearchMode = (byte)enTextSearchMode.WordsPrefix_Fast;
            rowsPerPage = 15;
        }

        public PersonSearchCriteria()
        {
            this.PageNumber = 1;
            rowsPerPage = 15;
            this.TextSearchMode = (byte)enTextSearchMode.WordsPrefix_Fast;
        }
    }
}
