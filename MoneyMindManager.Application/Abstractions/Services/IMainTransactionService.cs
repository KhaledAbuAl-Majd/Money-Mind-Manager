using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Shared.DTOs.MainTransaction;
using MoneyMindManager.Shared.DTOs.Paged_Result_DTOs;

namespace MoneyMindManager.Application.Abstractions.Services
{
    public interface IMainTransactionService
    {
        Task<IResult<MainTransactionDTO>> Get(int transactionID, int currentUserID);
        Task<IResult<PagedResultWithAmountDTO<MainTransactionDTO>>> GetAllPaged(MainTransactionPagedFilterDTO filterDTO, int currentUserID);
        Task<IResult<IEnumerable<MainTransactionDTO>>> GetAll(MainTransactionFilterDTO filterDTO, int currentUserID);
    }
}
