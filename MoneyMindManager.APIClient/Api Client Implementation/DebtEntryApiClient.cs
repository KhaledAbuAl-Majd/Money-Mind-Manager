using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.DebtPayment;
using MoneyMindManager.Core.Paged_Result_DTOs;
using MoneyMindManager.Shared.DTOs.DebtPayment;

namespace MoneyMindManager.APIClient.Api_Client_Implementation
{
    public class DebtEntryApiClient : IDebtEntryApiClient
    {
        private readonly IDebtEntryService _debtEntryService;
        public DebtEntryApiClient(IDebtEntryService debtEntryService)
        {
            this._debtEntryService = debtEntryService;
        }

        public async Task<IResult<DebtTransactionDTO>> Add(DebtTransactionDTO debtPayment, int currentUserID)
        {
            return await _debtEntryService.Add(debtPayment, currentUserID);
        }
        public async Task<IResult<bool>> Update(DebtTransactionDTO debtPayment, int currentUserID)
        {
            return await _debtEntryService.Update(debtPayment, currentUserID);
        }
        public async Task<IResult<bool>> Delete(int transactionID, int currentUserID)
        {
            return await _debtEntryService.Delete(transactionID, currentUserID);
        }
        public async Task<IResult<DebtTransactionDTO>> Get(int transactionID, int currentUserID)
        {
            return await _debtEntryService.Get(transactionID, currentUserID);
        }
        public async Task<IResult<PagedResultWithValueDTO<DebtTransactionsViewSummary>>> GetAllPagedForDebt(int debtID, int currentUserID, int pageNumber)
        {
            return await _debtEntryService.GetAllPagedForDebt(debtID, currentUserID, pageNumber);
        }
        public async Task<IResult<IEnumerable<DebtTransactionsExportSummary>>> GetAllForDebt(int debtID, int currentUserID)
        {
            return await _debtEntryService.GetAllForDebt(debtID, currentUserID);
        }
    }
}
