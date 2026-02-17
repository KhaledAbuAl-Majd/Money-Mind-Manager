using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Core;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Abstractions.Services;

namespace MoneyMindManager.Infrastructure.Repositories.Database.SQLServer
{
    public class SQLDatabaseMaintenanceService : IDatabaseMaintenanceService
    {
        private readonly IDatabaseSettings _databaseSettings;
        private readonly ILogger _logger;
        private readonly IResultFactory _resultFactory;

        public SQLDatabaseMaintenanceService(IDatabaseSettings databaseSettings, ILogger logger, IResultFactory resultFactory)
        {
            this._databaseSettings = databaseSettings;
            this._logger = logger;
            this._resultFactory = resultFactory;
        }

        public async Task<IResult<bool>> RoutineMaintenance()
        {
            var handler = _resultFactory.Create<bool>();

            await Task.Run(async () =>
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_databaseSettings.ConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand("SP_Global_DatabaseRoutineMaintenance", connection))
                        {
                            command.CommandType = System.Data.CommandType.StoredProcedure;

                            //10 minutes
                            command.CommandTimeout = 600;

                            await connection.OpenAsync();
                            await command.ExecuteNonQueryAsync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    handler.Failure("فشلت الصيانة الدورية. سيعمل البرنامج بشكل عادي، ولكن يُرجى إبلاغ الدعم الفني.");
                }
            });

            return handler.Success(true);
        }
    }
}
