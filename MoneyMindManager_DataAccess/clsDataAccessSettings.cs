using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManagerGlobal;
using System.Configuration;

namespace MoneyMindManager_DataAccess
{
    public static class clsDataAccessSettings
    {
        public static string connectionString = null;

        static clsDataAccessSettings()
        {
            try
            {
                // محاولة قراءة سلسلة الاتصال من ملف .config
                connectionString = ConfigurationManager.ConnectionStrings["MoneyMindManagerConnectionString"].ConnectionString;
            }
            catch (Exception ex)
            {
                clsGlobalEvents.RaiseErrorEvent(ex.InnerException?.ToString(), true);
            }
        }
    }
}
