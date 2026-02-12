using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManager.Domain.Entities
{
    public class Account
    {
        public short AccountID { get; set; }

        public string AccountName { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }

        public byte DefaultCurrencyID { get; set; }

        public string Description { get; set; }

        public decimal Balance { get; set; }

        public int AccountOwnerUserID { get; protected set; }

        public Account(short accountID, string accountName, DateTime createdDate, bool isActive, byte defaultCurrencyID,
            string description, decimal balance, int accountOwnerUserID)
        {
            this.AccountID = accountID;
            this.AccountName = accountName;
            this.CreatedDate = createdDate;
            this.IsActive = isActive;
            this.DefaultCurrencyID = defaultCurrencyID;
            this.Description = description;
            this.Balance = balance;
            this.AccountOwnerUserID = accountOwnerUserID;
        }
    }
}
