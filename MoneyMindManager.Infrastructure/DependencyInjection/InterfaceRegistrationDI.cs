using Microsoft.Extensions.DependencyInjection;
using MoneyMindManager.Application.Abstractions.Infrastructure;
using MoneyMindManager.Application.Services;
using MoneyMindManager.Core;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Abstractions.Repositories;
using MoneyMindManager.Domain.Abstractions.Repositories.Reports;
using MoneyMindManager.Domain.Abstractions.Services;
using MoneyMindManager.Infrastructure.General_Services;
using MoneyMindManager.Infrastructure.General_Services.Cryptography;
using MoneyMindManager.Infrastructure.Logging;
using MoneyMindManager.Infrastructure.Repositories;
using MoneyMindManager.Infrastructure.Repositories.Database.SQLServer;
using MoneyMindManager.Infrastructure.Repositories.Database.SQLServer.Reports;
using MoneyMindManager.Infrastructure.Repositories.SQLServer;

namespace MoneyMindManager.Infrastructure
{
    public static class InterfaceRegistrationDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IDatabaseSettings, SQLDatabaseSettings>();
            services.AddScoped<IDatabaseMaintenanceService, SQLDatabaseMaintenanceService>();

            services.AddScoped<ICurrencyRepository, SQLCurrencyRepository>();
            services.AddScoped<IAccountRepository, SQLAccountRepository>();
            services.AddScoped<IPersonRepository, SQLPersonRepository>();
            services.AddScoped<IUserRepository, SQLUserRepository>();
            services.AddScoped<IGeneralReportRepository, SQLGeneralReportRepository>();
            services.AddScoped<IDebtsReportRepository, SQLDebtsReportRepository>();
            services.AddScoped<ICategoriesReportRepository, SQLCategoriesReportRepository>();
            services.AddScoped<ITransactionTypeRepository, SQLTransactionTypeRepository>();
            services.AddScoped<IMainTransactionRepository, SQLMainTransactionRepository>();
            services.AddScoped<IFinCategoryRepository, SQLFinCategoryRepository>();

            services.AddSingleton<IEventLogLoggerSettings, EventLogLoggerSettings>();
            services.AddSingleton<ILogger, EventLogLogger>();

            services.AddSingleton<IRandomGenerator, RandomGenerator>();
            services.AddSingleton<IHashingSettings, HashingSettings>();
            services.AddSingleton<IHashingService, Sha256HashingService>();
            services.AddSingleton<ISymmetricEncryptionSettings, SymmetricEncryptionSettings>();
            services.AddSingleton<ISymmetricEncryption, SymmetricEncryption>();
            services.AddSingleton<IFormateHelper, IFormateHelper>();

            return services;
        }
    }
}
