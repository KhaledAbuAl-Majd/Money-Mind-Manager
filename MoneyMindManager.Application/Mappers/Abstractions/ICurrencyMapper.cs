using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.Currency;

namespace MoneyMindManager.Application.Abstractions.Mappers
{
    public interface ICurrencyMapper : IMapper<Currency,CurrencyDTO>
    {
    }
}
