using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManager.Shared.DTOs.Currency
{
    public class CurrencyDTO
    {
        public byte CurrencyID { get; }
        public string CurrencyName { get; }
        public string CurrencySymbol { get; }

        public CurrencyDTO(byte currencyID, string currencyName, string currencySymbol)
        {
            this.CurrencyID = currencyID;
            this.CurrencyName = currencyName;
            this.CurrencySymbol = currencySymbol;
        }
    }
}
