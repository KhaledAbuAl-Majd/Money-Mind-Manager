using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Shared.DTOs.Person
{
    public class PersonSelectFilterDTO
    {
        public string PersonName { get; set; }

        public enTextSearchMode TextSearchMode { get; set; }

        public int PageNumber { get; set; }

        public PersonSelectFilterDTO(int pageNumber,enTextSearchMode textSearchMode)
        {
            this.PageNumber = pageNumber;
            this.PersonName = null;
            this.TextSearchMode = textSearchMode;
        }
        public PersonSelectFilterDTO(string personName,int pageNumber,enTextSearchMode textSearchMode)
        {
            this.PersonName = personName;
            this.PageNumber = pageNumber;
            this.TextSearchMode = textSearchMode;
        }

        public PersonSelectFilterDTO()
        {
            this.PageNumber = 1;
            this.TextSearchMode = enTextSearchMode.WordsPrefix_Fast;
        }
    }
}
