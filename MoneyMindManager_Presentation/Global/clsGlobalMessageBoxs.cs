using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyMindManager_Presentation.Global
{
    public static class clsGlobalMessageBoxs
    {
        public static void ShowErrorMessage(string message)
        {
            ShowMessage(message, "حدث خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Show Usual Message and deal with arabic, english
        /// </summary>
        public static DialogResult ShowMessage(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1)
        {
            MessageBoxOptions options = 0;

            // التشييك لو الرسالة فيها حروف عربية
            if (message.Any(c => c >= 0x0600 && c <= 0x06FF))
            {
                options = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
            }

            DialogResult d = DialogResult.Cancel;

            clsGlobal_UI.MainForm.Invoke(new Action(() =>
              {
                  d = MessageBox.Show(message, caption, buttons, icon, defaultButton, options);
              }));

            return d;
        }

        public static void ShowValidateChildrenFailedMessage()
        {
            ShowMessage("تم العثور على حقول غير صالحة. ضع المؤشر على العلامات الحمراء لعرض سبب الخطأ.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
