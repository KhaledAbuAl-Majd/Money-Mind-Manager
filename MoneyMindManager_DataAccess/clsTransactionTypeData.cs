using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManagerGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.clsTransactionTypeClasses;

namespace MoneyMindManager_DataAccess
{
    public static class clsTransactionTypeData
    {
        
        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        public static async Task<clsTransactionTypeColumns> GetTransactionTypeInfoByID(byte transactionTypeID, bool RaiseEventOnErrorOccured = true)
        {
            clsTransactionTypeColumns TransactionTypeData = null;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_TransactionType_GetByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TransactionTypeID", transactionTypeID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                string transactionName = (reader["TransactionTypeName"] == DBNull.Value) ? null : reader["TransactionTypeName"] as string;

                                TransactionTypeData = new clsTransactionTypeColumns(transactionTypeID, transactionName);
                            }
                            else
                                TransactionTypeData = null;
                        }
                    }
                }

                if (TransactionTypeData == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                TransactionTypeData = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return TransactionTypeData;
        }

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        public static async Task<clsTransactionTypeColumns> GetTransactionTypeInfoByTransactionTypeName(string transactionName, bool RaiseEventOnErrorOccured = true)
        {
            clsTransactionTypeColumns TransactionTypeData = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_TransactionType_GetByName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TransactionTypeName", transactionName);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                byte transactionTypeID = Convert.ToByte(reader["TransactionTypeID"]);

                                TransactionTypeData = new clsTransactionTypeColumns(transactionTypeID, transactionName);
                            }
                            else
                                TransactionTypeData = null;
                        }
                    }
                }

                if (TransactionTypeData == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                TransactionTypeData = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return TransactionTypeData;
        }

        public static async Task<DataTable> GetAllTransactionTypes(bool RaiseEventOnErrorOccured = true)
        {
            DataTable dtTypes = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_TransactionTypes_GetAll]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            dtTypes.Load(reader);
                        }
                    }
                }

                if (dtTypes == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                dtTypes = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return dtTypes;
        }
    }
}
