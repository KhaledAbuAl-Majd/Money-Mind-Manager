using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Paged_Result_DTOs;
using MoneyMindManager.Shared.DTOs;
using MoneyMindManager.Shared.DTOs.IncomeAndExpenseCategory;

namespace MoneyMindManager.APIClient.Api_Client_Implementation
{
    internal class FinCategoryApiclient : IFinCategoryApiClient
    {
        private readonly IFinCategoryService _finCategoryService;

        public FinCategoryApiclient(IFinCategoryService finCategoryService)
        {
            this._finCategoryService = finCategoryService;
        }
        public async Task<IResult<FinCategoryDTO>> Add(FinCategoryDTO category, int currentUserID)
        {
            return await _finCategoryService.Add(category, currentUserID);
        }
        public async Task<IResult<bool>> Update(FinCategoryDTO category, int currentUserID)
        {
            return await _finCategoryService.Update(category, currentUserID);
        }
        public async Task<IResult<bool>> Delete(int categoryID, int currentUserID)
        {
            return await _finCategoryService.Delete(categoryID, currentUserID);
        }
        public async Task<IResult<FinCategoryDTO>> GetByID(int categoryID, int currentUserID)
        {
            return await _finCategoryService.GetByID(categoryID, currentUserID);
        }
        public async Task<IResult<FinCategoryDTO>> GetByName(string categoryName, int currentUserID)
        {
            return await _finCategoryService.GetByName(categoryName, currentUserID);
        }
        public async Task<IResult<bool>> IsExistByName(string categoryName, int currentUserID)
        {
            return await _finCategoryService.IsExistByName(categoryName, currentUserID);
        }
        public async Task<IResult<PagedResultDTO<FinCategoryDTO>>> GetAllForSelectOne(FinCategorySelectPagedFilterDTO DTO, int currentUserID)
        {
            return await _finCategoryService.GetAllForSelectOne(DTO, currentUserID);
        }
        public async Task<IResult<PagedResultDTO<FinCategoryDTO>>> GetAll(FinCategoryPagedFilterDTO DTO, int currentUserID)
        {
            return await _finCategoryService.GetAll(DTO, currentUserID);
        }
        public async Task<IResult<bool>> IsExceedMonthlyBudget(BudgetCheckDTO DTO, int currentUserID)
        {
            return await _finCategoryService.IsExceedMonthlyBudget(DTO, currentUserID);
        }
    }
}
