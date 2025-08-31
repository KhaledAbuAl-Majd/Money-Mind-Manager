using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManagerGlobal;

namespace MoneyMindManager_DataAccess
{
    public static class Class1
    {
        public static void koko()
        {
            string connectionString = "Server=.;DataBase=MonyMindManager;User Id=s; password=123456";

            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetUserByUserID", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", 1000000);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }



                }
            }
            catch (Exception ex)
            {
                clsGlobalEvents.RaiseEvent(ex.Message);
            }

        }
    }
}
