namespace MoneyMindManager.Core.Models.Reports.Debts
{
    public class TopDebtorsRankingReportModel
    {
        public int PersonID { get; set; }
        public string PersonName { get; set; }
        public decimal PersonRemaining { get; set; }
        public int PersonOrder { get; set; }


        public TopDebtorsRankingReportModel(int personID, string personName, decimal personRemaining, int personOrder)
        {
            this.PersonID = personID;
            this.PersonName = personName;
            this.PersonRemaining = personRemaining;
            this.PersonOrder = personOrder;
        }
    }
}
