using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Core;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.FinVoucher;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Abstractions.Repositories;
using MoneyMindManager.Domain.Criteria.FinVoucher;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.Paged_Result_DTOs;

namespace MoneyMindManager.Infrastructure.Repositories.Database.SQLServer
{
    public class SQLFinVoucherRepository : IFinVoucherRepository
    {
        private readonly IDatabaseSettings _databaseSettings;
        private readonly IResultFactory _resultFactory;
        private readonly ILogger _logger;

        public SQLFinVoucherRepository(IDatabaseSettings databaseSettings, IResultFactory resultFactory, ILogger logger)
        {
            this._databaseSettings = databaseSettings;
            this._resultFactory = resultFactory;
            this._logger = logger;
        }
        public async Task<IResult<int?>> Add(FinVoucher voucher)
        {
            int? newVoucherID = null;
            var handler = _resultFactory.Create<int?>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseVouchers_AddNew]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@VoucherName", voucher.VoucherName);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(voucher.Notes) ? DBNull.Value : (object)voucher.Notes);
                        command.Parameters.AddWithValue("@IsLocked", voucher.IsLocked);
                        command.Parameters.AddWithValue("@VoucherDate", voucher.VoucherDate);
                        command.Parameters.AddWithValue("@CreatedByUserID", voucher.CreatedByUserID);
                        command.Parameters.AddWithValue("@IsIncome", voucher.IsIncome);
                        command.Parameters.AddWithValue("@IsReturn", voucher.IsReturn);

                        SqlParameter outParmNewCategory = new SqlParameter("@NewVoucherID", System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };

                        command.Parameters.Add(outParmNewCategory);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        newVoucherID = outParmNewCategory.Value as int?;
                    }
                }

                if (newVoucherID == null)
                    throw new Exception("فشلت العمية");
            }
            catch (Exception ex)
            {
                newVoucherID = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(newVoucherID);
        }
        public async Task<IResult<bool>> Update(FinVoucher voucher, int currentUserID)
        {
            bool result = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseVouchers_UpdateByVoucherID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@VoucherID", voucher.VoucherID);
                        command.Parameters.AddWithValue("@VoucherName", voucher.VoucherName);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(voucher.Notes) ? DBNull.Value : (object)voucher.Notes);
                        command.Parameters.AddWithValue("@VoucherDate", voucher.VoucherDate);
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
        public async Task<IResult<bool>> ChangeLockingByID(int voucherID, bool isLocked, int currentUserID)
        {
            bool result = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseVouchers_ChangeLocking]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@VoucherID", voucherID);
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
        public async Task<IResult<bool>> Delete(int voucherID, int currentUserID)
        {
            bool result = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseVouchers_DeleteByVoucherID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@VoucherID", voucherID);
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
        public async Task<IResult<FinVoucher>> Get(int voucherID, int currentUserID)
        {
            FinVoucher voucherData = null;
            var handler = _resultFactory.Create<FinVoucher>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseVouchers_GetByID]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@VoucherID", voucherID);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                string voucherName = reader["VoucherName"] as string;
                                string notes = reader["Notes"] as string;
                                bool isLocked = Convert.ToBoolean(reader["IsLocked"]);
                                DateTime createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                                DateTime voucherDate = Convert.ToDateTime(reader["VoucherDate"]);
                                short accountID = Convert.ToInt16(reader["AccountID"]);
                                int createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                bool isIncome = Convert.ToBoolean(reader["IsIncome"]);
                                bool isReturn = Convert.ToBoolean(reader["IsReturn"]);
                                decimal voucherValue = Convert.ToDecimal(reader["VoucherValue"]);

                                voucherData = new FinVoucher(voucherID, voucherName, notes, isLocked,
                                    createdDate, voucherDate, accountID, createdByUserID, isIncome, isReturn, voucherValue);
                            }
                        }
                    }
                }

                if (voucherData == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                voucherData = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(voucherData);
        }
        public async Task<IResult<decimal?>> GetVoucherValueByID(int voucherID, int currentUserID)
        {
            decimal? voucherValue = null;
            var handler = _resultFactory.Create<decimal?>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseVouchers_GetVoucherValue]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@VoucherID", voucherID);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        SqlParameter outValue = new SqlParameter("@VoucherValue", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output,
                            Precision = 19,
                            Scale = 4
                        };

                        command.Parameters.Add(outValue);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        voucherValue = outValue.Value as decimal?;
                    }
                }

                if (voucherValue == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                voucherValue = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(voucherValue);
        }
        public async Task<IResult<PagedResultWithTotal_CurrentDTO<FinVoucherViewSummary>>> GetAllPaged(FinVoucherPagedSearchCriteria criteria, int currentUserID)
        {
            PagedResultWithTotal_CurrentDTO<FinVoucherViewSummary> allVouchers = null;
            var handler = _resultFactory.Create<PagedResultWithTotal_CurrentDTO<FinVoucherViewSummary>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseVouchers_GetAllBy]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@VoucherID", (object)criteria.VoucherID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsIncome", (object)criteria.IsIncome ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsReturn", (object)criteria.IsReturn ?? DBNull.Value);
                        command.Parameters.AddWithValue("@VoucherName", string.IsNullOrWhiteSpace(criteria.VoucherName) ? DBNull.Value : (object)criteria.VoucherName);
                        command.Parameters.AddWithValue("@UserName", string.IsNullOrWhiteSpace(criteria.UserName) ? DBNull.Value : (object)criteria.UserName);
                        command.Parameters.AddWithValue("@FromCreatedDate", (object)criteria.FromCreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ToCreatedDate", (object)criteria.ToCreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FromVoucherDate", (object)criteria.FromVoucherDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ToVoucherDate", (object)criteria.ToVoucherDate ?? DBNull.Value);
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

                        SqlParameter outputTotalVouchersValue = new SqlParameter("@TotalVouchersValue", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output,
                            Precision = 19,
                            Scale = 4
                        };

                        SqlParameter outputCurrentPageVouchersValue = new SqlParameter("@CurrentPageVouchersValue", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output,
                            Precision = 19,
                            Scale = 4
                        };

                        command.Parameters.Add(outputNumberOfPages);
                        command.Parameters.Add(outputRecordsCount);
                        command.Parameters.Add(outputTotalVouchersValue);
                        command.Parameters.Add(outputCurrentPageVouchersValue);

                        await connection.OpenAsync();
                        List<FinVoucherViewSummary> list;
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            int idOrdinal = reader.GetOrdinal("VoucherID");
                            int voucherNameOrdinal = reader.GetOrdinal("VoucherName");
                            int voucherValueOrdinal = reader.GetOrdinal("VoucherValue");
                            int transactionsCountOrdinal = reader.GetOrdinal("TransactionsCount");
                            int voucherDateOrdinal = reader.GetOrdinal("VoucherDate");
                            int createdDateOrdinal = reader.GetOrdinal("CreatedDate");
                            int userNameOrdinal = reader.GetOrdinal("CreatedByUserName");

                            list = new List<FinVoucherViewSummary>();

                            while (await reader.ReadAsync())
                            {
                                int id = Convert.ToInt32(reader[idOrdinal]);
                                string voucherName = reader[voucherNameOrdinal] as string;
                                decimal voucherValue = Convert.ToDecimal(reader[voucherValueOrdinal]);
                                int transactionsCount = Convert.ToInt32(reader[transactionsCountOrdinal]);
                                var voucerDate = Convert.ToDateTime(reader[voucherDateOrdinal]);
                                var createdDate = Convert.ToDateTime(reader[createdDateOrdinal]);
                                string userName = reader[userNameOrdinal] as string;

                                list.Add(new FinVoucherViewSummary(id, voucherName, transactionsCount, userName, createdDate, voucerDate, voucherValue));
                            }

                        }
                        int numberOfPages = Convert.ToInt32(outputNumberOfPages.Value);
                        int recordsCount = Convert.ToInt32(outputRecordsCount.Value);

                        allVouchers = new PagedResultWithTotal_CurrentDTO<FinVoucherViewSummary>(list, numberOfPages, recordsCount,
                            Convert.ToDecimal(outputTotalVouchersValue.Value), Convert.ToDecimal(outputCurrentPageVouchersValue.Value));
                    }
                }

                if (allVouchers == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                allVouchers = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(allVouchers);
        }
        public async Task<IResult<IEnumerable<FinVoucherExportSummary>>> GetAll(FinVoucherSearchCriteria criteria, int currentUserID)
        {
            List<FinVoucherExportSummary> vouchersList = null;
            var handler = _resultFactory.Create<IEnumerable<FinVoucherExportSummary>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseVouchers_GetAllByWithoutPaging]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@VoucherID", (object)criteria.VoucherID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsIncome", (object)criteria.IsIncome ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsReturn", (object)criteria.IsReturn ?? DBNull.Value);
                        command.Parameters.AddWithValue("@VoucherName", string.IsNullOrWhiteSpace(criteria.VoucherName) ? DBNull.Value : (object)criteria.VoucherName);
                        command.Parameters.AddWithValue("@UserName", string.IsNullOrWhiteSpace(criteria.UserName) ? DBNull.Value : (object)criteria.UserName);
                        command.Parameters.AddWithValue("@FromCreatedDate", (object)criteria.FromCreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ToCreatedDate", (object)criteria.ToCreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FromVoucherDate", (object)criteria.FromVoucherDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ToVoucherDate", (object)criteria.ToVoucherDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TextSearchMode", criteria.TextSearchMode);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            int idOrdinal = reader.GetOrdinal("VoucherID");
                            int voucherNameOrdinal = reader.GetOrdinal("VoucherName");
                            int voucherValueOrdinal = reader.GetOrdinal("VoucherValue");
                            int transactionsCountOrdinal = reader.GetOrdinal("TransactionsCount");
                            int voucherDateOrdinal = reader.GetOrdinal("VoucherDate");
                            int createdDateOrdinal = reader.GetOrdinal("CreatedDate");
                            int userNameOrdinal = reader.GetOrdinal("CreatedByUserName");
                            int userIDOrdinal = reader.GetOrdinal("CreatedByUserID");
                            int AccountIDOrdinal = reader.GetOrdinal("AccountID");


                            vouchersList = new List<FinVoucherExportSummary>();

                            while (await reader.ReadAsync())
                            {
                                int id = Convert.ToInt32(reader[idOrdinal]);
                                string voucherName = reader[voucherNameOrdinal] as string;
                                decimal voucherValue = Convert.ToDecimal(reader[voucherValueOrdinal]);
                                int transactionsCount = Convert.ToInt32(reader[transactionsCountOrdinal]);
                                var voucerDate = Convert.ToDateTime(reader[voucherDateOrdinal]);
                                var createdDate = Convert.ToDateTime(reader[createdDateOrdinal]);
                                string userName = reader[userNameOrdinal] as string;
                                short accountID = Convert.ToInt16(reader[AccountIDOrdinal]);
                                int userID = Convert.ToInt32(reader[userIDOrdinal]);

                                vouchersList.Add(new FinVoucherExportSummary(id, voucherName, transactionsCount, userName, createdDate, voucerDate, accountID, userID, voucherValue));
                            }
                        }
                    }
                }

                if (vouchersList == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                vouchersList = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(vouchersList);
        }
    }
}
