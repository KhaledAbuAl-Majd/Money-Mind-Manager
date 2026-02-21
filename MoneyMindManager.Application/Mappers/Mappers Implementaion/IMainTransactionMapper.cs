using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Domain.Criteria;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.MainTransaction;

namespace MoneyMindManager.Application.Mappers.Mappers_Implementaion
{
    public interface IMainTransactionMapper : IMapper<MainTransaction, MainTransactionDTO>
    {
        MainTransactionSearchCriteria MainTransactionFilterDTOToMainTransactionSearchCriteria(MainTransactionFilterDTO filterDTO);
        MainTransactionPagedSearchCriteria MainTransactionPagedFilterDTOToMainTransactionPagedSearchCriteria(MainTransactionPagedFilterDTO filterDTO);
    }
}
