namespace MoneyMindManager.Core.Models.Reports
{
    public class MonthlyFlowReportModel
    {
        public byte mon { get; set; }
        public short Year { get; set; }
        public decimal Income { get; set; }
        public decimal NetExpense { get; set; }
        public decimal NetCashFlow { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalNetExpense { get; set; }
        public decimal TotalNetCashFlow { get; set; }


        public MonthlyFlowReportModel(byte month, short year, decimal income, decimal netExpense, decimal netCashFlow,
            decimal totalIncome, decimal totalNetExpense, decimal totalNetCashFlow)
        {
            this.mon = month;
            this.Year = year;
            this.Income = income;
            this.NetExpense = netExpense;
            this.NetCashFlow = netCashFlow;
            this.TotalIncome = totalIncome;
            this.TotalNetExpense = totalNetExpense;
            this.TotalNetCashFlow = totalNetCashFlow;
        }
    }
}
