using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.Debt;
using MoneyMindManager.Shared.DTOs.Debt;
using MoneyMindManager.Shared.DTOs.Paged_Result_DTOs;

namespace MoneyMindManager.APIClient.Api_Client_Implementation
{
    public class DebtApiClient : IDebtApiClient
    {
        private readonly IDebtService _debtService;

        public DebtApiClient(IDebtService debtService)
        {
            this._debtService = debtService;
        }

        public async Task<IResult<DebtDTO>> Add(DebtDTO debt, int currentUserID)
        {
            return await _debtService.Add(debt, currentUserID);
        }
        public async Task<IResult<DebtUpdateResultDTO>> Update(DebtDTO debt, int currentUserID)
        {
            return await _debtService.Update(debt, currentUserID);
        }
        public async Task<IResult<bool>> ChangeLockingByID(int debtID, bool isLocked, int currentUserID)
        {
            return await _debtService.ChangeLockingByID(debtID, isLocked, currentUserID);
        }
        public async Task<IResult<bool>> Delete(int debtID, int currentUserID)
        {
            return await _debtService.Delete(debtID, currentUserID);
        }
        public async Task<IResult<DebtDTO>> Get(int debtID, int currentUserID)
        {
            return await _debtService.Get(debtID, currentUserID);
        }
        public async Task<IResult<DebtsPagedResultDTO<DebtViewSummary>>> GetAllPaged(DebtPagedFilterDTO DTO, int currentUserID)
        {
            return await _debtService.GetAllPaged(DTO, currentUserID);
        }
        public async Task<IResult<IEnumerable<DebtExportSummary>>> GetAll(DebtFilterDTO DTO, int currentUserID)
        {
            return await _debtService.GetAll(DTO, currentUserID);
        }
    }
}
