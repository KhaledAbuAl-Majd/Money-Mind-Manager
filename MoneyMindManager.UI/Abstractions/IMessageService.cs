using System.Windows.Forms;

namespace MoneyMindManager.UI.Abstractions
{
    public interface IMessageBoxService
    {
        void DisplayError(string message);
        DialogResult Display(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1);
        void ShowValidateChildrenFailedMessage();
    }
}
