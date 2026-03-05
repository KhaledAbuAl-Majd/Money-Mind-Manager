using System;
using System.Windows.Forms;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Shared.DTOs.FinTransaction;
using MoneyMindManager.Shared.DTOs.MainTransaction;
using MoneyMindManager.UI.Abstractions;

namespace MoneyMindManager_Presentation.Transactions
{
    public partial class frmFinTransactionInfo : Form
    {
        private IUserSession _userSession;
        private IMessageBoxService _messageBoxService;
        private IMainTransactionApiClient _mainTransactionApiClient;
        private IFormDisplayer _formDisplayer;
        private IFinTransactionApiClient _finTransactionApi;
        private bool isInitialized = false;
        public frmFinTransactionInfo(IUserSession userSession, IMessageBoxService messageBoxService, IMainTransactionApiClient mainTransactionApiClient
          , IFormDisplayer formDisplayer, IFinTransactionApiClient finTransactionApiClient)
        {
            InitializeComponent();
            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._mainTransactionApiClient = mainTransactionApiClient;
            this._formDisplayer = formDisplayer;
            this._finTransactionApi = finTransactionApiClient;
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

        FinTransactionDTO _IAETransactionInfo;

        private async void frmMainTransactionInfo_Load(object sender, EventArgs e)
        {
            if (!isInitialized)
            {
                this.Close();
                return;
            }

            var result = await _finTransactionApi.Get(_transactionID, Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || result.Data is null)
            {
                _messageBoxService.DisplayError("فشل تحميل المعاملة !" + result.ErrorMessage);
                this.Close();
                return;
            }

            _IAETransactionInfo = result.Data;

            if (!ctrlMainTransactionInfo1.LoadMainTransaction((MainTransactionDTO)_IAETransactionInfo))
                this.Close();

            this.kgtxtCategoryName.Text = _IAETransactionInfo.CategoryInfo?.CategoryName;
        }

        private void gbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
