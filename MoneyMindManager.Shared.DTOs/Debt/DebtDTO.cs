using System;

namespace MoneyMindManager.Shared.DTOs.Debt
{
    public class DebtDTO
    {
        public int? DebtID { get; set; }
        public bool IsLending { get; set; }
        public int? PersonID { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public short? AccountID { get; set; }
        public int? CreatedByUserID { get; set; }
        public string CreatedByUserName { get; set; }
        public bool IsLocked { get; set; }
        public decimal TotalValue { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal RemainingAmount { get; set; }
        public DateTime DebtDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Notes { get; set; }

        public PersonDTO PersonInfo { get; set; }

        public DebtDTO(int debtID, bool isLending, int personID, DateTime? paymentDueDate, short? accountID, int? createdByUserID, string createdByUserName, bool isLocked,
            decimal totalValue, decimal totalPaid, decimal remaintAmount, DateTime debtDate, DateTime createdDate, string notes)
        {
            this.DebtID = debtID;
            this.IsLending = isLending;
            this.PersonID = personID;
            this.PaymentDueDate = paymentDueDate;
            this.AccountID = accountID;
            this.CreatedByUserID = createdByUserID;
            this.CreatedByUserName = createdByUserName;
            this.IsLocked = isLocked;
            this.TotalValue = totalValue;
            this.TotalPaid = totalPaid;
            this.RemainingAmount = remaintAmount;
            this.DebtDate = debtDate;
            this.CreatedDate = createdDate;
            this.Notes = notes;
        }


        public DebtDTO()
        {
            this.DebtID = null;
            this.IsLending = false;
            this.PersonID = null;
            this.PaymentDueDate = null;
            this.RemainingAmount = -9999999999;
            this.CreatedDate = DateTime.MaxValue; ;
            this.AccountID = null;
            this.CreatedByUserID = null;
        }
    }
}

