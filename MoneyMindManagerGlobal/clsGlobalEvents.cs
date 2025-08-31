using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManagerGlobal
{
    public static class clsGlobalEvents
    {
        public static event Action<string> OnErrorOccured;

        public static void RaiseEvent(string message)
        {
            OnErrorOccured?.Invoke(message);
        }
    }
}
