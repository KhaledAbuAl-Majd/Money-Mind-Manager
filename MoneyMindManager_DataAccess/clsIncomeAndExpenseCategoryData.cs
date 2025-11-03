using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManagerGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.clsIncomeAndExpenseCategoriesClasses;


namespace MoneyMindManager_DataAccess
{
    public static class clsIncomeAndExpenseCategoryData
    {
        public static async Task<int?> AddNewIncomeAndExpenseCategory(string categoryName, decimal? monthlyBudget, bool isIncome,
                    int? parentCategoryID, int createdByUserID, bool isActive,string notes, bool RaiseEventOnErrorOccured = true)
        {
            int? newCategoryID = null;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_IncomeAndExpenseCategories_AddNew", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryName", categoryName);
                        command.Parameters.AddWithValue("@MonthlyBudget", (object)monthlyBudget ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsIncome", isIncome);
                        command.Parameters.AddWithValue("@ParentCategoryID", (object)parentCategoryID ?? DBNull.Value); 
                        command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                        command.Parameters.AddWithValue("@IsActive", isActive);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(notes) ? DBNull.Value : (object)notes);

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
            catch(Exception ex)
            {
                newCategoryID = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return newCategoryID;
        }

        public static async Task<bool> UpdateCategoryByID(int categoryID,string categoryName,Decimal?monthlyBudget,
            bool isActive, string notes,int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseCategories_UpdateByCategoryID]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryID", categoryID);
                        command.Parameters.AddWithValue("@CategoryName", categoryName);
                        command.Parameters.AddWithValue("@MonthlyBudget", (object)monthlyBudget ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsActive", isActive);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(notes) ? DBNull.Value : (object)notes);

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

        public static async Task<bool> DeleteCategoryByID(int categoryID,int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return result;
        }

        public static async Task<clsIncomeAndExpenseCategoriesColumns> GetCategryInfoByID(int categoryID
            , int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            clsIncomeAndExpenseCategoriesColumns categoryData = null;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using(SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseCategories_GetByID]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryID", categoryID);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        await connection.OpenAsync();

                        using(SqlDataReader reader = await command.ExecuteReaderAsync())
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


                                categoryData = new clsIncomeAndExpenseCategoriesColumns(categoryID, categoryName, createdDate,
                                    monthlyBudget, isIncome, parentCategoryID, accountID, createdByUseID, isActive, categoryHierarchical,
                                    notes, mainCategoryName,parentCategoryName,mainCategoryID);
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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return categoryData;
        }
        public static async Task<clsIncomeAndExpenseCategoriesColumns> GetCategryInfoByCategoryName(string categoryName 
            , int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            clsIncomeAndExpenseCategoriesColumns categoryData = null;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using(SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseCategories_GetByCategoryName]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryName", categoryName);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);

                        await connection.OpenAsync();

                        using(SqlDataReader reader = await command.ExecuteReaderAsync())
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

                                categoryData = new clsIncomeAndExpenseCategoriesColumns(categoryID, categoryName, createdDate,
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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return categoryData;
        }

        public static async Task<bool> IsCategoryExistByCategoryNameAsync(string categoryName,int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            bool isExist = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return isExist;
        }
       
        public static bool IsCategoryExistByCategoryName(string categoryName, int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            bool isExist = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
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
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return isExist;
        }


        /// <summary>
        /// Get All Active Categories For The Account at Current User for select one
        /// </summary>
        /// <param name="categoryName">if null => don't search by it, else => search by it</param>
        /// <param name="isIncome">if null => don't search by it, else => search by it</param>
        /// <returns></returns>
        public static async Task<clsGetAllCategories> GetAllCategoriesForSelectOne(string categoryName, bool? isIncome, int currentUserID,
            byte textSearchMode, int pageNumber, byte rowsPerPage, bool RaiseEventOnErrorOccured = true)
        {
            clsGetAllCategories allCategories = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_IncomeAndExpenseCategories_GetAllForSelectOne", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryName", (string.IsNullOrEmpty(categoryName) ? DBNull.Value : (object)categoryName));
                        command.Parameters.AddWithValue("@IsIncome", (object)isIncome ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TextSearchMode", textSearchMode);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);
                        command.Parameters.AddWithValue("@PageNumber", pageNumber);
                        command.Parameters.AddWithValue("@RowsPerPage", rowsPerPage);

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
                            DataTable dtCategories = new DataTable();
                            dtCategories.Load(reader);
                           int numberOfPages = Convert.ToInt32(outputNumberOfPages.Value);
                            int recordsCount = Convert.ToInt32(outputRecordsCount.Value);

                            allCategories = new clsGetAllCategories(dtCategories, numberOfPages, recordsCount);
                        }
                    }
                }

                if (allCategories == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                allCategories = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return allCategories;
        }

        /// <summary>
        /// if variable is null will not filter by it
        /// </summary>
        public static async Task<clsGetAllCategories> GetAllCategories(int? categoryID, string categoryName,string parentCategoryName,
            string mainCategoryName, bool? isIncome, bool? isActive,bool includeMainCategories,bool includeSubCategories,
            int currentUserID, byte textSearchMode, int pageNumber, byte rowsPerPage, bool RaiseEventOnErrorOccured = true)
        {
            clsGetAllCategories allCategories = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_IncomeAndExpenseCategories_GetAll]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryID", (object)categoryID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CategoryName", string.IsNullOrWhiteSpace(categoryName) ? DBNull.Value : (object)categoryName);
                        command.Parameters.AddWithValue("@ParentCategoryName", string.IsNullOrWhiteSpace(parentCategoryName) ? DBNull.Value : (object)parentCategoryName);
                        command.Parameters.AddWithValue("@MainCategoryName", string.IsNullOrWhiteSpace(mainCategoryName) ? DBNull.Value : (object)mainCategoryName);
                        command.Parameters.AddWithValue("@IsIncome", (object)isIncome ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsActive", (object)isActive ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IncludeMainCategories", includeMainCategories);
                        command.Parameters.AddWithValue("@IncludeSubCategories", includeSubCategories);
                        command.Parameters.AddWithValue("@TextSearchMode", textSearchMode);
                        command.Parameters.AddWithValue("@CurrentUserID", currentUserID);
                        command.Parameters.AddWithValue("@PageNumber", pageNumber);
                        command.Parameters.AddWithValue("@RowsPerPage", rowsPerPage);

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
                            DataTable dtCategories = new DataTable();
                            dtCategories.Load(reader);
                           int numberOfPages = Convert.ToInt32(outputNumberOfPages.Value);
                            int recordsCount = Convert.ToInt32(outputRecordsCount.Value);

                            allCategories = new clsGetAllCategories(dtCategories, numberOfPages, recordsCount);
                        }
                    }
                }

                if (allCategories == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                allCategories = null;

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return allCategories;
        }

        /// <summary>
        /// check if category exceed monthly budget for main expense category
        /// </summary>
        /// <param name="transactionID">null => if add transaction or check for category generally </param>
        /// <param name="amount">null if check for category generally</param>
        /// <param name="currentUserID"></param>
        /// <returns>is excceded or not</returns>
        public async static Task<bool> IsExceedMonthlyBudget(int categoryID, int? transactionID, decimal? amount, 
            DateTime transactionDate,bool? isReturn, int currentUserID, bool RaiseEventOnErrorOccured = true)
        {
            bool isExcced = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_IncomeAndExpenseCategory_IsExceedMonthlyBudget", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryID", categoryID);
                        command.Parameters.AddWithValue("@TransationID", (object)transactionID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Amount", (object)amount ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TransactionDate", transactionDate);
                        command.Parameters.AddWithValue("@IsReturn", (object)isReturn ?? DBNull.Value);
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

                if (RaiseEventOnErrorOccured)
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
            }

            return isExcced;
        }

    }
}
