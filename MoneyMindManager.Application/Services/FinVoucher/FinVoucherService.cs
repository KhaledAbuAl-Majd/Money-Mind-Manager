using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Application.Mappers.Abstractions;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Core.Models.FinVoucher;
using MoneyMindManager.Domain.Abstractions.Repositories;
using MoneyMindManager.Domain.Entities.DebtPayment;
using MoneyMindManager.Shared.DTOs.FinVoucher;
using MoneyMindManager.Shared.DTOs.Paged_Result_DTOs;

namespace MoneyMindManager.Application.Services.FinVoucher
{
    public class FinVoucherService : IFinVoucherService
    {
        private readonly IResultFactory _resultFactory;
        private readonly IFinVoucherRepository _finVoucherRepository;
        private readonly IFinVoucherMapper _finVoucherMapper;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserService _userService;

        public FinVoucherService(IResultFactory resultFactory, IFinVoucherRepository finVoucherRepository, IFinVoucherMapper finVoucherMapper,
            IAuthorizationService authorizationService, IUserService userService)
        {
            this._resultFactory = resultFactory;
            this._finVoucherRepository = finVoucherRepository;
            this._finVoucherMapper = finVoucherMapper;
            this._authorizationService = authorizationService;
            this._userService = userService;
        }
        public async Task<IResult<FinVoucherDTO>> Add(FinVoucherDTO voucherDTO, int currentUserID)
        {
            var handler = _resultFactory.Create<FinVoucherDTO>();

            if (voucherDTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.AddUpdateIETVoucher_Transactions);

            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية إضافة/تعديل مستندات - معاملات (واردات - مصروفات - مرتجعات مصروفات)");

            voucherDTO.CreatedByUserID = currentUserID;
            var result = await _finVoucherRepository.Add(_finVoucherMapper.DTOToEntity(voucherDTO));

            if (result is null)
                return handler.Failure("failed to add voucher!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to add voucher!");

            var DTOResult = await Get(Convert.ToInt32(result.Data), Convert.ToInt32(currentUserID));

            voucherDTO.VoucherID = result.Data;
            if (!DTOResult.IsSuccess)
                return handler.Success(voucherDTO);

            return handler.Success(DTOResult.Data);
        }
        public async Task<IResult<bool>> Update(FinVoucherDTO voucherDTO, int currentUserID)
        {
            var errorMessage = "failed to update voucher!";

            var handler = _resultFactory.Create<bool>();

            if (voucherDTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.AddUpdateIETVoucher_Transactions);

            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية إضافة/تعديل مستندات - معاملات (واردات - مصروفات - مرتجعات مصروفات)");

            var result = await _finVoucherRepository.Update(_finVoucherMapper.DTOToEntity(voucherDTO), currentUserID);

            if (result is null)
                return handler.Failure(errorMessage);

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            return handler.Success(result.Data);
        }
        public async Task<IResult<bool>> ChangeLockingByID(int voucherID, bool isLocked, int currentUserID)
        {
            var errorMessage = "failed to change voucher locking!";

            var handler = _resultFactory.Create<bool>();

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.ChangeIETVoucherLocking);

            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية غلق/فتح مستندات - معاملات (واردات - مصروفات - مرتجعات مصروفات)");

            var result = await _finVoucherRepository.ChangeLockingByID(voucherID, isLocked, currentUserID);

            if (result is null)
                return handler.Failure(errorMessage);

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            return handler.Success(result.Data);
        }
        public async Task<IResult<bool>> Delete(int voucherID, int currentUserID)
        {
            var errorMessage = "failed to delete voucher!";

            var handler = _resultFactory.Create<bool>();

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.DeleteIETVoucher_Transactions);

            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية حذف مستندات - معاملات (واردات - مصروفات - مرتجعات مصروفات)");

            var result = await _finVoucherRepository.Delete(voucherID, currentUserID);

            if (result is null)
                return handler.Failure(errorMessage);

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            return handler.Success(result.Data);
        }
        public async Task<IResult<FinVoucherDTO>> Get(int voucherID, int currentUserID)
        {
            var handler = _resultFactory.Create<FinVoucherDTO>();

            var result = await _finVoucherRepository.Get(voucherID, currentUserID);

            if (result is null)
                return handler.Failure("failed to get voucher!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to get voucher!");

            var userResult = await _userService.GetByUserID(Convert.ToInt32(result.Data.CreatedByUserID));

            if (!userResult.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            var DTO = _finVoucherMapper.EntityToDTO(result.Data);
            DTO.UserInfo = userResult.Data;

            return handler.Success(DTO);
        }
        public async Task<IResult<decimal?>> GetVoucherValueByID(int voucherID, int currentUserID)
        {
            var handler = _resultFactory.Create<decimal?>();

            var result = await _finVoucherRepository.GetVoucherValueByID(voucherID, currentUserID);

            if (result is null)
                return handler.Failure("failed to get voucher value!");

            return result;
        }
        public async Task<IResult<PagedResultWithTotal_CurrentDTO<FinVoucherViewSummary>>> GetAllPaged(FinVoucherPagedFilterDTO DTO, int currentUserID)
        {
            var handler = _resultFactory.Create<PagedResultWithTotal_CurrentDTO<FinVoucherViewSummary>>();
            if (DTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var criteria = _finVoucherMapper.ToPagedSearchCriteria(DTO);
            criteria.RowsPerPage = 15;
            var result = await _finVoucherRepository.GetAllPaged(criteria, currentUserID);

            if (result is null)
                return handler.Failure("failed to get voucher list!");

            return result;
        }
        public async Task<IResult<IEnumerable<FinVoucherExportSummary>>> GetAll(FinVoucherFilterDTO DTO, int currentUserID)
        {
            var handler = _resultFactory.Create<IEnumerable<FinVoucherExportSummary>>();
            if (DTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var criteria = _finVoucherMapper.ToSearchCriteria(DTO);
            var result = await _finVoucherRepository.GetAll(criteria, currentUserID);

            if (result is null)
                return handler.Failure("failed to get voucher list!");

            return result;
        }
    }
}
