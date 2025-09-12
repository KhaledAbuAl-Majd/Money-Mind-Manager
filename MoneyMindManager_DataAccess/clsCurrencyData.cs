using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManagerGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.clsCurrencyClasses;

namespace MoneyMindManager_DataAccess
{
    public static class clsCurrencyData
    {
        
        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        public static async Task<clsCurrencyColumns> GetCurrencyInfoByCurrencyID(byte currencyID, bool RaiseEventOnErrorOccured = true)
        {
            clsCurrencyColumns currencyData = null;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using(SqlCommand command = new SqlCommand("[dbo].[SP_GetCurrencyByCurrencyID]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CurrencyID", currencyID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                string currencyName = (reader["CurrencyName"] == DBNull.Value) ? null : reader["CurrencyName"] as string;
                                string currencySymbol = (reader["CurrencySymbol"] == DBNull.Value) ? null : reader["CurrencySymbol"] as string;

                                currencyData = new clsCurrencyColumns(currencyID, currencyName, currencySymbol);
                            }
                            else
                                currencyData = null;
                        }
                    }
                }

                if (currencyData == null)
                    throw new Exception("فشلت العملية");
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
        public static async Task<clsCurrencyColumns> GetCurrencyInfoByCurrencyName(string currencyName, bool RaiseEventOnErrorOccured = true)
        {
            clsCurrencyColumns currencyData = null;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using(SqlCommand command = new SqlCommand("[dbo].[SP_GetCurrencyByCurrencyName]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CurrencyName", currencyName);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                byte currencyID = Convert.ToByte(reader["CurrencyID"]);
                                string currencySymbol = (reader["CurrencySymbol"] == DBNull.Value) ? null : reader["CurrencySymbol"] as string;

                                currencyData = new clsCurrencyColumns(currencyID, currencyName, currencySymbol);
                            }
                            else
                                currencyData = null;
                        }
                    }
                }

                if (currencyData == null)
                    throw new Exception("فشلت العملية");
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
            DataTable dtCurrencies = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllCurrencies", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            dtCurrencies.Load(reader);
                        }
                    }
                }

                if (dtCurrencies == null)
                    throw new Exception("فشلت العملية");
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
