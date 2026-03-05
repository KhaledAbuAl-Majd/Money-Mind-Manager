using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Domain.Criteria
{
    public class PersonSelectSearchCriteria
    {
        public string PersonName { get; set; }

        public byte TextSearchMode { get; set; }

        public int PageNumber { get; set; }

        public byte RowsPerPage { get; set; }
        public PersonSelectSearchCriteria(int pageNumber)
        {
            this.PageNumber = pageNumber;
            this.PersonName = null;
            RowsPerPage = 15;
            this.TextSearchMode = (byte) enTextSearchMode.WordsPrefix_Fast;
        }

        public PersonSelectSearchCriteria()
        {
            this.PageNumber = 1;
            RowsPerPage = 15;
            this.TextSearchMode = (byte) enTextSearchMode.WordsPrefix_Fast;
        }
    }
}
