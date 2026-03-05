using Microsoft.Extensions.DependencyInjection;
using MoneyMindManager.APIClient.DependencyInjection;
using MoneyMindManager.Application;
using MoneyMindManager.Infrastructure;

namespace MoneyMindManager.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddInfrastructure();
            services.AddApplication();
            services.AddApiClient();
        }
    }
}
