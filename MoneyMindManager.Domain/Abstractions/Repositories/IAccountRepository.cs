using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Domain.Entities;

namespace MoneyMindManager.Domain.Abstractions
{
    public interface IAccountRepository
    {
        /// <returns>New AccountID if Success, if failed return null</returns>
        Task<IResult<short?>> Add(Person person, User user, Account account);

        /// <returns>Updating Result</returns>
        Task<IResult<bool>> Update(Account account, int currentUserID);

        /// <returns>Object of Account, if Account is not found it will return null</returns>
        Task<IResult<Account>> Get(short accountID);

        /// <returns>true if account exist, false if account not exist</returns>
        Task<IResult<bool>> IsExistByAccountName(string accountName);

        Task<IResult<bool>> Delete(short accountID);
    }
}
