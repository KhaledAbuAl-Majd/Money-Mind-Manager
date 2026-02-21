using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Domain.Criteria;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.Paged_Result_DTOs;

namespace MoneyMindManager.Domain.Abstractions.Repositories.Reports
{
    public interface IMainTransactionRepository
    {
        Task<IResult<MainTransaction>> Get(int transactionID, int currentUserID);
        Task<IResult<PagedResultWithAmountDTO<MainTransaction>>> GetAllPaged(MainTransactionPagedSearchCriteria mainTransactionPagedSearchCriteria, int currentUserID);
        Task<IResult<IEnumerable<MainTransaction>>> GetAll(MainTransactionSearchCriteria mainTransactionSearchCriteria, int currentUserID);
    }
}
