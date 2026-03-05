using System;

namespace MoneyMindManager.Shared.DTOs.IncomeAndExpenseCategory
{
    public class BudgetCheckDTO
    {
        public int CategoryID { get; set; }
        public int? TransactionID { get; set; }
        public decimal? Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool? IsReturn { get; set; }

        public BudgetCheckDTO(int categoryID, int? transactionID, decimal? amount, DateTime transactionDate, bool? isReturn)
        {
            this.CategoryID = categoryID;
            this.TransactionID = transactionID;
            this.Amount = amount;
            this.TransactionDate = transactionDate;
            this.IsReturn = IsReturn;
        }
    }
}
