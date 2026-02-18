using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.Reports;

namespace MoneyMindManager.Domain.Abstractions.Repositories.Reports
{
    public interface IGeneralReportRepository
    {
        IResult<Task<List<MonthlyFlowReportModel>>> GetMonthlyFlow(DateTime startDate, DateTime EndDate, short accountID);
        IResult<Task<MainKpisReportModel>> GetMainKPIS(short accountID);
    }
}
