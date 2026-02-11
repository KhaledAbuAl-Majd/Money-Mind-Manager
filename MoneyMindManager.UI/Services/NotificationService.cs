using System;
using System.Windows.Forms;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation;

namespace MoneyMindManager.UI.Services
{
    public class NotificationService : INotificationService
    {
        private readonly Func<Form> _activeFormProvider;

        public NotificationService(Func<Form> activeFormProvider)
        {
            this._activeFormProvider = activeFormProvider;
        }

        public void Display(System.Drawing.Icon notifyIcon, ToolTipIcon ballonTipIcon, bool visible, string title, string text, int timeOut)
        {
            var activeForm = _activeFormProvider();

            if (activeForm == null)
                return;

            activeForm.Invoke(new Action(() =>
            {
                NotifyIcon notify = new NotifyIcon();
                notify.Icon = notifyIcon;
                notify.BalloonTipIcon = ballonTipIcon;
                notify.Visible = visible;
                notify.BalloonTipTitle = title;
                notify.BalloonTipText = text;
                notify.ShowBalloonTip(timeOut);

                notify.BalloonTipClosed += (sender, e) =>
                {
                    notify.Dispose();
                };
            }));
        }

        public void DisplayWithOnClick(System.Drawing.Icon notifyIcon, ToolTipIcon ballonTipIcon, bool visible, string title, string text, int timeOut, EventHandler onClick)
        {
            var activeForm = _activeFormProvider();

            if (activeForm == null)
                return;

            activeForm.Invoke(new Action(() =>
            {
                NotifyIcon notify = new NotifyIcon();
                notify.Icon = notifyIcon;
                notify.BalloonTipIcon = ballonTipIcon;
                notify.Visible = visible;
                notify.BalloonTipTitle = title;
                notify.BalloonTipText = text;
                notify.ShowBalloonTip(timeOut);

                notify.BalloonTipClicked += (x, y) =>
                {
                    onClick.Invoke(x, y);
                    notify.Dispose();
                };



                notify.BalloonTipClosed += (sender, e) =>
                {
                    notify.Dispose();
                };
            }));
        }
    }
}
