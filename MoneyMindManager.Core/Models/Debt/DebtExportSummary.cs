using System;

namespace MoneyMindManager.Core.Models.Debt
{
    public class DebtExportSummary : DebtViewSummary
    {
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public short AccounntID { get; set; }

        public DebtExportSummary(int debtID, string personName, decimal debtValue, decimal remainingAmount, DateTime debtDate,
           DateTime createdDate, string debtType, string createdByUserName, int personID, int createdByUserID, short accountID)
            : base(debtID, personName, debtValue, remainingAmount, debtDate, createdDate, debtType, createdByUserName)
        {
            this.PersonID = personID;
            this.CreatedByUserID = createdByUserID;
            this.AccounntID = accountID;
        }
    }
}
