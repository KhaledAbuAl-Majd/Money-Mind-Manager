using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Shared.DTOs;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Income_And_Expense.Categories;

namespace MoneyMindManager_Presentation.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        private IFormDisplayer _formDisplayer;

        private bool isInitialized = false;
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
        public PersonDTO Person
        {
            get
            {
                return ctrlPersonCard1.Person;
            }
        }

        public bool Initialize(IPersonApiClient personApiClient, IUserSession userSession, IMessageBoxService messageBoxService,
           IUserApiClient userApiClient, IFormDisplayer formDisplayer)
        {
            if (personApiClient is null || userSession is null || messageBoxService is null || userApiClient is null || formDisplayer is null)
                return false;

            if (!ctrlPersonCard1.Initialize(personApiClient, userSession, messageBoxService, userApiClient, formDisplayer)) return false;

            this._formDisplayer = formDisplayer;
            isInitialized = true;

            return true;
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
            _formDisplayer.OpenDialog<frmSelectPerson>((frm) =>
            {
                frm.OnPersonSelected += FrmSelectPerson_OnPersonSelected;
                return true;
            });
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

        private void gibtnFindPerson_Click(object sender, EventArgs e)
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

            _formDisplayer.OpenAtContainer<frmAddUpdatePerson>((frm) =>
            {
                if (!frm.Initialize())
                    return false;
                frm.OnCloseAndSaved += FrmAddUpdatePerson_OnCloseAndSaved;
                return true;
            });
        }

        private async void FrmAddUpdatePerson_OnCloseAndSaved(int personID)
        {
            kgtxtPersonID.Text = personID.ToString();
            await _FindPerson(personID);
        }

        private void kgtxtPersonID_OnValidationError(object sender, KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            e.CancelEventArgs.Cancel = true;
            string errorMessage = clsPL_Utils.GetValidationErrorTypeString(e.validationErrorType, kgtxtPersonID);
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
            if (e.KeyCode == Keys.F9)
            {
                gibtnFindPerson.PerformClick();
            }
        }
    }
}
