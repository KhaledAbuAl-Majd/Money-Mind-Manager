using System.Windows.Forms;
using MoneyMindManager.UI.Abstractions;

namespace MoneyMindManager.UI.Services
{
    public class ActiveFormTracker : IActiveFormTracker
    {
        public Form ActiveForm { get; private set; }

        public bool ChangeActiveForm(Form activeForm)
        {
            this.ActiveForm = activeForm;
            return true;
        }
        public void ClearActiveForm()
        {
            this.ActiveForm = null;
        }
    }
}
