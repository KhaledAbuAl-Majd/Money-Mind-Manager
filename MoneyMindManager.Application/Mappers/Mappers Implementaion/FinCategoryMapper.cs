using MoneyMindManager.Application.Mappers.Abstractions;
using MoneyMindManager.Domain.Criteria.IncomeAndExpenseCategory;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs;
using MoneyMindManager.Shared.DTOs.IncomeAndExpenseCategory;

namespace MoneyMindManager.Application.Mappers.Mappers_Implementaion
{
    public class FinCategoryMapper : IFinCategoryMapper
    {
        public FinCategory DTOToEntity(FinCategoryDTO DTO)
        {
            if (DTO is null)
                return null;

            return new FinCategory()
            {
                CategoryHierarchical = DTO.CategoryHierarchical,
                AccountID = DTO.AccountID,
                CategoryID = DTO.CategoryID,
                CategoryName = DTO.CategoryName,
                CreatedByUserID = DTO.CreatedByUserID,
                CreatedDate = DTO.CreatedDate,
                IsActive = DTO.IsActive,
                IsIncome = DTO.IsIncome,
                MainCategoryID = DTO.MainCategoryID,
                MainCategoryName = DTO.MainCategoryName,
                MonthlyBudget = DTO.MonthlyBudget,
                Notes = DTO.Notes,
                ParentCategoryID = DTO.ParentCategoryID,
                ParentCategoryName = DTO.ParentCategoryName
            };
        }
        public FinCategoryDTO EntityToDTO(FinCategory entity)
        {
            if (entity is null)
                return null;

            return new FinCategoryDTO(entity.CategoryID, entity.CategoryName, entity.CreatedDate, entity.MonthlyBudget,
                entity.IsIncome, entity.ParentCategoryID, entity.AccountID, entity.CreatedByUserID, entity.IsActive, entity.CategoryHierarchical,
                entity.Notes, entity.MainCategoryName, entity.ParentCategoryName, entity.MainCategoryID);
        }
        public FinCategoryPagedSearchCriteria ToPagedCriteria(FinCategoryPagedFilterDTO DTO)
        {
            if (DTO is null)
                return null;

            return new FinCategoryPagedSearchCriteria()
            {
                CategoryID = DTO.CategoryID,
                MainCategoryName = DTO.MainCategoryName,
                ParentCategoryName = DTO.ParentCategoryName,
                CategoryName = DTO.CategoryName,
                IncludeMainCategories = DTO.IncludeMainCategories,
                IncludeSubCategories = DTO.IncludeSubCategories,
                IsActive = DTO.IsActive,
                IsIncome = DTO.IsIncome,
                PageNumber = DTO.PageNumber,
                TextSearchMode = (byte)DTO.TextSearchMode
            };
        }
        public FinCategorySelectPagedSearchCriteria ToSelectPagedCriteria(FinCategorySelectPagedFilterDTO DTO)
        {
            if (DTO is null)
                return null;

            return new FinCategorySelectPagedSearchCriteria()
            {
                CategoryName = DTO.CategoryName,
                IsIncome = DTO.IsIncome,
                PageNumber = DTO.PageNumber,
                TextSearchMode = (byte)DTO.TextSearchMode
            };
        }
        public BudgetCheckCriteria ToBudgetCriteria(BudgetCheckDTO DTO)
        {
            if (DTO is null)
                return null;

            return new BudgetCheckCriteria()
            {
                Amount = DTO.Amount,
                CategoryID = DTO.CategoryID,
                IsReturn = DTO.IsReturn,
                TransactionDate = DTO.TransactionDate,
                TransactionID = DTO.TransactionID
            };
        }
    }
}
