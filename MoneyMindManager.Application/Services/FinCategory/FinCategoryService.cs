using System;
using System.Linq;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Application.Mappers.Abstractions;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Core.Paged_Result_DTOs;
using MoneyMindManager.Domain.Abstractions.Repositories;
using MoneyMindManager.Domain.Entities.DebtPayment;
using MoneyMindManager.Shared.DTOs;
using MoneyMindManager.Shared.DTOs.IncomeAndExpenseCategory;

namespace MoneyMindManager.Application.Services
{
    public class FinCategoryService : IFinCategoryService
    {
        private readonly IResultFactory _resultFactory;
        private readonly IFinCategoryRepository _finCategoryRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly IFinCategoryMapper _finCategoryMapper;
        private readonly IUserService _userService;

        public FinCategoryService(IResultFactory resultFactory, IFinCategoryRepository finCategoryRepository, IAuthorizationService authorizationService,
            IFinCategoryMapper finCategoryMapper,IUserService userService)
        {
            this._resultFactory = resultFactory;
            this._finCategoryRepository = finCategoryRepository;
            this._authorizationService = authorizationService;
            this._finCategoryMapper = finCategoryMapper;
            this._userService = userService;
        }

        public async Task<IResult<FinCategoryDTO>> Add(FinCategoryDTO categoryDTO, int currentUserID)
        {
            var handler = _resultFactory.Create<FinCategoryDTO>();

            if (categoryDTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.AddUpdateCategory);

            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية إضافة/تعديل فئة.");

            categoryDTO.CreatedByUserID = currentUserID;
            var result = await _finCategoryRepository.Add(_finCategoryMapper.DTOToEntity(categoryDTO));

            if (result is null)
                return handler.Failure("failed to add category!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to add category!");

            var DTOResult = await GetByID(Convert.ToInt32(result.Data), Convert.ToInt32(categoryDTO.CreatedByUserID));

            categoryDTO.CategoryID = result.Data;
            if (!DTOResult.IsSuccess)
                return handler.Success(categoryDTO);

            return handler.Success(DTOResult.Data);
        }
        public async Task<IResult<bool>> Update(FinCategoryDTO categoryDTO, int currentUserID)
        {
            var errorMessage = "failed to update category!";

            var handler = _resultFactory.Create<bool>();

            if (categoryDTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.AddUpdateCategory);

            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية إضافة/تعديل فئة.");
            //

            var DTOResult = await GetByID(Convert.ToInt32(categoryDTO.CategoryID), Convert.ToInt32(categoryDTO.CreatedByUserID));

            if (!DTOResult.IsSuccess)
                return handler.Failure(errorMessage);

            if (DTOResult.Data.IsActive != categoryDTO.IsActive)
            {
                accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.ChangeCategoryActivation);

                if (accessResult is null)
                    return handler.Failure("failed to check permissions!");

                if (!accessResult.IsSuccess)
                    return handler.Failure(accessResult.ErrorMessage);

                if (!accessResult.Data)
                    return handler.Failure("ليس لديك صلاحية تغيير فعالية فئة.");
            }

            var result = await _finCategoryRepository.Update(_finCategoryMapper.DTOToEntity(categoryDTO), currentUserID);

            if (result is null)
                return handler.Failure(errorMessage);

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            return handler.Success(result.Data);
        }
        public async Task<IResult<bool>> Delete(int categoryID, int currentUserID)
        {
            var handler = _resultFactory.Create<bool>();

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.DeleteCategory);

            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية حذف فئة.");

            var result = await _finCategoryRepository.Delete(categoryID, currentUserID);

            if (result is null)
                return handler.Failure("failed to delete category!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            return handler.Success(result.Data);
        }
        public async Task<IResult<FinCategoryDTO>> GetByID(int categoryID, int currentUserID)
        {
            var handler = _resultFactory.Create<FinCategoryDTO>();

            var result = await _finCategoryRepository.GetByID(categoryID, currentUserID);


            if (result is null)
                return handler.Failure("failed to get category!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to get category!");

            var userResult = await _userService.GetByUserID(Convert.ToInt32(result.Data.CreatedByUserID));

            if (!userResult.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            var DTO = _finCategoryMapper.EntityToDTO(result.Data);
            DTO.UserInfo = userResult.Data;

            return handler.Success(DTO);
        }
        public async Task<IResult<FinCategoryDTO>> GetByName(string categoryName, int currentUserID)
        {
            var handler = _resultFactory.Create<FinCategoryDTO>();

            var result = await _finCategoryRepository.GetByName(categoryName, currentUserID);


            if (result is null)
                return handler.Failure("failed to get category!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to get category!");

            var userResult = await _userService.GetByUserID(Convert.ToInt32(result.Data.CreatedByUserID));

            if (!userResult.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            var DTO = _finCategoryMapper.EntityToDTO(result.Data);
            DTO.UserInfo = userResult.Data;

            return handler.Success(DTO);
        }
        public async Task<IResult<bool>> IsExistByName(string categoryName, int currentUserID)
        {
            var handler = _resultFactory.Create<bool>();

            var result = await _finCategoryRepository.IsExistByName(categoryName, currentUserID);

            if (result is null)
                return handler.Failure("failed to check category existense!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            return handler.Success(result.Data);
        }
        public async Task<IResult<PagedResultDTO<FinCategoryDTO>>> GetAllForSelectOne(FinCategorySelectPagedFilterDTO DTO, int currentUserID)
        {
            var handler = _resultFactory.Create<PagedResultDTO<FinCategoryDTO>>();
            if (DTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var criteria = _finCategoryMapper.ToSelectPagedCriteria(DTO);
            criteria.RowsPerPage = 15;
            var result = await _finCategoryRepository.GetAllForSelectOne(criteria, currentUserID);

            if (result is null)
                return handler.Failure("failed to get categoies list!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to get categoies list!");

            var returnResult = new PagedResultDTO<FinCategoryDTO>(result.Data.Data.Select(entity => _finCategoryMapper.EntityToDTO(entity)).ToList(),
                result.Data.TotalPages, result.Data.TotalRecords);

            return handler.Success(returnResult);
        }
        public async Task<IResult<PagedResultDTO<FinCategoryDTO>>> GetAll(FinCategoryPagedFilterDTO DTO, int currentUserID)
        {
            var handler = _resultFactory.Create<PagedResultDTO<FinCategoryDTO>>();
            if (DTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var criteria = _finCategoryMapper.ToPagedCriteria(DTO);
            criteria.RowsPerPage = 15;
            var result = await _finCategoryRepository.GetAll(criteria, currentUserID);

            if (result is null)
                return handler.Failure("failed to get categoies list!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to get categoies list!");

            var returnResult = new PagedResultDTO<FinCategoryDTO>(result.Data.Data.Select(entity => _finCategoryMapper.EntityToDTO(entity)).ToList(),
                result.Data.TotalPages, result.Data.TotalRecords);

            return handler.Success(returnResult);
        }
        public async Task<IResult<bool>> IsExceedMonthlyBudget(BudgetCheckDTO DTO, int currentUserID)
        {
            var handler = _resultFactory.Create<bool>();

            if (DTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var result = await _finCategoryRepository.IsExceedMonthlyBudget(_finCategoryMapper.ToBudgetCriteria(DTO), currentUserID);

            if (result is null)
                return handler.Failure("failed to check Mohthly budget!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            return handler.Success(result.Data);
        }
    }
}
