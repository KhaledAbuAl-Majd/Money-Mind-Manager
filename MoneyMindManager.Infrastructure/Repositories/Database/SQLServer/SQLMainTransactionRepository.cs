using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Core;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Abstractions.Repositories.Reports;
using MoneyMindManager.Domain.Criteria;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.Paged_Result_DTOs;

namespace MoneyMindManager.Infrastructure.Repositories.Database.SQLServer
{
    public class SQLMainTransactionRepository : IMainTransactionRepository
    {
        private readonly IDatabaseSettings _databaseSettings;
        private readonly IResultFactory _resultFactory;
        private readonly ILogger _logger;

        public SQLMainTransactionRepository(IDatabaseSettings databaseSettings, IResultFactory resultFactory, ILogger logger)
        {
            this._databaseSettings = databaseSettings;
            this._resultFactory = resultFactory;
            this._logger = logger;
        }

        public async Task<IResult<MainTransaction>> Get(int transactionID, int currentUserID)
        {
            MainTransaction data = null;
            var handler = _resultFactory.Create<MainTransaction>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_MainTransactions_GetByID]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MainTransactionID", transactionID);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                decimal amount = Convert.ToDecimal(reader["Amount"]);
                                DateTime createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                                short accountID = Convert.ToInt16(reader["AccountID"]);
                                int createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                byte transactionTypeID = Convert.ToByte(reader["TransactionTypeID"]);
                                string purpose = reader["Purpose"] as string;
                                bool IsLocked = Convert.ToBoolean(reader["IsLocked"]);
                                DateTime transactionDate = Convert.ToDateTime(reader["TransactionDate"]);
                                string transactionTypeName = reader["TransactionTypeName"] as string;
                                string createdByUserName = reader["CreatedByUserName"] as string;

                                data = new MainTransaction(transactionID, amount, createdDate, accountID,
                                    createdByUserID, transactionTypeID, purpose, IsLocked, transactionDate, transactionTypeName, createdByUserName);
                            }
                            else
                                data = null;
                        }
                    }
                }

                if (data == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                data = null;

                _logger.LogError(ex.Message);
                handler.Failure(ex.Message);
            }

            return handler.Success(data);
        }

        public async Task<IResult<PagedResultWithAmountDTO<MainTransaction>>> GetAllPaged(MainTransactionPagedSearchCriteria searchCriteria, int currentUserID)
        {
            PagedResultWithAmountDTO<MainTransaction> data = null;
            var handler = _resultFactory.Create<PagedResultWithAmountDTO<MainTransaction>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_MainTransactions_GetAll]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TransactionID", (object)searchCriteria.TransactionID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UserName", string.IsNullOrWhiteSpace(searchCriteria.CreatedByUserName) ? DBNull.Value : (object)searchCriteria.CreatedByUserName);
                        command.Parameters.AddWithValue("@Purpose", string.IsNullOrWhiteSpace(searchCriteria.Purpose) ? DBNull.Value : (object)searchCriteria.Purpose);
                        command.Parameters.AddWithValue("@TransactionTypes", string.IsNullOrWhiteSpace(searchCriteria.TransactionTypes) ? DBNull.Value : (object)searchCriteria.TransactionTypes);
                        command.Parameters.AddWithValue("@FromCreatedDate", (object)searchCriteria.FromCreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ToCreatedDate", (object)searchCriteria.ToCreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FromTransactionDate", (object)searchCriteria.FromTransactionDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ToTransactionDate", (object)searchCriteria.ToTransactionDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TextSearchMode", searchCriteria.TextSearchMode);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);
                        command.Parameters.AddWithValue("@PageNumber", searchCriteria.PageNumber);
                        command.Parameters.AddWithValue("@RowsPerPage", searchCriteria.RowsPerPage);

                        SqlParameter outputNumberOfPages = new SqlParameter("@NumberOfPages", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        SqlParameter outputRecordsCount = new SqlParameter("@RecordsCount", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        SqlParameter outputTotalTransactionsValue = new SqlParameter("@TotalTransactionsValue", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output,
                            Precision = 19,
                            Scale = 4
                        };

                        SqlParameter outputCurrentPageTransactionsValue = new SqlParameter("@CurrentPageTransactionsValue", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output,
                            Precision = 19,
                            Scale = 4
                        };

                        command.Parameters.Add(outputNumberOfPages);
                        command.Parameters.Add(outputRecordsCount);
                        command.Parameters.Add(outputTotalTransactionsValue);
                        command.Parameters.Add(outputCurrentPageTransactionsValue);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            int idOrdinal = reader.GetOrdinal("TransactionID");
                            int amountOrdinal = reader.GetOrdinal("Amount");
                            int transactionDateOrdinal = reader.GetOrdinal("TransactionDate");
                            int createdDateOrdinal = reader.GetOrdinal("CreatedDate");
                            int transactionTypeOrdianal = reader.GetOrdinal("TransactionTypeName");
                            int userNameOrdinal = reader.GetOrdinal("CreatedByUserName");
                            int purposeOrdinal = reader.GetOrdinal("Purpose");

                            List<MainTransaction> transactionsList = new List<MainTransaction>();

                            while (await reader.ReadAsync())
                            {
                                int id = Convert.ToInt32(reader[idOrdinal]);
                                decimal amount = Convert.ToDecimal(reader[amountOrdinal]);
                                DateTime transactionDate = Convert.ToDateTime(reader[transactionDateOrdinal]);
                                DateTime createdDate = Convert.ToDateTime(reader[createdDateOrdinal]);
                                string userName = reader[userNameOrdinal] as string;
                                string purpose = reader[purposeOrdinal] as string;

                                MainTransaction transaction = new MainTransaction()
                                {
                                    MainTransactionID = id,
                                    Amount = amount,
                                    TransactionDate = transactionDate,
                                    CreatedDate = createdDate,
                                    CreatedByUserName = userName,
                                    Purpose = purpose
                                };

                                transactionsList.Add(transaction);
                            }

                            int numberOfPages = Convert.ToInt32(outputNumberOfPages.Value);
                            int recordsCount = Convert.ToInt32(outputRecordsCount.Value);

                            data = new PagedResultWithAmountDTO<MainTransaction>(transactionsList, numberOfPages, recordsCount,
                                Convert.ToDecimal(outputTotalTransactionsValue.Value), Convert.ToDecimal(outputCurrentPageTransactionsValue.Value));
                        }
                    }
                }

                if (data == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                data = null;

                _logger.LogError(ex.Message);
                handler.Failure(ex.Message);
            }

            return handler.Success(data);
        }

        public async Task<IResult<IEnumerable<MainTransaction>>> GetAll(MainTransactionSearchCriteria searchCriteria, int currentUserID)
        {
            List<MainTransaction> transactionsList = null;
            var handler = _resultFactory.Create<IEnumerable<MainTransaction>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_MainTransactions_GetAllWithoutPaging]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TransactionID", (object)searchCriteria.TransactionID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UserName", string.IsNullOrWhiteSpace(searchCriteria.CreatedByUserName) ? DBNull.Value : (object)searchCriteria.CreatedByUserName);
                        command.Parameters.AddWithValue("@Purpose", string.IsNullOrWhiteSpace(searchCriteria.Purpose) ? DBNull.Value : (object)searchCriteria.Purpose);
                        command.Parameters.AddWithValue("@TransactionTypes", string.IsNullOrWhiteSpace(searchCriteria.TransactionTypes) ? DBNull.Value : (object)searchCriteria.TransactionTypes);
                        command.Parameters.AddWithValue("@FromCreatedDate", (object)searchCriteria.FromCreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ToCreatedDate", (object)searchCriteria.ToCreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FromTransactionDate", (object)searchCriteria.FromTransactionDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ToTransactionDate", (object)searchCriteria.ToTransactionDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TextSearchMode", searchCriteria.TextSearchMode);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);


                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            int idOrdinal = reader.GetOrdinal("TransactionID");
                            int amountOrdinal = reader.GetOrdinal("Amount");
                            int transactionDateOrdinal = reader.GetOrdinal("TransactionDate");
                            int createdDateOrdinal = reader.GetOrdinal("CreatedDate");
                            int transactionTypeOrdianal = reader.GetOrdinal("TransactionTypeName");
                            int userNameOrdinal = reader.GetOrdinal("CreatedByUserName");
                            int purposeOrdinal = reader.GetOrdinal("Purpose");
                            int transactionTypeIDOrdinal = reader.GetOrdinal("TransactionTypeID");
                            int userIDOrdinal = reader.GetOrdinal("CreatedByUserID");
                            int accountIDOrdinal = reader.GetOrdinal("AccountID");

                            transactionsList = new List<MainTransaction>();

                            while (await reader.ReadAsync())
                            {
                                int id = Convert.ToInt32(reader[idOrdinal]);
                                decimal amount = Convert.ToDecimal(reader[amountOrdinal]);
                                DateTime transactionDate = Convert.ToDateTime(reader[transactionDateOrdinal]);
                                DateTime createdDate = Convert.ToDateTime(reader[createdDateOrdinal]);
                                string userName = reader[userNameOrdinal] as string;
                                string purpose = reader[purposeOrdinal] as string;
                                byte transactionTypeID = Convert.ToByte(reader[transactionTypeIDOrdinal]);
                                int userID = Convert.ToInt32(reader[userIDOrdinal]);
                                short accountID = Convert.ToInt16(reader[accountIDOrdinal]);

                                MainTransaction transaction = new MainTransaction()
                                {
                                    MainTransactionID = id,
                                    Amount = amount,
                                    TransactionDate = transactionDate,
                                    CreatedDate = createdDate,
                                    CreatedByUserName = userName,
                                    Purpose = purpose,
                                    TransactionTypeID = transactionTypeID,
                                    CreatedByUserID = userID,
                                    AccountID = accountID
                                };

                                transactionsList.Add(transaction);
                            }
                        }
                    }
                }

                if (transactionsList == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                transactionsList = null;

                _logger.LogError(ex.Message);
                handler.Failure(ex.Message);
            }

            return handler.Success(transactionsList);
        }
    }
}
