using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Application.Mappers.Abstractions;
using MoneyMindManager.Application.Mappers.Mappers_Implementaion;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Core.Models.DebtPayment;
using MoneyMindManager.Core.Paged_Result_DTOs;
using MoneyMindManager.Domain.Abstractions.Repositories;
using MoneyMindManager.Shared.DTOs.DebtPayment;

namespace MoneyMindManager.Application.Services.DebtEntry
{
    public class DebtEntryService : IDebtEntryService
    {
        private readonly IResultFactory _resultFactory;
        private readonly IDebtEntryRepository _debtEntryRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly IDebtEntryMapper _debtEntryMapper;
        private readonly IMainTransactionService _mainTransactionService;
        private readonly IMainTransactionMapper _mainTransactionMapper;
        public DebtEntryService(IResultFactory resultFactory, IDebtEntryRepository DebtEntryRepository, IAuthorizationService authorizationService,
            IDebtEntryMapper DebtEntryMapper, IMainTransactionService mainTransactionService, IMainTransactionMapper mainTransactionMapper)
        {
            this._resultFactory = resultFactory;
            this._debtEntryRepository = DebtEntryRepository;
            this._authorizationService = authorizationService;
            this._debtEntryMapper = DebtEntryMapper;
            this._mainTransactionService = mainTransactionService;
            this._mainTransactionMapper = mainTransactionMapper;
        }
        public async Task<IResult<DebtTransactionDTO>> Add(DebtTransactionDTO debtEntry, int currentUserID)
        {
            var handler = _resultFactory.Create<DebtTransactionDTO>();

            if (debtEntry is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.AddUpdateDebt_Payments);

            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية إضافة/تعديل (سندات - معاملات سداد) الديون.");

            debtEntry.CreatedByUserID = currentUserID;
            var result = await _debtEntryRepository.Add(_debtEntryMapper.DTOToEntity(debtEntry));

            if (result is null)
                return handler.Failure("failed to add debt entry!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to add debt payment!");

            var DTOResult = await Get(Convert.ToInt32(result.Data), Convert.ToInt32(currentUserID));

            debtEntry.MainTransactionID = result.Data;
            if (!DTOResult.IsSuccess)
                return handler.Success(debtEntry);

            return handler.Success(DTOResult.Data);
        }
        public async Task<IResult<bool>> Update(DebtTransactionDTO debtDTO, int currentUserID)
        {
            var errorMessage = "failed to update debt entry!";

            var handler = _resultFactory.Create<bool>();

            if (debtDTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.AddUpdateDebt_Payments);

            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية إضافة/تعديل (سندات - معاملات سداد) الديون.");

            var result = await _debtEntryRepository.Update(_debtEntryMapper.DTOToEntity(debtDTO), currentUserID);

            if (result is null)
                return handler.Failure(errorMessage);

            return result;
        }
        public async Task<IResult<bool>> Delete(int transactionID, int currentUserID)
        {
            var errorMessage = "failed to delete debt entry!";

            var handler = _resultFactory.Create<bool>();

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.DeleteDebt_Payments);

            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية حذف (سندات - معاملات سداد) الديون.");

            var result = await _debtEntryRepository.Delete(transactionID, currentUserID);

            if (result is null)
                return handler.Failure(errorMessage);

            return result;
        }
        public async Task<IResult<DebtTransactionDTO>> Get(int transactionID, int currentUserID)
        {
            var handler = _resultFactory.Create<DebtTransactionDTO>();

            var result = await _debtEntryRepository.Get(transactionID, currentUserID);

            if (result is null)
                return handler.Failure("failed to get debt entry!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to get debt entry!");

            var mainTransactionResult = await _mainTransactionService.Get(transactionID, currentUserID);

            if (!mainTransactionResult.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            var mainTransactionEntity = _mainTransactionMapper.DTOToEntity(mainTransactionResult.Data);
            var DTO = _debtEntryMapper.EntityToDTO(new Domain.Entities.DebtEntry.DebtEntry(mainTransactionEntity, Convert.ToInt32(result.Data.DebtID)));

            return handler.Success(DTO);
        }
        public async Task<IResult<PagedResultWithValueDTO<DebtTransactionsViewSummary>>> GetAllPagedForDebt(int debtID, int currentUserID, int pageNumber)
        {
            var handler = _resultFactory.Create<PagedResultWithValueDTO<DebtTransactionsViewSummary>>();

            byte rowsPersPage = 15;
            var result = await _debtEntryRepository.GetAllPagedForDebt(debtID, currentUserID, pageNumber, rowsPersPage);

            if (result is null)
                return handler.Failure("failed to get debt entrys list!");

            return result;
        }
        public async Task<IResult<IEnumerable<DebtTransactionsExportSummary>>> GetAllForDebt(int debtID, int currentUserID)
        {
            var handler = _resultFactory.Create<IEnumerable<DebtTransactionsExportSummary>>();

            var result = await _debtEntryRepository.GetAllForDebt(debtID, currentUserID);

            if (result is null)
                return handler.Failure("failed to get debt entrys list!");

            return result;
        }
    }
}
