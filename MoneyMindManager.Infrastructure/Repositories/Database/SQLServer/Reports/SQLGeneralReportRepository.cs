using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Core;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.Reports;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Abstractions.Repositories.Reports;

namespace MoneyMindManager.Infrastructure.Repositories.Database.SQLServer.Reports
{
    public class SQLGeneralReportRepository : IGeneralReportRepository
    {
        private readonly IDatabaseSettings _databaseSettings;
        private readonly IResultFactory _resultFactory;
        private readonly ILogger _logger;

        public SQLGeneralReportRepository(IDatabaseSettings databaseSettings, IResultFactory resultFactory, ILogger logger)
        {
            this._databaseSettings = databaseSettings;
            this._resultFactory = resultFactory;
            this._logger = logger;
        }

        public async Task<IResult<IEnumerable<MonthlyFlowReportModel>>> GetMonthlyFlow(DateTime startDate, DateTime EndDate, short accountID)
        {
            List<MonthlyFlowReportModel> Data = new List<MonthlyFlowReportModel>();

            var handler = _resultFactory.Create<IEnumerable<MonthlyFlowReportModel>>();

            try
            {

                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
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
                                Data.Add(new MonthlyFlowReportModel(
                                    month: Convert.ToByte(reader["mon"]),
                                    year: Convert.ToInt16(reader["Year"]),
                                    income: Convert.ToDecimal(reader["Income"]),
                                    netExpense: Convert.ToDecimal(reader["NetExpense"]),
                                    netCashFlow: Convert.ToDecimal(reader["NetCashFlow"]),
                                    totalIncome: Convert.ToDecimal(reader["TotalIncome"]),
                                    totalNetExpense: Convert.ToDecimal(reader["TotalNetExpense"]),
                                    totalNetCashFlow: Convert.ToDecimal(reader["TotalNetCashFlow"])
                                ));
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Data = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(Data);
        }

        public async Task<IResult<MainKpisReportModel>> GetMainKPIS(short accountID)
        {
            MainKpisReportModel Data = null;
            var handler = _resultFactory.Create<MainKpisReportModel>();

            try
            {

                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
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

                                Data = new MainKpisReportModel(balance, totalReceivables, totalPayables, next30DayDebtsDue, dayPerformance,
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
                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(Data);
        }
    }
}
