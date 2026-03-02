using System;
using System.Windows.Forms;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.UI.Abstractions;

namespace MoneyMindManager_Presentation.Income_And_Expense.Categories
{
    public partial class frmCategoryMonthlyFlow : Form
    {
        private IUserSession _userSession;
        private IMessageBoxService _messageBoxService;
        private IReportApiClient _reportApi;
        private IFormDisplayer _formDisplayer;
        private IFinCategoryApiClient _finCategoryApi;
        private bool isInitialized = false;
        public frmCategoryMonthlyFlow(IUserSession userSession, IMessageBoxService messageBoxService, IReportApiClient reportApiClient,
            IFormDisplayer formDisplayer, IFinCategoryApiClient finCategoryApiClient)
        {
            InitializeComponent();
            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._reportApi = reportApiClient;
            this._formDisplayer = formDisplayer;
            this._finCategoryApi = finCategoryApiClient;
        }


        public bool Initialize(int categoryID)
        {
            if (!ctrlCategoryMonthlyFlow1.Initilaize(_userSession, _messageBoxService, _reportApi, _formDisplayer, _finCategoryApi))
                return false;

            this.CategoryID = categoryID;
            this.isInitialized = true;
            return true;
        }

        int CategoryID;

        private async void frmCategoryMonthlyFlow_Load(object sender, EventArgs e)
        {
            if (!isInitialized)
            {
                this.Close();
                return;
            }

            guna2WinProgressIndicator1.BringToFront();
            guna2WinProgressIndicator1.Start();
            guna2WinProgressIndicator1.Show();
            this.UseWaitCursor = true;

            if (!await ctrlCategoryMonthlyFlow1.LoadData(CategoryID))
                this.Close();

            this.UseWaitCursor = false;
            guna2WinProgressIndicator1.Stop();
            guna2WinProgressIndicator1.Hide();
        }

        private void gbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
