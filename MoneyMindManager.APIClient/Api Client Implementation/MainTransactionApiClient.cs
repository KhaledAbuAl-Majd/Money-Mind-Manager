using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.MainTransaction;
using MoneyMindManager.Shared.DTOs.MainTransaction;
using MoneyMindManager.Shared.DTOs.Paged_Result_DTOs;

namespace MoneyMindManager.APIClient.Api_Client_Implementation
{
    public class MainTransactionApiClient : IMainTransactionApiClient
    {
        private readonly IMainTransactionService _mainTransactionService;

        public MainTransactionApiClient(IMainTransactionService mainTransactionService)
        {
            this._mainTransactionService = mainTransactionService;
        }

        public async Task<IResult<MainTransactionDTO>> Get(int transactionID, int currentUserID)
        {
            return await _mainTransactionService.Get(transactionID, currentUserID);
        }

        public async Task<IResult<PagedResultWithTotal_CurrentDTO<MainTransactionViewSummary>>> GetAllPaged(MainTransactionPagedFilterDTO filterDTO, int currentUserID)
        {
            return await _mainTransactionService.GetAllPaged(filterDTO, currentUserID);
        }

        public async Task<IResult<IEnumerable<MainTransactionExportSummary>>> GetAll(MainTransactionFilterDTO filterDTO, int currentUserID)
        {
            return await _mainTransactionService.GetAll(filterDTO, currentUserID);
        }
    }
}
