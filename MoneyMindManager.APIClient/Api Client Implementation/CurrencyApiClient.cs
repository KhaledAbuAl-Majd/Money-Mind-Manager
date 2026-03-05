using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Shared.DTOs.Currency;

namespace MoneyMindManager.APIClient.Api_Client_Implementation
{
    public class CurrencyApiClient : ICurrencyApiClient
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyApiClient(ICurrencyService currencyService)
        {
            this._currencyService = currencyService;
        }

        public async Task<IResult<CurrencyDTO>> GetByID(byte currencyID)
        {
            return await _currencyService.GetByID(currencyID);
        }

        public async Task<IResult<CurrencyDTO>> GetByName(string currencyName)
        {
            return await _currencyService.GetByName(currencyName);
        }

        public async Task<IResult<IEnumerable<CurrencyDTO>>> GetAll()
        {
            return await _currencyService.GetAll();
        }
    }
}
