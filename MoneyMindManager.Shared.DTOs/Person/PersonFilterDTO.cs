using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Shared.DTOs.Person
{
    public class PersonFilterDTO
    {
        public int? PersonID { get; set; }
        public string PersonName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public enTextSearchMode TextSearchMode { get; set; }

        public int PageNumber { get; set; }

        public PersonFilterDTO(int pageNumber, enTextSearchMode textSearchMode)
        {
            this.PageNumber = pageNumber;
            this.PersonName = null;
            this.Email = null;
            this.Phone = null;
            this.TextSearchMode = textSearchMode;
        }

        public PersonFilterDTO()
        {
            this.PageNumber = 1;
            this.TextSearchMode = enTextSearchMode.WordsPrefix_Fast;
        }
    }
}
