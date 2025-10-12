using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManagerGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.clsReportClassess;

namespace MoneyMindManager_DataAccess
{
    public static class clsReportData
    {
        public static async Task<List<clsMonthlyFlow>> GetMonthlyFlow(bool RaiseEventOnErrorOccured = true)
        {
            List<clsMonthlyFlow> Data = new List<clsMonthlyFlow>();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Report_GetMonthlyFlow", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Data.Add(new clsMonthlyFlow(
                                    month: Convert.ToByte(reader["mon"]),
                                    income: Convert.ToDecimal(reader["Income"]),
                                    netExpense: Convert.ToDecimal(reader["NetExpense"]),
                                    netCashFlow: Convert.ToDecimal(reader["NetCashFlow"])
                                ));
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Data = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return Data;
        }
    }
}
