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
    public static class clsPersonData
    {
        public class clsPersonColumns
        {
            public Nullable<int> PersonID { get;protected set; }
            public string PersonName { get; set; } 
            public string Address { get; set; } 
            public string Email { get; set; } 
            public string Phone { get; set; }
            public Nullable<int> AccountID { get; set; }
            public string Notes { get; set; } 

            public clsPersonColumns(int? personID,string personName,string address,string email,string phone,int?accountID,string notes)
            {
                this.PersonID = personID;
                this.PersonName = personName;
                this.Address = address;
                this.Email = email;
                this.Phone = phone;
                this.AccountID = accountID;
                this.Notes = notes;
            }
       
            public clsPersonColumns()
            {
                this.PersonID = null;
                this.PersonName = null;
                this.Address = null;
                this.Email = null;
                this.Phone = null;
                this.AccountID = null;
                this.Notes = null;
            }
        }

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>New PersonID if Success, if failed return null</returns>
        public static async Task<Nullable<int>> AddNewPerson(string personName, string address, string email, string phone,
            int accountID, string notes, bool RaiseEventOnErrorOccured = true)
        {
            int? newPersonID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_AddNewPerson]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonName", personName);
                        command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(address) ? System.DBNull.Value : (object)address);
                        command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? System.DBNull.Value : (object)email);
                        command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(phone) ? System.DBNull.Value : (object)phone);
                        command.Parameters.AddWithValue("@AccountID", accountID);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? System.DBNull.Value : (object)notes);

                        SqlParameter outputnewPersonID = new SqlParameter("@NewPersonID", System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };

                        command.Parameters.Add(outputnewPersonID);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        if (outputnewPersonID.Value != DBNull.Value && (int.TryParse(outputnewPersonID.Value?.ToString(), out int parsingResult)))
                        {
                            newPersonID = parsingResult;
                        }
                        else
                            newPersonID = null;

                        //newPersonID = outputnewPersonID?.Value as int?;
                    }
                }
            }
            catch (Exception ex)
            {
                newPersonID = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return newPersonID;
        }

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>Updating Result</returns>
        public static async Task<bool> UpdatePerson(int personID, string personName, string address, string email, string phone,
            string notes, bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_UpdatePersonByID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@PersonName", personName);
                        command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(address) ? System.DBNull.Value : (object)address);
                        command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? System.DBNull.Value : (object)email);
                        command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(phone) ? System.DBNull.Value : (object)phone);
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

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>Deleting Result</returns>
        public static async Task<bool> DeletePersonByID(int personID, bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_DeletePersonByID]", connection))
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
        /// <returns>Object of clsUserColumns, if person is not found it will return null</returns>
        public static async Task<clsPersonColumns> GetPersonInfoByID(int personID, bool RaiseEventOnErrorOccured = true)
        {
            clsPersonColumns personData = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_GetPersonByID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", personID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {

                            if (await reader.ReadAsync())
                            {
                                string personName = reader["PersonName"] as string;
                                string address = (reader["Address"] == System.DBNull.Value) ? null : reader["Address"] as string;
                                string email = (reader["Email"] == System.DBNull.Value) ? null : reader["Email"] as string;
                                string phone = (reader["Phone"] == System.DBNull.Value) ? null : reader["Phone"] as string;
                                Nullable<int> accountID = Convert.ToInt32(reader["AccountID"]);
                                //Nullable<int> AccountID = reader["AccountID"] as int?;
                                string notes = (reader["Notes"] == System.DBNull.Value) ? null : reader["Notes"] as string;

                                personData = new clsPersonColumns(personID, personName, address, email, phone, accountID, notes);
                            }
                            else
                                personData = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                personData = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return personData;
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
