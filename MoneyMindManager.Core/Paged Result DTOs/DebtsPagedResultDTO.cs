using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManager.Shared.DTOs.Paged_Result_DTOs
{
    public class DebtsPagedResultDTO<T> : PagedResultWithAmountDTO<T>
    {
        public decimal TotalRemainingAmount { get; set; }

        public decimal CurrentPageRemainingAmount { get; set; }

        public DebtsPagedResultDTO(IEnumerable<T> data, int totalPages, int totalRecords, decimal totalValue,
                    decimal currentPageValue, decimal totalRemainingAmount, decimal currentPageRemainingAmount) : base(data, totalPages, totalRecords, totalValue, currentPageValue)
        {
            this.TotalRemainingAmount = totalRemainingAmount;
            this.CurrentPageRemainingAmount = currentPageRemainingAmount;
        }
    }
}
