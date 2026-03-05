using System.Data;
using System.Threading.Tasks;

namespace MoneyMindManager.UI.Abstractions
{
    public interface IExportWithDialogService
    {
        Task<bool> ExportToExcel(DataTable dt, string defaultFileName, string sheetName = "Data");
    }
}
