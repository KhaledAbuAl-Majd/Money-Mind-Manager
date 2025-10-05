using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using static MoneyMindManagerGlobal.clsDataColumns.clsIncomeAndExpenseCategoriesClasses;

namespace MoneyMindManager_Business
{
    public class clsIncomeAndExpenseCategory : clsIncomeAndExpenseCategoriesColumns
    {
        public enum enMode { AddNew, Update };
        public enMode Mode { get; private set; }
        public clsAccount AccountInfo { get; private set; }
        public clsUser CreatedByUserInfo { get; private set; }

        public async Task<clsIncomeAndExpenseCategory> GetParentCategoryInfo(int currentUserID)
        {
            if (this.ParentCategoryID == null)
                return null;

            return await clsIncomeAndExpenseCategory.FindCategoryByCategoryID(Convert.ToInt32(this.ParentCategoryID), currentUserID);
        }

        /// <summary>
        /// Assing ParentCategoryID At Add Mode 
        /// </summary>
        /// <param name="parentCategoryID">only at add mode, null = main category</param>
        /// <returns>false if it failed</returns>
        public bool AssignParentCateoryIDAtAddMode(int parentCategoryID)
        {
            if (Mode == enMode.Update)
                return false;

            this.ParentCategoryID = parentCategoryID;
            
            return true;
        }

        public bool AssignIsIncome_CategoryType_AtAddMode(bool isIncome)
        {
            if (Mode == enMode.Update)
                return false;

            this.IsIncome = isIncome;
            
            return true;
        }
        //public bool AssignAccountIDAtAddMode(short?accountID)
        //{
        //    if (Mode == enMode.Update)
        //        return false;

        //    this.AccountID = accountID;

        //    return true;
        //}

        private clsIncomeAndExpenseCategory(int categoryID, string categoryName, DateTime createdDate, decimal? monthlyBudget,
            bool isIncome,int? parentCategoryID, short accountID, int createdByUserID, bool isActive, string categoryHierarchical,
            string notes,string mainCategoryName,clsAccount accountInfo,clsUser createdByUserInfo) 
            : base(categoryID, categoryName, createdDate, monthlyBudget, isIncome, parentCategoryID, accountID,
                  createdByUserID, isActive,categoryHierarchical,notes,mainCategoryName)
        {
            this.Mode = enMode.Update;
            this.AccountInfo = accountInfo;
            this.CreatedByUserInfo = createdByUserInfo;
        }
        public clsIncomeAndExpenseCategory()
        {
            Mode = enMode.AddNew;
            AccountInfo = null;
            CreatedByUserInfo = null;
        }

        async Task<bool> _AddNewCategory(int currentUserID)
        {
            this.CreatedDate = DateTime.Now;
            this.CreatedByUserID = currentUserID;

            this.CategoryID = await clsIncomeAndExpenseCategoryData.AddNewIncomeAndExpenseCategory(CategoryName, MonthlyBudget,
                IsIncome, ParentCategoryID, currentUserID, IsActive, Notes);

            return (this.CategoryID != null);
        }

        async Task<bool> _UpdateCategory(int currentUserID)
        {
            return await clsIncomeAndExpenseCategoryData.UpdateCategoryByID(Convert.ToInt32(CategoryID),
                CategoryName, MonthlyBudget, IsActive,Notes, currentUserID);
        }

        public async Task<bool> RefreshData(int currentUserID)
        {
            clsIncomeAndExpenseCategory fresh = await FindCategoryByCategoryID(Convert.ToInt32(CategoryID), currentUserID);

            if (fresh == null)
                return false;

            this.CategoryName = fresh.CategoryName;
            this.CreatedDate = fresh.CreatedDate;
            this.MonthlyBudget = fresh.MonthlyBudget;
            this.IsIncome = fresh.IsIncome;
            this.ParentCategoryID = fresh.ParentCategoryID;
            this.AccountID = fresh.AccountID;
            this.CreatedByUserID = fresh.CreatedByUserID;
            this.IsActive = fresh.IsActive;
            this.CategoryHierarchical = fresh.CategoryHierarchical;
            this.Notes = fresh.Notes;
            this.MainCategoryName = fresh.MainCategoryName;
            this.AccountInfo = fresh.AccountInfo;
            this.CreatedByUserInfo = fresh.CreatedByUserInfo;

            return true;
        }

        public async Task<bool> Save(int currentUserID)
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (await _AddNewCategory(currentUserID))
                        {
                            Mode = enMode.Update;
                            await RefreshData(currentUserID);
                            return true;
                        }
                        else
                            return false;
                    }

                case enMode.Update:
                    return await _UpdateCategory(currentUserID);
            }

            return true;
        }

        public static async Task<clsIncomeAndExpenseCategory> FindCategoryByCategoryID(int categoryID,int currentUserID)
        {
            var result = await clsIncomeAndExpenseCategoryData.GetCategryInfoByID(categoryID, currentUserID);

            if (result == null)
                return null;

           var createdByUserInfo = await clsUser.FindUserByUserID(Convert.ToInt32(result.CreatedByUserID),currentUserID);
            var accountInfo = createdByUserInfo?.AccountInfo;

            if (createdByUserInfo == null || accountInfo == null)
                return null;

            return new clsIncomeAndExpenseCategory(Convert.ToInt32(result.CategoryID), result.CategoryName, result.CreatedDate,
                result.MonthlyBudget, result.IsIncome, result.ParentCategoryID,Convert.ToInt16(result.AccountID),
                Convert.ToInt32(result.CreatedByUserID), result.IsActive,result.CategoryHierarchical,result.Notes,
                result.MainCategoryName,accountInfo, createdByUserInfo);
        }
        
        public static async Task<clsIncomeAndExpenseCategory> FindCategoryByCategoryName(string categoryName,int currentUserID)
        {
            var result = await clsIncomeAndExpenseCategoryData.GetCategryInfoByCategoryName(categoryName, currentUserID);

            if (result == null)
                return null;

           var createdByUserInfo = await clsUser.FindUserByUserID(Convert.ToInt32(result.CreatedByUserID),currentUserID);
            var accountInfo = createdByUserInfo?.AccountInfo;

            if (createdByUserInfo == null || accountInfo == null)
                return null;

            return new clsIncomeAndExpenseCategory(Convert.ToInt32(result.CategoryID), result.CategoryName, result.CreatedDate,
               result.MonthlyBudget, result.IsIncome, result.ParentCategoryID, Convert.ToInt16(result.AccountID),
               Convert.ToInt32(result.CreatedByUserID), result.IsActive, result.CategoryHierarchical, result.Notes,
               result.MainCategoryName, accountInfo, createdByUserInfo);
        }

        public static async Task<bool> DeleteCategoryByCategoryID(int categoryID,int currentUserID)
        {
            return await clsIncomeAndExpenseCategoryData.DeleteCategoryByID(categoryID, currentUserID);
        }

        public static async Task<bool> IsCategoryExistByCategoryNameAsync(string categoryName, int currentUserID)
        {
            return await clsIncomeAndExpenseCategoryData.IsCategoryExistByCategoryNameAsync(categoryName, currentUserID);
        }
        public static bool IsCategoryExistByCategoryName(string categoryName, int currentUserID)
        {
            return clsIncomeAndExpenseCategoryData.IsCategoryExistByCategoryName(categoryName, currentUserID);
        }

        /// <summary>
        /// Filter by CategoryType - isIncome
        /// </summary>
        public static async Task<clsGetAllCategories> GetAllCategoriesForSelectOne(bool isIncome,int currentUserID,short pageNumber)
        {
         return  await clsIncomeAndExpenseCategoryData.GetAllCategoriesForSelectOne(null, isIncome, currentUserID,pageNumber);
        }

        /// <summary>
        /// Filter by CategoryName AND CategoryType - isIncome
        /// </summary>
        public static async Task<clsGetAllCategories> GetAllCategoriesForSelectOne(string categoryName ,bool isIncome,int currentUserID,short pageNumber)
        {
         return  await clsIncomeAndExpenseCategoryData.GetAllCategoriesForSelectOne(categoryName, isIncome, currentUserID,pageNumber);
        }

        /// <summary>
        /// if variable is null will not filter by it
        /// </summary>
        public static async Task<clsGetAllCategories> GetAllCategories(bool isIncome, bool? isActive, bool includeMainCategories, bool includeSubCategories,
            int currentUserID, short pageNumber)
        {
            return await clsIncomeAndExpenseCategoryData.GetAllCategories(null, null, null, null, isIncome, isActive, includeMainCategories,
                includeSubCategories, currentUserID, pageNumber);
        }

        /// <summary>
        /// if variable is null will not filter by it
        /// </summary>
        public static async Task<clsGetAllCategories> GetAllCategoriesByCategoryID(int categoryID,bool isIncome, bool? isActive, bool includeMainCategories, bool includeSubCategories,
            int currentUserID, short pageNumber)
        {
            return await clsIncomeAndExpenseCategoryData.GetAllCategories(categoryID, null, null, null, isIncome, isActive, includeMainCategories,
                includeSubCategories, currentUserID, pageNumber);
        }

        /// <summary>
        /// if variable is null will not filter by it
        /// </summary>
        public static async Task<clsGetAllCategories> GetAllCategoriesByCategoryName(string categoryName,bool isIncome, bool? isActive, bool includeMainCategories, bool includeSubCategories,
            int currentUserID, short pageNumber)
        {
            return await clsIncomeAndExpenseCategoryData.GetAllCategories(null, categoryName, null, null, isIncome, isActive, includeMainCategories,
                includeSubCategories, currentUserID, pageNumber);
        }

        /// <summary>
        /// if variable is null will not filter by it
        /// </summary>
        public static async Task<clsGetAllCategories> GetAllCategoriesByParentCategoryName(string parentCategoryName,bool isIncome, bool? isActive, bool includeMainCategories, bool includeSubCategories,
            int currentUserID, short pageNumber)
        {
            return await clsIncomeAndExpenseCategoryData.GetAllCategories(null, null, parentCategoryName, null, isIncome, isActive, includeMainCategories,
                includeSubCategories, currentUserID, pageNumber);
        }

        /// <summary>
        /// if variable is null will not filter by it
        /// </summary>
        public static async Task<clsGetAllCategories> GetAllCategoriesByMainCategoryName(string mainCategoryName,bool isIncome, bool? isActive, bool includeMainCategories, bool includeSubCategories,
            int currentUserID, short pageNumber)
        {
            return await clsIncomeAndExpenseCategoryData.GetAllCategories(null, null, null, mainCategoryName, isIncome, isActive, includeMainCategories,
                includeSubCategories, currentUserID, pageNumber);
        }
    }
}
