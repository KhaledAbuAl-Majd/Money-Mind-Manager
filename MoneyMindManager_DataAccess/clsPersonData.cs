using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManagerGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.PersonClassess;

namespace MoneyMindManager_DataAccess
{
    public static class clsPersonData
    {
        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>New PersonID if Success, if failed return null</returns>
        public static async Task<Nullable<int>> AddNewPerson(string personName, string address, string email, string phone,
            short accountID, string notes, bool RaiseEventOnErrorOccured = true)
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
                                Nullable<short> accountID = Convert.ToInt16(reader["AccountID"]);
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

        /// <summary>
        /// Get All People For Account Using Paging [10 rows per page]
        /// </summary>
        /// <param name="accountID">The current AccountID</param>
        /// <param name="pageNumber">The page Number you want to get rows of it</param>
        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>object of clsGetAllPeople : if error happend, return null</returns>
        public static async Task<clsGetAllPeople> GetAllPeople(short accountID,short pageNumber, bool RaiseEventOnErrorOccured = true)
        {
            clsGetAllPeople allPeople = null;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using(SqlCommand command = new SqlCommand("[dbo].[SP_GetAllPeople]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AccountID", accountID);
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
                            DataTable dtPeople = new DataTable();
                            dtPeople.Load(reader);
                            short numberOfPages = Convert.ToInt16(outputNumberOfPages.Value);
                            short recordsCount = Convert.ToInt16(outputRecordsCount.Value);

                            allPeople = new clsGetAllPeople(dtPeople, numberOfPages, pageNumber, recordsCount);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                allPeople = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return allPeople;
        }

        /// <summary>
        /// Get All People By PersonID For Account Using Paging [10 rows per page]
        /// </summary>
        /// <param name="accountID">The current AccountID</param>
        /// <param name="pageNumber">The page Number you want to get rows of it</param>
        /// <param name="personID">The personID you want to search for</param>
        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>object of clsGetAllPeople : if error happend, return null</returns>
        public static async Task<clsGetAllPeople> GetAllPeopleByPersonID(short accountID, short pageNumber,int personID, bool RaiseEventOnErrorOccured = true)
        {
            clsGetAllPeople allPeople = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_GetAllPeopleByPersonID]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AccountID", accountID);
                        command.Parameters.AddWithValue("@PageNumber", pageNumber);
                        command.Parameters.AddWithValue("@PersonID", personID);

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
                            DataTable dtPeople = new DataTable();
                            dtPeople.Load(reader);
                            short numberOfPages = Convert.ToInt16(outputNumberOfPages.Value);
                            short recordsCount = Convert.ToInt16(outputRecordsCount.Value);

                            allPeople = new clsGetAllPeople(dtPeople, numberOfPages, pageNumber, recordsCount);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                allPeople = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseEvent(ex.Message, true);
            }

            return allPeople;
        }
    }
}
