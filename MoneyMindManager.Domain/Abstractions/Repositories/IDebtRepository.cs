using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.Debt;
using MoneyMindManager.Domain.Criteria.Debt;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.Paged_Result_DTOs;

namespace MoneyMindManager.Domain.Abstractions.Repositories
{
    public interface IDebtRepository
    {
        Task<IResult<(int? NewDebtID, int? NewDebtTransactionID)>> Add(Debt debt);
        Task<IResult<(bool UpdateResult, decimal RemainingAmount)>> Update(Debt debt, int currentUserID);
        Task<IResult<bool>> ChangeLockingByID(int debtID, bool isLocked, int currentUserID);
        Task<IResult<bool>> Delete(int debtID, int currentUserID);
        Task<IResult<Debt>> Get(int debtID, int currentUserID);
        Task<IResult<DebtsPagedResultDTO<DebtViewSummary>>> GetAllPaged(DebtPagedSearchCriteria criteria, int currentUserID);
        Task<IResult<IEnumerable<DebtExportSummary>>> GetAll(DebtSearchCriteria criteria, int currentUserID);
    }
}
