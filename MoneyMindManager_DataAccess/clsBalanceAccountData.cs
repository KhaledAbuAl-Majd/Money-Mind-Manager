using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManagerGlobal;
using static MoneyMindManager_DataAccess.clsUserData;

namespace MoneyMindManager_DataAccess
{
    public static class clsBalanceAccountData
    {
        public class clsBalanceAccountColumns
        {
            public int? BalanceAccountID { get;}
            public string BalanceAccountName { get; set; }
            public decimal Balance { get; }
            public bool IsCurrentAccount { get; }
            public DateTime CreatedDate { get; }
            public string AccountTypeName { get; }

            public clsBalanceAccountColumns(int balanceAccountID,string balanceAccountName,decimal balance,
                bool isCurrentAccount,DateTime createdDate,string AccountTypeName)
            {
                this.BalanceAccountID = balanceAccountID;
                this.BalanceAccountName = balanceAccountName;
                this.Balance = balance;
                this.IsCurrentAccount = isCurrentAccount;
                this.CreatedDate = createdDate;
                this.AccountTypeName = AccountTypeName;
            }

            //public clsBalanceAccountColumns()
            //{
            //    this.BalanceAccountID = null;
            //    this.BalanceAccountName = null;
            //    this.Balance = 0;
            //    this.IsCurrentAccount = false;
            //    this.CreatedDate = DateTime.Now;
            //}
        }

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>Updating Result</returns>
        public static async Task<bool> UpdateBalanceAccountByBalanceAccountID(int balanceAccountID,string balanceAccountName,bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateBalanceAccountNameByBalanceAccountID ", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BalanceAccountID", balanceAccountID);
                        command.Parameters.AddWithValue("@BalanceAccountName", (string.IsNullOrEmpty(balanceAccountName)) ?
                            DBNull.Value : (object)balanceAccountName);

                        SqlParameter ReturnUpdateResult = new SqlParameter("ReturnVal", System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(ReturnUpdateResult);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        result = (ReturnUpdateResult.Value != DBNull.Value) && (Convert.ToInt32(ReturnUpdateResult.Value) == 1);
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
        /// <returns>Object of clsBalanceAccountsColumns, if balanceAccount is not found it will return null</returns>
        public static async Task<clsBalanceAccountColumns> GetBalanceAccountInfoByBalanceAccountID(int balanceAccountID, bool RaiseEventOnErrorOccured = true)
        {
            clsBalanceAccountColumns balanceAccountData = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetBalanceAccountByBalanceAccountID", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BalanceAccountID", balanceAccountID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                string balanceAccountName = reader["BalanceAccountName"] as string;
                                decimal balance = Convert.ToDecimal(reader["Balance"]);
                                bool isCurrentAccount = Convert.ToBoolean(reader["IsCurrentAccount"]);
                                DateTime createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                                string accountTypeName = reader["AccountTypeName"] as string;

                                balanceAccountData = new clsBalanceAccountColumns(balanceAccountID, balanceAccountName, balance, isCurrentAccount, createdDate, accountTypeName);
    }
                            else
                                balanceAccountData = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                balanceAccountData = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return balanceAccountData;
        }

    }
}
