using System;
using System.Windows.Forms;

namespace MoneyMindManager.UI.Abstractions
{
    public interface IFormDisplayer
    {
        void OpenDialog<T>(Action<T> initialize = null) where T : Form;
        bool OpenAtContainer<T>(Action<T> intialize = null) where T : Form;
    }
}
