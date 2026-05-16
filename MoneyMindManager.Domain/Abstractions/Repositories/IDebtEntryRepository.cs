using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.DebtPayment;
using MoneyMindManager.Core.Paged_Result_DTOs;
using MoneyMindManager.Domain.Entities.DebtEntry;

namespace MoneyMindManager.Domain.Abstractions.Repositories
{
    public interface IDebtEntryRepository
    {
        Task<IResult<int?>> Add(DebtEntry debtEntry);
        Task<IResult<bool>> Update(DebtEntry debtEntry, int currentUserID);
        Task<IResult<bool>> Delete(int transactionID, int currentUserID);
        Task<IResult<DebtEntryShort>> Get(int transactionID, int currentUserID);
        Task<IResult<PagedResultWithValueDTO<DebtTransactionsViewSummary>>> GetAllPagedForDebt(int debtID, int currentUserID, int pageNumber, byte rowsPerPage);
        Task<IResult<IEnumerable<DebtTransactionsExportSummary>>> GetAllForDebt(int debtID, int currentUserID);
    }
}
