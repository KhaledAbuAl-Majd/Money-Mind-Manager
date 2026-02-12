using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.Currency;

namespace MoneyMindManager.Application.Services.Currency
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IResultFactory _resultFactory;
        private CurrencyDTO _getCurrencyDTOFromCurrency(MoneyMindManager.Domain.Entities.Currency currency)
        {
            return new CurrencyDTO(currency.CurrencyID, currency.CurrencyName, currency.CurrencySymbol);
        }
        private MoneyMindManager.Domain.Entities.Currency _getCurrencyFromCurrencyDTO(CurrencyDTO currencyDTO)
        {
            return new MoneyMindManager.Domain.Entities.Currency(currencyDTO.CurrencyID, currencyDTO.CurrencyName, currencyDTO.CurrencySymbol);
        }
        public CurrencyService(ICurrencyRepository currencyRepository, IResultFactory resultFactory)
        {
            this._currencyRepository = currencyRepository;
            this._resultFactory = resultFactory;
        }
        public async Task<IResult<CurrencyDTO>> GetByID(byte currencyID)
        {
            var handler = _resultFactory.Create<CurrencyDTO>();

            var result = await _currencyRepository.GetByID(currencyID);
            if (result is null)
                return handler.Failure($"an error occured at get currency id");

            if (!result.IsSuccess)
                return handler.Failure(result?.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("The Currency Data is null");

            return handler.Success(_getCurrencyDTOFromCurrency(result.Data));
        }

        public async Task<IResult<CurrencyDTO>> GetByName(string currencyName)
        {
            var handler = _resultFactory.Create<CurrencyDTO>();

            var result = await _currencyRepository.GetByName(currencyName);
            if (result is null)
                return handler.Failure($"an error occured at get currency name");

            if (!result.IsSuccess)
                return handler.Failure(result?.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("The Currency Data is null");

            return handler.Success(_getCurrencyDTOFromCurrency(result.Data));
        }

        public async Task<IResult<IEnumerable<CurrencyDTO>>> GetAll()
        {
            var handler = _resultFactory.Create<IEnumerable<CurrencyDTO>>();
            var result = await _currencyRepository.GetAll();

            if (result is null)
                return handler.Failure("an error occured at get all currencies");

            if (!result.IsSuccess)
                return handler.Failure(result?.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("The Data Is null at get all currencies");

            return handler.Success(result.Data.Select(entity => _getCurrencyDTOFromCurrency(entity)));
        }
    }
}
