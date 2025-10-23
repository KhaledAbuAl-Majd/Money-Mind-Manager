using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManagerGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.clsMainTransactionClasses;

namespace MoneyMindManager_DataAccess
{
    public static class clsMainTransactionData
    {
        /// <summary>
        /// Get Single record of Main Transaction Table
        /// </summary>
        public static async Task<clsMainTransactionColumns> GetMainTransactionInfoByID(int transactionID,int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            clsMainTransactionColumns transactionTypeData = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
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

                                transactionTypeData = new clsMainTransactionColumns(transactionID, amount, createdDate, accountID,
                                    createdByUserID, transactionTypeID,purpose,IsLocked,transactionDate);
                            }
                            else
                                transactionTypeData = null;
                        }
                    }
                }

                if (transactionTypeData == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                transactionTypeData = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return transactionTypeData;
        }

        public static async Task<clsGetAllMainTransactions> GetAllMainTransactions(int? transactionID, string userName,
            string transactionTypes, DateTime? fromCreatedDate, DateTime? toCreatedDate, DateTime? fromTransactionDate,
           DateTime? toTransactionDate, int currentUserID, short pageNumber, bool RaiseEventOnErrorOccured = true)
        {
            clsGetAllMainTransactions allTransactions = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_MainTransactions_GetAll]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TransactionID", (object)transactionID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UserName", string.IsNullOrWhiteSpace(userName) ? DBNull.Value : (object)userName);
                        command.Parameters.AddWithValue("@TransactionTypes", string.IsNullOrWhiteSpace(transactionTypes) ? DBNull.Value : (object)transactionTypes);
                        command.Parameters.AddWithValue("@FromCreatedDate", (object)fromCreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ToCreatedDate", (object)toCreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FromTransactionDate", (object)fromTransactionDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ToTransactionDate", (object)toTransactionDate ?? DBNull.Value);
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
                            DataTable dtTransactions = new DataTable();
                            dtTransactions.Load(reader);
                            short numberOfPages = Convert.ToInt16(outputNumberOfPages.Value);
                            int recordsCount = Convert.ToInt32(outputRecordsCount.Value);

                            allTransactions = new clsGetAllMainTransactions(dtTransactions, numberOfPages, recordsCount,
                                Convert.ToDecimal(outputTotalTransactionsValue.Value), Convert.ToDecimal(outputCurrentPageTransactionsValue.Value));
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

        public static async Task<DataTable> GetAllMainTransactionsWithoutPaging(int? transactionID, string userName,
            string transactionTypes, DateTime? fromCreatedDate, DateTime? toCreatedDate, DateTime? fromTransactionDate,
           DateTime? toTransactionDate, int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            DataTable dtTransactions = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_MainTransactions_GetAllWithoutPaging]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TransactionID", (object)transactionID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UserName", string.IsNullOrWhiteSpace(userName) ? DBNull.Value : (object)userName);
                        command.Parameters.AddWithValue("@TransactionTypes", string.IsNullOrWhiteSpace(transactionTypes) ? DBNull.Value : (object)transactionTypes);
                        command.Parameters.AddWithValue("@FromCreatedDate", (object)fromCreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ToCreatedDate", (object)toCreatedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FromTransactionDate", (object)fromTransactionDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ToTransactionDate", (object)toTransactionDate ?? DBNull.Value);
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
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return dtTransactions;
        }
    }
}
