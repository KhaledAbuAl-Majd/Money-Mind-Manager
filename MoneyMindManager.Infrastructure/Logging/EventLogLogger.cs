using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Infrastructure;
using MoneyMindManager.Core;

namespace MoneyMindManager.Infrastructure.Logging
{
    public class EventLogLogger : ILogger
    {
        private readonly string _sourceName;

        public EventLogLogger(IEventLogLoggerSettings eventLogSettings)
        {
            _sourceName = eventLogSettings.SourceName;
        }

        private bool _Log(string message, EventLogEntryType eventLogEntryType)
        {
            try
            {
                EventLog.WriteEntry(_sourceName, message,eventLogEntryType);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Log(string message)
        {
            try
            {
                EventLog.WriteEntry(_sourceName, message);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool LogError(string message, Exception ex)
        {
            string errorMessage = $"An error happped with message: {message}, Exception: {ex.Message}";
            return _Log(errorMessage, EventLogEntryType.Error);
        }
        public bool LogError(string message)
        {
            string errorMessage = $"An error happped with message: {message}";
            return _Log(errorMessage, EventLogEntryType.Error);
        }

        public bool LogSuccess(string message)
        {
            return _Log(message, EventLogEntryType.SuccessAudit);
        }

        public bool LogWarning(string message)
        {
            return _Log(message, EventLogEntryType.Warning);
        }

        public bool LogInfo(string message)
        {
            return _Log(message, EventLogEntryType.Information);
        }
    }
}
