using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using MoneyMindManager.IoC;
using MoneyMindManager.UI.DependencyInjection;
using MoneyMindManager_Presentation.Login;
using MoneyMindManagerGlobal;

namespace MoneyMindManager_Presentation
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (HandleEventSourceSetup())
            {
                clsPL_Global.SubscribeToErrorOcrruedEvent();

                var services = new ServiceCollection();
                DependencyContainer.RegisterServices(services);
                services.AddUI();//register Ui DI

                var serviceProvider = services.BuildServiceProvider();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var loginForm = serviceProvider.GetRequiredService<frmLogin>();
                Application.Run(loginForm);
            }
        }

        private static bool HandleEventSourceSetup()
        {
            if (clsLogger.LogAtEventLog("Test Logging", EventLogEntryType.Information))
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
                    EventLog.CreateEventSource(clsLogger.SourceName, clsLogger.LogName);
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


