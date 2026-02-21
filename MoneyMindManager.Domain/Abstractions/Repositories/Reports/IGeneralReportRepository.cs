using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.Reports;

namespace MoneyMindManager.Domain.Abstractions.Repositories.Reports
{
    public interface IGeneralReportRepository
    {
        Task<IResult<IEnumerable<MonthlyFlowReportModel>>> GetMonthlyFlow(DateTime startDate, DateTime EndDate, short accountID);
        Task<IResult<MainKpisReportModel>> GetMainKPIS(short accountID);
    }
}
