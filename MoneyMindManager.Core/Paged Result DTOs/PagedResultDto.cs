using System.Collections.Generic;

namespace MoneyMindManager.Core.Paged_Result_DTOs
{
    public class PagedResultDTO<T>
    {
        public List<T> Data { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public PagedResultDTO(List<T> data, int totalPages, int totalRecords)
        {
            Data = data;
            TotalPages = totalPages;
            TotalRecords = totalRecords;
        }
    }
}
