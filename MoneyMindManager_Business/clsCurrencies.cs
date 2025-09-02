using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;

namespace MoneyMindManager_Business
{
    public class clsCurrencies : clsCurrenciesData.clsCurrenciesColumns
    {
        private clsCurrencies(byte currencyID, string currencyName, string currencySymbol) : base(currencyID, currencyName, currencySymbol)
        {

        }

        public static async Task<clsCurrencies> FindCurrencyByCurrencyID(byte currencyID)
        {
            clsCurrenciesData.clsCurrenciesColumns currencyColumns = await clsCurrenciesData.GetCurrencyInfoByCurrencyID(currencyID);

            if (currencyColumns == null)
                return null;

            return new clsCurrencies(currencyColumns.CurrencyID, currencyColumns.CurrencyName, currencyColumns.CurrencySymbol);
        }

        public static async Task<clsCurrencies> FindCurrencyByCurrencyName(string currencyName)
        {
            clsCurrenciesData.clsCurrenciesColumns currencyColumns = await clsCurrenciesData.GetCurrencyInfoByCurrencyName(currencyName);

            if (currencyColumns == null)
                return null;

            return new clsCurrencies(currencyColumns.CurrencyID, currencyColumns.CurrencyName, currencyColumns.CurrencySymbol);
        }

        public static async Task<DataTable> GetAllCurrencies()
        {
            return await clsCurrenciesData.GetAllCurrencies();
        }
    }
}
