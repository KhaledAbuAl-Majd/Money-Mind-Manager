using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyMindManager_Presentation.OverView
{
    public partial class frmOverViewDebts : Form
    {
        public frmOverViewDebts()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }


        private async void frmOverViewDebts_Shown(object sender, EventArgs e)
        {
            guna2WinProgressIndicator1.BringToFront();
            guna2WinProgressIndicator1.Start();
            guna2WinProgressIndicator1.Show();
            this.UseWaitCursor = true;

            Task task1 = ctlDebtsRepaymentSchedule2.LoadData();
            Task task2 = ctrlTopDebtorsRanking2.LoadData();
            Task task3 = ctrlTopPersonDebtsSumRanking1.LoadData();
            Task task4 = ctrlDebtsMonthlyFlow1.LoadData();

            await Task.WhenAll(task1, task2, task3, task4);

            this.UseWaitCursor = false;
            guna2WinProgressIndicator1.Stop();
            guna2WinProgressIndicator1.Hide();
        }
    }
}
