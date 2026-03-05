using System;

namespace MoneyMindManager.Core.Models.Person
{
    public class PersonSelectSummary
    {
        public Nullable<int> PersonID { get; set; }
        public string PersonName { get; set; }

        public PersonSelectSummary(int? personID, string personName)
        {
            this.PersonID = personID;
            this.PersonName = personName;
        }
    }
}
