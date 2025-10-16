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
        public static async Task<List<clsMonthlyFlow>> GetMonthlyFlow(DateTime startDate, DateTime EndDate, short accountID)
        {
            return await clsReportData.GetMonthlyFlow(startDate,EndDate,accountID);
        }

        public static async Task<clsMainKpis> GetMainKPIS(short accountID)
        {
            return await clsReportData.GetMainKPIS(accountID);
        }

        public static async Task<List<clsDebtRepaymentSchedule>> GetDebtsRepaymentSchedule(short accountID)
        {
            return await clsReportData.GetDebtsRepaymentSchedule(accountID);
        }

        public static async Task<List<clsTopDebtorsRanking>> GetTopDebtorsRanking(bool isLending, short accountID)
        {
            return await clsReportData.GetTopDebtorsRanking(isLending, accountID);
        }

        public static async Task<List<clsTopPeopleDebtsSumRanking>> GetTopPeopleDebtsSumRanking(bool isLending, short accountID)
        {
            return await clsReportData.GetTopPeopleDebtsSumRanking(isLending, accountID);
        }

        public static async Task<List<clsDebtsMonthlyFlow>> GetDebtsMonthlyFlow(DateTime startDate, DateTime EndDate, short accountID)
        {
            return await clsReportData.GetDebtsMonthlyFlow(startDate, EndDate, accountID);
        }
    }
}
