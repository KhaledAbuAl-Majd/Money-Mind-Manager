using System;

namespace MoneyMindManager.Core.Models.DebtPayment
{
    public class DebtPaymentViewSummary
    {
        public int? MainTransactionID { get; set; }
        public Decimal Amount { get; set; }
        public DateTime DebtDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
        public string Purpose { get; set; }

        public DebtPaymentViewSummary(int transactionID, decimal amount, DateTime debtDate, string createdByUserName,
            DateTime createdDate, string purpose)
        {
            this.MainTransactionID = transactionID;
            this.Amount = amount;
            this.DebtDate = debtDate;
            this.CreatedDate = createdDate;
            this.CreatedByUserName = createdByUserName;
            this.Purpose = purpose;
        }
    }
}
