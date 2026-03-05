using System;
using System.Windows.Forms;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.People.Controls;

namespace MoneyMindManager_Presentation.Users
{
    public partial class frmUserInfo : Form
    {
        private IPersonApiClient _personApiClient;
        private IUserSession _userSession;
        private IMessageBoxService _messageBoxService;
        private IUserApiClient _userApiClient;
        private IFormDisplayer _formDisplayer;

        private bool isInitialized = false;

        public event Action OnEditingUserAndFormClosed;

        bool _IsUserEdited = false;

        int _userID;

        public frmUserInfo(IPersonApiClient personApiClient, IUserSession userSession, IMessageBoxService messageBoxService,
           IUserApiClient userApiClient, IFormDisplayer formDisplayer)
        {
            InitializeComponent();
            this._personApiClient = personApiClient;
            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._userApiClient = userApiClient;
            this._formDisplayer = formDisplayer;
        }

        public bool Initialize(int userID)
        {
            if (!ctrlUserCard1.Initialize(_personApiClient, _userSession, _messageBoxService, _userApiClient, _formDisplayer))
                return false;
            this._userID = userID;
            this.isInitialized = true;
            return true;
        }

        private async void frmUseInfo_Load(object sender, EventArgs e)
        {
            if (!isInitialized)
                this.Close();

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
