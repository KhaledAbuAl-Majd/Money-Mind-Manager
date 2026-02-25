using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Domain.Criteria.Debt;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.Debt;

namespace MoneyMindManager.Application.Mappers.Abstractions
{
    public interface IDebtMapper : IMapper<Debt, DebtDTO>
    {
        DebtSearchCriteria ToSearchCriteria(DebtFilterDTO DTO);
        DebtPagedSearchCriteria ToPagedSearchCriteria(DebtPagedFilterDTO DTO);
    }
}
