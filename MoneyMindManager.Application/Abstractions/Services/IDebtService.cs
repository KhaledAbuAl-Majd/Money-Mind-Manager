using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.Debt;
using MoneyMindManager.Shared.DTOs.Debt;
using MoneyMindManager.Shared.DTOs.Paged_Result_DTOs;

namespace MoneyMindManager.Application.Abstractions.Services
{
    public interface IDebtService
    {
        Task<IResult<DebtDTO>> Add(DebtDTO debt, int currentUserID);
        Task<IResult<DebtUpdateResultDTO>> Update(DebtDTO debt, int currentUserID);
        Task<IResult<bool>> ChangeLockingByID(int debtID, bool isLocked, int currentUserID);
        Task<IResult<bool>> Delete(int debtID, int currentUserID);
        Task<IResult<DebtDTO>> Get(int debtID, int currentUserID);
        Task<IResult<DebtsPagedResultDTO<DebtViewSummary>>> GetAllPaged(DebtPagedFilterDTO DTO, int currentUserID);
        Task<IResult<IEnumerable<DebtExportSummary>>> GetAll(DebtFilterDTO DTO, int currentUserID);
    }
}
