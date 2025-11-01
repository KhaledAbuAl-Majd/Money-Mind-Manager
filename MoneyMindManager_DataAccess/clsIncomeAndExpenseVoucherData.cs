using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManagerGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.clsIncomeAndExpenseVoucherClasses;

namespace MoneyMindManager_DataAccess
{
    public static class clsIncomeAndExpenseVoucherData
    {
        public static async Task<int?> AddNewIncomeAndExpenseVoucher(string voucherName,string notes,
            bool isLocked,DateTime voucherDate,int createdByUserID,bool isIncome,bool isReturn, bool RaiseEventOnErrorOccured = true)
        {
            int? newVoucherID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseVouchers_AddNew]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@VoucherName", voucherName);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(notes) ? DBNull.Value : (object)notes);
                        command.Parameters.AddWithValue("@IsLocked",isLocked);
                        command.Parameters.AddWithValue("@VoucherDate",voucherDate);
                        command.Parameters.AddWithValue("@CreatedByUserID",createdByUserID);
                        command.Parameters.AddWithValue("@IsIncome",isIncome);
                        command.Parameters.AddWithValue("@IsReturn", isReturn);

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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return newVoucherID;
        }

        public static async Task<bool> UpdateVoucherByID(int voucherID,string voucherName, string notes, 
            DateTime voucherDate, int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseVouchers_UpdateByVoucherID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@VoucherID", voucherID);
                        command.Parameters.AddWithValue("@VoucherName", voucherName);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(notes) ? DBNull.Value : (object)notes);
                        command.Parameters.AddWithValue("@VoucherDate", voucherDate);
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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return result;
        }

        public static async Task<bool> ChangeVoucherLockingByID(int voucherID,bool isLocked, int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return result;
        }

        public static async Task<bool> DeleteVoucherByID(int voucherID, int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return result;
        }

        public static async Task<clsIncomeAndExpenseVoucherColumns> GetVoucherInfoByID(int voucherID
            , int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            clsIncomeAndExpenseVoucherColumns voucherData = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
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

                                voucherData = new clsIncomeAndExpenseVoucherColumns(voucherID, voucherName, notes, isLocked,
                                    createdDate, voucherDate, accountID, createdByUserID, isIncome,isReturn,voucherValue);
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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return voucherData;
        }
        public static async Task<decimal?> GetVoucherValueByID(int voucherID
            , int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            decimal? voucherValue = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return voucherValue;
        }

        /// <summary>
        /// if variable is null will not filter by it
        /// </summary>
        public static async Task<clsGetAllVouchers> GetAllVouchers(int? voucherID,bool? isIncome,bool? isReturn,string voucherName,
            string userName,DateTime? fromCreatedDate,DateTime? toCreatedDate,DateTime? fromVoucherDate,DateTime? toVoucherDate,
            int currentUserID, byte textSearchMode, short pageNumber, byte rowsPerPage, bool RaiseEventOnErrorOccured = true)
        {
            clsGetAllVouchers allVouchers = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseVouchers_GetAllBy]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@VoucherID", (object)voucherID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsIncome", (object)isIncome ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsReturn", (object)isReturn ?? DBNull.Value);
                        command.Parameters.AddWithValue("@VoucherName", string.IsNullOrWhiteSpace(voucherName) ? DBNull.Value : (object)voucherName);
                        command.Parameters.AddWithValue("@UserName", string.IsNullOrWhiteSpace(userName) ? DBNull.Value : (object)userName);
                        command.Parameters.AddWithValue("@FromCreatedDate", (object)fromCreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ToCreatedDate", (object)toCreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FromVoucherDate", (object)fromVoucherDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ToVoucherDate", (object)toVoucherDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TextSearchMode", textSearchMode);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);
                        command.Parameters.AddWithValue("@PageNumber", pageNumber);
                        command.Parameters.AddWithValue("@RowsPerPage", rowsPerPage);

                        SqlParameter outputNumberOfPages = new SqlParameter("@NumberOfPages", SqlDbType.SmallInt)
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

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            DataTable dtVouchers = new DataTable();
                            dtVouchers.Load(reader);
                            short numberOfPages = Convert.ToInt16(outputNumberOfPages.Value);
                            int recordsCount = Convert.ToInt32(outputRecordsCount.Value);

                            allVouchers = new clsGetAllVouchers(dtVouchers, numberOfPages, recordsCount,
                                Convert.ToDecimal(outputTotalVouchersValue.Value), Convert.ToDecimal(outputCurrentPageVouchersValue.Value));
                        }
                    }
                }

                if (allVouchers == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                allVouchers = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return allVouchers;
        }

        /// <summary>
        /// if variable is null will not filter by it
        /// </summary>
        public static async Task<DataTable> GetAllVouchersWithoutPaging(int? voucherID,bool? isIncome,bool? isReturn,string voucherName,
            string userName,DateTime? fromCreatedDate,DateTime? toCreatedDate,DateTime? fromVoucherDate,DateTime? toVoucherDate,
            int currentUserID, byte textSearchMode, bool RaiseEventOnErrorOccured = true)
        {
            DataTable dtVouchers = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseVouchers_GetAllByWithoutPaging]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@VoucherID", (object)voucherID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsIncome", (object)isIncome ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsReturn", (object)isReturn ?? DBNull.Value);
                        command.Parameters.AddWithValue("@VoucherName", string.IsNullOrWhiteSpace(voucherName) ? DBNull.Value : (object)voucherName);
                        command.Parameters.AddWithValue("@UserName", string.IsNullOrWhiteSpace(userName) ? DBNull.Value : (object)userName);
                        command.Parameters.AddWithValue("@FromCreatedDate", (object)fromCreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ToCreatedDate", (object)toCreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FromVoucherDate", (object)fromVoucherDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ToVoucherDate", (object)toVoucherDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TextSearchMode", textSearchMode);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            dtVouchers = new DataTable();
                            dtVouchers.Load(reader);
                        }
                    }
                }

                if (dtVouchers == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                dtVouchers = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return dtVouchers;
        }
    }
}
