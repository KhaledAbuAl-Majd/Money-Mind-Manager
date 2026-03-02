using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using MoneyMindManager.Application.Abstractions.Infrastructure;
using MoneyMindManager.Core;
using MoneyMindManager.IoC;
using MoneyMindManager.UI.DependencyInjection;
using MoneyMindManager_Presentation.Login;

namespace MoneyMindManager_Presentation
{
    internal static class Program
    {
        private static ILogger _logger;
        private static IEventLogLoggerSettings _eventLogLoggerSettings;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            DependencyContainer.RegisterServices(services);

            var serviceProvider = services.BuildServiceProvider();
            _logger = serviceProvider.GetRequiredService<ILogger>();
            _eventLogLoggerSettings = serviceProvider.GetRequiredService<IEventLogLoggerSettings>();

            if (HandleEventSourceSetup())
            {
                services.AddUI();//register Ui DI

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var loginForm = serviceProvider.GetRequiredService<frmLogin>();
                Application.Run(loginForm);
            }
        }

        private static bool HandleEventSourceSetup()
        {
            if (_logger.LogInfo("Test Logging"))
            {
                return true;
            }

            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            bool isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if (isAdmin)
            {
                try
                {
                    EventLog.CreateEventSource(_eventLogLoggerSettings.SourceName, "Application");
                    MessageBox.Show($"تم إنشاء مصدر تسجيل الأحداث بنجاح. البرنامج سيغلق الآن ويُعاد تشغيله بشكل عادي.", "إعداد النظام",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show($"فشل حرج في إنشاء مصدر الأحداث رغم صلاحيات المسؤول.", "خطأ في الإعداد",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Environment.Exit(0);
            }
            else
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = Assembly.GetExecutingAssembly().Location,
                    Verb = "runas"
                };

                try
                {
                    Process.Start(startInfo);
                }
                catch (Exception)
                {
                    MessageBox.Show("لا يمكن إنشاء مصدر تسجيل الأحداث بدون صلاحيات المسؤول. لن يعمل التسجيل.", "صلاحيات مطلوبة",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Environment.Exit(0);
            }

            return false;
        }
    }
}


