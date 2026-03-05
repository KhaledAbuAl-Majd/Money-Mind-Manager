using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;

namespace MoneyMindManager.Domain.Abstractions.Services
{
    public interface IDatabaseMaintenanceService
    {
       Task <IResult<bool>> RoutineMaintenance();
    }
}
