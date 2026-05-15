using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Core;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.Debt;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Abstractions.Repositories;
using MoneyMindManager.Domain.Criteria.Debt;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.Paged_Result_DTOs;

namespace MoneyMindManager.Infrastructure.Repositories.Database.SQLServer.Reports
{
    public class SQLDebtRepository : IDebtRepository
    {
        private readonly IDatabaseSettings _databaseSettings;
        private readonly IResultFactory _resultFactory;
        private readonly ILogger _logger;

        public SQLDebtRepository(IDatabaseSettings databaseSettings, IResultFactory resultFactory, ILogger logger)
        {
            this._databaseSettings = databaseSettings;
            this._resultFactory = resultFactory;
            this._logger = logger;
        }
        public async Task<IResult<int?>> Add(Debt debt)
        {
            int? newDebtID = null;
            _resultFactory.Create<int?>();

            var handler = _resultFactory.Create<int?>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_Debts_AddNew]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@IsLending", debt.IsLending);
                        command.Parameters.AddWithValue("@PersonID", debt.PersonID);
                        command.Parameters.AddWithValue("@PaymentDueDate", (object)debt.PaymentDueDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(debt.Notes) ? DBNull.Value : (object)debt.Notes);
                        command.Parameters.AddWithValue("@IsLocked", debt.IsLocked);
                        command.Parameters.AddWithValue("@DebtDate", debt.DebtDate);
                        command.Parameters.AddWithValue("@CreatedByUserID", debt.CreatedByUserID);

                        SqlParameter outParmNewDebt = new SqlParameter("@NewDebtID", System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };

                        command.Parameters.Add(outParmNewDebt);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        newDebtID = outParmNewDebt.Value as int?;
                    }
                }

                if (newDebtID == null)
                    throw new Exception("فشلت العمية");
            }
            catch (Exception ex)
            {
                newDebtID = null;


                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(newDebtID);
        }
        public async Task<IResult<(bool UpdateResult, decimal RemainingAmount)>> Update(Debt debt, int currentUserID)
        {
            bool result = false;
            decimal remainingAmount = -99999;

            var handler = _resultFactory.Create<(bool UpdateResult, decimal RemainingAmount)>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_Debts_UpdateByDebtID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DebtID", debt.DebtID);
                        command.Parameters.AddWithValue("@PaymentDueDate", (object)debt.PaymentDueDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(debt.Notes) ? DBNull.Value : (object)debt.Notes);
                        command.Parameters.AddWithValue("@DebtDate", debt.DebtDate);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        SqlParameter retunValue = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.ReturnValue
                        };

                        SqlParameter outRemainingAmount = new SqlParameter("@RemainingAmount", SqlDbType.Decimal)
                        {
                            Direction = System.Data.ParameterDirection.Output,
                            Precision = 19,
                            Scale = 4
                        };

                        command.Parameters.Add(retunValue);
                        command.Parameters.Add(outRemainingAmount);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        result = (retunValue.Value != DBNull.Value) && (Convert.ToInt32(retunValue.Value) == 1);
                        remainingAmount = Convert.ToDecimal(outRemainingAmount.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
                remainingAmount = -99999999;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success((result, remainingAmount));
        }
        public async Task<IResult<bool>> ChangeLockingByID(int debtID, bool isLocked, int currentUserID)
        {
            bool result = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_Debts_ChangeLocking]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DebtID", debtID);
                        command.Parameters.AddWithValue("@IsLocked", isLocked);
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
        public async Task<IResult<bool>> Delete(int debtID, int currentUserID)
        {
            bool result = false;
            var handler = _resultFactory.Create<bool>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_Debts_DeleteByDebtID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DebtID", debtID);
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
        public async Task<IResult<Debt>> Get(int debtID, int currentUserID)
        {
            Debt debtData = null;
            var handler = _resultFactory.Create<Debt>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_Debts_GetByID]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DebtID", debtID);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                bool isLending = Convert.ToBoolean(reader["IsLending"]);
                                int personID = Convert.ToInt32(reader["PersonID"]);
                                DateTime? paymentDueDate = (reader["PaymentDueDate"] == DBNull.Value) ? null : Convert.ToDateTime(reader["PaymentDueDate"]) as DateTime?;
                                short accountID = Convert.ToInt16(reader["AccountID"]);
                                int createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                string userName = reader["UserName"] as string;
                                bool isLocked = Convert.ToBoolean(reader["IsLocked"]);
                                decimal totalValue = Convert.ToDecimal(reader["TotalValue"]);
                                decimal totalPaid = Convert.ToDecimal(reader["TotalPaid"]);
                                decimal remainingAmount = Convert.ToDecimal(reader["RemainingAmount"]);
                                DateTime debtDate = Convert.ToDateTime(reader["DebtDate"]);
                                DateTime createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                                string notes = reader["Notes"] as string;

                                debtData = new Debt()
                                {
                                    DebtID = debtID,
                                    IsLending = isLending,
                                    PersonID = personID,
                                    PaymentDueDate = paymentDueDate,
                                    AccountID = accountID,
                                    CreatedByUserID = createdByUserID,
                                    CreatedByUserName = userName,
                                    IsLocked = isLocked,
                                    TotalValue = totalValue,
                                    TotalPaid = totalPaid,
                                    RemainingAmount = remainingAmount,
                                    DebtDate = debtDate,
                                    CreatedDate = createdDate,
                                    Notes = notes
                                };
                            }
                        }
                    }
                }

                if (debtData == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                debtData = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(debtData);
        }
        public async Task<IResult<DebtsPagedResultDTO<DebtViewSummary>>> GetAllPaged(DebtPagedSearchCriteria criteria, int currentUserID)
        {
            DebtsPagedResultDTO<DebtViewSummary> allDebts = null;
            var handler = _resultFactory.Create<DebtsPagedResultDTO<DebtViewSummary>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_Debts_GetAll]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DebtID", (object)criteria.DebtID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsLending", (object)criteria.IsLending ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PersonName", string.IsNullOrWhiteSpace(criteria.PersonName) ? DBNull.Value : (object)criteria.PersonName);
                        command.Parameters.AddWithValue("@UserName", string.IsNullOrWhiteSpace(criteria.UserName) ? DBNull.Value : (object)criteria.UserName);
                        command.Parameters.AddWithValue("@FromCreatedDate", (object)criteria.FromCreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ToCreatedDate", (object)criteria.ToCreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FromDebtDate", (object)criteria.FromDebtDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ToDebtDate", (object)criteria.ToDebtDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsPaid", (object)criteria.IsPaid ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TextSearchMode", criteria.TextSearchMode);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);
                        command.Parameters.AddWithValue("@PageNumber", criteria.PageNumber);
                        command.Parameters.AddWithValue("@RowsPerPage", criteria.RowsPerPage);

                        SqlParameter outputNumberOfPages = new SqlParameter("@NumberOfPages", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        SqlParameter outputRecordsCount = new SqlParameter("@RecordsCount", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        SqlParameter outputTotalDebtsValue = new SqlParameter("@TotalDebtsValue", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output,
                            Precision = 19,
                            Scale = 4
                        };

                        SqlParameter outputCurrentPageDebtsValue = new SqlParameter("@CurrentPageDebtsValue", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output,
                            Precision = 19,
                            Scale = 4
                        };

                        SqlParameter outputTotalRemainingAmount = new SqlParameter("@TotalRemainingAmount", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output,
                            Precision = 19,
                            Scale = 4
                        };
                        SqlParameter outputCurrentPageRemainingAmount = new SqlParameter("@CurrentPageRemainingAmount", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output,
                            Precision = 19,
                            Scale = 4
                        };

                        command.Parameters.Add(outputNumberOfPages);
                        command.Parameters.Add(outputRecordsCount);
                        command.Parameters.Add(outputTotalDebtsValue);
                        command.Parameters.Add(outputCurrentPageDebtsValue);
                        command.Parameters.Add(outputTotalRemainingAmount);
                        command.Parameters.Add(outputCurrentPageRemainingAmount);

                        await connection.OpenAsync();
                        List<DebtViewSummary> list;
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {

                            int debtIDOrdinal = reader.GetOrdinal("DebtID");
                            int personNameOrdinal = reader.GetOrdinal("PersonName");
                            int debtValueOrdinal = reader.GetOrdinal("DebtValue");
                            int remainingAmoutOrdinal = reader.GetOrdinal("RemainingAmount");
                            int debtDateOrdinal = reader.GetOrdinal("DebtDate");
                            int createdDaterdinal = reader.GetOrdinal("CreatedDate");
                            int debtTypeOrdinal = reader.GetOrdinal("DebtType");
                            int userNameOrdinal = reader.GetOrdinal("CreatedByUserName");

                            list = new List<DebtViewSummary>();

                            while (await reader.ReadAsync())
                            {
                                int id = Convert.ToInt32(reader[debtIDOrdinal]);
                                string personName = reader[personNameOrdinal] as string;
                                decimal debtValue = Convert.ToDecimal(reader[debtValueOrdinal]);
                                decimal remainingAmount = Convert.ToDecimal(reader[remainingAmoutOrdinal]);
                                DateTime debtDate = Convert.ToDateTime(reader[debtDateOrdinal]);
                                DateTime createdDate = Convert.ToDateTime(reader[debtDateOrdinal]);
                                string debtType = reader[debtTypeOrdinal] as string;
                                string userName = reader[userNameOrdinal] as string;

                                list.Add(new DebtViewSummary(id, personName, debtValue, remainingAmount, debtDate, createdDate, debtType, userName));
                            }

                        }
                        int numberOfPages = Convert.ToInt32(outputNumberOfPages.Value);
                        int recordsCount = Convert.ToInt32(outputRecordsCount.Value);
                        decimal totalDebtsValue = Convert.ToDecimal(outputTotalDebtsValue.Value);
                        decimal currentPageDebtsValue = Convert.ToDecimal(outputCurrentPageDebtsValue.Value);
                        decimal totalRemainingAmount = Convert.ToDecimal(outputTotalRemainingAmount.Value);
                        decimal currentPageRemainingAmount = Convert.ToDecimal(outputCurrentPageRemainingAmount.Value);

                        allDebts = new DebtsPagedResultDTO<DebtViewSummary>(list, numberOfPages, recordsCount, totalDebtsValue,
                            currentPageDebtsValue, totalRemainingAmount, currentPageRemainingAmount);
                    }
                }

                if (allDebts == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                allDebts = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(allDebts);
        }
        public async Task<IResult<IEnumerable<DebtExportSummary>>> GetAll(DebtSearchCriteria criteria, int currentUserID)
        {
            List<DebtExportSummary> debtsList = null;
            var handler = _resultFactory.Create<IEnumerable<DebtExportSummary>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_Debts_GetAllWithoutPaging]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DebtID", (object)criteria.DebtID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsLending", (object)criteria.IsLending ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PersonName", string.IsNullOrWhiteSpace(criteria.PersonName) ? DBNull.Value : (object)criteria.PersonName);
                        command.Parameters.AddWithValue("@UserName", string.IsNullOrWhiteSpace(criteria.UserName) ? DBNull.Value : (object)criteria.UserName);
                        command.Parameters.AddWithValue("@FromCreatedDate", (object)criteria.FromCreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ToCreatedDate", (object)criteria.ToCreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FromDebtDate", (object)criteria.FromDebtDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ToDebtDate", (object)criteria.ToDebtDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsPaid", (object)criteria.IsPaid ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TextSearchMode", criteria.TextSearchMode);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {

                            int debtIDOrdinal = reader.GetOrdinal("DebtID");
                            int personIDOrdinal = reader.GetOrdinal("PersonID");
                            int personNameOrdinal = reader.GetOrdinal("PersonName");
                            int debtValueOrdinal = reader.GetOrdinal("DebtValue");
                            int remainingAmoutOrdinal = reader.GetOrdinal("RemainingAmount");
                            int debtDateOrdinal = reader.GetOrdinal("DebtDate");
                            int createdDaterdinal = reader.GetOrdinal("CreatedDate");
                            int debtTypeOrdinal = reader.GetOrdinal("DebtType");
                            int userIDOrdinal = reader.GetOrdinal("CreatedByUserID");
                            int userNameOrdinal = reader.GetOrdinal("CreatedByUserName");
                            int accountIDOrdinal = reader.GetOrdinal("AccountID");

                            debtsList = new List<DebtExportSummary>();

                            while (await reader.ReadAsync())
                            {
                                int id = Convert.ToInt32(reader[debtIDOrdinal]);
                                int personID = Convert.ToInt32(reader[personIDOrdinal]);
                                string personName = reader[personNameOrdinal] as string;
                                decimal debtValue = Convert.ToDecimal(reader[debtValueOrdinal]);
                                decimal remainingAmount = Convert.ToDecimal(reader[remainingAmoutOrdinal]);
                                DateTime debtDate = Convert.ToDateTime(reader[debtDateOrdinal]);
                                DateTime createdDate = Convert.ToDateTime(reader[debtDateOrdinal]);
                                string debtType = reader[debtTypeOrdinal] as string;
                                int userID = Convert.ToInt32(reader[userIDOrdinal]);
                                string userName = reader[userNameOrdinal] as string;
                                short accountID = Convert.ToInt16(reader[accountIDOrdinal]);

                                debtsList.Add(new DebtExportSummary(id, personName, debtValue, remainingAmount, debtDate, createdDate,
                                    debtType, userName, personID, userID, accountID));
                            }
                        }
                    }
                }

                if (debtsList == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                debtsList = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(debtsList);
        }
    }
}
