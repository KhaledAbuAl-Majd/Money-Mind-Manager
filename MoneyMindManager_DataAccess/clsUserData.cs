using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManagerGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.clsUserClasses;
using static MoneyMindManagerGlobal.clsDataColumns.PersonClasses;

namespace MoneyMindManager_DataAccess
{
    public static class clsUserData
    {
        

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>New UserID if Success, if failed return null</returns>
        public static async Task<Nullable<int>> AddNewUser(string userName,int personID, int permissions, string password, string salt,
            bool isActive, string notes, int createdByUserID, bool RaiseEventOnErrorOccured = true)
        {
            int? newUserID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_AddNew", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", (string.IsNullOrEmpty(userName)) ? DBNull.Value : (object)userName);
                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@Permissions", permissions);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Salt", salt);
                        command.Parameters.AddWithValue("@IsActive", isActive);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? System.DBNull.Value : (object)notes);
                        command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return newUserID;
        }

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>Updating Result</returns>
        public static async Task<bool> UpdateUser(int userID,string userName, int personID, int permissions, bool isActive,
            string notes,int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_UpdateByUserID", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@UserName", (string.IsNullOrEmpty(userName)) ? DBNull.Value : (object)userName);
                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@Permissions", permissions);
                        command.Parameters.AddWithValue("@IsActive", isActive);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? System.DBNull.Value : (object)notes);
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

        /// <param name="oldPassword">the old hashed password</param>
        /// <param name="newPassword">the new hashed password</param>
        /// <param name="newSalt">the new salt of the new hashed password</param>
        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>Updating Result</returns>
        public static async Task<bool> ChangeUserPassword(int userID,string oldPassword ,string newPassword,
            string newSalt,int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return result;
        }

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>Deleting Result</returns>
        public static async Task<bool> DeleteUserByUserID(int userID, bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return result;
        }

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>Object of clsUserColumns, if user is not found it will return null</returns>
        public static async Task<clsUserColumns> GetUserInfoByUserNameAndPassword_Login(string userName,string password, bool RaiseEventOnErrorOccured = true)
        {
            clsUserColumns userData = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
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

                                userData = new clsUserColumns(userID, userName, personID, permissions, password, salt,
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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return userData;
        }

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>Object of clsUserColumns, if user is not found it will return null</returns>
        public static async Task<clsUserColumns> GetUserInfoByUserID(int userID, bool RaiseEventOnErrorOccured = true)
        {
            clsUserColumns userData = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
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

                                userData = new clsUserColumns(userID, userName, personID, permissions, password, salt,
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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return userData;
        }

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>Object of clsUserColumns, if user is not found it will return null</returns>
        public static async Task<clsUserColumns> GetUserInfoByUserName(string userName, bool RaiseEventOnErrorOccured = true)
        {
            clsUserColumns userData = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
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

                                userData = new clsUserColumns(userID, userName, personID, permissions, password, salt,
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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return userData;
        }

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>Object of clsUserColumns, if user is not found it will return null</returns>
        public static async Task<clsUserColumns> GetUserInfoByPersonID(int personID, bool RaiseEventOnErrorOccured = true)
        {
            clsUserColumns userData = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
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

                                userData = new clsUserColumns(userID, userName, personID, permissions, password, salt,
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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return userData;
        }

        /// <param name="userID">UserID of user you want to find</param>
        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>true if user exist, false if user not exist</returns>
        public static async Task<bool> IsUserExistByUserID(int userID, bool RaiseEventOnErrorOccured = true)
        {
            bool isExist = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_IsExistByUserID", connection))
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

                        isExist = (retunValue.Value != DBNull.Value) && (Convert.ToInt32(retunValue.Value) == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                isExist = false;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return isExist;
        }

        /// <param name="personID">PersonID of user you want to find</param>
        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>true if user exist, false if user not exist</returns>
        public static async Task<bool> IsUserExistByPersonID(int personID, bool RaiseEventOnErrorOccured = true)
        {
            bool isExist = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_IsExistByPersonID", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", personID);

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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return isExist;
        }

        /// <param name="userName">userName of user you want to find</param>
        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>true if user exist, false if user not exist</returns>
        public static async Task<bool> IsUserExistByUserNameAsync(string userName, bool RaiseEventOnErrorOccured = true)
        {
            bool isExist = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_IsExistByUserName", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", userName);

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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return isExist;
        }

        /// <param name="userName">userName of user you want to find</param>
        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>true if user exist, false if user not exist</returns>
        public static bool IsUserExistByUserName(string userName, bool RaiseEventOnErrorOccured = true)
        {
            bool isExist = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_IsExistByUserName", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", userName);

                        SqlParameter retunValue = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(retunValue);

                        connection.Open();
                        command.ExecuteNonQuery();

                        isExist = (retunValue.Value != DBNull.Value) && (Convert.ToInt32(retunValue.Value) == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                isExist = false;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return isExist;
        }

        /// <returns>UserSalt, if failed return null</returns>
        public static async Task<string> GetUserSaltByUserName(string userName, bool RaiseEventOnErrorOccured = true)
        {
            string salt = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_GetSaltByUserName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", (string.IsNullOrEmpty(userName)) ? DBNull.Value : (object)userName);

                        SqlParameter outputUserSalt = new SqlParameter("@Salt", SqlDbType.VarChar,24)
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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return salt;
        }

        /// <summary>
        /// Get All Users For Account Using Paging [10 rows per page], if variable is null will not filter by it
        /// </summary>
        /// <returns>object of clsGetAllUsers : if error happend, return null</returns>
        public static async Task<clsGetAllUsers> GetAllUsers(int? userID,string userName,string personName,
            bool? isActive, short pageNumber,int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            clsGetAllUsers allUsers = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_Users_GetAll]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", (object)userID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UserName", string.IsNullOrWhiteSpace(userName) ? DBNull.Value : (object)userName);
                        command.Parameters.AddWithValue("@PersonName", string.IsNullOrWhiteSpace(personName) ? DBNull.Value : (object)personName);
                        command.Parameters.AddWithValue("@IsActive", (object)isActive ?? DBNull.Value);
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

                        command.Parameters.Add(outputNumberOfPages);
                        command.Parameters.Add(outputRecordsCount);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            DataTable dtUsers = new DataTable();
                            dtUsers.Load(reader);
                            short numberOfPages = Convert.ToInt16(outputNumberOfPages.Value);
                            int recordsCount = Convert.ToInt32(outputRecordsCount.Value);

                            allUsers = new clsGetAllUsers(dtUsers, numberOfPages, recordsCount);
                        }
                    }
                }

                if (allUsers == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                allUsers = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return allUsers;
        }
    }
}
