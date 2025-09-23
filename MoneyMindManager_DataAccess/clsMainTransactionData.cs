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
        public static async Task<clsMainTransactionColumns> GetMainTransactionInfoByID(int transactionID, bool RaiseEventOnErrorOccured = true)
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

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                decimal amount = Convert.ToDecimal(reader["Amount"]);
                                DateTime createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                                short accountID = Convert.ToInt16(reader["AccountID"]);
                                int createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                int balanceAccountID = Convert.ToInt32(reader["BalanceAccountID"]);
                                byte transactionTypeID = Convert.ToByte(reader["TransactionTypeID"]);
                                bool isLocked = Convert.ToBoolean(reader["IsLocked"]);

                                transactionTypeData = new clsMainTransactionColumns(transactionID, amount, createdDate, accountID,
                                    createdByUserID, balanceAccountID, transactionTypeID,isLocked);
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
    }
}
