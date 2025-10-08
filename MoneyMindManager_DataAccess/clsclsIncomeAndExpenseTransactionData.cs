using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using MoneyMindManagerGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.clsIncomeAndExpenseTransactionsClasses;

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
                        command.Parameters.AddWithValue("@Purpose", string.IsNullOrWhiteSpace(purpose)? DBNull.Value : (object)purpose);
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
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseTransactions_UpdateByID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TransactionID",transactionID);
                        command.Parameters.AddWithValue("@Amount",amount);
                        command.Parameters.AddWithValue("@categoryID",categoryID);
                        command.Parameters.AddWithValue("@Purpose", string.IsNullOrWhiteSpace(purpose) ? DBNull.Value : (object)purpose);
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
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseTransactions_DeleteByID]", connection))
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

        public static async Task<(int VoucherID,int CategoryID)> GetIncomeAndExpenseTransactionInfoByID(int transactionID,
            int currentUserID,bool RaiseEventOnErrorOccured = true)
        {
            int? voucherID = null, categoryID = null;

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
                            }
                            else
                            {
                                voucherID = null;
                                categoryID = null;
                            }
                        }
                    }
                }

                if (voucherID == null || categoryID == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                voucherID = null;
                categoryID = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return (Convert.ToInt32(voucherID), Convert.ToInt32(categoryID));
        }

        public static async Task<clsGetAllIncomeAndExpenseTransactions> GetAllIncomeAndExpensTransactions(int voucherID,int currentUserID, short pageNumber, bool RaiseEventOnErrorOccured = true)
        {
            clsGetAllIncomeAndExpenseTransactions allTransactions = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseTransactionGetAllByVoucherID]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@VoucherID", voucherID);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);
                        command.Parameters.AddWithValue("@PageNumber", pageNumber);

                        SqlParameter outputNumberOfPages = new SqlParameter("@NumberOfPages", SqlDbType.SmallInt)
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

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            DataTable dtTransactions = new DataTable();
                            dtTransactions.Load(reader);
                            short numberOfPages = Convert.ToInt16(outputNumberOfPages.Value);
                            int recordsCount = Convert.ToInt32(outputRecordsCount.Value);
                            decimal voucherValue = Convert.ToDecimal(outputVoucherValue.Value);

                            allTransactions = new clsGetAllIncomeAndExpenseTransactions(dtTransactions, numberOfPages, recordsCount,voucherValue);
                        }
                    }
                }

                if (allTransactions == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                allTransactions = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return allTransactions;
        }
    }
}
