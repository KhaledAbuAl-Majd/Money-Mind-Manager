using System.Collections.Generic;
using MoneyMindManager.Core.Paged_Result_DTOs;

namespace MoneyMindManager.Shared.DTOs.Paged_Result_DTOs
{
    public class DebtPaymentsPagedResultDTO<T> : PagedResultDTO<T>
    {
        public decimal RemainingAmount { get; set; }
        public DebtPaymentsPagedResultDTO(IEnumerable<T> data, int totalPages, int totalRecords, decimal remainingAmount) : base(data, totalPages, totalRecords)
        {
            this.RemainingAmount = remainingAmount;
        }
    }
}
