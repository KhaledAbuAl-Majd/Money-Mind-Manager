using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManager.Shared.DTOs.Paged_Result_DTOs
{
    public class PagedResultWithAmountDTO<T> : PagedResultDTO<T>
    {
        public decimal TotalValue { get; set; }

        public decimal CurrentPageValue { get; set; }

        public PagedResultWithAmountDTO(IEnumerable<T> data, int totalPages, int totalRecords, decimal totalValue,
                    decimal currentPageValue) : base(data, totalPages, totalRecords)
        {
            this.TotalValue = totalValue;
            this.CurrentPageValue = currentPageValue;
        }
    }
}
