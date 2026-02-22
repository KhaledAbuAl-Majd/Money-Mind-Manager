using System.Collections.Generic;

namespace MoneyMindManager.Core.Paged_Result_DTOs
{
    public class PagedResultWithValueDTO<T> : PagedResultDTO<T>
    {
        public decimal Value { get; set; }

        public PagedResultWithValueDTO(IEnumerable<T> data, int totalPages, int totalRecords, decimal value) : base(data, totalPages, totalRecords)
        {
            this.Value = value;
        }
    }
}
