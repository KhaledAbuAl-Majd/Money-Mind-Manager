using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyMindManager_Presentation.Login;
using MoneyMindManager_Presentation.Main;
using MoneyMindManager_Presentation.People;

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
            clsGlobal_UI.SubscribeToErrorOcrruedEvent();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
