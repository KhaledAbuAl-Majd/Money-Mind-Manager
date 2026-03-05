namespace MoneyMindManager.Shared.DTOs.Debt
{
    public class DebtUpdateResultDTO
    {
        public bool UpdateResult { get; set; }
        public decimal RemainingAmount { get; set; }

        public DebtUpdateResultDTO(bool updateResult, decimal remainingAmount)
        {
            this.UpdateResult = updateResult;
            this.RemainingAmount = remainingAmount;
        }
    }
}
