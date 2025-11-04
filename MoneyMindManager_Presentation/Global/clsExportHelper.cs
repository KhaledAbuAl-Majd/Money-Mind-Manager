using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using ClosedXML.Excel;
using Microsoft.WindowsAPICodePack.Taskbar;
using MoneyMindManager_Presentation.Properties;
using MoneyMindManagerGlobal;

namespace MoneyMindManager_Presentation.Global
{
    public static class clsExportHelper
    {
        private static void UpdateProgress(int percentage)
        {
            if (clsPL_Global.ActiveForm == null)
                return;

            TaskbarManager.Instance.SetProgressValue(percentage, 100);
        }

        private static async Task<bool> _ExportToExcel(DataTable dt, string filePath, string sheetName = "Data")
        {
            bool result = await Task.Run(() =>
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        UpdateProgress(5);

                        var worksheet = workbook.Worksheets.Add(dt, sheetName);

                        UpdateProgress(60);

                        // تنسيقات إضافية اختيارية:
                        worksheet.Columns().AdjustToContents(); // يضبط عرض الأعمدة تلقائيًا
                        worksheet.Row(1).CellsUsed().Style.Font.Bold = true; // يجعل رؤوس الأعمدة Bold
                        worksheet.Row(1).CellsUsed().Style.Fill.BackgroundColor = XLColor.SteelBlue; // خلفية رمادية للرؤوس
                        worksheet.Row(1).CellsUsed().Style.Font.FontColor = XLColor.White; // خلفية رمادية للرؤوس
                        worksheet.CellsUsed().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        UpdateProgress(90);

                        workbook.SaveAs(filePath);

                        UpdateProgress(100);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
                    UpdateProgress(100);
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


                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);

                    result = await _ExportToExcel(dt, saveFile.FileName, sheetName);

                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);

                    if (result == true)
                    {
                        //clsPL_MessageBoxs.ShowMessage("تم تصدير الملف بنجاح", "نجاح العملية", MessageBoxButtons.OK,
                        //    MessageBoxIcon.Information);

                        _ShowNotification(System.IO.Path.GetDirectoryName(saveFile.FileName));
                    }
                }
            }

            return result;
        }

        private static void _ShowNotification(string folderPath)
        {
            if (clsPL_Global.ActiveForm == null)
                return;

            clsPL_Global.ActiveForm.Invoke(new Action(() =>
            {
                NotifyIcon notify = new NotifyIcon();
                notify.Icon = clsPL_Global.ActiveForm.Icon;
                notify.BalloonTipIcon = ToolTipIcon.Info;
                notify.Visible = true;
                notify.BalloonTipTitle = "نجاح العملية";
                notify.BalloonTipText = "تم تصدير الملف بنجاح ✅";
                notify.ShowBalloonTip(10000);

                notify.BalloonTipClicked += (x, y) =>
                {
                    clsFileSystemHelper.OpenFolder(folderPath);
                    notify.Dispose();
                };
            }));
        }
    }
}
