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
using MoneyMindManager.Domain.Entities.DebtPayment;
using MoneyMindManager.Shared.DTOs.DebtPayment;

namespace MoneyMindManager.Application.Services.DeptPayment
{
    public class DebtPaymentService : IDebtPyamentService
    {
        private readonly IResultFactory _resultFactory;
        private readonly IDebtPaymentRepository _debtPaymentRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly IDebtPaymentMapper _debtPaymentMapper;
        private readonly IFinCategoryService _finCategoryService;
        private readonly IMainTransactionService _mainTransactionService;
        private readonly IMainTransactionMapper _mainTransactionMapper;
        public DebtPaymentService(IResultFactory resultFactory, IDebtPaymentRepository DebtPaymentRepository, IAuthorizationService authorizationService,
            IDebtPaymentMapper DebtPaymentMapper, IFinCategoryService finCategoryService, IMainTransactionService mainTransactionService, IMainTransactionMapper mainTransactionMapper)
        {
            this._resultFactory = resultFactory;
            this._debtPaymentRepository = DebtPaymentRepository;
            this._authorizationService = authorizationService;
            this._debtPaymentMapper = DebtPaymentMapper;
            this._finCategoryService = finCategoryService;
            this._mainTransactionService = mainTransactionService;
            this._mainTransactionMapper = mainTransactionMapper;
        }
        public async Task<IResult<DebtPaymentDTO>> Add(DebtPaymentDTO debtPayment, int currentUserID)
        {
            var handler = _resultFactory.Create<DebtPaymentDTO>();

            if (debtPayment is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.AddUpdateDebt_Payments);

            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية إضافة/تعديل (سندات - معاملات سداد) الديون.");

            debtPayment.CreatedByUserID = currentUserID;
            var result = await _debtPaymentRepository.Add(_debtPaymentMapper.DTOToEntity(debtPayment));

            if (result is null)
                return handler.Failure("failed to add debt payment!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to add debt payment!");

            var DTOResult = await Get(Convert.ToInt32(result.Data), Convert.ToInt32(currentUserID));

            debtPayment.MainTransactionID = result.Data;
            if (!DTOResult.IsSuccess)
                return handler.Success(debtPayment);

            return handler.Success(DTOResult.Data);
        }
        public async Task<IResult<bool>> Update(DebtPaymentDTO debtDTO, int currentUserID)
        {
            var errorMessage = "failed to update debt payment!";

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

            var result = await _debtPaymentRepository.Update(_debtPaymentMapper.DTOToEntity(debtDTO), currentUserID);

            if (result is null)
                return handler.Failure(errorMessage);

            return result;
        }
        public async Task<IResult<bool>> Delete(int transactionID, int currentUserID)
        {
            var errorMessage = "failed to delete debt payment!";

            var handler = _resultFactory.Create<bool>();

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.DeleteDebt_Payments);

            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية حذف (سندات - معاملات سداد) الديون.");

            var result = await _debtPaymentRepository.Delete(transactionID, currentUserID);

            if (result is null)
                return handler.Failure(errorMessage);

            return result;
        }
        public async Task<IResult<DebtPaymentDTO>> Get(int transactionID, int currentUserID)
        {
            var handler = _resultFactory.Create<DebtPaymentDTO>();

            var result = await _debtPaymentRepository.Get(transactionID, currentUserID);

            if (result is null)
                return handler.Failure("failed to get debt payment!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to get debt payment!");

            var mainTransactionResult = await _mainTransactionService.Get(transactionID, currentUserID);

            if (!mainTransactionResult.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            var mainTransactionEntity = _mainTransactionMapper.DTOToEntity(mainTransactionResult.Data);
            var DTO = _debtPaymentMapper.EntityToDTO(new DebtPayment(mainTransactionEntity, Convert.ToInt32(result.Data.DebtID)));

            return handler.Success(DTO);
        }
        public async Task<IResult<PagedResultWithValueDTO<DebtTransactionsViewSummary>>> GetAllPagedForDebt(int debtID, int currentUserID, int pageNumber)
        {
            var handler = _resultFactory.Create<PagedResultWithValueDTO<DebtTransactionsViewSummary>>();

            byte rowsPersPage = 15;
            var result = await _debtPaymentRepository.GetAllPagedForDebt(debtID, currentUserID, pageNumber, rowsPersPage);

            if (result is null)
                return handler.Failure("failed to get debt payments list!");

            return result;
        }
        public async Task<IResult<IEnumerable<DebtTransactionsExportSummary>>> GetAllForDebt(int debtID, int currentUserID)
        {
            var handler = _resultFactory.Create<IEnumerable<DebtTransactionsExportSummary>>();

            var result = await _debtPaymentRepository.GetAllForDebt(debtID, currentUserID);

            if (result is null)
                return handler.Failure("failed to get debt payments list!");

            return result;
        }
    }
}
