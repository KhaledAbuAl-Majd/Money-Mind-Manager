using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyMindManagerGlobal;

namespace MoneyMindManager_Presentation
{
    public static class clsGlobal_Presentation
    {
        public static void SubscribeToErrorOcrruedEvent()
        {
            clsGlobalEvents.OnErrorOccured += message =>
            {
                MessageBoxOptions options = 0;

                // التشييك لو الرسالة فيها حروف عربية
                if (message.Any(c => c >= 0x0600 && c <= 0x06FF))
                {
                    options = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
                }

                MessageBox.Show(message,"حدث خطأ",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1,options);
            };

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
    }
}
