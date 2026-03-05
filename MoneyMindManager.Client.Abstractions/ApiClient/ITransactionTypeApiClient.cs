using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Shared.DTOs.TransactionTypes;

namespace MoneyMindManager.Client.Abstractions.ApiClient
{
    public interface ITransactionTypeApiClient
    {
        Task<IResult<TransactionTypeDTO>> GetByID(byte transactionTypeID);
        Task<IResult<TransactionTypeDTO>> GetByName(string transactionName);
        Task<IResult<IEnumerable<TransactionTypeDTO>>> GetAll();
    }
}
