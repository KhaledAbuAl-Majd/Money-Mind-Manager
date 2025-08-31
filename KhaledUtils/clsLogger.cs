using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhaledUtils
{
    public static class clsLogger
    {
        /// <summary>
        /// Logs a message to the Windows Event Viewer.
        /// </summary>
        /// <param name="sourceName">Programm Name</param>
        /// <param name="logName">Logging Department as [Application,Security,Setup,System,ForwardEvents]</param>
        /// <param name="message">The message to be logged.</param>
        /// <param name="entryType">The type of entry. Default is Error.</param>
        /// <returns>Result of Logging Operation [true if it succeeded, false if it failed]</returns>
        public static bool LogAtEventLog(string sourceName,string logName,string message, EventLogEntryType entryType = EventLogEntryType.Error)
        {
            bool result = false;

            try
            {
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, logName);
                }

                EventLog.WriteEntry(sourceName, message, entryType);

                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }
    }
}
