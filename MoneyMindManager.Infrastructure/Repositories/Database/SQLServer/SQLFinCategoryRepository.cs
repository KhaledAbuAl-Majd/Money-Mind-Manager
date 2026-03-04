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
using MoneyMindManager.Domain.Abstractions.Repositories;
using MoneyMindManager.Domain.Criteria.IncomeAndExpenseCategory;
using MoneyMindManager.Domain.Entities;

namespace MoneyMindManager.Infrastructure.Repositories.Database.SQLServer.Reports
{
    public class SQLFinCategoryRepository : IFinCategoryRepository
    {
        private readonly IDatabaseSettings _databaseSettings;
        private readonly IResultFactory _resultFactory;
        private readonly ILogger _logger;


        public SQLFinCategoryRepository(IDatabaseSettings databaseSettings, IResultFactory resultFactory, ILogger logger)
        {
            this._databaseSettings = databaseSettings;
            this._resultFactory = resultFactory;
            this._logger = logger;
        }
        public async Task<IResult<int?>> Add(FinCategory category)
        {
            int? newCategoryID = null;
            var handler = _resultFactory.Create<int?>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_IncomeAndExpenseCategories_AddNew", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                        command.Parameters.AddWithValue("@MonthlyBudget", (object)category.MonthlyBudget ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsIncome", category.IsIncome);
                        command.Parameters.AddWithValue("@ParentCategoryID", (object)category.ParentCategoryID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedByUserID", category.CreatedByUserID);
                        command.Parameters.AddWithValue("@IsActive", category.IsActive);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(category.Notes) ? DBNull.Value : (object)category.Notes);

                        SqlParameter outParmNewCategory = new SqlParameter("@NewCategoryID", System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };

                        command.Parameters.Add(outParmNewCategory);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        newCategoryID = outParmNewCategory.Value as int?;
                    }
                }

                if (newCategoryID == null)
                    throw new Exception("فشلت العمية");
            }
            catch (Exception ex)
            {
                newCategoryID = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(newCategoryID);
        }
        public async Task<IResult<bool>> Update(FinCategory category, int currentUserID)
        {
            bool result = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseCategories_UpdateByCategoryID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                        command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                        command.Parameters.AddWithValue("@MonthlyBudget", (object)category.MonthlyBudget ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsActive", category.IsActive);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(category.Notes) ? DBNull.Value : (object)category.Notes);

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
        public async Task<IResult<bool>> Delete(int categoryID, int currentUserID)
        {
            bool result = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseCategories_DeleteByCategoryID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryID", categoryID);
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
        public async Task<IResult<FinCategory>> GetByID(int categoryID, int currentUserID)
        {
            FinCategory categoryData = null;
            var handler = _resultFactory.Create<FinCategory>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseCategories_GetByID]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryID", categoryID);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                string categoryName = reader["CategoryName"] as string;
                                DateTime createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                                Decimal? monthlyBudget = reader["MonthlyBudget"] as Decimal?;
                                bool isIncome = Convert.ToBoolean(reader["IsIncome"]);
                                int? parentCategoryID = reader["ParentCategoryID"] as int?;
                                short accountID = Convert.ToInt16(reader["AccountID"]);
                                int createdByUseID = Convert.ToInt32(reader["CreatedByUserID"]);
                                bool isActive = Convert.ToBoolean(reader["IsActive"]);
                                string categoryHierarchical = reader["CategoryHierarchical"] as string;
                                string notes = reader["Notes"] as string;
                                string mainCategoryName = reader["MainCategoryName"] as string;
                                string parentCategoryName = reader["ParentCategoryName"] as string;
                                int? mainCategoryID = reader["MainCategoryID"] as int?;


                                categoryData = new FinCategory(categoryID, categoryName, createdDate,
                                    monthlyBudget, isIncome, parentCategoryID, accountID, createdByUseID, isActive, categoryHierarchical,
                                    notes, mainCategoryName, parentCategoryName, mainCategoryID);
                            }
                        }
                    }
                }

                if (categoryData == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                categoryData = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(categoryData);
        }
        public async Task<IResult<FinCategory>> GetByName(string categoryName, int currentUserID)
        {
            FinCategory categoryData = null;
            var handler = _resultFactory.Create<FinCategory>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseCategories_GetByCategoryName]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryName", categoryName);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                int categoryID = Convert.ToInt32(reader["CategoryID"]);
                                DateTime createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                                Decimal? monthlyBudget = reader["MonthlyBudget"] as Decimal?;
                                bool isIncome = Convert.ToBoolean(reader["IsIncome"]);
                                int? parentCategoryID = reader["ParentCategoryID"] as int?;
                                short accountID = Convert.ToInt16(reader["AccountID"]);
                                int createdByUseID = Convert.ToInt32(reader["CreatedByUserID"]);
                                bool isActive = Convert.ToBoolean(reader["IsActive"]);
                                string categoryHierarchical = reader["CategoryHierarchical"] as string;
                                string notes = reader["Notes"] as string;
                                string mainCategoryName = reader["MainCategoryName"] as string;
                                string parentCategoryName = reader["ParentCategoryName"] as string;
                                int? mainCategoryID = reader["MainCategoryID"] as int?;

                                categoryData = new FinCategory(categoryID, categoryName, createdDate,
                                    monthlyBudget, isIncome, parentCategoryID, accountID, createdByUseID, isActive, categoryHierarchical,
                                    notes, mainCategoryName, parentCategoryName, mainCategoryID);
                            }
                        }
                    }
                }

                if (categoryData == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                categoryData = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(categoryData);
        }
        public async Task<IResult<bool>> IsExistByName(string categoryName, int currentUserID)
        {
            bool isExist = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseCategories_IsExistByCategoryName]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryName", categoryName);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

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
        public async Task<IResult<PagedResultDTO<FinCategory>>> GetAllForSelectOne(FinCategorySelectPagedSearchCriteria criteria, int currentUserID)
        {
            PagedResultDTO<FinCategory> allCategories = null;
            var handler = _resultFactory.Create<PagedResultDTO<FinCategory>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_IncomeAndExpenseCategories_GetAllForSelectOne", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryName", (string.IsNullOrEmpty(criteria.CategoryName) ? DBNull.Value : (object)criteria.CategoryName));
                        command.Parameters.AddWithValue("@IsIncome", (object)criteria.IsIncome ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TextSearchMode", criteria.TextSearchMode);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);
                        command.Parameters.AddWithValue("@PageNumber", criteria.PageNumber);
                        command.Parameters.AddWithValue("@RowsPerPage", criteria.RowsPerPage);

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
                        List<FinCategory> list;
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            int idOrdinal = reader.GetOrdinal("CategoryID");
                            int categoryNameOrdinal = reader.GetOrdinal("CategoryName");
                            int parentCategoryNameOrdinal = reader.GetOrdinal("ParentCategoryName");
                            int mainCategoryNameOrdinal = reader.GetOrdinal("MainCategoryName");

                            list = new List<FinCategory>();

                            while (await reader.ReadAsync())
                            {
                                int categoryID = Convert.ToInt32(reader[idOrdinal]);
                                string categoryName = reader[categoryNameOrdinal] as string;
                                string parentCategoryName = reader[parentCategoryNameOrdinal] as string;
                                string mainCategoryName = reader[mainCategoryNameOrdinal] as string;


                                var category = new FinCategory()
                                {
                                    CategoryID = categoryID,
                                    CategoryName = categoryName,
                                    ParentCategoryName = parentCategoryName,
                                    MainCategoryName = mainCategoryName
                                };

                                list.Add(category);
                            }

                        }
                        int numberOfPages = Convert.ToInt32(outputNumberOfPages.Value);
                        int recordsCount = Convert.ToInt32(outputRecordsCount.Value);

                        allCategories = new PagedResultDTO<FinCategory>(list, numberOfPages, recordsCount);
                    }
                }

                if (allCategories == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                allCategories = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(allCategories);
        }
        public async Task<IResult<PagedResultDTO<FinCategory>>> GetAll(FinCategoryPagedSearchCriteria criteria, int currentUserID)
        {
            PagedResultDTO<FinCategory> allCategories = null;
            var handler = _resultFactory.Create<PagedResultDTO<FinCategory>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseCategories_GetAll]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryID", (object)criteria.CategoryID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CategoryName", string.IsNullOrWhiteSpace(criteria.CategoryName) ? DBNull.Value : (object)criteria.CategoryName);
                        command.Parameters.AddWithValue("@ParentCategoryName", string.IsNullOrWhiteSpace(criteria.ParentCategoryName) ? DBNull.Value : (object)criteria.ParentCategoryName);
                        command.Parameters.AddWithValue("@MainCategoryName", string.IsNullOrWhiteSpace(criteria.MainCategoryName) ? DBNull.Value : (object)criteria.MainCategoryName);
                        command.Parameters.AddWithValue("@IsIncome", (object)criteria.IsIncome ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsActive", (object)criteria.IsActive ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IncludeMainCategories", criteria.IncludeMainCategories);
                        command.Parameters.AddWithValue("@IncludeSubCategories", criteria.IncludeSubCategories);
                        command.Parameters.AddWithValue("@TextSearchMode", criteria.TextSearchMode);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);
                        command.Parameters.AddWithValue("@PageNumber", criteria.PageNumber);
                        command.Parameters.AddWithValue("@RowsPerPage", criteria.RowsPerPage);

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
                        List<FinCategory> list;
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            int idOrdinal = reader.GetOrdinal("CategoryID");
                            int categoryNameOrdinal = reader.GetOrdinal("CategoryName");
                            int parentCategoryNameOrdinal = reader.GetOrdinal("ParentCategoryName");
                            int mainCategoryNameOrdinal = reader.GetOrdinal("MainCategoryName");
                            int createdDateOrdinal = reader.GetOrdinal("CreatedDate");
                            int isActiveOrdinal = reader.GetOrdinal("IsActive");

                            list = new List<FinCategory>();

                            while (await reader.ReadAsync())
                            {
                                int categoryID = Convert.ToInt32(reader[idOrdinal]);
                                string categoryName = reader[categoryNameOrdinal] as string;
                                string parentCategoryName = reader[parentCategoryNameOrdinal] as string;
                                string mainCategoryName = reader[mainCategoryNameOrdinal] as string;
                                DateTime createdDate = Convert.ToDateTime(reader[createdDateOrdinal]);
                                bool isActive = Convert.ToBoolean(reader[isActiveOrdinal]);

                                var category = new FinCategory()
                                {
                                    CategoryID = categoryID,
                                    CategoryName = categoryName,
                                    ParentCategoryName = parentCategoryName,
                                    MainCategoryName = mainCategoryName,
                                    CreatedDate = createdDate,
                                    IsActive = isActive
                                };

                                list.Add(category);
                            }

                        }
                        int numberOfPages = Convert.ToInt32(outputNumberOfPages.Value);
                        int recordsCount = Convert.ToInt32(outputRecordsCount.Value);

                        allCategories = new PagedResultDTO<FinCategory>(list, numberOfPages, recordsCount);
                    }
                }

                if (allCategories == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                allCategories = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(allCategories);
        }
        public async Task<IResult<bool>> IsExceedMonthlyBudget(BudgetCheckCriteria budgetCheckCriteria, int currentUserID)
        {
            bool isExcced = false;
            var handler = _resultFactory.Create<bool>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_IncomeAndExpenseCategory_IsExceedMonthlyBudget", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryID", budgetCheckCriteria.CategoryID);
                        command.Parameters.AddWithValue("@TransationID", (object)budgetCheckCriteria.TransactionID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Amount", (object)budgetCheckCriteria.Amount ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TransactionDate", budgetCheckCriteria.TransactionDate);
                        command.Parameters.AddWithValue("@IsReturn", (object)budgetCheckCriteria.IsReturn ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        SqlParameter retunValue = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(retunValue);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        isExcced = (retunValue.Value != DBNull.Value) && (Convert.ToInt32(retunValue.Value) == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                isExcced = false;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(isExcced);
        }
    }
}
