using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Infrastructure;

namespace MoneyMindManager.Infrastructure.Logging
{
    public class EventLogLoggerSettings: IEventLogLoggerSettings
    {
        public string SourceName { get; } = "MonyMindManager";
    }
}
