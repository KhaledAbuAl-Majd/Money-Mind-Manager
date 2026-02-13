using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs;

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
    }
}
