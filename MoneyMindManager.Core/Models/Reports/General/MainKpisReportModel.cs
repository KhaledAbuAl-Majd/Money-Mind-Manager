namespace MoneyMindManager.Core.Models.Reports
{
    public class MainKpisReportModel
    {
        public decimal Balance { get; set; }
        public decimal TotalReceivables { get; set; }
        public decimal TotalPayables { get; set; }
        public decimal Next30DayDebtsDue { get; set; }
        public decimal DayPerformance { get; set; }
        public decimal MonthPerformance { get; set; }
        public decimal YearPerformance { get; set; }
        public decimal AvgNetProfitLast6Months { get; set; }


        public MainKpisReportModel(decimal balance, decimal totalReceivables, decimal totalPayables, decimal next30DayDebtsDue,
            decimal dayPerformance, decimal monthPerformance, decimal yearPerformance, decimal avgNetProfitLast6Months)
        {
            this.Balance = balance;
            this.TotalReceivables = totalReceivables;
            this.TotalPayables = totalPayables;
            this.Next30DayDebtsDue = next30DayDebtsDue;
            this.DayPerformance = dayPerformance;
            this.MonthPerformance = monthPerformance;
            this.YearPerformance = yearPerformance;
            this.AvgNetProfitLast6Months = avgNetProfitLast6Months;
        }
    }
}
