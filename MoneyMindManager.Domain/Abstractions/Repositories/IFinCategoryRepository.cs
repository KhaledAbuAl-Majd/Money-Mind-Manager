using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Paged_Result_DTOs;
using MoneyMindManager.Domain.Criteria.IncomeAndExpenseCategory;
using MoneyMindManager.Domain.Entities;

namespace MoneyMindManager.Domain.Abstractions.Repositories
{
    public interface IFinCategoryRepository
    {
        Task<IResult<int?>> Add(FinCategory category);
        Task<IResult<bool>> Update(FinCategory category, int currentUserID);
        Task<IResult<bool>> Delete(int categoryID, int currentUserID);
        Task<IResult<FinCategory>> GetByID(int categoryID, int currentUserID);
        Task<IResult<FinCategory>> GetByName(string categoryName, int currentUserID);
        Task<IResult<bool>> IsExistByName(string categoryName, int currentUserID);
        Task<IResult<PagedResultDTO<FinCategory>>> GetAllForSelectOne(FinCategorySelectPagedSearchCriteria criteria, int currentUserID);
        Task<IResult<PagedResultDTO<FinCategory>>> GetAll(FinCategoryPagedSearchCriteria criteria, int currentUserID);
        Task<IResult<bool>> IsExceedMonthlyBudget(BudgetCheckCriteria budgetCheckCriteria, int currentUserID);
    }
}
