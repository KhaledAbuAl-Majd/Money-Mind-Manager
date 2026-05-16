using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Core;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.DebtPayment;
using MoneyMindManager.Core.Paged_Result_DTOs;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Abstractions.Repositories;
using MoneyMindManager.Domain.Entities.DebtEntry;

namespace MoneyMindManager.Infrastructure.Repositories.Database.SQLServer
{
    public class SQLDebtEntryRepository : IDebtEntryRepository
    {
        private readonly IDatabaseSettings _databaseSettings;
        private readonly IResultFactory _resultFactory;
        private readonly ILogger _logger;

        public SQLDebtEntryRepository(IDatabaseSettings databaseSettings, IResultFactory resultFactory, ILogger logger)
        {
            this._databaseSettings = databaseSettings;
            this._resultFactory = resultFactory;
            this._logger = logger;
        }
        public async Task<IResult<int?>> Add(DebtEntry debtEntry)
        {
            int? newTransactionID = null;
            var handler = _resultFactory.Create<int?>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_DebtEntries_AddNew]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DebtID", debtEntry.DebtID);
                        command.Parameters.AddWithValue("@Amount", debtEntry.Amount);
                        command.Parameters.AddWithValue("@DebtDate", debtEntry.TransactionDate);
                        command.Parameters.AddWithValue("@Purpose", string.IsNullOrWhiteSpace(debtEntry.Purpose) ? DBNull.Value : (object)debtEntry.Purpose);
                        command.Parameters.AddWithValue("@CreatedByUserID", debtEntry.CreatedByUserID);

                        SqlParameter outParmNewCategory = new SqlParameter("@NewTransactionID", System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };

                        command.Parameters.Add(outParmNewCategory);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        newTransactionID = outParmNewCategory.Value as int?;
                    }
                }

                if (newTransactionID == null)
                    throw new Exception("فشلت العمية");
            }
            catch (Exception ex)
            {
                newTransactionID = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(newTransactionID);
        }
        public async Task<IResult<bool>> Update(DebtEntry debtEntry, int currentUserID)
        {
            bool result = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_DebtEntries_UpdateByID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TransactionID", debtEntry.MainTransactionID);
                        command.Parameters.AddWithValue("@Amount", debtEntry.Amount);
                        command.Parameters.AddWithValue("@Purpose", string.IsNullOrWhiteSpace(debtEntry.Purpose) ? DBNull.Value : (object)debtEntry.Purpose);
                        command.Parameters.AddWithValue("@DebtDate", debtEntry.TransactionDate);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);


                        SqlParameter retunValue = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(retunValue);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        result = (retunValue.Value != DBNull.Value) && (Convert.ToInt32(retunValue.Value) == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(result);
        }
        public async Task<IResult<bool>> Delete(int transactionID, int currentUserID)
        {
            bool result = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_DebtEntries_DeleteByID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TransactionID", transactionID);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);


                        SqlParameter retunValue = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(retunValue);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        result = (retunValue.Value != DBNull.Value) && (Convert.ToInt32(retunValue.Value) == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(result);
        }
        public async Task<IResult<DebtEntryShort>> Get(int transactionID, int currentUserID)
        {
            DebtEntryShort debtEntry = null;
            var handler = _resultFactory.Create<DebtEntryShort>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_DebtEntry_GetByID]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TransactionID", transactionID);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                int debtID = Convert.ToInt32(reader["DebtID"]);
                                debtEntry = new DebtEntryShort(debtID);
                            }
                        }
                    }
                }

                if (debtEntry == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                debtEntry = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(debtEntry);
        }
        public async Task<IResult<PagedResultWithValueDTO<DebtTransactionsViewSummary>>> GetAllPagedForDebt(int debtID, int currentUserID, int pageNumber, byte rowsPerPage)
        {
            PagedResultWithValueDTO<DebtTransactionsViewSummary> allTransactions = null;
            var handler = _resultFactory.Create<PagedResultWithValueDTO<DebtTransactionsViewSummary>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_DebtEntries_GetAllForDebt]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DebtID", debtID);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);
                        command.Parameters.AddWithValue("@PageNumber", pageNumber);
                        command.Parameters.AddWithValue("@RowsPerPage", rowsPerPage);

                        SqlParameter outputNumberOfPages = new SqlParameter("@NumberOfPages", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        SqlParameter outputRecordsCount = new SqlParameter("@RecordsCount", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        SqlParameter outputRemainingAmount = new SqlParameter("@RemainingAmount", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output,
                            Precision = 19,
                            Scale = 4
                        };

                        command.Parameters.Add(outputNumberOfPages);
                        command.Parameters.Add(outputRecordsCount);
                        command.Parameters.Add(outputRemainingAmount);

                        await connection.OpenAsync();
                        List<DebtTransactionsViewSummary> list;
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {

                            int idOrdinal = reader.GetOrdinal("MainTransactionID");
                            int amountOrdinal = reader.GetOrdinal("Amount");
                            int debtDateOrdinal = reader.GetOrdinal("DebtDate");
                            int createdDateOrdinal = reader.GetOrdinal("CreatedDate");
                            int userNameOrdinal = reader.GetOrdinal("CreatedByUserName");
                            int purposeOrdinal = reader.GetOrdinal("Purpose");

                            list = new List<DebtTransactionsViewSummary>();

                            while (await reader.ReadAsync())
                            {
                                int id = Convert.ToInt32(reader[idOrdinal]);
                                decimal amount = Convert.ToDecimal(reader[amountOrdinal]);
                                DateTime debtDate = Convert.ToDateTime(reader[debtDateOrdinal]);
                                DateTime createdDate = Convert.ToDateTime(reader[createdDateOrdinal]);
                                string userName = reader[userNameOrdinal] as string;
                                string purpose = reader[purposeOrdinal] as string;

                                list.Add(new DebtTransactionsViewSummary(id, amount, debtDate, userName, createdDate, purpose));
                            }
                        }
                        int numberOfPages = Convert.ToInt32(outputNumberOfPages.Value);
                        int recordsCount = Convert.ToInt32(outputRecordsCount.Value);
                        decimal remainingAmount = Convert.ToDecimal(outputRemainingAmount.Value);

                        allTransactions = new PagedResultWithValueDTO<DebtTransactionsViewSummary>(list, numberOfPages, recordsCount, remainingAmount);
                    }
                }

                if (allTransactions == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                allTransactions = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(allTransactions);
        }
        public async Task<IResult<IEnumerable<DebtTransactionsExportSummary>>> GetAllForDebt(int debtID, int currentUserID)
        {
            List<DebtTransactionsExportSummary> paymentsList = null;
            var handler = _resultFactory.Create<IEnumerable<DebtTransactionsExportSummary>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_DebtEntries_GetAllForDebtWihtoutPaging]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DebtID", debtID);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            int idOrdinal = reader.GetOrdinal("MainTransactionID");
                            int amountOrdinal = reader.GetOrdinal("Amount");
                            int debtDateOrdinal = reader.GetOrdinal("DebtDate");
                            int createdDateOrdinal = reader.GetOrdinal("CreatedDate");
                            int purposeOrdinal = reader.GetOrdinal("Purpose");
                            int userIDOrdinal = reader.GetOrdinal("CreatedByUserID");
                            int userNameOrdinal = reader.GetOrdinal("CreatedByUserName");
                            int accountIDOrinial = reader.GetOrdinal("AccountID");

                            paymentsList = new List<DebtTransactionsExportSummary>();

                            while (await reader.ReadAsync())
                            {
                                int id = Convert.ToInt32(reader[idOrdinal]);
                                decimal amount = Convert.ToDecimal(reader[amountOrdinal]);
                                DateTime debtDate = Convert.ToDateTime(reader[debtDateOrdinal]);
                                DateTime createdDate = Convert.ToDateTime(reader[createdDateOrdinal]);
                                string purpose = reader[purposeOrdinal] as string;
                                int userID = Convert.ToInt32(reader[userIDOrdinal]);
                                string userName = reader[userNameOrdinal] as string;
                                short accountID = Convert.ToInt16(reader[accountIDOrinial]);

                                paymentsList.Add(new DebtTransactionsExportSummary(id, amount, debtDate, userName, createdDate, purpose, userID, accountID));
                            }

                        }
                    }
                }

                if (paymentsList == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                paymentsList = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(paymentsList);
        }
    }
}
