namespace MoneyMindManager.Core.Models.FinCategory
{
    public class FinCategorySelectSummary
    {
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ParentCategoryName { get; set; }
        public string MainCategoryName { get; set; }

        public FinCategorySelectSummary(int categoryID, string categoryName, string mainCategoryName, string parentCategoryName)
        {
            this.CategoryID = categoryID;
            this.CategoryName = categoryName;
            this.MainCategoryName = mainCategoryName;
            this.ParentCategoryName = parentCategoryName;
        }
    }
}
