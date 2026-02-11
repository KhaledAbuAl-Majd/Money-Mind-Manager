using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyMindManager_Presentation.People
{
    public partial class frmPersonInfo : Form
    {
      public event Action OnEditingPersonAndFormClosed;

        bool _IsPersonEdited = false;

        int _personID;

        bool _allowEdigitringPerson;
        public frmPersonInfo(int personID)
        {
            InitializeComponent();
            this._personID = personID;
            this._allowEdigitringPerson = true;
        }

        public frmPersonInfo(int personID,bool allowEditingPerson)
        {
            InitializeComponent();
            this._personID = personID;
            this._allowEdigitringPerson = allowEditingPerson;
        }

        private async void frmPersonInfo_Load(object sender, EventArgs e)
        {
            if (!await ctrlPersonCard1.LoadPerson(_personID))
                this.Close();

            ctrlPersonCard1.AllowEditingPerson = this._allowEdigitringPerson;

            _IsPersonEdited = false;
        }

        private void gbtnClose_Click(object sender, EventArgs e)
        {
            if (_IsPersonEdited)
                OnEditingPersonAndFormClosed?.Invoke();
            this.Close();
        }

        private void ctrlPersonCard1_OnEditingPerson()
        {
            _IsPersonEdited = true;
            //OnEditingPersonAndFormClosed?.Invoke();
        }

    }
}
