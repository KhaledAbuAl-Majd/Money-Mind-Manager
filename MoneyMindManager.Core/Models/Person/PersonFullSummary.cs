using System;

namespace MoneyMindManager.Core.Models.Person
{
    public class PersonFullSummary
    {
        public Nullable<int> PersonID { get; set; }
        public string PersonName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public PersonFullSummary(int? personID, string personName, string address, string email, string phone)
        {
            this.PersonID = personID;
            this.PersonName = personName;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
        }
    }
}
