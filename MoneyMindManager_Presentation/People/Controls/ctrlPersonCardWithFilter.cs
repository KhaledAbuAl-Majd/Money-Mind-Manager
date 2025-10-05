using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyMindManager_Business;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Income_And_Expense.Categories;

namespace MoneyMindManager_Presentation.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public bool EnablityOfSearchPart
        {
            get
            {
                return pnlSearchPart.Enabled;
            }
            set
            {
                pnlSearchPart.Enabled = value;
            }
        }
        public clsPerson Person
        {
            get
            {
                return ctrlPersonCard1.Person;
            }
        }

        /// <summary>
        /// When search or add person successed, person loaded at control
        /// </summary>
        public event Action OnSuccess;

        /// <summary>
        /// When search or add person Failed, person Failed to load at control
        /// </summary>
        public event Action OnFailed;

        public event Action OnEditingPerson;
        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            FocusOnTextBox();
        }

        private void ctrlPersonCard1_OnEditingPerson()
        {
            OnEditingPerson?.Invoke();
        }

        void _ShowSelectPersonForm()
        {
            var frm = new frmSelectPerson();
            frm.OnPersonSelected += FrmSelectPerson_OnPersonSelected;
            clsGlobal_UI.MainForm.AddNewFormAsDialog(frm);
        }

        async Task _FindPerson(int personID)
        {
            if (!await ctrlPersonCard1.LoadPerson(personID))
            {
                OnFailed?.Invoke();
                return;
            }

            kgtxtPersonID.Text = personID.ToString();
            kgtxtPersonName.Text = ctrlPersonCard1.Person?.PersonName;

            OnSuccess?.Invoke();
        }
        private async void FrmSelectPerson_OnPersonSelected(object sender, frmSelectPerson.SelectPersonEventArgs e)
        {
           await _FindPerson(e.PersonID);
        }

        private  void gibtnFindPerson_Click(object sender, EventArgs e)
        {
            if (gibtnFindPerson.Enabled)
            {
                _ShowSelectPersonForm();
            }
        }

        private void gibtnAddPerson_Click(object sender, EventArgs e)
        {
            if (!gibtnAddPerson.Enabled)
                return;

            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.OnCloseAndSaved += FrmAddUpdatePerson_OnCloseAndSaved;
            clsGlobal_UI.MainForm.AddNewFormAtContainer(frm);
        }

        private async void FrmAddUpdatePerson_OnCloseAndSaved(int personID)
        {
            kgtxtPersonID.Text = personID.ToString();
            await _FindPerson(personID);
        }

        private void kgtxtPersonID_OnValidationError(object sender, KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            e.CancelEventArgs.Cancel = true;
            string errorMessage = clsUtils.GetValidationErrorTypeString(e.validationErrorType, kgtxtPersonID);
            errorProvider1.SetError(kgtxtPersonID, errorMessage);
        }

        private void kgtxtPersonID_OnValidationSuccess(object arg1, CancelEventArgs arg2)
        {
            arg2.Cancel = false;
            errorProvider1.SetError(kgtxtPersonID, null);
        }

        public void FocusOnTextBox()
        {
            kgtxtPersonID.Focus();
        }

        public async Task<bool> LoadPerson(int personID)
        {
            bool loadResult = await ctrlPersonCard1.LoadPerson(personID);

            if (!loadResult)
                return false;

            kgtxtPersonID.Text = personID.ToString();
            kgtxtPersonName.Text = ctrlPersonCard1.Person?.PersonName;
            pnlSearchPart.Enabled = false;

            return true;

        }

        public void ResetControls()
        {
            ctrlPersonCard1.ResetControls();
            kgtxtPersonID.Text = null;
            kgtxtPersonName.Text = null;
        }

        private void kgtxtPersonID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F9)
            {
                gibtnFindPerson.PerformClick();
            }
        }
    }
}
