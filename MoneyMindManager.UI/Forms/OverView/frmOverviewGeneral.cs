using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.UI.Abstractions;

namespace MoneyMindManager_Presentation.OverView
{
    public partial class frmOverviewGeneral : Form
    {
        private readonly IUserSession _userSession;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IReportApiClient _reportApi;

        private bool isInitialized = false;
        public frmOverviewGeneral(IUserSession userSession, IMessageBoxService messageBoxService, IReportApiClient reportApiClient)
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
            if (!ctrlTest1.Initilaize(_userSession, _messageBoxService, _reportApi))
                return false;

            isInitialized = true;
            return true;
        }

        async Task _LoadKPIS()
        {
            var result = await _reportApi.GetMainKPIS(Convert.ToInt16(_userSession.CurrentUser.AccountID));

            if (!result.IsSuccess)
            {
                _messageBoxService.DisplayError(result.ErrorMessage);
                this.Close();
                return;
            }

            var KPIS = result.Data;

            if (KPIS == null)
                this.Close();

            klblBalance.Text = (_userSession.IsHasPermissions(enPermissions.AccountBalance)) ? KPIS.Balance.ToString() : "************";
            klblTotalReceivables.Text = KPIS.TotalReceivables.ToString();
            klblTotalPayables.Text = KPIS.TotalPayables.ToString();
            klblNext30DayDebtsDue.Text = KPIS.Next30DayDebtsDue.ToString();
            klblTodayPerformance.Text = KPIS.DayPerformance.ToString();
            klblMonthPerformace.Text = KPIS.MonthPerformance.ToString();
            klblYearPerformance.Text = KPIS.YearPerformance.ToString();
            klblAvgNetProfitLast6Months.Text = KPIS.AvgNetProfitLast6Months.ToString();
        }

        private async void frmOverviewGeneral_Shown(object sender, EventArgs e)
        {
            guna2WinProgressIndicator1.BringToFront();
            guna2WinProgressIndicator1.Start();
            guna2WinProgressIndicator1.Show();
            this.UseWaitCursor = true;

            Task task1 = _LoadKPIS();
            Task task2 = ctrlTest1.LoadData();

            await Task.WhenAll(task1, task2);

            this.UseWaitCursor = false;
            guna2WinProgressIndicator1.Stop();
            guna2WinProgressIndicator1.Hide();
        }

        private void frmOverviewGeneral_Load(object sender, EventArgs e)
        {
            if (!isInitialized)
            {
                this.Close();
                return;
            }
        }
    }
}
