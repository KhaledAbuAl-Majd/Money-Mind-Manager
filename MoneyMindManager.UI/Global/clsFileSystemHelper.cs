using System;
using System.Diagnostics;
using System.IO;
using MoneyMindManagerGlobal;

public static class clsFileSystemHelper
{
    public static bool OpenFolder(string folderPath)
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
            clsLogger.LogAtEventLog($"Failed to open folder: {folderPath}. Error: {ex.Message}");
            return false;
        }
    }
}