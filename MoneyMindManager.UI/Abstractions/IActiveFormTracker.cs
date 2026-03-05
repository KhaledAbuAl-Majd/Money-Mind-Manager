using System.Windows.Forms;

namespace MoneyMindManager.UI.Abstractions
{
    public interface IActiveFormTracker
    {
        Form ActiveForm { get; }

        bool ChangeActiveForm(Form activeForm);
        void ClearActiveForm();
    }
}
