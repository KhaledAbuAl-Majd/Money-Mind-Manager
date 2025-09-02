using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;

namespace MoneyMindManager_Business
{
    public class clsCurrency : clsCurrencyData.clsCurrencyColumns
    {
        private clsCurrency(byte currencyID, string currencyName, string currencySymbol) : base(currencyID, currencyName, currencySymbol)
        {

        }

        public static async Task<clsCurrency> FindCurrencyByCurrencyID(byte currencyID)
        {
            clsCurrencyData.clsCurrencyColumns currencyColumns = await clsCurrencyData.GetCurrencyInfoByCurrencyID(currencyID);

            if (currencyColumns == null)
                return null;

            return new clsCurrency(currencyColumns.CurrencyID, currencyColumns.CurrencyName, currencyColumns.CurrencySymbol);
        }

        public static async Task<clsCurrency> FindCurrencyByCurrencyName(string currencyName)
        {
            clsCurrencyData.clsCurrencyColumns currencyColumns = await clsCurrencyData.GetCurrencyInfoByCurrencyName(currencyName);

            if (currencyColumns == null)
                return null;

            return new clsCurrency(currencyColumns.CurrencyID, currencyColumns.CurrencyName, currencyColumns.CurrencySymbol);
        }

        public static async Task<DataTable> GetAllCurrencies()
        {
            return await clsCurrencyData.GetAllCurrencies();
        }
    }
}
