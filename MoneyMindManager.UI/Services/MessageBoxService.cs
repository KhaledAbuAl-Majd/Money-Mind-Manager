using System;
using System.Linq;
using System.Windows.Forms;
using MoneyMindManager.UI.Abstractions;

namespace MoneyMindManager.UI.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        private readonly IActiveFormTracker _activeFormTracker;

        public MessageBoxService(IActiveFormTracker activeFormTracker)
        {
            this._activeFormTracker = activeFormTracker;
        }
        public void DisplayError(string message)
        {
            Display(message, "حدث خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Show Usual Message and deal with arabic, english
        /// </summary>
        public DialogResult Display(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1)
        {
            var activeForm = _activeFormTracker.ActiveForm;

            if (activeForm == null)
                return DialogResult.Cancel;

            MessageBoxOptions options = 0;

            // التشييك لو الرسالة فيها حروف عربية
            if (message.Any(c => c >= 0x0600 && c <= 0x06FF))
            {
                options = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
            }

            DialogResult d = DialogResult.Cancel;

            activeForm.Invoke(new Action(() =>
            {
                d = MessageBox.Show(message, caption, buttons, icon, defaultButton, options);
            }));

            return d;
        }

        public void ShowValidateChildrenFailedMessage()
        {
            Display("تم العثور على حقول غير صالحة. ضع المؤشر على العلامات الحمراء لعرض سبب الخطأ.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
