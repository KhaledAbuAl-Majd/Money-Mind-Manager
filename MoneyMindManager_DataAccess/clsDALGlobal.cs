using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManagerGlobal;

namespace MoneyMindManager_DataAccess
{
    public static class clsDALGlobal
    {
        public static async Task RoutineMaintenance()
        {
            await Task.Run(async () =>
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                    {
                        using (SqlCommand command = new SqlCommand("SP_Global_DatabaseRoutineMaintenance", connection))
                        {
                            command.CommandType = System.Data.CommandType.StoredProcedure;

                            //10 minutes
                            command.CommandTimeout = 600;

                            await connection.OpenAsync();
                            await command.ExecuteNonQueryAsync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsLogger.LogAtEventLog(ex.Message);
                    clsGlobalEvents.RaiseErrorEvent("فشلت الصيانة الدورية. سيعمل البرنامج بشكل عادي، ولكن يُرجى إبلاغ الدعم الفني.", true);
                }
            });
        }
    }
}
