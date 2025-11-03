using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;

namespace MoneyMindManager_Business
{
    public class clsBLLGlobal
    {
        public enum enTextSearchMode
        {
            /// <summary>
            /// search with (full text search Using "Contains" OR LIKE text %) - faster
            /// </summary>
            WordsPrefix_Fast = 1,

            /// <summary>
            /// search using Like Statement - any part of text "Like" - slower
            /// </summary>
            Substring_Slow = 2
        }

        public static async Task RoutineMaintenance()
        {
            await clsDALGlobal.RoutineMaintenance();
        }
    }
}
