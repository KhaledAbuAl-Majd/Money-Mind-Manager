using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Core;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.Reports.Debts;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Abstractions.Repositories.Reports;

namespace MoneyMindManager.Infrastructure.Repositories.Database.SQLServer.Reports
{
    public class SQLDebtsReportRepository : IDebtsReportRepository
    {
        private readonly IDatabaseSettings _databaseSettings;
        private readonly IResultFactory _resultFactory;
        private readonly ILogger _logger;

        public SQLDebtsReportRepository(IDatabaseSettings databaseSettings, IResultFactory resultFactory, ILogger logger)
        {
            this._databaseSettings = databaseSettings;
            this._resultFactory = resultFactory;
            this._logger = logger;
        }

        public async Task<IResult<IEnumerable<DebtRepaymentScheduleReportModel>>> GetDebtsRepaymentSchedule(short accountID)
        {
            List<DebtRepaymentScheduleReportModel> Data = new List<DebtRepaymentScheduleReportModel>();
            var handler = _resultFactory.Create<IEnumerable<DebtRepaymentScheduleReportModel>>();


            try
            {

                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
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
                                Data.Add(new DebtRepaymentScheduleReportModel(
                                    month: (reader["mon"] == DBNull.Value) ? null : Convert.ToByte(reader["mon"]) as byte?,
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

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(Data);
        }

        public async Task<IResult<IEnumerable<TopDebtorsRankingReportModel>>> GetTopDebtorsRanking(bool isLending, short accountID)
        {
            List<TopDebtorsRankingReportModel> Data = new List<TopDebtorsRankingReportModel>();
            var handler = _resultFactory.Create<IEnumerable<TopDebtorsRankingReportModel>>();

            try
            {

                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
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
                                Data.Add(new TopDebtorsRankingReportModel(
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

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(Data);
        }

        public async Task<IResult<IEnumerable<TopPeopleDebtsSumRankingReportModel>>> GetTopPeopleDebtsSumRanking(bool isLending, short accountID)
        {
            List<TopPeopleDebtsSumRankingReportModel> Data = new List<TopPeopleDebtsSumRankingReportModel>();
            var handler = _resultFactory.Create<IEnumerable<TopPeopleDebtsSumRankingReportModel>>();

            try
            {

                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
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
                                Data.Add(new TopPeopleDebtsSumRankingReportModel(
                                    personID: Convert.ToInt32(reader["PersonID"]),
                                    personName: Convert.ToString(reader["PersonName"]),
                                    personDebtsSum: Convert.ToDecimal(reader["PersonDebtsSum"]),
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

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(Data);
        }

        public async Task<IResult<IEnumerable<DebtsMonthlyFlowReportModel>>> GetDebtsMonthlyFlow(DateTime startDate, DateTime EndDate, short accountID)
        {
            List<DebtsMonthlyFlowReportModel> Data = new List<DebtsMonthlyFlowReportModel>();
            var handler = _resultFactory.Create<IEnumerable<DebtsMonthlyFlowReportModel>>();

            try
            {

                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
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
                                Data.Add(new DebtsMonthlyFlowReportModel(
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

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(Data);
        }

    }
}
