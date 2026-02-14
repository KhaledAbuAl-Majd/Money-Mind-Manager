using Microsoft.Extensions.DependencyInjection;
using MoneyMindManager.Application.Abstractions;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Application.Mappers.Mappers_Implementaion;
using MoneyMindManager.Application.Services;
using MoneyMindManager.Application.Services.Account;
using MoneyMindManager.Application.Services.Authorization;
using MoneyMindManager.Application.Services.Currency;
using MoneyMindManager.Application.Services.Permissions;
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

            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IAccountService, AccountService>();
        }

        static void _mappers(IServiceCollection services)
        {
            services.AddSingleton<ICurrencyMapper, CurrencyMapper>();
            services.AddSingleton<IPersonMapper, PersonMapper>();
            services.AddSingleton<IUserMapper, UserMapper>();
            services.AddSingleton<IAccountMapper, AccountMapper>();
        }
    }
}
