using System.Collections.Generic;

namespace MoneyMindManager.Shared.DTOs.Paged_Result_DTOs
{
    public class DebtsPagedResultDTO<T> : PagedResultWithTotal_CurrentDTO<T>
    {
        public decimal TotalRemainingAmount { get; set; }

        public decimal CurrentPageRemainingAmount { get; set; }

        public DebtsPagedResultDTO(List<T> data, int totalPages, int totalRecords, decimal totalValue,
                    decimal currentPageValue, decimal totalRemainingAmount, decimal currentPageRemainingAmount) : base(data, totalPages, totalRecords, totalValue, currentPageValue)
        {
            this.TotalRemainingAmount = totalRemainingAmount;
            this.CurrentPageRemainingAmount = currentPageRemainingAmount;
        }
    }
}
