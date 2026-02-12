using System;
using System.Threading.Tasks;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.Account;

namespace MoneyMindManager.Domain.Abstractions
{
    public interface IAccountRepository
    {
        /// <returns>New AccountID if Success, if failed return null</returns>
        Task<Nullable<int>> Add(Person person, User user, Account account);

        /// <returns>Updating Result</returns>
        Task<bool> Update(Account account, int currentUserID);

        /// <returns>Object of Account, if Account is not found it will return null</returns>
        Task<Account> Get(short accountID);

        /// <returns>true if account exist, false if account not exist</returns>
        Task<bool> IsExistByAccountName(string accountName);

        Task<bool> Delete(short accountID);
    }
}
