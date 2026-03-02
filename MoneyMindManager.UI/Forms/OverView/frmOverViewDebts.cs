using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.UI.Abstractions;

namespace MoneyMindManager_Presentation.OverView
{
    public partial class frmOverViewDebts : Form
    {
        private readonly IUserSession _userSession;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IReportApiClient _reportApi;

        private bool isInitialized = false;
        public frmOverViewDebts(IUserSession userSession, IMessageBoxService messageBoxService, IReportApiClient reportApiClient)
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._reportApi = reportApiClient;
        }

        public bool Initilaize()
        {
            if (!ctrlDebtsMonthlyFlow1.Initilaize(_userSession, _messageBoxService, _reportApi))
                return false;
            if (!ctrDebtsRepaymentSchedule2.Initilaize(_userSession, _messageBoxService, _reportApi))
                return false;
            if (!ctrlTopDebtorsRanking2.Initilaize(_userSession, _messageBoxService, _reportApi))
                return false;
            if (!ctrlTopPersonDebtsSumRanking1.Initilaize(_userSession, _messageBoxService, _reportApi))
                return false;

            isInitialized = true;
            return true;
        }

        private async void frmOverViewDebts_Shown(object sender, EventArgs e)
        {
            guna2WinProgressIndicator1.BringToFront();
            guna2WinProgressIndicator1.Start();
            guna2WinProgressIndicator1.Show();
            this.UseWaitCursor = true;

            Task task1 = ctrDebtsRepaymentSchedule2.LoadData();
            Task task2 = ctrlTopDebtorsRanking2.LoadData();
            Task task3 = ctrlTopPersonDebtsSumRanking1.LoadData();
            Task task4 = ctrlDebtsMonthlyFlow1.LoadData();

            await Task.WhenAll(task1, task2, task3, task4);

            this.UseWaitCursor = false;
            guna2WinProgressIndicator1.Stop();
            guna2WinProgressIndicator1.Hide();
        }

        private void frmOverViewDebts_Load(object sender, EventArgs e)
        {
            if (!isInitialized)
            {
                this.Close();
                return;
            }
        }
    }
}
