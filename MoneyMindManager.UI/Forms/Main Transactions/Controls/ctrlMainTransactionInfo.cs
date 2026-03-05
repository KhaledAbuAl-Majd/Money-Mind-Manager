using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Shared.DTOs.MainTransaction;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.Users;

namespace MoneyMindManager_Presentation.Transactions.Controls
{
    public partial class ctrlMainTransactionInfo : UserControl
    {
        private IUserSession _userSession;
        private IMessageBoxService _messageBoxService;
        private IMainTransactionApiClient _mainTransactionApiClient;
        private IFormDisplayer _formDisplayer;

        private bool isInitialized = false;
        public ctrlMainTransactionInfo()
        {
            InitializeComponent();
        }

        public bool Initialize(IUserSession userSession, IMessageBoxService messageBoxService, IMainTransactionApiClient mainTransactionApiClient
          , IFormDisplayer formDisplayer)
        {
            if (userSession is null || messageBoxService is null || mainTransactionApiClient is null || formDisplayer is null)
                return false;

            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._mainTransactionApiClient = mainTransactionApiClient;
            this._formDisplayer = formDisplayer;
            isInitialized = true;
            return true;
        }

        public MainTransactionDTO MainTransaction { get; private set; }
        public async Task<bool> LoadMainTransaction(int transactionID)
        {
            if (!isInitialized)
                return false;

            var result = await _mainTransactionApiClient.Get(transactionID, Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || result.Data is null)
            {
                _messageBoxService.DisplayError(result.ErrorMessage);
                ResetControls();
                return false;
            }

            MainTransaction = result.Data;

            if (MainTransaction == null)
            {
                ResetControls();
                return false;
            }

            _ShowData();

            return true;
        }

        public bool LoadMainTransaction(MainTransactionDTO _mainTransaction)
        {
            if (!isInitialized)
                return false;

            MainTransaction = _mainTransaction;

            if (MainTransaction == null)
            {
                ResetControls();
                return false;
            }

            _ShowData();

            return true;
        }

        void _ShowData()
        {
            kgtxtTransactionID.Text = MainTransaction?.MainTransactionID?.ToString();
            kgtxtAmount.RefreshNumber_DateTimeFormattedText(MainTransaction?.Amount.ToString());
            kgtxtTransactionDate.RefreshNumber_DateTimeFormattedText(MainTransaction?.TransactionDate.ToString());
            kgtxtCreatedDate.RefreshNumber_DateTimeFormattedText(MainTransaction?.CreatedDate.ToString());
            kgtxtCreatedByUserName.RefreshNumber_DateTimeFormattedText(MainTransaction?.CreatedByUserName.ToString());
            kgtxtTransactionType.RefreshNumber_DateTimeFormattedText(MainTransaction?.TransactionTypeName.ToString());
            kgtxtPurpose.Text = MainTransaction?.Purpose?.ToString();
        }

        /// <summary>
        /// Reset Controls With Start Value
        /// </summary>
        public void ResetControls()
        {
            MainTransaction = null;

            kgtxtTransactionID.Text = null;
            kgtxtAmount.Text = null;
            kgtxtTransactionDate.Text = null;
            kgtxtCreatedDate.Text = null;
            kgtxtCreatedByUserName.Text = null;
            kgtxtTransactionType.Text = null;
            kgtxtPurpose.Text = null;
        }

        private void kgtxtCreatedByUserName_IconRightClick(object sender, EventArgs e)
        {
            if (MainTransaction == null)
                return;

            _formDisplayer.OpenAtContainer<frmUserInfo>((frm) =>
            {
                return frm.Initialize(Convert.ToInt32(MainTransaction?.CreatedByUserID));
            });
        }
    }
}
