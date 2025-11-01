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
    public static class clsPersonData
    {
        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>New PersonID if Success, if failed return null</returns>
        public static async Task<Nullable<int>> AddNewPerson(string personName, string address, string email, string phone,
            short accountID, string notes,int createdByUserID, bool RaiseEventOnErrorOccured = true)
        {
            int? newPersonID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Person_AddNew", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonName", personName);
                        command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(address) ? System.DBNull.Value : (object)address);
                        command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? System.DBNull.Value : (object)email);
                        command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(phone) ? System.DBNull.Value : (object)phone);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? System.DBNull.Value : (object)notes);
                        command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

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

                if (newPersonID == null)
                    throw new Exception("فشلت العمية");
            }
            catch (Exception ex)
            {
                newPersonID = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return newPersonID;
        }

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>Updating Result</returns>
        public static async Task<bool> UpdatePerson(int personID, string personName, string address, string email, string phone,
            string notes,int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Person_UpdateByID", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@PersonName", personName);
                        command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(address) ? System.DBNull.Value : (object)address);
                        command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? System.DBNull.Value : (object)email);
                        command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(phone) ? System.DBNull.Value : (object)phone);
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
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return result;
        }

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>Deleting Result</returns>
        public static async Task<bool> DeletePersonByID(int personID,int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Person_DeleteByID", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", personID);
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
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return result;
        }

        /// <param name="RaiseEventOnErrorOccured">if error occured will raise event,log it, show message box of error</param>
        /// <returns>Object of clsUserColumns, if person is not found it will return null</returns>
        public static async Task<clsPersonColumns> GetPersonInfoByID(int personID,int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            clsPersonColumns personData = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_Person_GetByID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

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
                                Nullable<int> createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                DateTime createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                                decimal receivable = Convert.ToDecimal(reader["Receivable"]);
                                decimal payable = Convert.ToDecimal(reader["Payable"]);

                                personData = new clsPersonColumns(personID, personName, address, email, phone, accountID,
                                    notes,createdByUserID,createdDate,receivable,payable);
                            }
                            else
                                personData = null;
                        }
                    }
                }

                if (personData == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                personData = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
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
                    using (SqlCommand command = new SqlCommand("SP_Person_IsExistByID", connection))
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
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return isExist;
        }

        /// <summary>
        /// Get All People For Account Using Paging , if variable null will not filter by it.
        /// </summary>
        /// <returns>object of clsGetAllPeople : if error happend, return null</returns>
        public static async Task<clsGetAllPeople> GetAllPeople(int? personID, string personName, string email,
             string phone,byte textSearchMode, short pageNumber,byte rowsPerPage, int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            clsGetAllPeople allPeople = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_People_GetAll]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", (object)personID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PersonName", string.IsNullOrWhiteSpace(personName) ? DBNull.Value : (object)personName);
                        command.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? DBNull.Value : (object)email);
                        command.Parameters.AddWithValue("@Phone", string.IsNullOrWhiteSpace(phone) ? DBNull.Value : (object)phone);
                        command.Parameters.AddWithValue("@TextSearchMode", textSearchMode);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);
                        command.Parameters.AddWithValue("@PageNumber", pageNumber);
                        command.Parameters.AddWithValue("@RowsPerPage", rowsPerPage);

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
                            int recordsCount = Convert.ToInt32(outputRecordsCount.Value);

                            allPeople = new clsGetAllPeople(dtPeople, numberOfPages, recordsCount);
                        }
                    }
                }

                if (allPeople == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                allPeople = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return allPeople;
        }

        public static async Task<clsGetAllPeople> GetAllPeopleForSelectOne(string personName, byte textSearchMode,
            short pageNumber, byte rowsPerPage, int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            clsGetAllPeople allPeople = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_People_GetAllForSelectOne]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonName", string.IsNullOrWhiteSpace(personName) ? DBNull.Value : (object)personName);
                        command.Parameters.AddWithValue("@TextSearchMode", textSearchMode);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);
                        command.Parameters.AddWithValue("@PageNumber", pageNumber);
                        command.Parameters.AddWithValue("@RowsPerPage", rowsPerPage);

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
                            int recordsCount = Convert.ToInt32(outputRecordsCount.Value);

                            allPeople = new clsGetAllPeople(dtPeople, numberOfPages, recordsCount);
                        }
                    }
                }

                if (allPeople == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                allPeople = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return allPeople;
        }
    }
}
