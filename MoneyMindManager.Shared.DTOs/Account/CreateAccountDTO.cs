using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManager.Shared.DTOs.Account
{
    public class CreateAccountDTO
    {
        public string AccountName { get; set; }

        public byte DefaultCurrencyID { get; set; }

        public string Description { get; set; }

        public string PersonName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Notes { get; set; }

        public string UserName { get; set; }

        public string Password { get; protected set; }

        public CreateAccountDTO(string accountName, byte defaultCurrencyID,
            string description, string personName, string address, string email, string phone, string notes, string userName,
           string password)
        {
            this.AccountName = accountName;
            this.DefaultCurrencyID = defaultCurrencyID;
            this.Description = description;
            this.PersonName = personName;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
            this.Notes = notes;
            this.UserName = userName;
            this.Password = password;
        }
    }
}
