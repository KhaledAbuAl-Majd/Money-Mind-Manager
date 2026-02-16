using System.Windows.Forms;

namespace MoneyMindManager.UI.Abstractions
{
    public interface IFormDisplayer
    {
        void AddNewFormAsDialog(Form frm);
        void AddNewFormAtContainer(Form frm);
    }
}
