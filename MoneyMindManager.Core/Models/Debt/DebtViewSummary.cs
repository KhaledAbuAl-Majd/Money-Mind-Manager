using System;

namespace MoneyMindManager.Core.Models.Debt
{
    public class DebtViewSummary
    {
        public int DebtID { get; set; }
        public string PersonName { get; set; }
        public decimal DebtValue { get; set; }
        public decimal RemainingAmount { get; set; }
        public DateTime DebtDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string DebtType { get; set; }
        public string CreatedByUserName { get; set; }

        public DebtViewSummary(int debtID, string personName, decimal debtValue, decimal remainingAmount, DateTime debtDate,
            DateTime createdDate, string debtType, string createdByUserName)
        {
            DebtID = debtID;
            PersonName = personName;
            DebtValue = debtValue;
            RemainingAmount = remainingAmount;
            DebtDate = debtDate;
            CreatedDate = createdDate;
            DebtType = debtType;
            CreatedByUserName = createdByUserName;
        }
    }
}
