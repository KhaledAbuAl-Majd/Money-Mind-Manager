namespace MoneyMindManager.Core.Models.Reports.Debts
{
    public class DebtRepaymentScheduleReportModel
    {
        public byte? mon { get; set; }
        public short? Year { get; set; }
        public decimal Receivable { get; set; }
        public decimal Payables { get; set; }
        public decimal NetCashFlow { get; set; }


        public DebtRepaymentScheduleReportModel(byte? month, short? year, decimal receivable, decimal payables, decimal netCashFlow)
        {
            this.mon = month;
            this.Year = year;
            this.Receivable = receivable;
            this.Payables = payables;
            this.NetCashFlow = netCashFlow;
        }
    }
}
