using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.TransactionTypes;

namespace MoneyMindManager.Application.Mappers.Abstractions
{
    public interface ITransactionTypeMapper : IMapper<TransactionType, TransactionTypeDTO>
    {
    }
}
