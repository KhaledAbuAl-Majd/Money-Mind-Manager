using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManagerGlobal;
using static MoneyMindManager_DataAccess.clsUserData;
using static MoneyMindManagerGlobal.clsDataColumns.clsAccountClasses;

namespace MoneyMindManager_DataAccess
{
    public static class clsAccountData
    {
       

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>New AccountID if Success, if failed return null</returns>
        public static async Task<Nullable<int>> CreateAccount(string accountName, byte defaultCurrencyID, string description,
            string personName, string address, string email, string phone, string notes, string userName, 
            string password, string salt, bool RaiseEventOnErrorOccured = true)
        {
            short? newAccountID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_CreateAccount]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AccountName", accountName);
                        command.Parameters.AddWithValue("@DefaultCurrencyID", defaultCurrencyID);
                        command.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(description) ? System.DBNull.Value : (object)description);
                        command.Parameters.AddWithValue("@PersonName", personName);
                        command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(address) ? System.DBNull.Value : (object)address);
                        command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? System.DBNull.Value : (object)email);
                        command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(phone) ? System.DBNull.Value : (object)phone);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? System.DBNull.Value : (object)notes);
                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Salt", salt);

                        SqlParameter outputnewAccountID = new SqlParameter("@NewAccountID", System.Data.SqlDbType.SmallInt)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };

                        command.Parameters.Add(outputnewAccountID);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        if (outputnewAccountID.Value != DBNull.Value && (short.TryParse(outputnewAccountID.Value?.ToString(), out short parsingResult)))
                        {
                            newAccountID = parsingResult;
                        }
                        else
                            newAccountID = null;
                    }
                }
            }
            catch (Exception ex)
            {
                newAccountID = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return newAccountID;
        }

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>Updating Result</returns>
        public static async Task<bool> UpdateAccount(int accountID, string accountName, bool isActive, string description, bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_UpdateAccountByAccountID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AccountID", accountID);
                        command.Parameters.AddWithValue("@AccountName", accountName);
                        command.Parameters.AddWithValue("@IsActive", isActive);
                        command.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(description) ? System.DBNull.Value : (object)description);

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

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>Object of clsAccountColumns, if Account is not found it will return null</returns>
        public static async Task<clsAccountColumns> GetAccountInfoByAccountID(short accountID, bool RaiseEventOnErrorOccured = true)
        {
            clsAccountColumns accountColumns = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_GetAccountByAccountID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AccountID", accountID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                string accountName = reader["AccountName"] as string;
                                DateTime createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                                bool isActive = Convert.ToBoolean(reader["IsActive"]);
                                byte defaultCurrencyID = Convert.ToByte(reader["DefaultCurrencyID"]);
                                string description = (reader["Description"] == DBNull.Value) ? null : reader["Description"] as string;
                                int currentBalanceAccountID = Convert.ToInt32(reader["CurrentAccountBalanceID"]);
                                int savingBalanceAccountID = Convert.ToInt32(reader["SavingAccountBalanceID"]);

                                accountColumns = new clsAccountColumns(accountID, accountName, createdDate, isActive, defaultCurrencyID, description,
                                    currentBalanceAccountID, savingBalanceAccountID);
                            }
                            else
                                accountColumns = null;

                            if (accountColumns == null)
                                throw new Exception("فشلت العملية");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                accountColumns = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return accountColumns;
        }



    }
}
