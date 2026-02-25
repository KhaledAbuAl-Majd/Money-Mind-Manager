namespace MoneyMindManager.Domain.Entities.DebtPayment
{
    public class DebtPaymentShort
    {
        public int? DebtID { get; set; }

        public DebtPaymentShort(int debtID)
        {
            this.DebtID = debtID;
        }
    }
}
