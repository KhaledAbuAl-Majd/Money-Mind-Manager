using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.Reports.Debts;

namespace MoneyMindManager.Domain.Abstractions.Repositories.Reports
{
    public interface IDebtsReportRepository
    {
        Task<IResult<IEnumerable<DebtRepaymentScheduleReportModel>>> GetDebtsRepaymentSchedule(short accountID);
        Task<IResult<IEnumerable<TopDebtorsRankingReportModel>>> GetTopDebtorsRanking(bool isLending, short accountID);
        Task<IResult<IEnumerable<TopPeopleDebtsSumRankingReportModel>>> GetTopPeopleDebtsSumRanking(bool isLending, short accountID);
        Task<IResult<IEnumerable<DebtsMonthlyFlowReportModel>>> GetDebtsMonthlyFlow(DateTime startDate, DateTime EndDate, short accountID);
    }
}
