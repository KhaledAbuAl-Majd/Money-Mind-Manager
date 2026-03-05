using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Domain.Criteria.IncomeAndExpenseCategory;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs;
using MoneyMindManager.Shared.DTOs.IncomeAndExpenseCategory;

namespace MoneyMindManager.Application.Mappers.Abstractions
{
    public interface IFinCategoryMapper : IMapper<FinCategory, FinCategoryDTO>
    {
        FinCategoryPagedSearchCriteria ToPagedCriteria(FinCategoryPagedFilterDTO DTO);
        FinCategorySelectPagedSearchCriteria ToSelectPagedCriteria(FinCategorySelectPagedFilterDTO DTO);
        BudgetCheckCriteria ToBudgetCriteria(BudgetCheckDTO DTO);
    }
}
