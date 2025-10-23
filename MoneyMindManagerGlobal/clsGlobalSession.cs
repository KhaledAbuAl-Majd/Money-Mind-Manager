using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManagerGlobal
{
    public static class clsGlobalSession
    {
        public static int? CurrentUserID { get; private set; }
        public static int CurrentUserPermissions{ get; private set; }

        public static void Login(int userID,int permissions)
        {
            CurrentUserID = userID;
            CurrentUserPermissions = permissions;
        }

        public static void Logout()
        {
            CurrentUserID = null;
            CurrentUserPermissions = 0;
        }

    }
}
