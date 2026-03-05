using System;
using System.Windows.Forms;
using MoneyMindManager.UI.Abstractions;

namespace MoneyMindManager.UI.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IActiveFormTracker _activeFormTracker;

        public NotificationService(IActiveFormTracker activeFormTracker)
        {
            this._activeFormTracker = activeFormTracker;
        }

        public void Display(System.Drawing.Icon notifyIcon, ToolTipIcon ballonTipIcon, bool visible, string title, string text, int timeOut)
        {
            var activeForm = _activeFormTracker.ActiveForm;

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
            var activeForm = _activeFormTracker.ActiveForm;

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
