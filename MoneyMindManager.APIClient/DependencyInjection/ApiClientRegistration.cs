using Microsoft.Extensions.DependencyInjection;
using MoneyMindManager.APIClient.Api_Client_Implementation;
using MoneyMindManager.Client.Abstractions.ApiClient;

namespace MoneyMindManager.APIClient.DependencyInjection
{
    public static class ApiClientRegistration
    {
        public static IServiceCollection AddApiClient(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseAppApiClient, DatabaseAppClient>();
            services.AddScoped<ICurrencyApiClient, CurrencyApiClient>();
            services.AddScoped<IAccountApiClient, AccountApiClient>();
            services.AddScoped<IPersonApiClient, PersonApiClient>();
            services.AddScoped<IUserApiClient, UserApiClient>();
            services.AddScoped<IReportApiClient, ReportApiClient>();

            return services;
        }
    }
}
