using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Application.Mappers.Abstractions;
using MoneyMindManager.Application.Mappers.Mappers_Implementaion;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Core.Models.FinTransaction;
using MoneyMindManager.Core.Paged_Result_DTOs;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Entities.DebtPayment;
using MoneyMindManager.Shared.DTOs.FinTransaction;
using MoneyMindManager.Shared.DTOs.IncomeAndExpenseCategory;

namespace MoneyMindManager.Application.Services.FinTransaction
{
    public class FinTransactionService : IFinTransactionService
    {
        private readonly IResultFactory _resultFactory;
        private readonly IFinTransactionRepository _finTransactionRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly IFinTransactionMapper _finTransactionMapper;
        private readonly IFinCategoryService _finCategoryService;
        private readonly IMainTransactionService _mainTransactionService;
        private readonly IMainTransactionMapper _mainTransactionMapper;
        public FinTransactionService(IResultFactory resultFactory, IFinTransactionRepository finTransactionRepository, IAuthorizationService authorizationService,
            IFinTransactionMapper finTransactionMapper, IFinCategoryService finCategoryService, IMainTransactionService mainTransactionService, IMainTransactionMapper mainTransactionMapper)
        {
            this._resultFactory = resultFactory;
            this._finTransactionRepository = finTransactionRepository;
            this._authorizationService = authorizationService;
            this._finTransactionMapper = finTransactionMapper;
            this._finCategoryService = finCategoryService;
            this._mainTransactionService = mainTransactionService;
            this._mainTransactionMapper = mainTransactionMapper;
        }
        public async Task<IResult<FinTransactionDTO>> Add(FinTransactionDTO finTransaction, bool isReturn, int currentUserID)
        {
            var handler = _resultFactory.Create<FinTransactionDTO>();

            if (finTransaction is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.AddUpdateIETVoucher_Transactions);

            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية إضافة/تعديل مستندات - معاملات (واردات - مصروفات - مرتجعات مصروفات)");


            var isExeedResult = await _finCategoryService.IsExceedMonthlyBudget(new BudgetCheckDTO(Convert.ToInt32(finTransaction.CategoryID),
                finTransaction.MainTransactionID, finTransaction.Amount, finTransaction.TransactionDate, isReturn), currentUserID);

            if (!isExeedResult.IsSuccess)
                return handler.Failure("failed to check monthly budget exeed!");

            //

            if (isExeedResult.Data)
            {
                accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.ExceedsCategoryBudget);

                if (accessResult is null)
                    return handler.Failure("failed to check permissions!");

                if (!accessResult.IsSuccess)
                    return handler.Failure(accessResult.ErrorMessage);

                if (!accessResult.Data)
                    return handler.Failure("ليس لديك صلاحية تخطي الميزانية الشهرية لفئات المصروفات.");
            }

            //
            finTransaction.CreatedByUserID = currentUserID;
            var result = await _finTransactionRepository.Add(_finTransactionMapper.DTOToEntity(finTransaction));

            if (result is null)
                return handler.Failure("failed to add transaction!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to add transaction!");

            var DTOResult = await Get(Convert.ToInt32(result.Data), Convert.ToInt32(currentUserID));

            finTransaction.MainTransactionID = result.Data;
            if (!DTOResult.IsSuccess)
                return handler.Success(finTransaction);

            return handler.Success(DTOResult.Data);
        }
        public async Task<IResult<bool>> Update(FinTransactionDTO finTransaction, int currentUserID)
        {
            var errorMessage = "failed to update Transaction!";

            var handler = _resultFactory.Create<bool>();

            if (finTransaction is null)
                return handler.Failure("البيانات المرسلة غير صالحة");


            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.AddUpdateIETVoucher_Transactions);

            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية إضافة/تعديل مستندات - معاملات (واردات - مصروفات - مرتجعات مصروفات)");

            var result = await _finTransactionRepository.Update(_finTransactionMapper.DTOToEntity(finTransaction), currentUserID);

            if (result is null)
                return handler.Failure(errorMessage);

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            return handler.Success(result.Data);
        }
        public async Task<IResult<bool>> Delete(int transactionID, int currentUserID)
        {
            var errorMessage = "failed to delete Transaction!";

            var handler = _resultFactory.Create<bool>();


            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.DeleteIETVoucher_Transactions);

            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية حذف مستندات - معاملات (واردات - مصروفات - مرتجعات مصروفات)");

            var result = await _finTransactionRepository.Delete(transactionID, currentUserID);

            if (result is null)
                return handler.Failure(errorMessage);

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            return handler.Success(result.Data);
        }
        public async Task<IResult<FinTransactionDTO>> Get(int transactionID, int currentUserID)
        {
            var handler = _resultFactory.Create<FinTransactionDTO>();

            var result = await _finTransactionRepository.Get(transactionID, currentUserID);

            if (result is null)
                return handler.Failure("failed to get transaction!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to get transaction!");

            var mainTransactionResult = await _mainTransactionService.Get(Convert.ToInt32(result.Data.TransactionID), currentUserID);

            if (!mainTransactionResult.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            var mainTransactionDTO = _mainTransactionMapper.DTOToEntity(mainTransactionResult.Data);
            var DTO = _finTransactionMapper.EntityToDTO(new Domain.Entities.FinTransaction.FinTransaction(mainTransactionDTO,
                Convert.ToInt32(result.Data.VoucherID), Convert.ToInt32(result.Data.CategoryID)));

            var categoryResult = await _finCategoryService.GetByID(Convert.ToInt32(DTO.CategoryID), currentUserID);
            if(!categoryResult.IsSuccess)
                return handler.Failure(categoryResult.ErrorMessage);

            DTO.CategoryInfo = categoryResult.Data;

            return handler.Success(DTO);
        }
        public async Task<IResult<PagedResultWithValueDTO<FinTransactionViewSummary>>> GetAllPagedForVoucher(int vouceherID, int currentUserID, int pageNumber)
        {
            var handler = _resultFactory.Create<PagedResultWithValueDTO<FinTransactionViewSummary>>();

            byte rowsPersPage = 15;
            var result = await _finTransactionRepository.GetAllPagedForVoucher(vouceherID, currentUserID, pageNumber, rowsPersPage);

            if (result is null)
                return handler.Failure("failed to get transactions list!");

            return result;
        }
        public async Task<IResult<IEnumerable<FinTransactionExportSummary>>> GetAllForVoucher(int voucherID, int currentUserID)
        {
            var handler = _resultFactory.Create<IEnumerable<FinTransactionExportSummary>>();

            var result = await _finTransactionRepository.GetAllForVoucher(voucherID, currentUserID);

            if (result is null)
                return handler.Failure("failed to get transactions list!");

            return result;
        }
    }
}
