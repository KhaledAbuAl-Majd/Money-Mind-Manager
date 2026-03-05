using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Domain.Entities.FinTransaction;
using MoneyMindManager.Shared.DTOs.FinTransaction;

namespace MoneyMindManager.Application.Mappers.Abstractions
{
    public interface IFinTransactionMapper : IMapper<FinTransaction, FinTransactionDTO>
    {

    }
}
