using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Shared.DTOs.Currency;

namespace MoneyMindManager.Client.Abstractions.ApiClient
{
    public interface ICurrencyApiClient
    {
        Task<IResult<CurrencyDTO>> GetByID(byte currencyID);

        Task<IResult<CurrencyDTO>> GetByName(string currencyName);

        Task<IResult<IEnumerable<CurrencyDTO>>> GetAll();
    }
}
