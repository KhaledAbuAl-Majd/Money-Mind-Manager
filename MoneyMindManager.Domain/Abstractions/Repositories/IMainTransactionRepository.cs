using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.MainTransaction;
using MoneyMindManager.Domain.Criteria;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.Paged_Result_DTOs;

namespace MoneyMindManager.Domain.Abstractions.Repositories.Reports
{
    public interface IMainTransactionRepository
    {
        Task<IResult<MainTransaction>> Get(int transactionID, int currentUserID);
        Task<IResult<PagedResultWithTotal_CurrentDTO<MainTransactionViewSummary>>> GetAllPaged(MainTransactionPagedSearchCriteria mainTransactionPagedSearchCriteria, int currentUserID);
        Task<IResult<IEnumerable<MainTransactionExportSummary>>> GetAll(MainTransactionSearchCriteria mainTransactionSearchCriteria, int currentUserID);
    }
}
