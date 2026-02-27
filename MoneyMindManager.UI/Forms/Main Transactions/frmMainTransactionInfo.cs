using System;
using System.Windows.Forms;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.UI.Abstractions;

namespace MoneyMindManager_Presentation.Transactions
{
    public partial class frmMainTransactionInfo : Form
    {
        private IUserSession _userSession;
        private IMessageBoxService _messageBoxService;
        private IMainTransactionApiClient _mainTransactionApiClient;
        private IFormDisplayer _formDisplayer;
        private bool isInitialized = false;
        public frmMainTransactionInfo(IUserSession userSession, IMessageBoxService messageBoxService, IMainTransactionApiClient mainTransactionApiClient
          , IFormDisplayer formDisplayer)
        {
            InitializeComponent();
            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._mainTransactionApiClient = mainTransactionApiClient;
            this._formDisplayer = formDisplayer;
        }

        public bool Initilize(int transactionID)
        {
            if (!ctrlMainTransactionInfo1.Initialize(_userSession, _messageBoxService, _mainTransactionApiClient, _formDisplayer))
                return false;

            this.isInitialized = true;
            this._transactionID = transactionID;
            return true;
        }

        int _transactionID;

        private async void frmMainTransactionInfo_Load(object sender, EventArgs e)
        {
            if (!isInitialized)
            {
                this.Close();
                return;
            }

            if (!await this.ctrlMainTransactionInfo1.LoadMainTransaction(_transactionID))
                this.Close();
        }

        private void gbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
