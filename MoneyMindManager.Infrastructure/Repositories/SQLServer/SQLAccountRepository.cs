using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Core;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Entities;

namespace MoneyMindManager.Infrastructure.Repositories.SQLServer
{
    public class SQLAccountRepository : IAccountRepository
    {
        private readonly ILogger _logger;
        private readonly IDatabaseSettings _databaseSettings;
        private readonly IResultFactory _resultFactory;

        public SQLAccountRepository(ILogger logger, IDatabaseSettings databaseSettings, IResultFactory resultFactory)
        {
            this._logger = logger;
            this._databaseSettings = databaseSettings;
            this._resultFactory = resultFactory;
        }

        public async Task<IResult<short?>> Add(Person person, User user, Account account)
        {
            short? newAccountID = null;
            var handler = _resultFactory.Create<short?>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Account_Create", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AccountName", account.AccountName);
                        command.Parameters.AddWithValue("@DefaultCurrencyID", account.DefaultCurrencyID);
                        command.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(account.Description) ? System.DBNull.Value : (object)account.Description);
                        command.Parameters.AddWithValue("@PersonName", person.PersonName);
                        command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(person.Address) ? System.DBNull.Value : (object)person.Address);
                        command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(person.Email) ? System.DBNull.Value : (object)person.Email);
                        command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(person.Phone) ? System.DBNull.Value : (object)person.Phone);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(person.Notes) ? System.DBNull.Value : (object)person.Notes);
                        command.Parameters.AddWithValue("@UserName", user.UserName);
                        command.Parameters.AddWithValue("@Password", user.Password);
                        command.Parameters.AddWithValue("@Salt", user.Salt);

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
                        {
                            newAccountID = null;
                            throw new Exception("حدث خطأ في إنشاء الحساب");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                newAccountID = null;
                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(newAccountID);
        }

        public async Task<IResult<bool>> Update(Account account, int currentUserID)
        {
            bool result = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Account_UpdateByUserID", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AccountName", account.AccountName);
                        command.Parameters.AddWithValue("@IsActive", account.IsActive);
                        command.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(account.Description) ? System.DBNull.Value : (object)account.Description);
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

                if (!result)
                {
                    throw new Exception("فشل تحديث الحساب");
                }
            }
            catch (Exception ex)
            {
                result = false;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(result);
        }

        public async Task<IResult<Account>> Get(short accountID)
        {
            Account accountData = null;
            var handler = _resultFactory.Create<Account>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Account_GetByAccountID", connection))
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
                                decimal balance = Convert.ToDecimal(reader["Balance"]);
                                int accountOwnerUserID = Convert.ToInt32(reader["AccountOwnerUserID"]);

                                accountData = new Account(accountID, accountName, createdDate, isActive,
                                    defaultCurrencyID, description, balance, accountOwnerUserID);
                            }
                            else
                                accountData = null;

                            if (accountData == null)
                                throw new Exception("فشلت العملية");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                accountData = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(accountData);
        }

        public async Task<IResult<bool>> IsExistByAccountName(string accountName)
        {
            bool isExist = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Account_IsExistByAccountName", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AccountName", accountName);

                        SqlParameter retunValue = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(retunValue);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        isExist = (retunValue.Value != DBNull.Value) && (Convert.ToInt32(retunValue.Value) == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                isExist = false;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(isExist);
        }

        public async Task<IResult<bool>> Delete(short accountID)
        {
            bool result = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_Account_DeleteByID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AccountID", accountID);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                    }
                }

                result = true;
            }
            catch (Exception ex)
            {
                result = false;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(result);
        }
    }
}
