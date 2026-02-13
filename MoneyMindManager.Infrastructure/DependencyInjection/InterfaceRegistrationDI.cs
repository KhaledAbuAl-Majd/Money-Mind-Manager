using Microsoft.Extensions.DependencyInjection;
using MoneyMindManager.Core;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Infrastructure.Logging;
using MoneyMindManager.Infrastructure.Repositories;
using MoneyMindManager.Infrastructure.Repositories.SQLServer;

namespace MoneyMindManager.Infrastructure
{
    public static class InterfaceRegistrationDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IDatabaseSettings, SQLDatabaseSettings>();
            services.AddScoped<ILogger, EventLogLogger>();
            services.AddScoped<ICurrencyRepository, SQLCurrencyRepository>();
            return services;
        }
    }
}
