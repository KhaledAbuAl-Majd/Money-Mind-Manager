using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using MoneyMindManagerGlobal;

namespace MoneyMindManager_DataAccess
{
    public static class clsclsIncomeAndExpenseTransactionData
    {
        public static async Task<int?> AddNewIncomeAndExpenseTransaction(int voucherID, int categoryID, Decimal amount,string purpose,
            int createdByUserID, bool RaiseEventOnErrorOccured = true)
        {
            int? newTransactionID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseTransaction_AddNew]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@VoucherID", voucherID);
                        command.Parameters.AddWithValue("@categoryID", categoryID);
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@Purpose", (object)purpose ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return newTransactionID;
        }

        public static async Task<bool> UpdateIncomeAndExpenseTransactoinByID(int transactionID,
            decimal amount,int categoryID,string purpose,int currentUserID,  bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpneseTransactions_UpdateByID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TransactionID",transactionID);
                        command.Parameters.AddWithValue("@Amount",amount);
                        command.Parameters.AddWithValue("@categoryID",categoryID);
                        command.Parameters.AddWithValue("@Purpose", (object)purpose ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CurrentUserID",currentUserID);
                       

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

        public static async Task<bool> DeleteIncomeAndExpenseTransactoinByID(int transactionID,int currentUserID,  bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_MainTransactions_DeleteByID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TransactionID",transactionID);
                        command.Parameters.AddWithValue("@CurrentUserID",currentUserID);
                       

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

        public static async Task<(int VoucherID,int CategoryID,string Purpose)> GetIncomeAndExpenseTransactionInfoByID(int transactionID,
            int currentUserID,bool RaiseEventOnErrorOccured = true)
        {
            int? voucherID = null, categoryID = null;
            string purpose = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseTransaction_GetByID]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TransactionID", transactionID);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                voucherID = reader["VoucherID"] as int?;
                                categoryID = reader["CategoryID"] as int?;
                                purpose = reader["Purpose"] as string;
                            }
                            else
                            {
                                voucherID = null;
                                categoryID = null;
                                purpose = null;
                            }
                        }
                    }
                }

                if (voucherID == null || categoryID == null || purpose == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                voucherID = null;
                categoryID = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return (Convert.ToInt32(voucherID), Convert.ToInt32(categoryID),purpose);
        }
    }
}
