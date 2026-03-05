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
            services.AddScoped<ITransactionTypeApiClient, TransactionTypeApiClient>();
            services.AddScoped<IMainTransactionApiClient, MainTransactionApiClient>();
            services.AddScoped<IFinCategoryApiClient, FinCategoryApiclient>();
            services.AddScoped<IFinVoucherApiClient, FinVoucherApiClient>();
            services.AddScoped<IFinTransactionApiClient, FinTransactionApiClient>();
            services.AddScoped<IDebtApiClient, DebtApiClient>();
            services.AddScoped<IDebtPaymentApiClient, DebtPaymentApiClient>();

            return services;
        }
    }
}
