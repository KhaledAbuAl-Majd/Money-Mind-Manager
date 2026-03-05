using System;

namespace MoneyMindManager.Core.Models.FinCategory
{
    public class FinCategoryFullSummary
    {
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ParentCategoryName { get; set; }
        public string MainCategoryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        public FinCategoryFullSummary(int categoryID, string categoryName, DateTime createdDate, bool isActive,
           string mainCategoryName, string parentCategoryName)
        {
            this.CategoryID = categoryID;
            this.CategoryName = categoryName;
            this.CreatedDate = createdDate;
            this.IsActive = isActive;
            this.MainCategoryName = mainCategoryName;
            this.ParentCategoryName = parentCategoryName;
        }
    }
}
