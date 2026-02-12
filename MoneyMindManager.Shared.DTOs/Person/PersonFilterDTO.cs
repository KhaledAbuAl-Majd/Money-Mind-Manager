using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManager.Shared.DTOs.Person
{
    public class PersonFilterDTO
    {
        public int? PersonID { get; set; }
        public string PersonName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte TextSearchMode { get; set; }

        public int PageNumber { get; set; }

        public PersonFilterDTO(int pageNumber )
        {
            this.PageNumber = pageNumber;
            this.PersonName = null;
            this.Email = null;
            this.Phone = null;
            this.TextSearchMode = 1;
        }

        public PersonFilterDTO()
        {
            this.PageNumber = 1;
        }
    }
}
