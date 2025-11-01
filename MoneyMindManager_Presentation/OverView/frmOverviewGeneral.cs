using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyMindManager_Business;
using static MoneyMindManagerGlobal.clsDataColumns.clsReportClassess;

namespace MoneyMindManager_Presentation.OverView
{
    public partial class frmOverviewGeneral : Form
    {
        public frmOverviewGeneral()
        {
            InitializeComponent();
        }

        async Task _LoadKPIS()
        {
            var KPIS = await clsReport.GetMainKPIS(Convert.ToInt16(clsPL_Global.CurrentUser?.AccountID));

            if (KPIS == null)
                this.Close();

            klblBalance.Text = (clsUser.CheckLogedInUserPermissions(clsUser.enPermissions.AccountBalance)) ?
                KPIS.Balance.ToString() : "************";
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

            Task task1 =  _LoadKPIS();
            Task task2 = ctrlTest1.LoadData();

           await Task.WhenAll(task1, task2);

            this.UseWaitCursor = false;
            guna2WinProgressIndicator1.Stop();
            guna2WinProgressIndicator1.Hide();
        }
    }
}
