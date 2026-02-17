using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Abstractions;

namespace MoneyMindManager.APIClient.Api_Client_Implementation
{
    internal class DatabaseAppClient : IDatabaseAppApiClient
    {
        private readonly IDatabaseAppService _databaseAppService;

        public DatabaseAppClient(IDatabaseAppService databaseAppService)
        {
            this._databaseAppService = databaseAppService;
        }

        public async Task<IResult<bool>> RoutineMaintenance()
        {
            return await _databaseAppService.RoutineMaintenance();
        }
    }
}
