using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Domain.Criteria;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.MainTransaction;

namespace MoneyMindManager.Application.Mappers.Mappers_Implementaion
{
    public interface IMainTransactionMapper : IMapper<MainTransaction, MainTransactionDTO>
    {
        MainTransactionSearchCriteria ToSearchCriteria(MainTransactionFilterDTO filterDTO);
        MainTransactionPagedSearchCriteria ToPagedSearchCriteria(MainTransactionPagedFilterDTO filterDTO);
    }
}
