using Microsoft.Extensions.DependencyInjection;
using MoneyMindManager.APIClient.Api_Client_Implementation;
using MoneyMindManager.Client.Abstractions.ApiClient;

namespace MoneyMindManager.APIClient.DependencyInjection
{
    public static class ApiClientRegistration
    {
        public static IServiceCollection AddApiClient(this IServiceCollection services)
        {
            services.AddScoped<ICurrencyApiClient, CurrencyApiClient>();
            services.AddScoped<IAccountApiClient, AccountApiClient>();
            services.AddScoped<IPersonApiClient, PersonApiClient>();

            return services;
        }
    }
}
