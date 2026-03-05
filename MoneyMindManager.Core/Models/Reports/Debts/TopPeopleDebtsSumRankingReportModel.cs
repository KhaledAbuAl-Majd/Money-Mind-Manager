namespace MoneyMindManager.Core.Models.Reports.Debts
{
    public class TopPeopleDebtsSumRankingReportModel
    {
        public int PersonID { get; set; }
        public string PersonName { get; set; }
        public decimal PersonDebtsSum { get; set; }
        public int PersonOrder { get; set; }


        public TopPeopleDebtsSumRankingReportModel(int personID, string personName, decimal personDebtsSum, int personOrder)
        {
            this.PersonID = personID;
            this.PersonName = personName;
            this.PersonDebtsSum = personDebtsSum;
            this.PersonOrder = personOrder;
        }
    }
}
