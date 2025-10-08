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
using MoneyMindManager_Presentation.People;
using static System.Net.Mime.MediaTypeNames;

namespace MoneyMindManager_Presentation.Main
{
    public partial class frmMain : Form
    {
        public event Action OnCloseProgramm;

        int _userID;
        public frmMain(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        public void AddNewFormAsDialog(Form frm)
        {
            if (frm == null)
                return;

            frm.Move += (sender, e) =>
            {
                if (frm.Left < this.Left) frm.Left = this.Left;
                if (frm.Top < this.Top) frm.Top = this.Top;
                if (frm.Right > this.Right) frm.Left = this.Right - frm.Width;
                if (frm.Bottom > this.Bottom) frm.Top = this.Bottom - frm.Height;
            };

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

            if (clearOldControls)
            {
                gpnlFormContainer.Controls.Clear();
                //clsGlobal_Presentation.RefreshCurrentUser();
            }

            gpnlFormContainer.Controls.Add(frm);

            if (!frm.IsDisposed)
            {
                frm.Show();
                frm.BringToFront();
            }
        }

        private void gbtnOverOview_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("kk");
            //_LoadFormAtPanelContainer(new frmAddUpdateVoucher(1), true);
            //_LoadFormAtPanelContainer(new frmVouhcersList(clsIncomeAndExpenseVoucher.enVoucherType.UnKnown), true);
            //_LoadFormAtPanelContainer(new frmCategoriesList(false), true);

            //new frmSelectCategory(false).ShowDialog();
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            this.Enabled = false;

            await clsGlobal_UI.Login(_userID, this);

            //clsUser user = await clsUser.FindUserByUserID(_userID,_userID);

            //if (user == null)
            //{
            //    this.Close();
            //    return;
            //}

            this.Enabled = true;
            this.UseWaitCursor = false;
            this.Cursor = Cursors.Default;

            //clsGlobal_Presentation.CurrentUser = user;
            //clsGlobal_Presentation.MainForm = this;

            gbtnOverOview.PerformClick();

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

        }
        private void gbtnLogout_Click(object sender, EventArgs e)
        {
            clsGlobal_UI.Logout();
        }

        private void gcbClose_Click(object sender, EventArgs e)
        {
            OnCloseProgramm?.Invoke();
        }
    }
}
