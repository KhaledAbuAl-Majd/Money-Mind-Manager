using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Shared.DTOs.Account;

namespace MoneyMindManager.Application.Services.Account
{
    public class AccountService /*: IAccountService*/
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountMapper _accountMapper;
        private readonly IAuthorizationService _authorizationService;
        private readonly IResultFactory _resultFactory;
        public AccountService(IAccountRepository accountRepository, IAccountMapper accountMapper, IAuthorizationService authorizationService,IResultFactory resultFactory)
        {
            this._accountRepository = accountRepository;
            this._accountMapper = accountMapper;
            this._authorizationService = authorizationService;
            this._resultFactory = resultFactory;
        }

        //public Task<IResult<int?>> Add(CreateAccountDTO createAccountDTO)
        //{
        //    var HashedPasswordAndSalat = clsHashing.HashPasswordWithSalt(enteredpassword);
        //    string hashedPassword = HashedPasswordAndSalat.HashedPassword;
        //    string salt = HashedPasswordAndSalat.Salt;

        //    int? newAccountID = await clsAccountData.Add(accountName, defaultCurrencyID, description, personName, address, email,
        //        phone, notes, userName, hashedPassword, salt);

        //    return (newAccountID);

        //    var (person, user, account) = _accountMapper.CreateAccountDTOToEntities(createAccountDTO);
        //    var result = _accountRepository.Add(person, user, account);

        //    if (result is null)
        //        return result;

        //    var handler = _resultFactory.Create<int>();
        //}

        //public Task<IResult<bool>> Update(AccountBaseDTO accountBaseDTO, int currentUserID)
        //{

        //}

        //public Task<IResult<AccountBaseDTO>> Get(short accountID)
        //{

        //}

        //public Task<IResult<bool>> IsExistByAccountName(string accountName)
        //{

        //}

        //public Task<IResult<bool>> Delete(short accountID, int currentUserID)
        //{

        //}
    }
}
