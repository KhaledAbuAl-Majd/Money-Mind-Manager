using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.Currency;

namespace MoneyMindManager.Application.Mappers.Mappers_Implementaion
{
    public class CurrencyMapper : ICurrencyMapper
    {
        public Currency DTOToEntity(CurrencyDTO currencyDTO)
        {
            return new Currency(currencyDTO.CurrencyID, currencyDTO.CurrencyName, currencyDTO.CurrencySymbol);
        }

        public CurrencyDTO EntityToDTO(Currency currency)
        {
            return new CurrencyDTO(currency.CurrencyID, currency.CurrencyName, currency.CurrencySymbol);
        }
    }
}
