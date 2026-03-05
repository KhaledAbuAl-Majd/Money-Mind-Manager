namespace MoneyMindManager.Core.Models.Reports.Categories
{
    public class CategoryMonthlyFlowReportModel
    {
        public byte mon { get; set; }
        public short Year { get; set; }
        public decimal CategorySum { get; set; }
        public decimal CategorySonsSum { get; set; }
        public decimal Total { get; set; }


        public CategoryMonthlyFlowReportModel(byte month, short year, decimal categorySum, decimal categorySonsSum, decimal total)
        {
            this.mon = month;
            this.Year = year;
            this.CategorySum = categorySum;
            this.CategorySonsSum = categorySonsSum;
            this.Total = total;
        }
    }
}
