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
    public class DebtPaymentApiClient : IDebtPaymentApiClient
    {
        private readonly IDebtPyamentService _debtPyamentService;
        public DebtPaymentApiClient(IDebtPyamentService debtPyamentService)
        {
            this._debtPyamentService = debtPyamentService;
        }

        public async Task<IResult<DebtPaymentDTO>> Add(DebtPaymentDTO debtPayment, int currentUserID)
        {
            return await _debtPyamentService.Add(debtPayment, currentUserID);
        }
        public async Task<IResult<bool>> Update(DebtPaymentDTO debtPayment, int currentUserID)
        {
            return await _debtPyamentService.Update(debtPayment, currentUserID);
        }
        public async Task<IResult<bool>> Delete(int transactionID, int currentUserID)
        {
            return await _debtPyamentService.Delete(transactionID, currentUserID);
        }
        public async Task<IResult<DebtPaymentDTO>> Get(int transactionID, int currentUserID)
        {
            return await _debtPyamentService.Get(transactionID, currentUserID);
        }
        public async Task<IResult<PagedResultWithValueDTO<DebtTransactionsViewSummary>>> GetAllPagedForDebt(int debtID, int currentUserID, int pageNumber)
        {
            return await _debtPyamentService.GetAllPagedForDebt(debtID, currentUserID, pageNumber);
        }
        public async Task<IResult<IEnumerable<DebtTransactionsExportSummary>>> GetAllForDebt(int debtID, int currentUserID)
        {
            return await _debtPyamentService.GetAllForDebt(debtID, currentUserID);
        }
    }
}
