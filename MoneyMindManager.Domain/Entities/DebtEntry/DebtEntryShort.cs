namespace MoneyMindManager.Domain.Entities.DebtEntry
{
    public class DebtEntryShort
    {
        public int? DebtID { get; set; }

        public DebtEntryShort(int debtID)
        {
            this.DebtID = debtID;
        }
    }
}
