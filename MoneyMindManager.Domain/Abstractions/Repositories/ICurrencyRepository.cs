using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Domain.Entities;

namespace MoneyMindManager.Domain.Abstractions
{
    public interface ICurrencyRepository
    {
        Task<IResult<Currency>> GetByID(byte currencyID);

        Task<IResult<Currency>> GetByName(string currencyName);

        Task<IResult<IEnumerable<Currency>>> GetAll();
    }
}
