using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyMindManager_Business;
using MoneyMindManager_Presentation.Income_And_Expense;
using MoneyMindManager_Presentation.Income_And_Expense.Categories;
using MoneyMindManager_Presentation.Income_And_Expense.Vouchers;
using MoneyMindManager_Presentation.Login;
using MoneyMindManager_Presentation.OverView;
using MoneyMindManager_Presentation.People;
using MoneyMindManager_Presentation.Users;
using static System.Net.Mime.MediaTypeNames;

namespace MoneyMindManager_Presentation.Main
{
    public partial class frmMain : Form
    {
        public event Action OnCloseProgramm;
        public frmMain()
        {
            InitializeComponent();
        }

        public void LoadMainFormLabels()
        {
            lblCurrentUserName.Text = clsGlobal_UI.CurrentUser?.UserName;
        }
        public void AddNewFormAsDialog(Form frm)
        {
            if (frm == null || frm.IsDisposed)
                return;

            //frm.Move += (sender, e) =>
            //{
            //    if (frm.Left < this.Left) frm.Left = this.Left;
            //    if (frm.Top < this.Top) frm.Top = this.Top;
            //    if (frm.Right > this.Right) frm.Left = this.Right - frm.Width;
            //    if (frm.Bottom > this.Bottom) frm.Top = this.Bottom - frm.Height;
            //};

            frm.ShowDialog(this);
        }
        public void AddNewFormAtContainer(Form frm)
        {
            _LoadFormAtPanelContainer(frm, false);
        }

        void _LoadFormAtPanelContainer(Form frm,bool clearOldControls)
        {
            if (frm == null)
                return;

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            if (!frm.IsDisposed)
            {
                if (clearOldControls)
                {
                    gpnlFormContainer.Controls.Clear();
                }
                gpnlFormContainer.Controls.Add(frm);

                frm.Show();
                frm.BringToFront();
            }
        }

        private void gbtnOverOview_Click(object sender, EventArgs e)
        {
            _LoadFormAtPanelContainer(new frmOverView(), true);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            this.Enabled = false;

            LoadMainFormLabels();

            if (clsUser.CheckLogedInUserPermissions(clsUser.enPermissions.OverView))
                gbtnOverOview.PerformClick();
            else
                gbtnAccount.PerformClick();

                this.Enabled = true;
            this.UseWaitCursor = false;
            this.Cursor = Cursors.Default;
        }

        private void gbtnPeople_Click(object sender, EventArgs e)
        {
            _LoadFormAtPanelContainer(new frmPeople(),true);
        }

        private void gbtnUsers_Click(object sender, EventArgs e)
        {
            _LoadFormAtPanelContainer(new FrmUsers(), true);
        }


        private void gbtnIncome_Click(object sender, EventArgs e)
        {
            _LoadFormAtPanelContainer(new frmIncomeAndExpense(clsIncomeAndExpenseVoucher.enVoucherType.Incomes),true);
        }

        private void gbtnExpense_Click(object sender, EventArgs e)
        {
            _LoadFormAtPanelContainer(new frmIncomeAndExpense(clsIncomeAndExpenseVoucher.enVoucherType.Expenses), true);
        }

        private void gbtnExpensesReturn_Click(object sender, EventArgs e)
        {
            _LoadFormAtPanelContainer(new frmIncomeAndExpense(clsIncomeAndExpenseVoucher.enVoucherType.ExpensesReturn), true);
        }

        private void gbtnDebts_Click(object sender, EventArgs e)
        {
            _LoadFormAtPanelContainer(new frmDebtsList(), true);
        }
        private void gbtnTransactions_Click(object sender, EventArgs e)
        {
            _LoadFormAtPanelContainer(new frmMainTransactionsList(), true);
        }
        private void gbtnLogout_Click(object sender, EventArgs e)
        {
            clsGlobal_UI.Logout();
        }

        private void gcbClose_Click(object sender, EventArgs e)
        {
            OnCloseProgramm?.Invoke();
        }

        private void gbtnSettings_Click(object sender, EventArgs e)
        {

        }

        private void gbtnAccount_Click(object sender, EventArgs e)
        {
            _LoadFormAtPanelContainer(new frmCurrentAccount(), true);
        }

        private void llblCurrentUserInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new frmUserInfo(Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID));
            AddNewFormAtContainer(frm);
        }

        private void llblChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new frmChangePassword(Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID));
            AddNewFormAtContainer(frm);
        }
    }
}
