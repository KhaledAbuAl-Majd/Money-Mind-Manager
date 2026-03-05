using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;

namespace MoneyMindManager.Application.Abstractions.Services
{
    public interface IDatabaseAppService
    {
        Task<IResult<bool>> RoutineMaintenance();
    }
}
