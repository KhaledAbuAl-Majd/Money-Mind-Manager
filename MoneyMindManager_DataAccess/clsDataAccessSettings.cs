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
        public static string connectionString = ConfigurationManager.ConnectionStrings["MoneyMindManagerConnectionString"].ConnectionString;
    }
}
