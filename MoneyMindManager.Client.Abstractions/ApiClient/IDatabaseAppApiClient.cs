using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;

namespace MoneyMindManager.Client.Abstractions.ApiClient
{
    public interface IDatabaseAppApiClient
    {
        Task<IResult<bool>> RoutineMaintenance();
    }
}
