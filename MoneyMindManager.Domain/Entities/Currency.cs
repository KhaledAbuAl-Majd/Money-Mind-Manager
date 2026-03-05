using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManager.Domain.Entities
{
    public class Currency
    {
        public byte CurrencyID { get; }
        public string CurrencyName { get; }
        public string CurrencySymbol { get; }

        public Currency(byte currencyID, string currencyName, string currencySymbol)
        {
            this.CurrencyID = currencyID;
            this.CurrencyName = currencyName;
            this.CurrencySymbol = currencySymbol;
        }
    }
}
