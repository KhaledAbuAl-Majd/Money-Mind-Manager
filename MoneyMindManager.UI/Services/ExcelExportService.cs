using System;
using System.Data;
using System.Threading.Tasks;
using ClosedXML.Excel;
using MoneyMindManager.Core;
using MoneyMindManager.UI.Abstractions;

namespace MoneyMindManager.UI.Services
{
    public class ExcelExportService : IExportExcelService
    {
        private readonly ILogger _logger;

        public ExcelExportService(ILogger logger)
        {
            this._logger = logger;
        }

        public event Action<byte> OnProgressChanged;
        public async Task<bool> Export(DataTable dt, string filePath, string sheetName = "Data")
        {
            bool result = await Task.Run(() =>
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        OnProgressChanged.Invoke(5);

                        var worksheet = workbook.Worksheets.Add(dt, sheetName);

                        OnProgressChanged.Invoke(60);

                        // تنسيقات إضافية اختيارية:
                        worksheet.Columns().AdjustToContents(); // يضبط عرض الأعمدة تلقائيًا
                        worksheet.Row(1).CellsUsed().Style.Font.Bold = true; // يجعل رؤوس الأعمدة Bold
                        worksheet.Row(1).CellsUsed().Style.Fill.BackgroundColor = XLColor.SteelBlue; // خلفية رمادية للرؤوس
                        worksheet.Row(1).CellsUsed().Style.Font.FontColor = XLColor.White; // خلفية رمادية للرؤوس
                        worksheet.CellsUsed().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        OnProgressChanged.Invoke(90);

                        workbook.SaveAs(filePath);

                        OnProgressChanged.Invoke(100);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    OnProgressChanged.Invoke(100);
                    return false;
                }
            });

            return result;
        }
    }
}
