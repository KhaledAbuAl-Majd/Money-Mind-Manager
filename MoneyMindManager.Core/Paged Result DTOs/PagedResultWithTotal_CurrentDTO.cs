using System.Collections.Generic;
using MoneyMindManager.Core.Paged_Result_DTOs;

namespace MoneyMindManager.Shared.DTOs.Paged_Result_DTOs
{
    public class PagedResultWithTotal_CurrentDTO<T> : PagedResultDTO<T>
    {
        public decimal TotalValue { get; set; }

        public decimal CurrentPageValue { get; set; }

        public PagedResultWithTotal_CurrentDTO(List<T> data, int totalPages, int totalRecords, decimal totalValue,
                    decimal currentPageValue) : base(data, totalPages, totalRecords)
        {
            this.TotalValue = totalValue;
            this.CurrentPageValue = currentPageValue;
        }
    }
}
