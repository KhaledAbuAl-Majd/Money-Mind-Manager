using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Core;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Abstractions.Repositories;
using MoneyMindManager.Domain.Entities;

namespace MoneyMindManager.Infrastructure.Repositories.Database.SQLServer
{
    public class SQLTransactionTypeRepository : ITransactionTypeRepository
    {
        private readonly IDatabaseSettings _databaseSettings;
        private readonly ILogger _logger;
        private readonly IResultFactory _resultFactory;

        public SQLTransactionTypeRepository(IDatabaseSettings databaseSettings, ILogger logger, IResultFactory resultFactory)
        {
            this._databaseSettings = databaseSettings;
            this._logger = logger;
            this._resultFactory = resultFactory;
        }

        public async Task<IResult<TransactionType>> GetByID(byte transactionTypeID)
        {
            TransactionType TransactionTypeData = null;
            var handler = _resultFactory.Create<TransactionType>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_TransactionType_GetByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TransactionTypeID", transactionTypeID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                string transactionName = (reader["TransactionTypeName"] == DBNull.Value) ? null : reader["TransactionTypeName"] as string;

                                TransactionTypeData = new TransactionType(transactionTypeID, transactionName);
                            }
                            else
                                TransactionTypeData = null;
                        }
                    }
                }

                if (TransactionTypeData == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                TransactionTypeData = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(TransactionTypeData);
        }

        public async Task<IResult<TransactionType>> GetByName(string transactionName)
        {
            TransactionType TransactionTypeData = null;
            var handler = _resultFactory.Create<TransactionType>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_TransactionType_GetByName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TransactionTypeName", transactionName);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                byte transactionTypeID = Convert.ToByte(reader["TransactionTypeID"]);

                                TransactionTypeData = new TransactionType(transactionTypeID, transactionName);
                            }
                            else
                                TransactionTypeData = null;
                        }
                    }
                }

                if (TransactionTypeData == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                TransactionTypeData = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(TransactionTypeData);
        }

        public async Task<IResult<IEnumerable<TransactionType>>> GetAll()
        {
            List<TransactionType> TransactionTypeData = new List<TransactionType>();
            var handler = _resultFactory.Create<IEnumerable<TransactionType>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[SP_TransactionTypes_GetAll]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            int idOrdinal = reader.GetOrdinal("TransactionTypeID");
                            int nameOrdinal = reader.GetOrdinal("TransactionTypeName");

                            while (await reader.ReadAsync())
                            {
                                byte id = Convert.ToByte(reader[idOrdinal]);
                                string name = reader[nameOrdinal] as string;

                                TransactionTypeData.Add(new TransactionType(id, name));
                            }
                        }
                    }
                }

                if (TransactionTypeData == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                TransactionTypeData = null;

                _logger.LogError(ex.Message);
                return handler.Failure(ex.Message);
            }

            return handler.Success(TransactionTypeData);
        }
    }
}
