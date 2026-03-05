using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManager.Application.Abstractions.Infrastructure
{
    public interface IEventLogLoggerSettings
    {
        string SourceName { get; }
    }
}
