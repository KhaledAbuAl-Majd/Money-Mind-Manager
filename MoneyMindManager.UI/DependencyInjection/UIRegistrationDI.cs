using System;
using Microsoft.Extensions.DependencyInjection;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager.UI.Services;
using MoneyMindManager_Presentation.Login;
using MoneyMindManager_Presentation.Main;

namespace MoneyMindManager.UI.DependencyInjection
{
    public static class UIRegistrationDI
    {
        public static IServiceCollection AddUI(this IServiceCollection services)
        {
            services.AddScoped<frmMain>();

            services.AddScoped<IFormDisplayer, frmMain>();
            services.AddSingleton<IActiveFormTracker, ActiveFormTracker>();
            services.AddSingleton<IMessageBoxService, MessageBoxService>();

            services.AddScoped<IUserSession, UserSession>();
            services.AddScoped<IFolderService, FolderService>();

            //forms
            services.AddSingleton<frmLogin>();


            return services;
        }
    }
}
