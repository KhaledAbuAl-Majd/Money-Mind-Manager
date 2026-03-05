using System;

namespace MoneyMindManager.Core.Models.DebtPayment
{
    public class DebtPaymentExportSummary : DebtPaymentViewSummary
    {
        public int? CreatedByUserID { get; set; }
        public short? AccountID { get; set; }

        public DebtPaymentExportSummary(int transactionID, decimal amount, DateTime debtDate, string createdByUserName,
            DateTime createdDate, string purpose, int createdByUserID, short accountID) :
            base(transactionID, amount, debtDate, createdByUserName, createdDate, purpose)
        {
            this.CreatedByUserID = createdByUserID;
            this.AccountID = accountID;
        }
    }
}
