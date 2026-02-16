using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Core;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Paged_Result_DTOs;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Criteria;
using MoneyMindManager.Domain.Entities;

namespace MoneyMindManager.Infrastructure.Repositories.Database.SQLServer
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly ILogger _logger;
        private readonly IDatabaseSettings _databaseSettings;
        private readonly IResultFactory _resultFactory;

        public SQLUserRepository(ILogger logger, IDatabaseSettings databaseSettings, IResultFactory resultFactory)
        {
            this._logger = logger;
            this._databaseSettings = databaseSettings;
            this._resultFactory = resultFactory;
        }

        public async Task<IResult<int?>> Add(User user)
        {
            int? newUserID = null;
            var handler = _resultFactory.Create<int?>();

            try
            {

                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_AddNew", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", (string.IsNullOrEmpty(user.UserName)) ? DBNull.Value : (object)user.UserName);
                        command.Parameters.AddWithValue("@PersonID", user.PersonID);
                        command.Parameters.AddWithValue("@Permissions", user.Permissions);
                        command.Parameters.AddWithValue("@Password", user.Password);
                        command.Parameters.AddWithValue("@Salt", user.Salt);
                        command.Parameters.AddWithValue("@IsActive", user.IsActive);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(user.Notes) ? System.DBNull.Value : (object)user.Notes);
                        command.Parameters.AddWithValue("@CreatedByUserID", user.CreatedByUserID);

                        SqlParameter outputnewUserID = new SqlParameter("@NewUserID", System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };

                        command.Parameters.Add(outputnewUserID);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        if (outputnewUserID.Value != DBNull.Value && (int.TryParse(outputnewUserID.Value?.ToString(), out int parsingResult)))
                        {
                            newUserID = parsingResult;
                        }
                        else
                            newUserID = null;

                        //newUserID = outputnewUserID?.Value as int?;
                    }
                }

                if (newUserID == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                newUserID = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(newUserID);
        }

        public async Task<IResult<bool>> Update(User user, int currentUserID)
        {
            bool result = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_UpdateByUserID", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", user.UserID);
                        command.Parameters.AddWithValue("@UserName", (string.IsNullOrEmpty(user.UserName)) ? DBNull.Value : (object)user.UserName);
                        command.Parameters.AddWithValue("@PersonID", user.PersonID);
                        command.Parameters.AddWithValue("@Permissions", user.Permissions);
                        command.Parameters.AddWithValue("@IsActive", user.IsActive);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(user.Notes) ? System.DBNull.Value : (object)user.Notes);
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

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(result);
        }

        public async Task<IResult<bool>> ChangePassword(int userID, string oldPassword, string newPassword, string newSalt, int currentUserID)
        {
            bool result = false;
            var handler = _resultFactory.Create<bool>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_ChangePassword", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@OldPassword", oldPassword);
                        command.Parameters.AddWithValue("@NewPassword", newPassword);
                        command.Parameters.AddWithValue("@NewSalt", newSalt);
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

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(result);
        }

        public async Task<IResult<bool>> DeleteByUserID(int userID)
        {
            bool result = false;
            var handler = _resultFactory.Create<bool>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_DeleteByUserID", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", userID);

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

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(result);
        }

        public async Task<IResult<User>> Login(string userName, string password)
        {
            User userData = null;
            var handler = _resultFactory.Create<User>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_GetByUserNameAndPassword_Login", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@Password", password);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                Nullable<int> userID = Convert.ToInt32(reader["UserID"]);
                                Nullable<int> personID = Convert.ToInt32(reader["PersonID"]);
                                int permissions = Convert.ToInt32(reader["Permissions"]);
                                string salt = (reader["Salt"] == DBNull.Value) ? null : reader["Salt"] as string;
                                bool isActive = Convert.ToBoolean(reader["IsActive"]);
                                string notes = (reader["Notes"] == DBNull.Value) ? null : reader["Notes"] as string;
                                short accountID = Convert.ToInt16(reader["AccountID"]);
                                bool isDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                                Nullable<int> createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                DateTime createdDate = Convert.ToDateTime(reader["CreatedDate"]);

                                userData = new User(userID, userName, personID, permissions, password, salt,
                                    isActive, notes, accountID, isDeleted, createdByUserID, createdDate);
                            }
                            else
                                userData = null;

                        }
                    }
                }

                if (userData == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                userData = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(userData);
        }

        public async Task<IResult<User>> GetByUserID(int userID)
        {
            User userData = null;
            var handler = _resultFactory.Create<User>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_GetByUserID", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", userID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                string userName = (reader["UserName"] == DBNull.Value) ? null : reader["UserName"] as string;
                                Nullable<int> personID = Convert.ToInt32(reader["PersonID"]);
                                int permissions = Convert.ToInt32(reader["Permissions"]);
                                string password = (reader["Password"] == DBNull.Value) ? null : reader["Password"] as string;
                                string salt = (reader["Salt"] == DBNull.Value) ? null : reader["Salt"] as string;
                                bool isActive = Convert.ToBoolean(reader["IsActive"]);
                                string notes = (reader["Notes"] == DBNull.Value) ? null : reader["Notes"] as string;
                                short accountID = Convert.ToInt16(reader["AccountID"]);
                                bool isDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                                Nullable<int> createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                DateTime createdDate = Convert.ToDateTime(reader["CreatedDate"]);

                                userData = new User(userID, userName, personID, permissions, password, salt,
                                    isActive, notes, accountID, isDeleted, createdByUserID, createdDate);
                            }
                            else
                                userData = null;
                        }
                    }
                }

                if (userData == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                userData = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(userData);
        }

        public async Task<IResult<User>> GetByUserName(string userName)
        {
            User userData = null;
            var handler = _resultFactory.Create<User>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_GetByUserName", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", (string.IsNullOrEmpty(userName)) ? DBNull.Value : (object)userName);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                Nullable<int> userID = Convert.ToInt32(reader["UserID"]);
                                Nullable<int> personID = Convert.ToInt32(reader["PersonID"]);
                                int permissions = Convert.ToInt32(reader["Permissions"]);
                                string password = (reader["Password"] == DBNull.Value) ? null : reader["Password"] as string;
                                string salt = (reader["Salt"] == DBNull.Value) ? null : reader["Salt"] as string;
                                bool isActive = Convert.ToBoolean(reader["IsActive"]);
                                string notes = (reader["Notes"] == DBNull.Value) ? null : reader["Notes"] as string;
                                short accountID = Convert.ToInt16(reader["AccountID"]);
                                bool isDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                                Nullable<int> createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                DateTime createdDate = Convert.ToDateTime(reader["CreatedDate"]);

                                userData = new User(userID, userName, personID, permissions, password, salt,
                                    isActive, notes, accountID, isDeleted, createdByUserID, createdDate);
                            }
                            else
                                userData = null;
                        }
                    }
                }

                if (userData == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                userData = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(userData);
        }

        public async Task<IResult<User>> GetByPersonID(int personID)
        {
            User userData = null;
            var handler = _resultFactory.Create<User>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_GetByPersonID", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", personID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                Nullable<int> userID = Convert.ToInt32(reader["UserID"]);
                                string userName = (reader["UserName"] == DBNull.Value) ? null : reader["UserName"] as string;
                                int permissions = Convert.ToInt32(reader["Permissions"]);
                                string password = (reader["Password"] == DBNull.Value) ? null : reader["Password"] as string;
                                string salt = (reader["Salt"] == DBNull.Value) ? null : reader["Salt"] as string;
                                bool isActive = Convert.ToBoolean(reader["IsActive"]);
                                string notes = (reader["Notes"] == DBNull.Value) ? null : reader["Notes"] as string;
                                short accountID = Convert.ToInt16(reader["AccountID"]);
                                bool isDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                                Nullable<int> createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                DateTime createdDate = Convert.ToDateTime(reader["CreatedDate"]);

                                userData = new User(userID, userName, personID, permissions, password, salt,
                                    isActive, notes, accountID, isDeleted, createdByUserID, createdDate);
                            }
                            else
                                userData = null;
                        }
                    }
                }

                if (userData == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                userData = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(userData);
        }

        public async Task<IResult<bool>> IsExistByUserID(int userID, bool includeDeleted)
        {
            bool isExist = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_IsExistByUserID", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@IncludeDeleted", includeDeleted);

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

        public async Task<IResult<bool>> IsExistByPersonID(int personID, bool includeDeleted)
        {
            bool isExist = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_IsExistByPersonID", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@IncludeDeleted", includeDeleted);

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

        public async Task<IResult<bool>> IsExistByUserName(string userName, bool includeDeleted)
        {
            bool isExist = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_IsExistByUserName", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@IncludeDeleted", includeDeleted);

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

        public async Task<IResult<string>> GetSaltByUserID(int userID)
        {
            string salt = null;
            var handler = _resultFactory.Create<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_GetSaltByUserID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", userID);

                        SqlParameter outputUserSalt = new SqlParameter("@Salt", SqlDbType.VarChar, 24)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(outputUserSalt);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        salt = (outputUserSalt.Value == DBNull.Value) ? null : outputUserSalt.Value as string;
                    }
                }

                if (salt == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                salt = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(salt);
        }

        public async Task<IResult<string>> GetSaltByUserName(string userName)
        {
            string salt = null;
            var handler = _resultFactory.Create<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_GetSaltByUserName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", (string.IsNullOrEmpty(userName)) ? DBNull.Value : (object)userName);

                        SqlParameter outputUserSalt = new SqlParameter("@Salt", SqlDbType.VarChar, 24)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(outputUserSalt);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        salt = (outputUserSalt.Value == DBNull.Value) ? null : outputUserSalt.Value as string;
                    }
                }

                if (salt == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                salt = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(salt);
        }

        public async Task<IResult<PagedResultDTO<UserSummary>>> GetAll(UserSearchCriteria userFilterDTO, int currentUserID)
        {
            PagedResultDTO<UserSummary> userPaged = null;
            var handler = _resultFactory.Create<PagedResultDTO<UserSummary>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_Users_GetAll]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", (object)userFilterDTO.UserID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UserName", string.IsNullOrWhiteSpace(userFilterDTO.UserName) ? DBNull.Value : (object)userFilterDTO.UserName);
                        command.Parameters.AddWithValue("@PersonName", string.IsNullOrWhiteSpace(userFilterDTO.PersonName) ? DBNull.Value : (object)userFilterDTO.PersonName);
                        command.Parameters.AddWithValue("@IsActive", (object)userFilterDTO.IsActive ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TextSearchMode", userFilterDTO.TextSearchMode);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);
                        command.Parameters.AddWithValue("@PageNumber", userFilterDTO.PageNumber);
                        command.Parameters.AddWithValue("@RowsPerPage", userFilterDTO.RowsPerPage);

                        SqlParameter outputNumberOfPages = new SqlParameter("@NumberOfPages", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        SqlParameter outputRecordsCount = new SqlParameter("@RecordsCount", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(outputNumberOfPages);
                        command.Parameters.Add(outputRecordsCount);

                        await connection.OpenAsync();


                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            int userIDOrdinal = reader.GetOrdinal("UserID");
                            int userNameOrdianl = reader.GetOrdinal("UserName");
                            int personNameOrdianl = reader.GetOrdinal("PersonName");
                            int phoneOrdianl = reader.GetOrdinal("Phone");
                            int emailOrdianl = reader.GetOrdinal("Email");
                            int isActiveOrdianl = reader.GetOrdinal("IsActive");

                            List<UserSummary> userSummariesList = new List<UserSummary>();

                            while (await reader.ReadAsync())
                            {
                                int userID = Convert.ToInt32(reader[userIDOrdinal]);
                                string userName = reader[userNameOrdianl] as string;
                                string personName = reader[personNameOrdianl] as string;
                                string phone = reader[phoneOrdianl] as string;
                                string email = reader[emailOrdianl] as string;
                                bool isActive = Convert.ToBoolean(reader[isActiveOrdianl]);

                                var user = new UserSummary()
                                {
                                    UserID = userID,
                                    UserName = userName,
                                    PersonName = personName,
                                    Phone = phone,
                                    Email = email,
                                    IsActive = isActive
                                };

                                userSummariesList.Add(user);
                            }

                            int numberOfPages = Convert.ToInt32(outputNumberOfPages.Value);
                            int recordsCount = Convert.ToInt32(outputRecordsCount.Value);

                            userPaged = new PagedResultDTO<UserSummary>(userSummariesList, numberOfPages, recordsCount);
                        }
                    }
                }

                if (userPaged == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                userPaged = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(userPaged);
        }

        public async Task<IResult<int>> GetPermissions(int userID)
        {
            int permissions = 0;
            var handler = _resultFactory.Create<int>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_GetPermissionsByUserID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", userID);

                        SqlParameter permissionsOut = new SqlParameter("@Permissions", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(permissionsOut);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        permissions = (permissionsOut.Value != DBNull.Value) ? Convert.ToInt32(permissionsOut.Value) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(permissions);
        }
    }
}
