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

        private async void frmOverViewDebts_Load(object sender, EventArgs e)
        {
            guna2WinProgressIndicator1.BringToFront();
            guna2WinProgressIndicator1.Start();
            guna2WinProgressIndicator1.Show();
            this.UseWaitCursor = true;

            await ctlDebtsRepaymentSchedule2.LoadData();
            await ctrlTopDebtorsRanking2.LoadData();
            await ctrlTopPersonDebtsSumRanking1.LoadData();
            await ctrlDebtsMonthlyFlow1.LoadData();

            this.UseWaitCursor = false;
            guna2WinProgressIndicator1.Stop();
            guna2WinProgressIndicator1.Hide();
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
