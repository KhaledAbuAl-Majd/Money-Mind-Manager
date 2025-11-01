using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManagerGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.clsDebtPaymentClasses;

namespace MoneyMindManager_DataAccess
{
    public static class clsDebtPaymentData
    {
        public static async Task<int?> AddNewDebtPayment(int debtID, Decimal amount,DateTime paymentDate, string purpose,
          int createdByUserID, bool RaiseEventOnErrorOccured = true)
        {
            int? newTransactionID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_DebtPayment_AddNew]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DebtID", debtID);
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@PaymentDate", paymentDate);
                        command.Parameters.AddWithValue("@Purpose", string.IsNullOrWhiteSpace(purpose) ? DBNull.Value : (object)purpose);
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
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return newTransactionID;
        }

        public static async Task<bool> UpdateDebtPaymentByID(int transactionID,
            decimal amount, string purpose, DateTime paymentDate, int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_DebtPayment_UpdateByID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TransactionID", transactionID);
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@Purpose", string.IsNullOrWhiteSpace(purpose) ? DBNull.Value : (object)purpose);
                        command.Parameters.AddWithValue("@PaymentDate", paymentDate);
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

        public static async Task<bool> DeleteDebtPaymentByID(int transactionID, int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_DebtPayment_DeleteByID]", connection))
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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return result;
        }

        /// <returns>DebtID for debtPayment which is linked with transactionID</returns>
        public static async Task <int> GetDebtPaymentByID(int transactionID,
            int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            int? debtID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_DebtPayment_GetByID]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TransactionID", transactionID);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                debtID = reader["DebtID"] as int?;
                            }
                            else
                            {
                                debtID = null;
                            }
                        }
                    }
                }

                if (debtID == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                debtID = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return (Convert.ToInt32(debtID));
        }

        public static async Task<clsGetAllDebtPayments> GetAllDebtPaymentsForDebt(int debtID, int currentUserID,
            short pageNumber, byte rowsPerPage, bool RaiseEventOnErrorOccured = true)
        {
            clsGetAllDebtPayments allTransactions = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DebtPayment_GetAllForDebt", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DebtID", debtID);
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

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            DataTable dtTransactions = new DataTable();
                            dtTransactions.Load(reader);
                            short numberOfPages = Convert.ToInt16(outputNumberOfPages.Value);
                            int recordsCount = Convert.ToInt32(outputRecordsCount.Value);
                            decimal remainingAmount = Convert.ToDecimal(outputRemainingAmount.Value);

                            allTransactions = new clsGetAllDebtPayments(dtTransactions, numberOfPages, recordsCount, remainingAmount);
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
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return allTransactions;
        }

        public static async Task<DataTable> GetAllDebtPaymentsForDebtWithoutPaging(int debtID, int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            DataTable dtTransactions = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DebtPayment_GetAllForDebtWihtoutPaging", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DebtID", debtID);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            dtTransactions = new DataTable();
                            dtTransactions.Load(reader);
                        }
                    }
                }

                if (dtTransactions == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                dtTransactions = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return dtTransactions;
        }
    }
}
