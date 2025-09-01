using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManagerGlobal;

namespace MoneyMindManager_DataAccess
{
    public static class clsUserData
    {
        public class clsUserColumns
        {
            public Nullable<int> UserID { get; set; }
            public string UserName { get; set; }
            public Nullable<int> PersonID { get; set; }
            public Nullable<int> Permissions { get; set; }

            /// <summary>
            /// Hashed Password [Hash(Password + Salt) ]
            /// </summary>
            public string Password { get; set; }
            public string Salt { get; set; }
            public bool IsActive { get; set; }
            public string Notes { get; set; }
            public Nullable<int> AccountID { get; set; }
            public bool IsDeleted { get; set; }

            public clsUserColumns(int? userID, string userName,int? personID, int? permissions, string password, string salt
                , bool isActive, string notes, int? accountID,bool isDeleted)
            {
                this.UserID = userID;
                this.UserName = userName;
                this.PersonID = personID;
                this.Permissions = permissions;
                this.Password = password;
                this.Salt = salt;
                this.IsActive = isActive;
                this.Notes = notes;
                this.AccountID = accountID;
                this.IsDeleted = isDeleted;
            }

            public clsUserColumns()
            {
                this.UserID = null;
                this.UserName = null;
                this.PersonID = null;
                this.Permissions = null;
                this.Password = null;
                this.Salt = null;
                this.IsActive = true;
                this.Notes = null;
                this.AccountID = null;
                this.IsDeleted = false;
            }
        }

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>New UserID if Success, if failed return null</returns>
        public static async Task<Nullable<int>> AddNewUser(string userName,int personID, int permissions, string password, string salt,
            bool isActive,int accountID, string notes, bool RaiseEventOnErrorOccured = true)
        {
            int? newUserID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_AddNewUser]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@Permissions", (object)permissions ?? System.DBNull.Value);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Salt", salt);
                        command.Parameters.AddWithValue("@IsActive", isActive);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? System.DBNull.Value : (object)notes);
                        command.Parameters.AddWithValue("@AccountID", accountID);

                        SqlParameter outputnewUserID = new SqlParameter("@NewUserID", System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };

                        command.Parameters.Add(outputnewUserID);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        if (int.TryParse(outputnewUserID.Value?.ToString(), out int parsingResult))
                        {
                            newUserID = parsingResult;
                        }
                        else
                            newUserID = null;

                        //newUserID = outputnewUserID?.Value as int?;
                    }
                }
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
        public static async Task<bool> UpdateUser(int userID, int personID, int permissions, bool isActive,
            string notes, bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_UpdateUserByUserID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@Permissions", (object)permissions?? System.DBNull.Value);
                        command.Parameters.AddWithValue("@IsActive", isActive);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? System.DBNull.Value : (object)notes);

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
            string newSalt, bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_ChangeUserPassword]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@OldPassword", oldPassword);
                        command.Parameters.AddWithValue("@NewPassword", newPassword);
                        command.Parameters.AddWithValue("@NewSalt", newSalt);

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
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_DeleteUserByUserID]", connection))
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
        public static async Task<clsUserColumns> GetUserInfoByUserID(int userID, bool RaiseEventOnErrorOccured = true)
        {
            clsUserColumns userData = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_GetUserByUserID]", connection))
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
                                Nullable<int> permissions = (reader["Permissions"] == DBNull.Value) ? null : Convert.ToInt32(reader["Permissions"]) as int?;
                                string password = (reader["Password"] == DBNull.Value) ? null : reader["Password"] as string;
                                string salt = (reader["Salt"] == DBNull.Value) ? null : reader["Salt"] as string;
                                bool isActive = Convert.ToBoolean(reader["IsActive"]);
                                string notes = (reader["Notes"] == DBNull.Value) ? null : reader["Notes"] as string;
                                Nullable<int> accountID = Convert.ToInt32(reader["AccountID"]);
                                bool isDeleted = Convert.ToBoolean(reader["IsDeleted"]);

                                userData = new clsUserColumns(userID, userName, personID, permissions, password, salt, isActive, notes, accountID, isDeleted);
                            }
                            else
                                userData = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                userData = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return userData;
        }

        /// <param name="personID">PersonID of person you wnat to find</param>
        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>true if person exist, false if person not exist</returns>
        public static async Task<bool> IsPersonExistByID(int personID, bool RaiseEventOnErrorOccured = true)
        {
            bool isExist = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IsPersonExistByID]", connection))
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
    }
}
