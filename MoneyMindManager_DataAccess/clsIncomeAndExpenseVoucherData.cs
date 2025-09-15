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
            bool isLocked,DateTime voucherDate,int createdByUserID,bool isIncome, bool RaiseEventOnErrorOccured = true)
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
                        command.Parameters.AddWithValue("@Notes", (object)notes ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsLocked",isLocked);
                        command.Parameters.AddWithValue("@VoucherDate",voucherDate);
                        command.Parameters.AddWithValue("@CreatedByUserID",createdByUserID);
                        command.Parameters.AddWithValue("@IsIncome",isIncome);

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
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return newVoucherID;
        }

        public static async Task<bool> UpdateVoucherByID(int voucherID,string voucherName, string notes, bool isLocked, 
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
                        command.Parameters.AddWithValue("@Notes", (object)notes ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsLocked", isLocked);
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
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
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
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
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

                                voucherData = new clsIncomeAndExpenseVoucherColumns(voucherID, voucherName, notes, isLocked,
                                    createdDate, voucherDate, accountID, createdByUserID, isIncome);
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

                if (RaiseEventOnErrorOccured == false)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return voucherData;
        }
    }
}
