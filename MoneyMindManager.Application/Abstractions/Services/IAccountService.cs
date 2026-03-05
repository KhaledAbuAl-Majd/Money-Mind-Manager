using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Shared.DTOs.Account;

namespace MoneyMindManager.Application.Abstractions.Services
{
    public interface IAccountService
    {
        Task<IResult<short?>> Add(CreateAccountDTO createAccountDTO);

        Task<IResult<bool>> Update(AccountBaseDTO accountBaseDTO, int currentUserID);

        Task<IResult<AccountBaseDTO>> Get(short accountID);

        Task<IResult<bool>> IsExistByAccountName(string accountName);

        Task<IResult<bool>> Delete(short accountID, int currentUserID);
    }
}
