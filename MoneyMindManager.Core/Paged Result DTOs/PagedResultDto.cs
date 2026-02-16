using System.Collections.Generic;

namespace MoneyMindManager.Core.Paged_Result_DTOs
{
    public class PagedResultDTO<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public PagedResultDTO(IEnumerable<T> data, int totalPages, int totalRecords)
        {
            Data = data;
            TotalPages = totalPages;
            TotalRecords = totalRecords;
        }
    }
}
