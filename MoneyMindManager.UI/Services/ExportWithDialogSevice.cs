using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using MoneyMindManager.UI.Abstractions;

namespace MoneyMindManager.UI.Services
{
    public class ExportWithDialogSevice : IExportWithDialogService
    {
        private readonly IExportExcelService _exportExcelService;
        private readonly INotificationService _notificationService;
        private readonly IActiveFormTracker _activeFormTracker;

        public ExportWithDialogSevice(IExportExcelService exportExcelService, INotificationService notificationService, IActiveFormTracker activeFormTracker)
        {
            this._exportExcelService = exportExcelService;
            this._notificationService = notificationService;
            this._activeFormTracker = activeFormTracker;
        }

        private void UpdateProgress(byte percentage)
        {
            if (_activeFormTracker.ActiveForm == null)
                return;

            TaskbarManager.Instance.SetProgressValue(percentage, 100);
        }
        public async Task<bool> ExportToExcel(DataTable dt, string defaultFileName, string sheetName = "Data")
        {
            bool result = false;

            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Title = "Money Mind Manager \"Export Report\"";
                saveFile.FileName = defaultFileName;
                saveFile.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";


                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                    _exportExcelService.OnProgressChanged += UpdateProgress;

                    result = await _exportExcelService.Export(dt, saveFile.FileName, sheetName);

                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);

                    if (result == true)
                    {
                        _notificationService.DisplayWithOnClick(_activeFormTracker.ActiveForm.Icon, ToolTipIcon.Info, true, "نجاح العملية", "تم تصدير الملف بنجاح ✅", 10000,
                          (e, s) => System.IO.Path.GetDirectoryName(saveFile.FileName));
                    }
                }
            }

            return result;
        }
    }
}
