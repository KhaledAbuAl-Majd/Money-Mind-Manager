using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.Reports;
using MoneyMindManager.Core.Models.Reports.Categories;
using MoneyMindManager.Core.Models.Reports.Debts;
using MoneyMindManager.Domain.Abstractions.Repositories.Reports;

namespace MoneyMindManager.Application.Services.Report
{
    public class ReportService : IReportService
    {
        private readonly IResultFactory _resultFactory;
        private readonly IGeneralReportRepository _generalReportRepository;
        private readonly IDebtsReportRepository _debtsReportRepository;
        private readonly ICategoriesReportRepository _categoriesReportRepository;

        public ReportService(IResultFactory resultFactory, IGeneralReportRepository generalReportRepository, IDebtsReportRepository debtsReportRepository, ICategoriesReportRepository categoriesReportRepository)
        {
            this._resultFactory = resultFactory;
            this._generalReportRepository = generalReportRepository;
            this._debtsReportRepository = debtsReportRepository;
            this._categoriesReportRepository = categoriesReportRepository;
        }

        public async Task<IResult<IEnumerable<MonthlyFlowReportModel>>> GetMonthlyFlow(DateTime startDate, DateTime EndDate, short accountID)
        {
            var result = await _generalReportRepository.GetMonthlyFlow(startDate, EndDate, accountID);

            var handler = _resultFactory.Create<IEnumerable<MonthlyFlowReportModel>>();

            if (result is null || (result.Data is null && result.IsSuccess))
                return handler.Failure("Failed to get Monthly Flow Report");

            return result;
        }

        public async Task<IResult<MainKpisReportModel>> GetMainKPIS(short accountID)
        {
            var result = await _generalReportRepository.GetMainKPIS(accountID);

            var handler = _resultFactory.Create<MainKpisReportModel>();

            if (result is null || (result.Data is null && result.IsSuccess))
                return handler.Failure("Failed to get Main KPIS Report");

            return result;
        }

        public async Task<IResult<IEnumerable<DebtRepaymentScheduleReportModel>>> GetDebtsRepaymentSchedule(short accountID)
        {
            var result = await _debtsReportRepository.GetDebtsRepaymentSchedule(accountID);

            var handler = _resultFactory.Create<IEnumerable<DebtRepaymentScheduleReportModel>>();

            if (result is null || (result.Data is null && result.IsSuccess))
                return handler.Failure("Failed to get Debts Payment Schedule Report");

            return result;
        }

        public async Task<IResult<IEnumerable<TopDebtorsRankingReportModel>>> GetTopDebtorsRanking(bool isLending, short accountID)
        {
            var result = await _debtsReportRepository.GetTopDebtorsRanking(isLending, accountID);

            var handler = _resultFactory.Create<IEnumerable<TopDebtorsRankingReportModel>>();

            if (result is null || (result.Data is null && result.IsSuccess))
                return handler.Failure("Failed to get Top Debtors Report");

            return result;
        }

        public async Task<IResult<IEnumerable<TopPeopleDebtsSumRankingReportModel>>> GetTopPeopleDebtsSumRanking(bool isLending, short accountID)
        {
            var result = await _debtsReportRepository.GetTopPeopleDebtsSumRanking(isLending, accountID);

            var handler = _resultFactory.Create<IEnumerable<TopPeopleDebtsSumRankingReportModel>>();

            if (result is null || (result.Data is null && result.IsSuccess))
                return handler.Failure("Failed to get Top People Debts Ranking Report");

            return result;
        }

        public async Task<IResult<IEnumerable<DebtsMonthlyFlowReportModel>>> GetDebtsMonthlyFlow(DateTime startDate, DateTime EndDate, short accountID)
        {
            var result = await _debtsReportRepository.GetDebtsMonthlyFlow(startDate, EndDate, accountID);

            var handler = _resultFactory.Create<IEnumerable<DebtsMonthlyFlowReportModel>>();

            if (result is null || (result.Data is null && result.IsSuccess))
                return handler.Failure("Failed to get debts Monthly Flow Report");

            return result;
        }

        public async Task<IResult<IEnumerable<TopCategoriesReportModel>>> GetTopCategories(DateTime? startDate, DateTime? EndDate, bool isIncome, short accountID)
        {
            var result = await _categoriesReportRepository.GetTopCategories(startDate, EndDate, isIncome, accountID);

            var handler = _resultFactory.Create<IEnumerable<TopCategoriesReportModel>>();

            if (result is null || (result.Data is null && result.IsSuccess))
                return handler.Failure("Failed to get top categories Report");

            return result;
        }

        public async Task<IResult<IEnumerable<CategoryMonthlyFlowReportModel>>> GetCategoryMonthlyFlow(int categoryID, DateTime startDate, DateTime EndDate, short accountID)
        {
            var result = await _categoriesReportRepository.GetCategoryMonthlyFlow(categoryID, startDate, EndDate, accountID);

            var handler = _resultFactory.Create<IEnumerable<CategoryMonthlyFlowReportModel>>();

            if (result is null || (result.Data is null && result.IsSuccess))
                return handler.Failure("Failed to get Categories Monthly Flow Report");

            return result;
        }
    }
}
