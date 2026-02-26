using MoneyMindManager.Domain.Criteria;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Domain.NewFolder1;
using MoneyMindManager.Shared.DTOs;
using MoneyMindManager.Shared.DTOs.Person;

namespace MoneyMindManager.Application.Abstractions.Mappers
{
    public interface IPersonMapper : IMapper<Person, PersonDTO>
    {
        PersonSearchCriteria ToSearchCriteria(PersonFilterDTO personFilterDTO);
        PersonSelectSearchCriteria ToSelectSearchCriteria(PersonSelectFilterDTO personSelectFilterDTO);
    }
}
