using Microsoft.Extensions.DependencyInjection;
using MoneyMindManager.Application.Abstractions.Infrastructure;
using MoneyMindManager.Application.Services;
using MoneyMindManager.Core;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Abstractions.Services;
using MoneyMindManager.Infrastructure.General_Services;
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
            services.AddScoped<ICurrencyRepository, SQLCurrencyRepository>();
            services.AddScoped<IAccountRepository, SQLAccountRepository>();

            services.AddSingleton<IEventLogLoggerSettings, EventLogLoggerSettings>();
            services.AddSingleton<ILogger, EventLogLogger>();

            services.AddSingleton<IRandomGenerator, RandomGenerator>();
            services.AddSingleton<IHashingSettings, HashingSettings>();
            services.AddSingleton<IHashingService, Sha256HashingService>();

            return services;
        }
    }
}
