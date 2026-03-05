using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.Reports;
using MoneyMindManager.Core.Models.Reports.Categories;
using MoneyMindManager.Core.Models.Reports.Debts;

namespace MoneyMindManager.APIClient.Api_Client_Implementation
{
    public class ReportApiClient : IReportApiClient
    {
        private readonly IReportService _reportService;

        public ReportApiClient(IReportService reportService)
        {
            this._reportService = reportService;
        }

        public async Task<IResult<IEnumerable<MonthlyFlowReportModel>>> GetMonthlyFlow(DateTime startDate, DateTime EndDate, short accountID)
        {
            return await _reportService.GetMonthlyFlow(startDate, EndDate, accountID);
        }

        public async Task<IResult<MainKpisReportModel>> GetMainKPIS(short accountID)
        {
            return await _reportService.GetMainKPIS(accountID);
        }

        public async Task<IResult<IEnumerable<DebtRepaymentScheduleReportModel>>> GetDebtsRepaymentSchedule(short accountID)
        {
            return await _reportService.GetDebtsRepaymentSchedule(accountID);
        }

        public async Task<IResult<IEnumerable<TopDebtorsRankingReportModel>>> GetTopDebtorsRanking(bool isLending, short accountID)
        {
            return await _reportService.GetTopDebtorsRanking(isLending, accountID);
        }

        public async Task<IResult<IEnumerable<TopPeopleDebtsSumRankingReportModel>>> GetTopPeopleDebtsSumRanking(bool isLending, short accountID)
        {
            return await _reportService.GetTopPeopleDebtsSumRanking(isLending, accountID);
        }

        public async Task<IResult<IEnumerable<DebtsMonthlyFlowReportModel>>> GetDebtsMonthlyFlow(DateTime startDate, DateTime EndDate, short accountID)
        {
            return await _reportService.GetDebtsMonthlyFlow(startDate, EndDate, accountID);
        }

        public async Task<IResult<IEnumerable<TopCategoriesReportModel>>> GetTopCategories(DateTime? startDate, DateTime? EndDate, bool isIncome, short accountID)
        {
            return await _reportService.GetTopCategories(startDate, EndDate, isIncome, accountID);
        }

        public async Task<IResult<IEnumerable<CategoryMonthlyFlowReportModel>>> GetCategoryMonthlyFlow(int categoryID, DateTime startDate, DateTime EndDate, short accountID)
        {
            return await _reportService.GetCategoryMonthlyFlow(categoryID, startDate, EndDate, accountID);
        }
    }
}
