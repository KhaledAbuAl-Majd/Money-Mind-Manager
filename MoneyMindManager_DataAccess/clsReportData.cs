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
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
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
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return Data;
        }

        public static async Task<List<clsDebtRepaymentSchedule>> GetDebtsRepaymentSchedule(short accountID, bool RaiseEventOnErrorOccured = true)
        {
            List<clsDebtRepaymentSchedule> Data = new List<clsDebtRepaymentSchedule>();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Report_GetDebtsRepaymentSchedule", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AccountID", accountID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Data.Add(new clsDebtRepaymentSchedule(
                                    month: (reader["mon"] == DBNull.Value)? null: Convert.ToByte(reader["mon"]) as byte?,
                                    year: (reader["Year"] == DBNull.Value) ? null : Convert.ToInt16(reader["Year"]) as short?,
                                    receivable: Convert.ToDecimal(reader["Receivable"]),
                                    payables: Convert.ToDecimal(reader["Payables"]),
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
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return Data;
        }

        public static async Task<List<clsTopDebtorsRanking>> GetTopDebtorsRanking(bool isLending, short accountID, bool RaiseEventOnErrorOccured = true)
        {
            List<clsTopDebtorsRanking> Data = new List<clsTopDebtorsRanking>();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Report_Top5DebtorsRanking", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@IsLending", isLending);
                        command.Parameters.AddWithValue("@AccountID", accountID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Data.Add(new clsTopDebtorsRanking(
                                    personID: Convert.ToInt32(reader["PersonID"]),
                                    personName: Convert.ToString(reader["PersonName"]),
                                    personRemaining: Convert.ToDecimal(reader["PersonRemaining"]),
                                    personOrder: Convert.ToInt32(reader["PersonOrder"])
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
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return Data;
        }

        public static async Task<List<clsTopPeopleDebtsSumRanking>> GetTopPeopleDebtsSumRanking(bool isLending, short accountID, bool RaiseEventOnErrorOccured = true)
        {
            List<clsTopPeopleDebtsSumRanking> Data = new List<clsTopPeopleDebtsSumRanking>();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_Report_Top5PeopleDebtsSumRanking]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@IsLending", isLending);
                        command.Parameters.AddWithValue("@AccountID", accountID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Data.Add(new clsTopPeopleDebtsSumRanking(
                                    personID: Convert.ToInt32(reader["PersonID"]),
                                    personName: Convert.ToString(reader["PersonName"]),
                                    personDebtsSum : Convert.ToDecimal(reader["PersonDebtsSum"]),
                                    personOrder: Convert.ToInt32(reader["PersonOrder"])
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
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return Data;
        }

        public static async Task<List<clsDebtsMonthlyFlow>> GetDebtsMonthlyFlow(DateTime startDate, DateTime EndDate, short accountID, bool RaiseEventOnErrorOccured = true)
        {
            List<clsDebtsMonthlyFlow> Data = new List<clsDebtsMonthlyFlow>();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[SP_Report_GetDebtsMonthlyFlow]", connection))
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
                                Data.Add(new clsDebtsMonthlyFlow(
                                    month: Convert.ToByte(reader["mon"]),
                                    year: Convert.ToInt16(reader["Year"]),
                                    lendingDebtsSum: Convert.ToDecimal(reader["LendingDebtsSum"]),
                                    borrowingDebtsSum: Convert.ToDecimal(reader["BorrowingDebtsSum"]),
                                    lendingPaymentsSum: Convert.ToDecimal(reader["LendingPaymentsSum"]),
                                    borrowingPaymentsSum: Convert.ToDecimal(reader["BorrowingPaymentsSum"])
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
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return Data;
        }

        public static async Task<List<clsTopCategories >> GetTopCategories(DateTime? startDate, DateTime? EndDate,bool isIncome, short accountID, bool RaiseEventOnErrorOccured = true)
        {
            List<clsTopCategories> Data = new List<clsTopCategories>();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Report_GetTopCategories", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@StartDate", (object)startDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@EndDate", (object)EndDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsIncome", isIncome);
                        command.Parameters.AddWithValue("@AccountID", accountID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Data.Add(new clsTopCategories(
                                    categoryName: reader["CategoryName"].ToString(),
                                    value: Convert.ToDecimal(reader["Value"]),
                                    ranking: Convert.ToInt32(reader["Ranking"]),
                                    percentage: Convert.ToDecimal(reader["Percentage"]) 
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
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return Data;
        }

        public static async Task<List<clsCategoryMonthlyFlow>> GetCategoryMonthlyFlow(int categoryID, DateTime startDate, DateTime EndDate, short accountID, bool RaiseEventOnErrorOccured = true)
        {
            List<clsCategoryMonthlyFlow> Data = new List<clsCategoryMonthlyFlow>();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_Report_GetCategoryMonthlyFlow]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryID", categoryID);
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);
                        command.Parameters.AddWithValue("@AccountID", accountID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Data.Add(new clsCategoryMonthlyFlow(
                                    month: Convert.ToByte(reader["mon"]),
                                    year: Convert.ToInt16(reader["Year"]),
                                    categorySum: Convert.ToDecimal(reader["CategorySum"]),
                                    categorySonsSum: Convert.ToDecimal(reader["CategorySonsSum"]),
                                    total: Convert.ToDecimal(reader["Total"])
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
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return Data;
        }

    }
}
