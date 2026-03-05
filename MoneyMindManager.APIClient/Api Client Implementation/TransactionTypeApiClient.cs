using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Shared.DTOs.TransactionTypes;

namespace MoneyMindManager.APIClient.Api_Client_Implementation
{
    public class TransactionTypeApiClient : ITransactionTypeApiClient
    {
        private readonly ITransactionTypeService _transactionTypeService;

        public TransactionTypeApiClient(ITransactionTypeService transactionTypeService)
        {
            this._transactionTypeService = transactionTypeService;
        }

        public async Task<IResult<TransactionTypeDTO>> GetByID(byte transactionTypeID)
        {
            return await _transactionTypeService.GetByID(transactionTypeID);
        }
        public async Task<IResult<TransactionTypeDTO>> GetByName(string transactionName)
        {
            return await _transactionTypeService.GetByName(transactionName);
        }
        public async Task<IResult<IEnumerable<TransactionTypeDTO>>> GetAll()
        {
            return await _transactionTypeService.GetAll();
        }
    }
}
