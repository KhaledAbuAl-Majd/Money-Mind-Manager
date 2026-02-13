using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManager.Core
{
    public interface ILogger
    {
        bool Log(string message);

        bool LogError(string message,Exception ex);

        bool LogError(string message);

        bool LogSuccess(string message);

        bool LogWarning(string message);

        bool LogInfo(string message);
    }
}
