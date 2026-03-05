using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Domain.Abstractions.Services;

namespace MoneyMindManager.Application.Services.Database
{
    public class DatabaseAppService : IDatabaseAppService
    {
        private readonly IResultFactory _resultFactory;
        private readonly IDatabaseMaintenanceService _databaseMaintenanceService;

        public DatabaseAppService(IResultFactory resultFactory, IDatabaseMaintenanceService databaseMaintenanceService)
        {
            this._resultFactory = resultFactory;
            this._databaseMaintenanceService = databaseMaintenanceService;
        }
        public async Task<IResult<bool>> RoutineMaintenance()
        {
            var result = await _databaseMaintenanceService.RoutineMaintenance();

            var handler = _resultFactory.Create<bool>();

            if (result is null)
                return handler.Failure("فشلت الصيانة الدورية!");

            return result;
        }
    }
}
