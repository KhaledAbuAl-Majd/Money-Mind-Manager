using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.FinVoucher;
using MoneyMindManager.Shared.DTOs.FinVoucher;
using MoneyMindManager.Shared.DTOs.Paged_Result_DTOs;

namespace MoneyMindManager.Client.Abstractions.ApiClient
{
    public interface IFinVoucherApiClient
    {
        Task<IResult<FinVoucherDTO>> Add(FinVoucherDTO voucher, int currentUserID);
        Task<IResult<bool>> Update(FinVoucherDTO voucher, int currentUserID);
        Task<IResult<bool>> ChangeLockingByID(int voucherID, bool isLocked, int currentUserID);
        Task<IResult<bool>> Delete(int voucherID, int currentUserID);
        Task<IResult<FinVoucherDTO>> Get(int voucherID, int currentUserID);
        Task<IResult<decimal?>> GetVoucherValueByID(int voucherID, int currentUserID);
        Task<IResult<PagedResultWithTotal_CurrentDTO<FinVoucherViewSummary>>> GetAllPaged(FinVoucherPagedFilterDTO DTO, int currentUserID);
        Task<IResult<IEnumerable<FinVoucherExportSummary>>> GetAll(FinVoucherFilterDTO DTO, int currentUserID);
    }
}
