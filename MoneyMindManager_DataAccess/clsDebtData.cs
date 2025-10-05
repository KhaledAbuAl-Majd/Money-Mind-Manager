using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManagerGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.clsDebtsClasses;

namespace MoneyMindManager_DataAccess
{
    public static class clsDebtData
    {
        public static async Task<(int? NewDebtID,int? NewDebtTransactionID)> AddNewDebt(bool isLending,int personID,DateTime? paymentDueDate,  decimal amount,
            string purpose,bool isLocked,DateTime debtDate,int createdByUserID,bool RaiseEventOnErrorOccured = true)
        {
            int? newDebtID = null,newDebtTransactionID;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_Debts_AddNew]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@IsLending", isLending);
                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@PaymentDueDate", (object)paymentDueDate?? DBNull.Value);
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@Purpose", string.IsNullOrWhiteSpace(purpose) ? DBNull.Value : (object)purpose);
                        command.Parameters.AddWithValue("@IsLocked", isLocked);
                        command.Parameters.AddWithValue("@DebtDate", debtDate);
                        command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                        SqlParameter outParmNewDebt = new SqlParameter("@NewDebtID", System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };

                        SqlParameter outParmNewDebtTransactionID = new SqlParameter("@NewTransactionID", System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };

                        command.Parameters.Add(outParmNewDebt);
                        command.Parameters.Add(outParmNewDebtTransactionID);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        newDebtID = outParmNewDebt.Value as int?;
                        newDebtTransactionID = outParmNewDebtTransactionID.Value as int?;
                    }
                }

                if (newDebtID == null || newDebtTransactionID == null)
                    throw new Exception("فشلت العمية");
            }
            catch (Exception ex)
            {
                newDebtID = null;
                newDebtTransactionID = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return (newDebtID, newDebtTransactionID);
        }

        public static async Task<(bool UpdateResult,decimal RemainingAmount)> UpdateDebtByID(int debtID,DateTime? paymentDueDate, decimal amount, string purpose,
            DateTime debtDate, int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;
            decimal remainingAmount = -99999;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_Debts_UpdateByDebtID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DebtID", debtID);
                        command.Parameters.AddWithValue("@PaymentDueDate", (object)paymentDueDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Amount", amount); 
                        command.Parameters.AddWithValue("@Purpose", string.IsNullOrWhiteSpace(purpose) ? DBNull.Value : (object)purpose);
                        command.Parameters.AddWithValue("@DebtDate", debtDate);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        SqlParameter retunValue = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.ReturnValue
                        };

                        SqlParameter outRemainingAmount = new SqlParameter("@RemainingAmount", SqlDbType.Decimal)
                        {
                            Direction = System.Data.ParameterDirection.ReturnValue,
                            Precision = 19,
                            Scale = 4
                        };

                        command.Parameters.Add(retunValue);
                        command.Parameters.Add(outRemainingAmount);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        result = (retunValue.Value != DBNull.Value) && (Convert.ToInt32(retunValue.Value) == 1);
                        remainingAmount = Convert.ToDecimal(outRemainingAmount.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
                remainingAmount = -99999999;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return (result,remainingAmount);
        }

        public static async Task<bool> ChangeDebtLockingByID(int debtID, bool isLocked, int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_Debts_ChangeLocking]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DebtID", debtID);
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
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return result;
        }

        public static async Task<bool> DeleteDebtByID(int debtID, int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_Debts_DeleteByDebtID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DebtID", debtID);
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

        public static async Task<clsDebtsColumns> GetDebtInfoByID(int debtID
            , int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            clsDebtsColumns voucherData = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_Debts_GetByID]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DebtID", debtID);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                bool isLending = Convert.ToBoolean(reader["IsLending"]);
                                int personID = Convert.ToInt32(reader["PersonID"]);
                                DateTime? paymentDueDate = (reader["PaymentDueDate"] == DBNull.Value) ? null : Convert.ToDateTime(reader["PaymentDueDate"]) as DateTime?;
                                int debtTransactionID = Convert.ToInt32(reader["DebtTransactionID"]);
                                short accountID = Convert.ToInt16(reader["AccountID"]);
                                int createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                bool isLocked = Convert.ToBoolean(reader["IsLocked"]);
                                decimal remainingAmount = Convert.ToDecimal(reader["RemainingAmount"]);


                                voucherData = new clsDebtsColumns(debtID, isLending, personID, paymentDueDate, debtTransactionID, accountID,
                                    createdByUserID, isLocked, remainingAmount);
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
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return voucherData;
        }
    }
}
