using System;

namespace MoneyMindManager.UI.Models
{
    [Serializable]
    public class UserSettings
    {
        public int UserID { get; }

        //
        public bool AskBeforeDeletePerson { get; set; }
        //
        public bool AskBeforeDeleteUser { get; set; }
        //
        public bool AskBeforeDeleteIncomeVoucher { get; set; }
        public bool AskBeforeDeleteIncomeTransactions { get; set; }
        public bool Income_TodayAsDefaultDate { get; set; }
        public bool IncomeTransaction_AutoAddNewDefault { get; set; }
        //
        public bool AskBeforeDeleteExpenseVoucher { get; set; }
        public bool AskBeforeDeleteExpenseTransactions { get; set; }
        public bool Expense_TodayAsDefaultDate { get; set; }
        public bool ExpenseTransaction_AutoAddNewDefault { get; set; }
        //
        public bool AskBeforeDeleteExpenseReturnVoucher { get; set; }
        public bool AskBeforeDeleteExpenseReturnTransactions { get; set; }
        public bool ExpenseReturn_TodayAsDefaultDate { get; set; }
        public bool ExpenseReturnTransaction_AutoAddNewDefault { get; set; }
        //
        public bool AskBeforeDeleteDebts { get; set; }
        public bool AskBeforeDeleteDebtPayments { get; set; }
        public bool Debts_TodayAsDefaultDate { get; set; }
        public bool DebtPayments_TodayAsDefaultDate { get; set; }
        public bool DebtPayment_AutoAddNewDefault { get; set; }
        public bool AskBeforeDeleteCategory { get; set; }

        public UserSettings(int userID)
        {
            this.UserID = userID;
        }
    }
}
