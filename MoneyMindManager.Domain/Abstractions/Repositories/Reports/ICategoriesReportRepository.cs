using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.Reports.Categories;

namespace MoneyMindManager.Domain.Abstractions.Repositories.Reports
{
    public interface ICategoriesReportRepository
    {
        Task<IResult<IEnumerable<TopCategoriesReportModel>>> GetTopCategories(DateTime? startDate, DateTime? EndDate, bool isIncome, short accountID);
        Task<IResult<IEnumerable<CategoryMonthlyFlowReportModel>>> GetCategoryMonthlyFlow(int categoryID, DateTime startDate, DateTime EndDate, short accountID);
    }
}
