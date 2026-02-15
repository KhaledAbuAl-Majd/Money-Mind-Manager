using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManager.Shared.DTOs
{
    public class PagedResultDTO<T>
    {
        public IEnumerable<T> Data {get;set;}
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
