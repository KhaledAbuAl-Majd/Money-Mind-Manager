using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Application.Mappers.Abstractions;
using MoneyMindManager.Application.Mappers.Mappers_Implementaion;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Core.Models.Debt;
using MoneyMindManager.Domain.Abstractions.Repositories;
using MoneyMindManager.Shared.DTOs.Debt;
using MoneyMindManager.Shared.DTOs.Paged_Result_DTOs;

namespace MoneyMindManager.Application.Services.Debt
{
    public class DebtService : IDebtService
    {
        private readonly IResultFactory _resultFactory;
        private readonly IDebtRepository _debtRepository;
        private readonly IDebtMapper _debtMapper;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMainTransactionService _mainTransactionService;
        private readonly IMainTransactionMapper _mainTransactionMapper;

        public DebtService(IResultFactory resultFactory, IDebtRepository debtRepository, IDebtMapper debtMapper,
            IAuthorizationService authorizationService, IMainTransactionService mainTransactionService, IMainTransactionMapper mainTransactionMapper)
        {
            this._resultFactory = resultFactory;
            this._debtRepository = debtRepository;
            this._debtMapper = debtMapper;
            this._authorizationService = authorizationService;
            this._mainTransactionService = mainTransactionService;
            this._mainTransactionMapper = mainTransactionMapper;
        }
        public async Task<IResult<DebtDTO>> Add(DebtDTO debtDTO, int currentUserID)
        {
            var handler = _resultFactory.Create<DebtDTO>();

            if (debtDTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.AddUpdateDebt_Payments);

            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية إضافة/تعديل (سندات - معاملات سداد) الديون.");


            var result = await _debtRepository.Add(_debtMapper.DTOToEntity(debtDTO));

            if (result is null)
                return handler.Failure("failed to add debt!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data.NewDebtID is null)
                return handler.Failure("failed to add debt!");

            var DTOResult = await Get(Convert.ToInt32(result.Data.NewDebtID), Convert.ToInt32(currentUserID));

            (debtDTO.DebtID, debtDTO.MainTransactionID) = result.Data;
            if (!DTOResult.IsSuccess)
                return handler.Success(debtDTO);

            return handler.Success(DTOResult.Data);
        }
        public async Task<IResult<DebtUpdateResultDTO>> Update(DebtDTO debtDTO, int currentUserID)
        {
            var errorMessage = "failed to update debt!";

            var handler = _resultFactory.Create<DebtUpdateResultDTO>();

            if (debtDTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.AddUpdateDebt_Payments);

            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية إضافة/تعديل (سندات - معاملات سداد) الديون.");

            var result = await _debtRepository.Update(_debtMapper.DTOToEntity(debtDTO), currentUserID);

            if (result is null)
                return handler.Failure(errorMessage);

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            return handler.Success(new DebtUpdateResultDTO(result.Data.UpdateResult, result.Data.RemainingAmount));
        }
        public async Task<IResult<bool>> ChangeLockingByID(int debtID, bool isLocked, int currentUserID)
        {
            var errorMessage = "failed to change debt locking!";

            var handler = _resultFactory.Create<bool>();

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.ChangeDebtsLocking);

            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية غلق/فتح سندات الديون.");

            var result = await _debtRepository.ChangeLockingByID(debtID, isLocked, currentUserID);

            if (result is null)
                return handler.Failure(errorMessage);

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            return handler.Success(result.Data);
        }
        public async Task<IResult<bool>> Delete(int debtID, int currentUserID)
        {
            var errorMessage = "failed to delete debt!";

            var handler = _resultFactory.Create<bool>();

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.DeleteDebt_Payments);

            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية حذف (سندات - معاملات سداد) الديون.");

            var result = await _debtRepository.Delete(debtID, currentUserID);

            if (result is null)
                return handler.Failure(errorMessage);

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            return handler.Success(result.Data);
        }
        public async Task<IResult<DebtDTO>> Get(int debtID, int currentUserID)
        {
            var handler = _resultFactory.Create<DebtDTO>();

            var result = await _debtRepository.Get(debtID, currentUserID);

            if (result is null)
                return handler.Failure("failed to get debt!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to get debt!");

            var mainTransactionResult = await _mainTransactionService.Get(Convert.ToInt32(result.Data.MainTransactionID), currentUserID);

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            var mainTransaction = _mainTransactionMapper.DTOToEntity(mainTransactionResult.Data);

            var debt = new Domain.Entities.Debt(mainTransaction, result.Data.DebtID, result.Data.IsLending,
                result.Data.PersonID, result.Data.PaymentDueDate, result.Data.RemainingAmount);

            return handler.Success(_debtMapper.EntityToDTO(debt));
        }
        public async Task<IResult<DebtsPagedResultDTO<DebtViewSummary>>> GetAllPaged(DebtPagedFilterDTO DTO, int currentUserID)
        {
            var handler = _resultFactory.Create<DebtsPagedResultDTO<DebtViewSummary>>();
            if (DTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var criteria = _debtMapper.ToPagedSearchCriteria(DTO);
            var result = await _debtRepository.GetAllPaged(criteria, currentUserID);

            if (result is null)
                return handler.Failure("failed to get debt list!");

            return result;
        }
        public async Task<IResult<IEnumerable<DebtExportSummary>>> GetAll(DebtFilterDTO DTO, int currentUserID)
        {
            var handler = _resultFactory.Create<IEnumerable<DebtExportSummary>>();
            if (DTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var criteria = _debtMapper.ToSearchCriteria(DTO);
            var result = await _debtRepository.GetAll(criteria, currentUserID);

            if (result is null)
                return handler.Failure("failed to get debt list!");

            return result;
        }
    }
}
