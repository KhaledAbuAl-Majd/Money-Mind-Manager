using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Domain.Criteria;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Domain.NewFolder1;
using MoneyMindManager.Shared.DTOs;
using MoneyMindManager.Shared.DTOs.Person;

namespace MoneyMindManager.Application.Mappers.Mappers_Implementaion
{
    public class PersonMapper : IPersonMapper
    {
        public Person DTOToEntity(PersonDTO personDTO)
        {
            if (personDTO is null)
                return null;

            return new Person(personDTO.PersonID, personDTO.PersonName, personDTO.Address, personDTO.Email, personDTO.Phone, personDTO.AccountID, personDTO.Notes,
                personDTO.CreatedByUserID, personDTO.CreatedDate, personDTO.Receivable, personDTO.Payable);
        }

        public PersonDTO EntityToDTO(Person person)
        {
            if (person is null)
                return null;

            return new PersonDTO(person.PersonID, person.PersonName, person.Address, person.Email, person.Phone, person.AccountID, person.Notes,
                person.CreatedByUserID, person.CreatedDate, person.Receivable, person.Payable);
        }

        public PersonSearchCriteria ToSearchCriteria(PersonFilterDTO personFilterDTO)
        {
            if (personFilterDTO is null)
                return null;

            return new PersonSearchCriteria()
            {
                PersonID = personFilterDTO.PersonID,
                PersonName = personFilterDTO.PersonName,
                Email = personFilterDTO.Email,
                PageNumber = personFilterDTO.PageNumber,
                Phone = personFilterDTO.Phone,
                TextSearchMode = (byte)personFilterDTO.TextSearchMode
            };
        }

        public PersonSelectSearchCriteria ToSelectSearchCriteria(PersonSelectFilterDTO personFilterDTO)
        {
            if (personFilterDTO is null)
                return null;

            return new PersonSelectSearchCriteria()
            {
                TextSearchMode = (byte)personFilterDTO.TextSearchMode,
                PageNumber = personFilterDTO.PageNumber,
                PersonName = personFilterDTO.PersonName
            };
        }
    }
}
