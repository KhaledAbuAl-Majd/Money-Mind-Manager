using System;
using Microsoft.Extensions.DependencyInjection;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager.UI.Services;
using MoneyMindManager_Presentation;
using MoneyMindManager_Presentation.Income_And_Expense.Categories;
using MoneyMindManager_Presentation.Login;
using MoneyMindManager_Presentation.Main;
using MoneyMindManager_Presentation.People;
using MoneyMindManager_Presentation.Users;

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

            services.AddScoped<IUserSettingsService, JsonUserSettingsService>();
            services.AddScoped<IUserSession, UserSession>();
            services.AddScoped<IFolderService, FolderService>();


            services.AddSingleton<IWindowsRegisterysettings, WindowsRegistrysettings>();
            services.AddSingleton<IUserCredentialsService, WindowsRegistryUserCredentialsService>();

            //forms
            services.AddSingleton<frmLogin>();
            services.AddTransient<frmCurrentAccount>();
            services.AddTransient<frmPersonInfo>();
            services.AddTransient<frmAddUpdatePerson>();
            services.AddTransient<frmSelectPerson>();
            services.AddTransient<frmPeople>();

            services.AddTransient<frmUserInfo>();
            services.AddTransient<frmAddUpdateUser>();
            services.AddTransient<frmChangePassword>();
            services.AddTransient<frmUserInfo>();
            services.AddTransient<FrmUsers>();

            services.AddTransient<frmSettings>();

            return services;
        }
    }
}
