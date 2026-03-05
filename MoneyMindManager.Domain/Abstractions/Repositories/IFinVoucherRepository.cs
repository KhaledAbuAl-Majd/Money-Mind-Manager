using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.FinVoucher;
using MoneyMindManager.Domain.Criteria.FinVoucher;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.Paged_Result_DTOs;

namespace MoneyMindManager.Domain.Abstractions.Repositories
{
    public interface IFinVoucherRepository
    {
        Task<IResult<int?>> Add(FinVoucher voucher);
        Task<IResult<bool>> Update(FinVoucher voucher, int currentUserID);
        Task<IResult<bool>> ChangeLockingByID(int voucherID, bool isLocked, int currentUserID);
        Task<IResult<bool>> Delete(int voucherID, int currentUserID);
        Task<IResult<FinVoucher>> Get(int voucherID, int currentUserID);
        Task<IResult<decimal?>> GetVoucherValueByID(int voucherID, int currentUserID);
        Task<IResult<PagedResultWithTotal_CurrentDTO<FinVoucherViewSummary>>> GetAllPaged(FinVoucherPagedSearchCriteria criteria, int currentUserID);
        Task<IResult<IEnumerable<FinVoucherExportSummary>>> GetAll(FinVoucherSearchCriteria criteria, int currentUserID);
    }
}
