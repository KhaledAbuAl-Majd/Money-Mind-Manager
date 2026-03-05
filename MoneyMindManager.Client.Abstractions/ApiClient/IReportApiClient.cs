using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.Reports;
using MoneyMindManager.Core.Models.Reports.Categories;
using MoneyMindManager.Core.Models.Reports.Debts;

namespace MoneyMindManager.Client.Abstractions.ApiClient
{
    public interface IReportApiClient
    {
        Task<IResult<IEnumerable<MonthlyFlowReportModel>>> GetMonthlyFlow(DateTime startDate, DateTime EndDate, short accountID);
        Task<IResult<MainKpisReportModel>> GetMainKPIS(short accountID);
        Task<IResult<IEnumerable<DebtRepaymentScheduleReportModel>>> GetDebtsRepaymentSchedule(short accountID);
        Task<IResult<IEnumerable<TopDebtorsRankingReportModel>>> GetTopDebtorsRanking(bool isLending, short accountID);
        Task<IResult<IEnumerable<TopPeopleDebtsSumRankingReportModel>>> GetTopPeopleDebtsSumRanking(bool isLending, short accountID);
        Task<IResult<IEnumerable<DebtsMonthlyFlowReportModel>>> GetDebtsMonthlyFlow(DateTime startDate, DateTime EndDate, short accountID);
        Task<IResult<IEnumerable<TopCategoriesReportModel>>> GetTopCategories(DateTime? startDate, DateTime? EndDate, bool isIncome, short accountID);
        Task<IResult<IEnumerable<CategoryMonthlyFlowReportModel>>> GetCategoryMonthlyFlow(int categoryID, DateTime startDate, DateTime EndDate, short accountID);
    }
}
