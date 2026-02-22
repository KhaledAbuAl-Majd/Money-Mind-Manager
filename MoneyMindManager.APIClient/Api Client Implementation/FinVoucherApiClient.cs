using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.FinVoucher;
using MoneyMindManager.Shared.DTOs.FinVoucher;
using MoneyMindManager.Shared.DTOs.Paged_Result_DTOs;

namespace MoneyMindManager.APIClient.Api_Client_Implementation
{
    public class FinVoucherApiClient : IFinVoucherApiClient
    {
        private readonly IFinVoucherService _finVoucherService;

        public FinVoucherApiClient(IFinVoucherService finVoucherService)
        {
            this._finVoucherService = finVoucherService;
        }
        public async Task<IResult<FinVoucherDTO>> Add(FinVoucherDTO voucher, int currentUserID)
        {
            return await _finVoucherService.Add(voucher, currentUserID);
        }
        public async Task<IResult<bool>> Update(FinVoucherDTO voucher, int currentUserID)
        {
            return await _finVoucherService.Update(voucher, currentUserID);
        }
        public async Task<IResult<bool>> ChangeLockingByID(int voucherID, bool isLocked, int currentUserID)
        {
            return await _finVoucherService.ChangeLockingByID(voucherID, isLocked, currentUserID);
        }
        public async Task<IResult<bool>> Delete(int voucherID, int currentUserID)
        {
            return await _finVoucherService.Delete(voucherID, currentUserID);
        }
        public async Task<IResult<FinVoucherDTO>> Get(int voucherID, int currentUserID)
        {
            return await _finVoucherService.Get(voucherID, currentUserID);
        }
        public async Task<IResult<decimal?>> GetVoucherValueByID(int voucherID, int currentUserID)
        {
            return await _finVoucherService.GetVoucherValueByID(voucherID, currentUserID);
        }
        public async Task<IResult<PagedResultWithTotal_CurrentDTO<FinVoucherViewSummary>>> GetAllPaged(FinVoucherPagedFilterDTO DTO, int currentUserID)
        {
            return await _finVoucherService.GetAllPaged(DTO, currentUserID);
        }
        public async Task<IResult<IEnumerable<FinVoucherExportSummary>>> GetAll(FinVoucherFilterDTO DTO, int currentUserID)
        {
            return await _finVoucherService.GetAll(DTO, currentUserID);
        }
    }
}
