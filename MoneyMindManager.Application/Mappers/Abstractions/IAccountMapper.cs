using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.Account;

namespace MoneyMindManager.Application.Abstractions.Mappers
{
    public interface IAccountMapper : IMapper<Account, AccountBaseDTO>
    {
        (Person, User, Account) CreateAccountDTOToEntities(CreateAccountDTO createAccountDTO);
    }
}
