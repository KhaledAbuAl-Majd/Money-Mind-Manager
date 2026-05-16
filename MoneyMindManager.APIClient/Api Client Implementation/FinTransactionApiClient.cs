using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.FinTransaction;
using MoneyMindManager.Core.Paged_Result_DTOs;
using MoneyMindManager.Shared.DTOs.FinTransaction;

namespace MoneyMindManager.APIClient.Api_Client_Implementation
{
    public class FinTransactionApiClient : IFinTransactionApiClient
    {
        private readonly IFinTransactionService _finTransactionService;

        public FinTransactionApiClient(IFinTransactionService finTransactionService)
        {
            this._finTransactionService = finTransactionService;
        }
        public async Task<IResult<FinTransactionDTO>> Add(FinTransactionDTO finTransaction, bool isReturn, int currentUserID)
        {
            return await _finTransactionService.Add(finTransaction, isReturn, currentUserID);
        }
        public async Task<IResult<bool>> Update(FinTransactionDTO finTransaction, int currentUserID)
        {
            return await _finTransactionService.Update(finTransaction, currentUserID);
        }
        public async Task<IResult<bool>> Delete(int transactionID, int currentUserID)
        {
            return await _finTransactionService.Delete(transactionID, currentUserID);
        }

        public async Task<IResult<FinTransactionDTO>> Get(int transactionID, int currentUserID)
        {
            return await _finTransactionService.Get(transactionID, currentUserID);
        }
        public async Task<IResult<PagedResultWithValueDTO<FinTransactionViewSummary>>> GetAllPagedForVoucher(int voucherID, int currentUserID, int pageNumber)
        {
            return await _finTransactionService.GetAllPagedForVoucher(voucherID, currentUserID, pageNumber);
        }
        public async Task<IResult<IEnumerable<FinTransactionExportSummary>>> GetAllForVoucher(int voucherID, int currentUserID)
        {
            return await _finTransactionService.GetAllForVoucher(voucherID, currentUserID);
        }
    }
}
