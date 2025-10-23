using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using MoneyMindManagerGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.clsIncomeAndExpenseCategoriesClasses;

namespace MoneyMindManager_Business
{
    public class clsIncomeAndExpenseCategory : clsIncomeAndExpenseCategoriesColumns
    {
        public enum enMode { AddNew, Update };
        public enMode Mode { get; private set; }
        public clsAccount AccountInfo { get; private set; }
        public clsUser CreatedByUserInfo { get; private set; }

        public async Task<clsIncomeAndExpenseCategory> GetParentCategoryInfo()
        {
            if (this.ParentCategoryID == null)
                return null;

            return await clsIncomeAndExpenseCategory.FindCategoryByCategoryID(Convert.ToInt32(this.ParentCategoryID));
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

        async Task<bool> _AddNewCategory()
        {
            this.CreatedDate = DateTime.Now;
            this.CreatedByUserID = Convert.ToInt32(clsGlobalSession.CurrentUserID);

            this.CategoryID = await clsIncomeAndExpenseCategoryData.AddNewIncomeAndExpenseCategory(CategoryName, MonthlyBudget,
                IsIncome, ParentCategoryID, Convert.ToInt32(clsGlobalSession.CurrentUserID), IsActive, Notes);

            return (this.CategoryID != null);
        }

        async Task<bool> _UpdateCategory()
        {
            return await clsIncomeAndExpenseCategoryData.UpdateCategoryByID(Convert.ToInt32(CategoryID),
                CategoryName, MonthlyBudget, IsActive,Notes, Convert.ToInt32(clsGlobalSession.CurrentUserID));
        }

        public async Task<bool> RefreshData()
        {
            clsIncomeAndExpenseCategory fresh = await FindCategoryByCategoryID(Convert.ToInt32(CategoryID));

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

        public async Task<bool> Save(bool isActive)
        {
            if (!clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.AddUpdateCategory,
             "ليس لديك صلاحية إضافة/تعديل فئة."))
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        this.IsActive = isActive;

                        if (await _AddNewCategory())
                        {
                            Mode = enMode.Update;
                            await RefreshData();
                            return true;
                        }
                        else
                            return false;
                    }

                case enMode.Update:
                    {
                        if (this.IsActive != isActive && !clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.ChangeCategoryActivation,
                         "ليس لديك صلاحية تغيير فعالية فئة."))
                            return false;

                        this.IsActive = isActive;
                        return await _UpdateCategory();
                    }
            }

            return true;
        }

        public static async Task<clsIncomeAndExpenseCategory> FindCategoryByCategoryID(int categoryID)
        {
            var result = await clsIncomeAndExpenseCategoryData.GetCategryInfoByID(categoryID, Convert.ToInt32(clsGlobalSession.CurrentUserID));

            if (result == null)
                return null;

           var createdByUserInfo = await clsUser.FindUserByUserID(Convert.ToInt32(result.CreatedByUserID));
            var accountInfo = createdByUserInfo?.AccountInfo;

            if (createdByUserInfo == null || accountInfo == null)
                return null;

            return new clsIncomeAndExpenseCategory(Convert.ToInt32(result.CategoryID), result.CategoryName, result.CreatedDate,
                result.MonthlyBudget, result.IsIncome, result.ParentCategoryID,Convert.ToInt16(result.AccountID),
                Convert.ToInt32(result.CreatedByUserID), result.IsActive,result.CategoryHierarchical,result.Notes,
                result.MainCategoryName,accountInfo, createdByUserInfo);
        }
        
        public static async Task<clsIncomeAndExpenseCategory> FindCategoryByCategoryName(string categoryName)
        {
            var result = await clsIncomeAndExpenseCategoryData.GetCategryInfoByCategoryName(categoryName, Convert.ToInt32(clsGlobalSession.CurrentUserID));

            if (result == null)
                return null;

           var createdByUserInfo = await clsUser.FindUserByUserID(Convert.ToInt32(result.CreatedByUserID));
            var accountInfo = createdByUserInfo?.AccountInfo;

            if (createdByUserInfo == null || accountInfo == null)
                return null;

            return new clsIncomeAndExpenseCategory(Convert.ToInt32(result.CategoryID), result.CategoryName, result.CreatedDate,
               result.MonthlyBudget, result.IsIncome, result.ParentCategoryID, Convert.ToInt16(result.AccountID),
               Convert.ToInt32(result.CreatedByUserID), result.IsActive, result.CategoryHierarchical, result.Notes,
               result.MainCategoryName, accountInfo, createdByUserInfo);
        }

        public static async Task<bool> DeleteCategoryByCategoryID(int categoryID)
        {
            if (!clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.DeleteCategory,
                "ليس لديك صلاحية حذف فئة."))
                return false;

            return await clsIncomeAndExpenseCategoryData.DeleteCategoryByID(categoryID, Convert.ToInt32(clsGlobalSession.CurrentUserID));
        }

        public static async Task<bool> IsCategoryExistByCategoryNameAsync(string categoryName)
        {
            return await clsIncomeAndExpenseCategoryData.IsCategoryExistByCategoryNameAsync(categoryName, Convert.ToInt32(clsGlobalSession.CurrentUserID));
        }

        public static bool IsCategoryExistByCategoryName(string categoryName)
        {
            return clsIncomeAndExpenseCategoryData.IsCategoryExistByCategoryName(categoryName, Convert.ToInt32(clsGlobalSession.CurrentUserID));
        }

        /// <summary>
        /// Filter by CategoryType - isIncome, if vairable is null will not filter by it
        /// </summary>
        public static async Task<clsGetAllCategories> GetAllCategoriesForSelectOne(bool? isIncome,short pageNumber)
        {
         return  await clsIncomeAndExpenseCategoryData.GetAllCategoriesForSelectOne(null, isIncome, Convert.ToInt32(clsGlobalSession.CurrentUserID), pageNumber);
        }

        /// <summary>
        /// Filter by CategoryName AND CategoryType - isIncome, if vairable is null will not filter by it
        /// </summary>
        public static async Task<clsGetAllCategories> GetAllCategoriesForSelectOne(string categoryName ,bool? isIncome,short pageNumber)
        {
         return  await clsIncomeAndExpenseCategoryData.GetAllCategoriesForSelectOne(categoryName, isIncome, Convert.ToInt32(clsGlobalSession.CurrentUserID), pageNumber);
        }

        /// <summary>
        /// if variable is null will not filter by it
        /// </summary>
        public static async Task<clsGetAllCategories> GetAllCategories(bool isIncome, bool? isActive, bool includeMainCategories, bool includeSubCategories,
             short pageNumber)
        {
            return await clsIncomeAndExpenseCategoryData.GetAllCategories(null, null, null, null, isIncome, isActive, includeMainCategories,
                includeSubCategories, Convert.ToInt32(clsGlobalSession.CurrentUserID), pageNumber);
        }

        /// <summary>
        /// if variable is null will not filter by it
        /// </summary>
        public static async Task<clsGetAllCategories> GetAllCategoriesByCategoryID(int categoryID,bool isIncome, bool? isActive, bool includeMainCategories, bool includeSubCategories,
             short pageNumber)
        {
            return await clsIncomeAndExpenseCategoryData.GetAllCategories(categoryID, null, null, null, isIncome, isActive, includeMainCategories,
                includeSubCategories, Convert.ToInt32(clsGlobalSession.CurrentUserID), pageNumber);
        }

        /// <summary>
        /// if variable is null will not filter by it
        /// </summary>
        public static async Task<clsGetAllCategories> GetAllCategoriesByCategoryName(string categoryName,bool isIncome, bool? isActive, bool includeMainCategories, bool includeSubCategories,
             short pageNumber)
        {
            return await clsIncomeAndExpenseCategoryData.GetAllCategories(null, categoryName, null, null, isIncome, isActive, includeMainCategories,
                includeSubCategories, Convert.ToInt32(clsGlobalSession.CurrentUserID), pageNumber);
        }

        /// <summary>
        /// if variable is null will not filter by it
        /// </summary>
        public static async Task<clsGetAllCategories> GetAllCategoriesByParentCategoryName(string parentCategoryName,bool isIncome, bool? isActive, bool includeMainCategories, bool includeSubCategories,
             short pageNumber)
        {
            return await clsIncomeAndExpenseCategoryData.GetAllCategories(null, null, parentCategoryName, null, isIncome, isActive, includeMainCategories,
                includeSubCategories, Convert.ToInt32(clsGlobalSession.CurrentUserID), pageNumber);
        }

        /// <summary>
        /// if variable is null will not filter by it
        /// </summary>
        public static async Task<clsGetAllCategories> GetAllCategoriesByMainCategoryName(string mainCategoryName,bool isIncome, bool? isActive, bool includeMainCategories, bool includeSubCategories,
             short pageNumber)
        {
            return await clsIncomeAndExpenseCategoryData.GetAllCategories(null, null, null, mainCategoryName, isIncome, isActive, includeMainCategories,
                includeSubCategories, Convert.ToInt32(clsGlobalSession.CurrentUserID), pageNumber);
        }
    }
}
