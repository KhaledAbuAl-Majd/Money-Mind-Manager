using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManagerGlobal;

namespace MoneyMindManager_DataAccess
{
    public static class clsCurrenciesData
    {
        public class clsCurrenciesColumns
        {
            public byte CurrencyID { get; }
            public string CurrencyName { get; }
            public string CurrencySymbol { get; }

            public clsCurrenciesColumns(byte currencyID,string currencyName,string currencySymbol)
            {
                this.CurrencyID = currencyID;
                this.CurrencyName = currencyName;
                this.CurrencySymbol = currencySymbol;
            }

            //public clsCurrenciesColumns()
            //{
            //    this.CurrencyID = null;
            //    this.CurrencyName = null;
            //    this.CurrencySymbol = null;
            //}
        }

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        public static async Task<clsCurrenciesColumns> GetCurrencyInfoByCurrencyID(byte currencyID, bool RaiseEventOnErrorOccured = true)
        {
            clsCurrenciesColumns currencyData = null;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using(SqlCommand command = new SqlCommand("[dbo].[SP_GetCurrencyByCurrencyID]", connection))
                    {
                        command.Parameters.AddWithValue("@CurrencyID", currencyID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                string currencyName = (reader["CurrencyName"] == DBNull.Value) ? null : reader["CurrencyName"] as string;
                                string currencySymbol = (reader["CurrencySymbol"] == DBNull.Value) ? null : reader["CurrencySymbol"] as string;

                                currencyData = new clsCurrenciesColumns(currencyID, currencyName, currencySymbol);
                            }
                            else
                                currencyData = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                currencyData = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return currencyData;
        }

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        public static async Task<clsCurrenciesColumns> GetCurrencyInfoByCurrencyName(string currencyName, bool RaiseEventOnErrorOccured = true)
        {
            clsCurrenciesColumns currencyData = null;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using(SqlCommand command = new SqlCommand("[dbo].[SP_GetCurrencyByCurrencyName]", connection))
                    {
                        command.Parameters.AddWithValue("@CurrencyName", currencyName);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                byte currencyID = Convert.ToByte(reader["CurrencyID"]);
                                string currencySymbol = (reader["CurrencySymbol"] == DBNull.Value) ? null : reader["CurrencySymbol"] as string;

                                currencyData = new clsCurrenciesColumns(currencyID, currencyName, currencySymbol);
                            }
                            else
                                currencyData = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                currencyData = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return currencyData;
        }

        public static async Task<DataTable> GetAllCurrencies(bool RaiseEventOnErrorOccured = true)
        {
            DataTable dtCurrencies = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllCurrencies", connection))
                    {
                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            dtCurrencies.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dtCurrencies = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return dtCurrencies;
        }
    }
}
