using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using MoneyMindManagerGlobal;

namespace MoneyMindManager_Presentation.Global
{
    public static class clsExportHelper
    {
        private static async Task<bool> _ExportToExcel(DataTable dt, string filePath, string sheetName = "Data")
        {
            bool result = await Task.Run(() =>
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add(dt, sheetName);

                        // تنسيقات إضافية اختيارية:
                        worksheet.Columns().AdjustToContents(); // يضبط عرض الأعمدة تلقائيًا
                        worksheet.Row(1).CellsUsed().Style.Font.Bold = true; // يجعل رؤوس الأعمدة Bold
                        worksheet.Row(1).CellsUsed().Style.Fill.BackgroundColor = XLColor.SteelBlue; // خلفية رمادية للرؤوس
                        worksheet.Row(1).CellsUsed().Style.Font.FontColor = XLColor.White; // خلفية رمادية للرؤوس
                        worksheet.CellsUsed().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        workbook.SaveAs(filePath);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
                    return false;
                }
            });

            return result;
        }

        public static async Task<bool> ExportToExcelWithDialog(DataTable dt,string defaultFileName, string sheetName = "Data")
        {
            bool result = false;

            using(SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Title = "Money Mind Manager \"Export Report\"";
                saveFile.FileName = defaultFileName;
                saveFile.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";

                if(saveFile.ShowDialog() == DialogResult.OK)
                {
                    result = await _ExportToExcel(dt, saveFile.FileName, sheetName);

                    if(result == true)
                    {
                        clsPL_MessageBoxs.ShowMessage("تم تصدير الملف بنجاح", "نجاح العملية", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }

            return result;
        }
    }
}
