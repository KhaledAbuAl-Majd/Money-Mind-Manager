using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Domain.Entities;

namespace MoneyMindManager.Domain.Abstractions
{
    public interface ICurrencyRepository
    {
        Task<Currency> GetByID(byte currencyID);

        Task<Currency> GetByName(string currencyName);

        Task<IEnumerable<Currency>> GetAll();
    }
}
