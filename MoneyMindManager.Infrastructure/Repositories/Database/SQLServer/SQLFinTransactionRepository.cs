using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Core;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.FinTransaction;
using MoneyMindManager.Core.Paged_Result_DTOs;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Entities.FinTransaction;

namespace MoneyMindManager.Infrastructure.Repositories.Database.SQLServer
{
    public class SQLFinTransactionRepository : IFinTransactionRepository
    {
        private readonly IDatabaseSettings _databaseSettings;
        private readonly IResultFactory _resultFactory;
        private readonly ILogger _logger;

        public SQLFinTransactionRepository(IDatabaseSettings databaseSettings, IResultFactory resultFactory, ILogger logger)
        {
            this._databaseSettings = databaseSettings;
            this._resultFactory = resultFactory;
            this._logger = logger;
        }
        public async Task<IResult<int?>> Add(FinTransaction finTransaction)
        {
            int? newTransactionID = null;
            var handler = _resultFactory.Create<int?>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseTransaction_AddNew]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@VoucherID", finTransaction.VoucherID);
                        command.Parameters.AddWithValue("@categoryID", finTransaction.CategoryID);
                        command.Parameters.AddWithValue("@Amount", finTransaction.Amount);
                        command.Parameters.AddWithValue("@Purpose", string.IsNullOrWhiteSpace(finTransaction.Purpose) ? DBNull.Value : (object)finTransaction.Purpose);
                        command.Parameters.AddWithValue("@CreatedByUserID", finTransaction.CreatedByUserID);

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
        public async Task<IResult<bool>> Update(FinTransaction finTransaction, int currentUserID)
        {
            bool result = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseTransactions_UpdateByID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TransactionID", finTransaction.MainTransactionID);
                        command.Parameters.AddWithValue("@Amount", finTransaction.Amount);
                        command.Parameters.AddWithValue("@categoryID", finTransaction.CategoryID);
                        command.Parameters.AddWithValue("@Purpose", string.IsNullOrWhiteSpace(finTransaction.Purpose) ? DBNull.Value : (object)finTransaction.Purpose);
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
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseTransactions_DeleteByID]", connection))
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
        public async Task<IResult<FinTransactionShort>> Get(int transactionID, int currentUserID)
        {
            FinTransactionShort result = null;
            var handler = _resultFactory.Create<FinTransactionShort>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseTransaction_GetByID]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TransactionID", transactionID);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            int voucherID = 0;
                            int categoryID = 0;

                            if (await reader.ReadAsync())
                            {
                                voucherID = Convert.ToInt32(reader["VoucherID"]);
                                categoryID = Convert.ToInt32(reader["CategoryID"]);
                            }

                            result = new FinTransactionShort(transactionID, voucherID, categoryID);
                        }
                    }
                }

                if (result == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                result = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(result);
        }
        public async Task<IResult<PagedResultWithValueDTO<FinTransactionViewSummary>>> GetAllPagedForVoucher(int voucherID, int currentUserID, int pageNumber, byte rowsPerPage)
        {
            PagedResultWithValueDTO<FinTransactionViewSummary> allTransactions = null;
            var handler = _resultFactory.Create<PagedResultWithValueDTO<FinTransactionViewSummary>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_IncomeAndExpenseTransactionGetAllForVoucher", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@VoucherID", voucherID);
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

                        SqlParameter outputVoucherValue = new SqlParameter("@VoucherValue", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output,
                            Precision = 19,
                            Scale = 4
                        };

                        command.Parameters.Add(outputNumberOfPages);
                        command.Parameters.Add(outputRecordsCount);
                        command.Parameters.Add(outputVoucherValue);

                        await connection.OpenAsync();
                        List<FinTransactionViewSummary> list;
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            int idOrdinal = reader.GetOrdinal("MainTransactionID");
                            int categoryNameOrdinal = reader.GetOrdinal("CategoryName");
                            int amountOrdinal = reader.GetOrdinal("Amount");
                            int createdDateOrdinal = reader.GetOrdinal("CreatedDate");
                            int userNameOrdinal = reader.GetOrdinal("CreatedByUserName");
                            int purposeOrdinal = reader.GetOrdinal("Purpose");

                            list = new List<FinTransactionViewSummary>();

                            while (await reader.ReadAsync())
                            {
                                int id = Convert.ToInt32(reader[idOrdinal]);
                                string categoryName = reader[categoryNameOrdinal] as string;
                                decimal amount = Convert.ToDecimal(reader[amountOrdinal]);
                                DateTime createdDate = Convert.ToDateTime(reader[createdDateOrdinal]);
                                string userName = reader[userNameOrdinal] as string;
                                string purpose = reader[purposeOrdinal] as string;

                                list.Add(new FinTransactionViewSummary(id, categoryName, amount, userName, createdDate, purpose));
                            }

                        }
                        int numberOfPages = Convert.ToInt32(outputNumberOfPages.Value);
                        int recordsCount = Convert.ToInt32(outputRecordsCount.Value);
                        decimal voucherValue = Convert.ToDecimal(outputVoucherValue.Value);

                        allTransactions = new PagedResultWithValueDTO<FinTransactionViewSummary>(list, numberOfPages, recordsCount, voucherValue);
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
        public async Task<IResult<IEnumerable<FinTransactionExportSummary>>> GetAllForVoucher(int voucherID, int currentUserID)
        {
            List<FinTransactionExportSummary> result = null;
            var handler = _resultFactory.Create<IEnumerable<FinTransactionExportSummary>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_IncomeAndExpenseTransactionGetAllForVoucherWithoutPaging", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@VoucherID", voucherID);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            int idOrdinal = reader.GetOrdinal("MainTransactionID");
                            int categoryIDOrdinal = reader.GetOrdinal("CategoryID");
                            int categoryNameOrdinal = reader.GetOrdinal("CategoryName");
                            int amountOrdinal = reader.GetOrdinal("Amount");
                            int transactionDateOrdinal = reader.GetOrdinal("TransactionDate");
                            int createdDateOrdinal = reader.GetOrdinal("CreatedDate");
                            int userIDOrdinal = reader.GetOrdinal("CreatedByUserID");
                            int userNameOrdinal = reader.GetOrdinal("CreatedByUserName");
                            int purposeOrdinal = reader.GetOrdinal("Purpose");
                            int accountIDOrinial = reader.GetOrdinal("AccountID");

                            result = new List<FinTransactionExportSummary>();

                            while (await reader.ReadAsync())
                            {
                                int id = Convert.ToInt32(reader[idOrdinal]);
                                int categoryID = Convert.ToInt32(reader[categoryIDOrdinal]);
                                string categoryName = reader[categoryNameOrdinal] as string;
                                decimal amount = Convert.ToDecimal(reader[amountOrdinal]);
                                DateTime transactionDate = Convert.ToDateTime(reader[transactionDateOrdinal]);
                                DateTime createdDate = Convert.ToDateTime(reader[createdDateOrdinal]);
                                int userID = Convert.ToInt32(reader[userIDOrdinal]);
                                string userName = reader[userNameOrdinal] as string;
                                string purpose = reader[purposeOrdinal] as string;
                                short accountID = Convert.ToInt16(reader[accountIDOrinial]);

                                result.Add(new FinTransactionExportSummary(id, categoryName, amount, userName, createdDate, purpose, categoryID, transactionDate,
                                    userID, accountID));
                            }
                        }
                    }
                }

                if (result == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                result = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(result);
        }
    }
}
