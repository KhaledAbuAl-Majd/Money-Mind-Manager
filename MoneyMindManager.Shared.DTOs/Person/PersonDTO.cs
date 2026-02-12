using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager.Shared.DTOs.Account;

namespace MoneyMindManager.Shared.DTOs
{
    public class PersonDTO
    {
        public Nullable<int> PersonID { get; set; }
        public string PersonName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        /// <summary>
        /// At Add Mode Only
        /// </summary>
        public Nullable<short> AccountID { get; set; }
        public string Notes { get; set; }

        /// <summary>
        /// At Add Mode Only
        /// </summary>
        public int? CreatedByUserID { get; set; }

        /// <summary>
        /// At Add Mode Only
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// lending
        /// </summary>
        public decimal Receivable { get; set; } // مستحقات لك

        /// <summary>
        /// borrwing
        /// </summary>
        public decimal Payable { get; set; }    // مستحقات عليك

        public AccountBaseDTO AccountInfo { get; set; }

        public PersonDTO(int? personID, string personName, string address, string email, string phone,
            short? accountID, string notes, int? createdByUserID, DateTime createdDate, decimal receivable, decimal payable, AccountBaseDTO accountBaseDTO)
        {
            this.PersonID = personID;
            this.PersonName = personName;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
            this.AccountID = accountID;
            this.Notes = notes;
            this.CreatedByUserID = createdByUserID;
            this.CreatedDate = createdDate;
            this.Receivable = receivable;
            this.Payable = payable;
            this.AccountInfo = accountBaseDTO;
        }

        public PersonDTO()
        {
            this.PersonID = null;
            this.PersonName = null;
            this.Address = null;
            this.Email = null;
            this.Phone = null;
            this.AccountID = null;
            this.Notes = null;
            this.CreatedByUserID = null;
            this.CreatedDate = DateTime.Now;
            this.Receivable = 0;
            this.Payable = 0;
            this.AccountInfo = null;
        }
    }
}
