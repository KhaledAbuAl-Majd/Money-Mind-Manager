using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Core;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.Reports.Categories;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Abstractions.Repositories.Reports;

namespace MoneyMindManager.Infrastructure.Repositories.Database.SQLServer.Reports
{
    public class SQLCategoriesReportRepository : ICategoriesReportRepository
    {
        private readonly IDatabaseSettings _databaseSettings;
        private readonly IResultFactory _resultFactory;
        private readonly ILogger _logger;

        public SQLCategoriesReportRepository(IDatabaseSettings databaseSettings, IResultFactory resultFactory, ILogger logger)
        {
            this._databaseSettings = databaseSettings;
            this._resultFactory = resultFactory;
            this._logger = logger;
        }

        public async Task<IResult<IEnumerable<TopCategoriesReportModel>>> GetTopCategories(DateTime? startDate, DateTime? EndDate, bool isIncome, short accountID)
        {
            List<TopCategoriesReportModel> Data = new List<TopCategoriesReportModel>();
            var handler = _resultFactory.Create<IEnumerable<TopCategoriesReportModel>>();

            try
            {

                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
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
                                Data.Add(new TopCategoriesReportModel(
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

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(Data);
        }

        public async Task<IResult<IEnumerable<CategoryMonthlyFlowReportModel>>> GetCategoryMonthlyFlow(int categoryID, DateTime startDate, DateTime EndDate, short accountID)
        {
            List<CategoryMonthlyFlowReportModel> Data = new List<CategoryMonthlyFlowReportModel>();
            var handler = _resultFactory.Create<IEnumerable<CategoryMonthlyFlowReportModel>>();

            try
            {

                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
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
                                Data.Add(new CategoryMonthlyFlowReportModel(
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

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(Data);
        }
    }
}
