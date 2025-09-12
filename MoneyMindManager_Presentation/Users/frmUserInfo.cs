using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyMindManager_Presentation.Users
{
    public partial class frmUserInfo : Form
    {
        
        public event Action OnEditingUserAndFormClosed;

        bool _IsUserEdited = false;

        int _userID;
        public frmUserInfo(int userID)
        {
            InitializeComponent();
            this._userID = userID;
        }

        private async void frmUseInfo_Load(object sender, EventArgs e)
        {
            if (!await ctrlUserCard1.LoadUser(_userID))
                this.Close();

            _IsUserEdited = false;
        }

        private void gbtnClose_Click(object sender, EventArgs e)
        {
            if (_IsUserEdited)
                OnEditingUserAndFormClosed?.Invoke();

            this.Close();
        }

        private void ctrlUserCard1_OnEditingUserOrPerson()
        {
            _IsUserEdited = true;
        }
    }
}
