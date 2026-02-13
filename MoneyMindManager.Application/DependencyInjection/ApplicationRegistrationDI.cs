using Microsoft.Extensions.DependencyInjection;
using MoneyMindManager.Application.Abstractions;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Application.Services;
using MoneyMindManager.Application.Services.Currency;
using MoneyMindManager.Application.Services.Permissions;

namespace MoneyMindManager.Application
{
    public static class ApplicationRegistrationDI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IResultFactory, ResultFactory>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            return services;
        }
    }
}
