using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager.Core;
using MoneyMindManager.UI.Abstractions;

namespace MoneyMindManager.UI.Services
{
    public class FolderService:IFolderService
    {
        private readonly ILogger _logger;
        private readonly IMessageBoxService _messageBoxService;
        public FolderService(ILogger logger,IMessageBoxService messageBoxService)
        {
            this._logger = logger;
            this._messageBoxService = messageBoxService;
        }
        public bool Open(string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    return false;
                }

                Process.Start(new ProcessStartInfo()
                {
                    FileName = folderPath,
                    UseShellExecute = true,
                    Verb = "open"
                });

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to open folder: {folderPath}. Error: {ex.Message}", ex);
                _messageBoxService.DisplayError("فشل فتح المجلد");
                return false;
            }
        }
    }
}
