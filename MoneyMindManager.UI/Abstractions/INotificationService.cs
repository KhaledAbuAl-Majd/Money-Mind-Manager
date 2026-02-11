using System;
using System.Windows.Forms;

namespace MoneyMindManager.UI.Abstractions
{
    public interface INotificationService
    {
        void Display(System.Drawing.Icon notifyIcon, ToolTipIcon ballonTipIcon, bool visible, string title, string text, int timeOut);

        void DisplayWithOnClick(System.Drawing.Icon notifyIcon, ToolTipIcon ballonTipIcon, bool visible, string title, string text, int timeOut, EventHandler onClick);
    }
}
