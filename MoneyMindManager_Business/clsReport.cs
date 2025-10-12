using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using static MoneyMindManagerGlobal.clsDataColumns.clsReportClassess;

namespace MoneyMindManager_Business
{
    public class clsReport
    {
        public static async Task<List<clsMonthlyFlow>> GetMonthlyFlow(int accountID)
        {
            return await clsReportData.GetMonthlyFlow();
        }
    }
}
