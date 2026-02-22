using System;
using MoneyMindManager.Shared.DTOs.User;

namespace MoneyMindManager.Shared.DTOs
{
    public class FinCategoryDTO
    {
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public Decimal? MonthlyBudget { get; set; }
        public bool IsIncome { get; set; }
        public int? ParentCategoryID { get; set; }
        public short? AccountID { get; set; }
        public int? CreatedByUserID { get; set; }
        public bool IsActive { get; set; }
        public string CategoryHierarchical { get; set; }
        public string Notes { get; set; }
        public string MainCategoryName { get; set; }
        public string ParentCategoryName { get; set; }
        public int? MainCategoryID { get; set; }
        public UserDTO UserInfo { get; set; }

        public FinCategoryDTO(int? categoryID, string categoryName, DateTime createdDate, decimal? monthlyBudget,
            bool isIncome, int? parentCategoryID, short? accountID, int? createdByUserID, bool isActive,
            string categoryHierarchical, string notes, string mainCategoryName, string parentCategoryName, int? mainCategoryID)
        {
            this.CategoryID = categoryID;
            this.CategoryName = categoryName;
            this.CreatedDate = createdDate;
            this.MonthlyBudget = monthlyBudget;
            this.IsIncome = isIncome;
            this.ParentCategoryID = parentCategoryID;
            this.AccountID = accountID;
            this.CreatedByUserID = createdByUserID;
            this.IsActive = isActive;
            this.CategoryHierarchical = categoryHierarchical;
            this.Notes = notes;
            this.MainCategoryName = mainCategoryName;
            this.ParentCategoryName = parentCategoryName;
            this.MainCategoryID = mainCategoryID;
        }

        public FinCategoryDTO()
        {
            this.CategoryID = null;
            this.CategoryName = null;
            this.CreatedDate = DateTime.Now;
            this.MonthlyBudget = null;
            this.IsIncome = false;
            this.ParentCategoryID = null;
            this.AccountID = null;
            this.CreatedByUserID = null;
            this.IsActive = false;
            this.CategoryHierarchical = null;
            this.Notes = null;
            this.MainCategoryName = null;
            this.ParentCategoryName = null;
            this.MainCategoryID = null;
        }
    }
}
