using System;
using System.Data;
using System.Threading.Tasks;

namespace MoneyMindManager.UI.Abstractions
{
    public interface IExportExcelService
    {
        event Action<byte> OnProgressChanged;
        Task<bool> Export(DataTable dt, string filePath, string sheetName = "Data");
    }
}
