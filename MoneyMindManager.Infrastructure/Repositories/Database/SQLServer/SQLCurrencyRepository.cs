using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Core;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Entities;

namespace MoneyMindManager.Infrastructure.Repositories
{
    public class SQLCurrencyRepository : ICurrencyRepository
    {
        private readonly IDatabaseSettings _databaseSettings;

        private readonly ILogger _logger;

        private readonly IResultFactory _resultFactory;

        public SQLCurrencyRepository(IDatabaseSettings databaseSettings, ILogger logger, IResultFactory resultFactory)
        {
            this._databaseSettings = databaseSettings;
            this._logger = logger;
            this._resultFactory = resultFactory;
        }
        public async Task<IResult<Currency>> GetByID(byte currencyID)
        {
            Currency currencyData = null;
            var handler = _resultFactory.Create<Currency>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Currency_GetByCurrencyID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CurrencyID", currencyID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                string currencyName = (reader["CurrencyName"] == DBNull.Value) ? null : reader["CurrencyName"] as string;
                                string currencySymbol = (reader["CurrencySymbol"] == DBNull.Value) ? null : reader["CurrencySymbol"] as string;

                                currencyData = new Currency(currencyID, currencyName, currencySymbol);
                            }
                            else
                                currencyData = null;
                        }
                    }
                }

                if (currencyData == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                currencyData = null;

                _logger.LogError("Sql database error", ex);

                return handler.Failure(ex.Message);
            }

            return handler.Success(currencyData);
        }

        public async Task<IResult<Currency>> GetByName(string currencyName)
        {
            Currency currencyData = null;
            var handler = _resultFactory.Create<Currency>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Currency_GetByCurrencyName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CurrencyName", currencyName);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                byte currencyID = Convert.ToByte(reader["CurrencyID"]);
                                string currencySymbol = (reader["CurrencySymbol"] == DBNull.Value) ? null : reader["CurrencySymbol"] as string;

                                currencyData = new Currency(currencyID, currencyName, currencySymbol);
                            }
                            else
                                currencyData = null;
                        }
                    }
                }

                if (currencyData == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                currencyData = null;

                _logger.LogError("Sql database error", ex);

                return handler.Failure(ex.Message);
            }

            return handler.Success(currencyData);
        }

        public async Task<IResult<IEnumerable<Currency>>> GetAll()
        {
            var currencies = new List<Currency>();
            var handler = _resultFactory.Create<IEnumerable<Currency>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Currencies_GetAll", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                byte currencyID = Convert.ToByte(reader["CurrencyID"]);
                                string currencyName = Convert.ToString(reader["CurrencyName"]);
                                string currencySymbol = Convert.ToString(reader["CurrencySymbol"]);

                                currencies.Add(new Currency(currencyID, currencyName, currencySymbol));
                            }
                        }
                    }
                }

                if (currencies == null)
                    throw new Exception("فشلت العملية");
            }
            catch (Exception ex)
            {
                currencies = null;

                _logger.LogError("Sql database error", ex);

                return handler.Failure(ex.Message);
            }

            return handler.Success(currencies);
        }
    }
}
