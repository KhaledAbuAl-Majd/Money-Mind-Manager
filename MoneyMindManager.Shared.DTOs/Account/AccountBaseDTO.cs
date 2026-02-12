using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager.Shared.DTOs.Currency;

namespace MoneyMindManager.Shared.DTOs.Account
{
    public class AccountBaseDTO
    {
        public short AccountID { get; set; }

        public string AccountName { get; set; }

        public DateTime CreatedDate { get; set; }

        public byte DefaultCurrencyID { get; set; }

        public string Description { get; set; }

        public decimal Balance { get; set; }

        public int AccountOwnerUserID { get; protected set; }

        public CurrencyDTO DefaultCurrencyInfo { get; private set; }

        public AccountBaseDTO(short accountID, string accountName, DateTime createdDate, byte defaultCurrencyID,
            string description, decimal balance, int accountOwnerUserID,CurrencyDTO currencyDTO)
        {
            this.AccountID = accountID;
            this.AccountName = accountName;
            this.CreatedDate = createdDate;
            this.DefaultCurrencyID = defaultCurrencyID;
            this.Description = description;
            this.Balance = balance;
            this.AccountOwnerUserID = accountOwnerUserID;
            this.DefaultCurrencyInfo = currencyDTO;
        }
    }
}
