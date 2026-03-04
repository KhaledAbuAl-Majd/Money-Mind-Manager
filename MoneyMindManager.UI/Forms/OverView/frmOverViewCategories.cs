using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.UI.Abstractions;

namespace MoneyMindManager_Presentation.OverView
{
    public partial class frmOverViewCategories : Form
    {
        private IUserSession _userSession;
        private IMessageBoxService _messageBoxService;
        private IReportApiClient _reportApi;
        private IFormDisplayer _formDisplayer;
        private IFinCategoryApiClient _finCategoryApi;
        private IFormateHelper _formateHelper;

        private bool isInitialized = false;
        public frmOverViewCategories(IUserSession userSession, IMessageBoxService messageBoxService, IReportApiClient reportApiClient,
            IFormDisplayer formDisplayer, IFinCategoryApiClient finCategoryApiClient, IFormateHelper formateHelper)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._reportApi = reportApiClient;
            this._formDisplayer = formDisplayer;
            this._finCategoryApi = finCategoryApiClient;
            this._formateHelper = formateHelper;
        }

        public bool Initilaize()
        {
            if (!ctrlCategoryMonthlyFlow1.Initilaize(_userSession, _messageBoxService, _reportApi, _formDisplayer, _finCategoryApi))
                return false;
            if (!ctrlTopCategories_Income.Initilaize(_userSession, _messageBoxService, _reportApi, _formateHelper))
                return false;
            if (!ctrlTopCategories_NetExpense.Initilaize(_userSession, _messageBoxService, _reportApi, _formateHelper))
                return false;

            isInitialized = true;
            return true;
        }

        private async void frmOverViewCategories_Shown(object sender, EventArgs e)
        {
            guna2WinProgressIndicator1.BringToFront();
            guna2WinProgressIndicator1.Start();
            guna2WinProgressIndicator1.Show();
            this.UseWaitCursor = true;

            Task task1 = ctrlTopCategories_Income.LoadData();
            Task task2 = ctrlTopCategories_NetExpense.LoadData();

            await Task.WhenAll(task1, task2);

            this.UseWaitCursor = false;
            guna2WinProgressIndicator1.Stop();
            guna2WinProgressIndicator1.Hide();
        }

        private void frmOverViewCategories_Load(object sender, EventArgs e)
        {
            if (!isInitialized)
            {
                this.Close();
                return;
            }
        }
    }
}
