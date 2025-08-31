using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManagerGlobal
{
    public static class clsLogger
    {
        private static string _sourceName = "MonyMindManager";
        private static string _logName = "Application";

        /// <summary>
        /// Logs a message to the Windows Event Viewer.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        /// <param name="entryType">The type of entry. Default is Error.</param>
        /// <returns>Result of Logging Operation [true if it succeeded, false if it failed]</returns>
        public static bool LogAtEventLog(string message, EventLogEntryType entryType = EventLogEntryType.Error)
            => KhaledUtils.clsLogger.LogAtEventLog(_sourceName, _logName, message, entryType);
       
    }
}
