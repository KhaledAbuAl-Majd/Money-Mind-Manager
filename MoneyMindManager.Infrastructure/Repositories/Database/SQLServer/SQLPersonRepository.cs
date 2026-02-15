using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Core;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Criteria;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Domain.NewFolder1;
using MoneyMindManager.Shared.DTOs;

namespace MoneyMindManager.Infrastructure.Repositories.Database.SQLServer
{
    public class SQLPersonRepository : IPersonRepository
    {
        private readonly ILogger _logger;
        private readonly IDatabaseSettings _databaseSettings;
        private readonly IResultFactory _resultFactory;

        public SQLPersonRepository(ILogger logger, IDatabaseSettings databaseSettings, IResultFactory resultFactory)
        {
            this._logger = logger;
            this._databaseSettings = databaseSettings;
            this._resultFactory = resultFactory;
        }

        public async Task<IResult<int?>> Add(Person person)
        {
            int? newPersonID = null;
            var handler = _resultFactory.Create<int?>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Person_AddNew", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonName", person.PersonName);
                        command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(person.Address) ? System.DBNull.Value : (object)person.Address);
                        command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(person.Email) ? System.DBNull.Value : (object)person.Email);
                        command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(person.Phone) ? System.DBNull.Value : (object)person.Phone);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(person.Notes) ? System.DBNull.Value : (object)person.Notes);
                        command.Parameters.AddWithValue("@CreatedByUserID", person.CreatedByUserID);

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

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(newPersonID);
        }

        /// <returns>Updating Result</returns>
        public async Task<IResult<bool>> Update(Person person, int currentUserID)
        {
            bool result = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Person_UpdateByID", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", person.PersonID);
                        command.Parameters.AddWithValue("@PersonName", person.PersonName);
                        command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(person.Address) ? System.DBNull.Value : (object)person.Address);
                        command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(person.Email) ? System.DBNull.Value : (object)person.Email);
                        command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(person.Phone) ? System.DBNull.Value : (object)person.Phone);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(person.Notes) ? System.DBNull.Value : (object)person.Notes);
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

        public async Task<IResult<bool>> Delete(int personID, int currentUserID)
        {
            bool result = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
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

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(result);
        }

        /// <returns>Object of Person, if person is not found it will return null</returns>
        public async Task<IResult<Person>> Get(int personID, int currentUserID)
        {
            Person personData = null;
            var handler = _resultFactory.Create<Person>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
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

                                personData = new Person(personID, personName, address, email, phone, accountID,
                                    notes, createdByUserID, createdDate, receivable, payable);
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

                _logger.LogError(ex.Message);
                handler.Failure(ex.Message);
            }

            return handler.Success(personData);
        }

        // <returns>true if person exist, false if person not exist</returns>
        public async Task<IResult<bool>> IsExist(int personID)
        {
            bool isExist = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
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

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(isExist);
        }

        public async Task<IResult<PagedResultDTO<Person>>> GetAll(PersonSearchCriteria personSearchCriteria, int currentUserID)
        {
            PagedResultDTO<Person> PeoplePaged = null;
            var handler = _resultFactory.Create<PagedResultDTO<Person>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_People_GetAll]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", (object)personSearchCriteria.PersonID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PersonName", string.IsNullOrWhiteSpace(personSearchCriteria.PersonName) ? DBNull.Value : (object)personSearchCriteria.PersonName);
                        command.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(personSearchCriteria.Email) ? DBNull.Value : (object)personSearchCriteria.Email);
                        command.Parameters.AddWithValue("@Phone", string.IsNullOrWhiteSpace(personSearchCriteria.Phone) ? DBNull.Value : (object)personSearchCriteria.Phone);
                        command.Parameters.AddWithValue("@TextSearchMode", personSearchCriteria.TextSearchMode);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);
                        command.Parameters.AddWithValue("@PageNumber", personSearchCriteria.PageNumber);
                        command.Parameters.AddWithValue("@RowsPerPage", personSearchCriteria.RowsPerPage);

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
                            List<Person> people = new List<Person>();

                            int personOrdianl = reader.GetOrdinal("PersonID");
                            int personNameOrdinal = reader.GetOrdinal("PersonName");
                            int addressOrdinal = reader.GetOrdinal("Address");
                            int emailOrdinal = reader.GetOrdinal("Email");
                            int phoneOrdinal = reader.GetOrdinal("Phone");

                            while (await reader.ReadAsync())
                            {
                                int personID = Convert.ToInt32(reader[personOrdianl]);
                                string personName = reader[personNameOrdinal] as string;
                                string address = reader[addressOrdinal] as string;
                                string email = reader[emailOrdinal] as string;
                                string phone = reader[phoneOrdinal] as string;

                                var person = new Person()
                                {
                                    PersonID = personID,
                                    PersonName = personName,
                                    Address = address,
                                    Email = email,
                                    Phone = phone
                                };

                                people.Add(person);
                            }

                            int numberOfPages = Convert.ToInt32(outputNumberOfPages.Value);
                            int recordsCount = Convert.ToInt32(outputRecordsCount.Value);

                            PeoplePaged = new PagedResultDTO<Person>(people, numberOfPages, recordsCount);
                        }
                    }
                }

                if (PeoplePaged == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                PeoplePaged = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(PeoplePaged);
        }

        public async Task<IResult<PagedResultDTO<Person>>> GetAllForSelectOne(PersonSelectSearchCriteria personSearchCriteria, int currentUserID)
        {
            PagedResultDTO<Person> peoplePaged = null;
            var handler = _resultFactory.Create<PagedResultDTO<Person>>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_People_GetAllForSelectOne]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonName", string.IsNullOrWhiteSpace(personSearchCriteria.PersonName) ? DBNull.Value : (object)personSearchCriteria.PersonName);
                        command.Parameters.AddWithValue("@TextSearchMode", personSearchCriteria.TextSearchMode);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);
                        command.Parameters.AddWithValue("@PageNumber", personSearchCriteria.PageNumber);
                        command.Parameters.AddWithValue("@RowsPerPage", personSearchCriteria.RowsPerPage);


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
                            List<Person> people = new List<Person>();

                            int personOrdianl = reader.GetOrdinal("PersonID");
                            int personNameOrdinal = reader.GetOrdinal("PersonName");

                            while (await reader.ReadAsync())
                            {
                                int personID = Convert.ToInt32(reader[personOrdianl]);
                                string personName = reader[personNameOrdinal] as string;

                                var person = new Person()
                                {
                                    PersonID = personID,
                                    PersonName = personName
                                };

                                people.Add(person);
                            }

                            int numberOfPages = Convert.ToInt32(outputNumberOfPages.Value);
                            int recordsCount = Convert.ToInt32(outputRecordsCount.Value);

                            peoplePaged = new PagedResultDTO<Person>(people, numberOfPages, recordsCount);
                        }
                    }
                }

                if (peoplePaged == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                peoplePaged = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(peoplePaged);
        }
    }
}
