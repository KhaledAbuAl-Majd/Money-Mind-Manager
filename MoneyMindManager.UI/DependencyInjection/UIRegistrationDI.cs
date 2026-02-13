using System;
using Microsoft.Extensions.DependencyInjection;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager.UI.Services;
using MoneyMindManager_Presentation;
using MoneyMindManager_Presentation.Login;

namespace MoneyMindManager.UI.DependencyInjection
{
    public static class UIRegistrationDI
    {
        public static IServiceCollection AddUI(this IServiceCollection services)
        {
            services.AddSingleton<IMessageBoxService, MessageBoxService>(provider =>
            {
                return new MessageBoxService(() => clsPL_Global.ActiveForm);
            });

            services.AddScoped<IFolderService, FolderService>();

            //forms
            services.AddTransient<frmLogin>();
            return services;
        }
    }
}
