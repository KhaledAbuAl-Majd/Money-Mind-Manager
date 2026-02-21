namespace MoneyMindManager.Core.Models.Reports.Categories
{
    public class TopCategoriesReportModel
    {
        public string CategoryName { get; set; }
        public decimal Value { get; set; }
        public int Ranking { get; set; }
        public decimal Percentage { get; set; }
        public TopCategoriesReportModel(string categoryName, decimal value, int ranking, decimal percentage)
        {
            this.CategoryName = categoryName;
            this.Value = value;
            this.Ranking = ranking;
            this.Percentage = percentage;
        }
    }
}
