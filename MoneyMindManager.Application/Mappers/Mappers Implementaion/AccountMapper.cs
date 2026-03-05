using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.Account;

namespace MoneyMindManager.Application.Mappers.Mappers_Implementaion
{
    public class AccountMapper : IAccountMapper
    {
        public Account DTOToEntity(AccountBaseDTO accountDTO)
        {
            if (accountDTO is null)
                return null;

            return new Account()
            {
                AccountID = accountDTO.AccountID,
                AccountName = accountDTO.AccountName,
                AccountOwnerUserID = accountDTO.AccountOwnerUserID,
                CreatedDate = accountDTO.CreatedDate,
                Balance = accountDTO.Balance,
                DefaultCurrencyID = accountDTO.DefaultCurrencyID,
                Description = accountDTO.Description
            };
        }

        public AccountBaseDTO EntityToDTO(Account account)
        {
            if (account is null)
                return null;

            return new AccountBaseDTO(account.AccountID, account.AccountName, account.CreatedDate, account.DefaultCurrencyID, account.Description, account.Balance,
                account.AccountOwnerUserID);
        }

        public (Person, User, Account) CreateAccountDTOToEntities(CreateAccountDTO createAccountDTO)
        {
            if (createAccountDTO is null)
                return (null, null, null);

            var person = new Person()
            {
                PersonName = createAccountDTO.PersonName,
                Email = createAccountDTO.Email,
                Phone = createAccountDTO.Phone,
                Notes = createAccountDTO.Notes
            };

            var user = new User()
            {
                UserName = createAccountDTO.UserName,
                Password = createAccountDTO.Password
            };

            var account = new Account()
            {
                AccountName = createAccountDTO.AccountName,
                Description = createAccountDTO.Description,
                DefaultCurrencyID = createAccountDTO.DefaultCurrencyID
            };

            return (person, user, account);
        }
    }
}
