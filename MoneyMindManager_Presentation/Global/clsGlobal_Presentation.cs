using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyMindManager_Business;
using MoneyMindManagerGlobal;

namespace MoneyMindManager_Presentation
{
    public static class clsGlobal_Presentation
    {
        public static clsUser CurrentUser { get; set; }
        public static void SubscribeToErrorOcrruedEvent()
        {
            clsGlobalEvents.OnErrorOccured += ShowErrorMessage;

            //SynchronizationContext uiContext = SynchronizationContext.Current;

            //clsGlobalEvents.OnErrorOccured += message =>
            //{
            //    uiContext.Post(_ =>
            //    {
            //        MessageBoxOptions options = 0;

            //        // التشييك لو الرسالة فيها حروف عربية
            //        if (message.Any(c => c >= 0x0600 && c <= 0x06FF))
            //        {
            //            options = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
            //        }

            //        MessageBox.Show(message, "حدث خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
            //    }, null);

            //};
        }
        public static void ShowErrorMessage(string message)
        {
            ShowMessage(message, "حدث خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Show Usual Message and deal with arabic, english
        /// </summary>
        public static void ShowMessage(string message,string caption,MessageBoxButtons buttons,MessageBoxIcon icon,MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1)
        {
            MessageBoxOptions options = 0;

            // التشييك لو الرسالة فيها حروف عربية
            if (message.Any(c => c >= 0x0600 && c <= 0x06FF))
            {
                options = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
            }

            MessageBox.Show(message, caption, buttons, icon, defaultButton, options);
        }
    }
}
