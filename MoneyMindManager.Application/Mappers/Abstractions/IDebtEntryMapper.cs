using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Domain.Entities.DebtEntry;
using MoneyMindManager.Shared.DTOs.DebtPayment;

namespace MoneyMindManager.Application.Mappers.Abstractions
{
    public interface IDebtEntryMapper : IMapper<DebtEntry, DebtTransactionDTO>
    {
    }
}
