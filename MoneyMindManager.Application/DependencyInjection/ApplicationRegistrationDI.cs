using Microsoft.Extensions.DependencyInjection;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Application.Mappers.Abstractions;
using MoneyMindManager.Application.Mappers.Mappers_Implementaion;
using MoneyMindManager.Application.Services;
using MoneyMindManager.Application.Services.Account;
using MoneyMindManager.Application.Services.Authorization;
using MoneyMindManager.Application.Services.Currency;
using MoneyMindManager.Application.Services.Database;
using MoneyMindManager.Application.Services.Debt;
using MoneyMindManager.Application.Services.FinTransaction;
using MoneyMindManager.Application.Services.FinVoucher;
using MoneyMindManager.Application.Services.MainTransaction;
using MoneyMindManager.Application.Services.Permissions;
using MoneyMindManager.Application.Services.Report;
using MoneyMindManager.Application.Services.TransactionType;
using MoneyMindManager.Application.Services.User;
using MoneyMindManager.Domain.Abstractions.Services;

namespace MoneyMindManager.Application
{
    public static class ApplicationRegistrationDI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            _services(services);
            _mappers(services);
            return services;
        }

        static void _services(IServiceCollection services)
        {
            services.AddSingleton<IResultFactory, ResultFactory>();
            services.AddSingleton<IPermissionService, PermissionService>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();

            services.AddScoped<IDatabaseAppService, DatabaseAppService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<ITransactionTypeService, TransactionTypeService>();
            services.AddScoped<IMainTransactionService, MainTransactionService>();
            services.AddScoped<IFinCategoryService, FinCategoryService>();
            services.AddScoped<IFinCategoryService, FinCategoryService>();
            services.AddScoped<IFinVoucherService, FinVoucherService>();
            services.AddScoped<IFinTransactionService, FinTransactionService>();
            services.AddScoped<IDebtService, DebtService>();
        }

        static void _mappers(IServiceCollection services)
        {
            services.AddSingleton<ICurrencyMapper, CurrencyMapper>();
            services.AddSingleton<IPersonMapper, PersonMapper>();
            services.AddSingleton<IUserMapper, UserMapper>();
            services.AddSingleton<IAccountMapper, AccountMapper>();
            services.AddSingleton<ITransactionTypeMapper, TransactionTypeMapper>();
            services.AddSingleton<IMainTransactionMapper, MainTransactionMapper>();
            services.AddSingleton<IFinCategoryMapper, FinCategoryMapper>();
            services.AddSingleton<IFinCategoryMapper, FinCategoryMapper>();
            services.AddSingleton<IFinVoucherMapper, FinVoucherMapper>();
            services.AddSingleton<IFinTransactionMapper, FinTransactionMapper>();
            services.AddSingleton<IDebtMapper, DebtMapper>();
        }
    }
}
