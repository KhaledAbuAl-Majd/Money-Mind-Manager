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
        public static async Task<List<clsMonthlyFlow>> GetMonthlyFlow(DateTime startDate,DateTime EndDate,short accountID, bool RaiseEventOnErrorOccured = true)
        {
            List<clsMonthlyFlow> Data = new List<clsMonthlyFlow>();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Report_GetMonthlyFlow", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);
                        command.Parameters.AddWithValue("@AccountID", accountID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Data.Add(new clsMonthlyFlow(
                                    month: Convert.ToByte(reader["mon"]),
                                    year: Convert.ToInt16(reader["Year"]),
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

        public static async Task<clsMainKpis> GetMainKPIS(short accountID, bool RaiseEventOnErrorOccured = true)
        {
            clsMainKpis Data = null;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Report_GetMainKPIS", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AccountID", accountID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                decimal balance = Convert.ToDecimal(reader["Balance"]);
                                decimal totalReceivables = Convert.ToDecimal(reader["TotalReceivables"]);
                                decimal totalPayables = Convert.ToDecimal(reader["TotalPayables"]);
                                decimal next30DayDebtsDue = Convert.ToDecimal(reader["Next30DayDebtsDue"]);
                                decimal dayPerformance = Convert.ToDecimal(reader["DayPerformance"]);
                                decimal monthPerformance = Convert.ToDecimal(reader["MonthPerformance"]);
                                decimal yearPerformance = Convert.ToDecimal(reader["YearPerformance"]);
                                decimal avgNetProfitLast6Months = Convert.ToDecimal(reader["AvgNetProfitLast6Months"]);

                                Data = new clsMainKpis(balance, totalReceivables, totalPayables, next30DayDebtsDue, dayPerformance,
                                    monthPerformance, yearPerformance, avgNetProfitLast6Months);
                            }
                        }
                    }
                }

                if (Data == null)
                    throw new Exception("فشلت العملية");

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
