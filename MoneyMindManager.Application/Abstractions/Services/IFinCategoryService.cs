using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.FinCategory;
using MoneyMindManager.Core.Paged_Result_DTOs;
using MoneyMindManager.Shared.DTOs;
using MoneyMindManager.Shared.DTOs.IncomeAndExpenseCategory;

namespace MoneyMindManager.Application.Abstractions.Services
{
    public interface IFinCategoryService
    {
        Task<IResult<FinCategoryDTO>> Add(FinCategoryDTO category, int currentUserID);
        Task<IResult<bool>> Update(FinCategoryDTO category, int currentUserID);
        Task<IResult<bool>> Delete(int categoryID, int currentUserID);
        Task<IResult<FinCategoryDTO>> GetByID(int categoryID, int currentUserID);
        Task<IResult<FinCategoryDTO>> GetByName(string categoryName, int currentUserID);
        Task<IResult<bool>> IsExistByName(string categoryName, int currentUserID);
        Task<IResult<PagedResultDTO<FinCategorySelectSummary>>> GetAllForSelectOne(FinCategorySelectPagedFilterDTO DTO, int currentUserID);
        Task<IResult<PagedResultDTO<FinCategoryFullSummary>>> GetAll(FinCategoryPagedFilterDTO DTO, int currentUserID);
        Task<IResult<bool>> IsExceedMonthlyBudget(BudgetCheckDTO DTO, int currentUserID);
    }
}
