using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Shared.DTOs.MainTransaction;
using MoneyMindManager.Shared.DTOs.Paged_Result_DTOs;

namespace MoneyMindManager.Client.Abstractions.ApiClient
{
    public interface IMainTransactionApiClient
    {
        Task<IResult<MainTransactionDTO>> Get(int transactionID, int currentUserID);
        Task<IResult<PagedResultWithTotal_CurrentDTO<MainTransactionDTO>>> GetAllPaged(MainTransactionPagedFilterDTO filterDTO, int currentUserID);
        Task<IResult<IEnumerable<MainTransactionDTO>>> GetAll(MainTransactionFilterDTO filterDTO, int currentUserID);
    }
}
