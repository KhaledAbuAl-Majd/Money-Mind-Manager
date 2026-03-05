using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Shared.DTOs.Account;

namespace MoneyMindManager.APIClient.Api_Client_Implementation
{
    public class AccountApiClient : IAccountApiClient
    {
        private readonly IAccountService _accountService;

        public AccountApiClient(IAccountService accountService)
        {
            this._accountService = accountService;
        }
        public Task<IResult<short?>> Add(CreateAccountDTO createAccountDTO)
        {
            return _accountService.Add(createAccountDTO);
        }

        public Task<IResult<bool>> Update(AccountBaseDTO accountBaseDTO, int currentUserID)
        {
            return _accountService.Update(accountBaseDTO, currentUserID);
        }

        public Task<IResult<AccountBaseDTO>> Get(short accountID)
        {
            return _accountService.Get(accountID);
        }

        public Task<IResult<bool>> IsExistByAccountName(string accountName)
        {
            return _accountService.IsExistByAccountName(accountName);
        }

        public Task<IResult<bool>> Delete(short accountID, int currentUserID)
        {
            return _accountService.Delete(accountID, currentUserID);
        }
    }
}
