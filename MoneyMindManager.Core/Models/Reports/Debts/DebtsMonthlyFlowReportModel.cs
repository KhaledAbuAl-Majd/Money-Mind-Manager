namespace MoneyMindManager.Core.Models.Reports.Debts
{
    public class DebtsMonthlyFlowReportModel
    {
        public byte mon { get; set; }
        public short Year { get; set; }
        public decimal LendingDebtsSum { get; set; }
        public decimal BorrowingDebtsSum { get; set; }
        public decimal LendingPaymentsSum { get; set; }
        public decimal BorrowingPaymentsSum { get; set; }


        public DebtsMonthlyFlowReportModel(byte month, short year, decimal lendingDebtsSum, decimal borrowingDebtsSum, decimal lendingPaymentsSum, decimal borrowingPaymentsSum)
        {
            this.mon = month;
            this.Year = year;
            this.LendingDebtsSum = lendingDebtsSum;
            this.BorrowingDebtsSum = borrowingDebtsSum;
            this.LendingPaymentsSum = lendingPaymentsSum;
            this.BorrowingPaymentsSum = borrowingPaymentsSum;
        }
    }
}
