using System;
using System.Windows.Forms;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.People.Controls;

namespace MoneyMindManager_Presentation.People
{
    public partial class frmPersonInfo : Form
    {
        private IPersonApiClient _personApiClient;
        private IUserSession _userSession;
        private IMessageBoxService _messageBoxService;
        private IUserApiClient _userApiClient;
        private IFormDisplayer _formDisplayer;

        private bool isInitialized = false;

        public event Action OnEditingPersonAndFormClosed;

        bool _IsPersonEdited = false;

        int _personID;

        bool _allowEdigitringPerson;

        public frmPersonInfo(IPersonApiClient personApiClient, IUserSession userSession, IMessageBoxService messageBoxService,
            IUserApiClient userApiClient, IFormDisplayer formDisplayer)
        {
            InitializeComponent();
            this._allowEdigitringPerson = true;
            this._personApiClient = personApiClient;
            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._userApiClient = userApiClient;
            this._formDisplayer = formDisplayer;
        }

        public bool Initialize(int personID)
        {
            if (!ctrlPersonCard1.Initialize(_personApiClient, _userSession, _messageBoxService, _userApiClient, _formDisplayer))
                return false;
            this._personID = personID;
            this.isInitialized = true;
            return true;
        }
        public bool Initialize(int personID, bool allowEditingPerson)
        {
            if (!ctrlPersonCard1.Initialize(_personApiClient, _userSession, _messageBoxService, _userApiClient, _formDisplayer))
                return false;
            this._personID = personID;
            this._allowEdigitringPerson = allowEditingPerson;
            this.isInitialized = true;
            return true;
        }

        private async void frmPersonInfo_Load(object sender, EventArgs e)
        {
            if (!isInitialized)
                this.Close();

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
