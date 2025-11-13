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
using Guna.UI2.WinForms;
using MoneyMindManager_Business;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Income_And_Expense;
using MoneyMindManager_Presentation.Income_And_Expense.Categories;
using MoneyMindManager_Presentation.Income_And_Expense.Vouchers;
using MoneyMindManager_Presentation.Login;
using MoneyMindManager_Presentation.OverView;
using MoneyMindManager_Presentation.People;
using MoneyMindManager_Presentation.Users;


namespace MoneyMindManager_Presentation.Main
{
    public partial class frmMain : Form
    {
        public event Action OnCloseProgramm;
        public frmMain()
        {
            InitializeComponent();
        }

        Guna2Button prevButton;
        public void LoadMainFormLabels()
        {
            lblCurrentUserName.Text = clsPL_Global.CurrentUser?.UserName;
        }
        public void AddNewFormAsDialog(Form frm)
        {
            if (frm == null || frm.IsDisposed)
                return;

            frm.ShowDialog(this);
        }
        public void AddNewFormAtContainer(Form frm)
        {
            _LoadFormAtPanelContainer(frm, false);
        }

        bool _LoadFormAtPanelContainer(Form frm, bool clearOldControls)
        {
            if (frm == null)
                return false;

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
            else
            {
                if (prevButton != null)
                {
                    prevButton.Checked = true;
                    prevButton.Focus();
                }

                return false;
            }

            return true;
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            LoadMainFormLabels();

            prevButton = null;
            //if (clsUser.CheckLogedInUserPermissions(clsUser.enPermissions.OverView))
            //{
            //    prevButton = gbtnOverOview;
            //    gbtnOverOview.PerformClick();
            //}
            //else
            //{
            //    prevButton = gbtnAccount;
            //    gbtnAccount.PerformClick();
            //}

            prevButton = gbtnAccount;
            gbtnAccount.PerformClick();
        }

        private void llblCurrentUserInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llblCurrentUserInfo.Enabled = false;
            var frm = new frmUserInfo(Convert.ToInt32(clsPL_Global.CurrentUser?.UserID));
            frm.FormClosed += (x,y) => llblCurrentUserInfo.Enabled = true;
            AddNewFormAtContainer(frm);
        }

        private void llblChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llblChangePassword.Enabled = false;
            var frm = new frmChangePassword(Convert.ToInt32(clsPL_Global.CurrentUser?.UserID));
            frm.FormClosed += (x, y) => llblChangePassword.Enabled = true;
            AddNewFormAtContainer(frm);
        }

        private void gbtnOverOview_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();
            if (_LoadFormAtPanelContainer(new frmOverView(), true))
                prevButton = gbtnOverOview;
        }
        private void gbtnPeople_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();
            if (_LoadFormAtPanelContainer(new frmPeople(), true))
                prevButton = gbtnPeople;
        }

        private void gbtnUsers_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();
            if (_LoadFormAtPanelContainer(new FrmUsers(), true))
                prevButton = gbtnUsers;
        }


        private void gbtnIncome_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();
            if (_LoadFormAtPanelContainer(new frmIncomeAndExpense(clsIncomeAndExpenseVoucher.enVoucherType.Incomes), true))
                prevButton = gbtnIncome;
        }

        private void gbtnExpense_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();
            if (_LoadFormAtPanelContainer(new frmIncomeAndExpense(clsIncomeAndExpenseVoucher.enVoucherType.Expenses), true))
                prevButton = gbtnExpense;
        }

        private void gbtnExpensesReturn_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();
            if (_LoadFormAtPanelContainer(new frmIncomeAndExpense(clsIncomeAndExpenseVoucher.enVoucherType.ExpensesReturn), true))
                prevButton = gbtnExpensesReturn;
        }

        private void gbtnDebts_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();
            if (_LoadFormAtPanelContainer(new frmDebtsList(), true))
                prevButton = gbtnDebts;
        }

        private void gbtnTransactions_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();
            if (_LoadFormAtPanelContainer(new frmMainTransactionsList(), true))
                prevButton = gbtnTransactions;
        }

        private void gbtnAccount_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();
            if (_LoadFormAtPanelContainer(new frmCurrentAccount(), true))
                prevButton = gbtnAccount;
        }

        private void gbtnSettings_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();
            if (_LoadFormAtPanelContainer(new frmSettings(), true))
                prevButton = gbtnSettings;
        }

        private void gbtnAboutProgramm_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();
            if (_LoadFormAtPanelContainer(new frmAboutProgramm(), true))
                prevButton = gbtnAboutProgramm;
        }

        private void gbtnLogout_Click(object sender, EventArgs e)
        {
            clsPL_Global.Logout();
        }


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clsPL_Global.CurrentUser != null)
                OnCloseProgramm?.Invoke();
        }
    }
}
