using System;
using System.Windows.Forms;

namespace MoneyMindManager.UI.Abstractions
{
    public interface IFormDisplayer
    {
        bool OpenDialog<T>(Func<T, bool> initialize = null) where T : Form;
        bool OpenAtContainer<T>(Func<T, bool> intialize = null) where T : Form;
    }
}
