using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Income_And_Expense.Categories;
using MoneyMindManager_Presentation.Income_And_Expense.Vouchers;
using static MoneyMindManager_Business.clsIncomeAndExpenseVoucher;

namespace MoneyMindManager_Presentation.Income_And_Expense
{
    public partial class frmIncomeAndExpense : Form
    {
        public frmIncomeAndExpense(enVoucherType voucherType)
        {
            if (voucherType == enVoucherType.UnKnown)
            {
                clsGlobalMessageBoxs.ShowErrorMessage("نوع المستند غير معروف !");
                this.Dispose();
                return;
            }

            InitializeComponent();
            _voucherType = voucherType;
        }



        enVoucherType _voucherType;

        void ChangeHeaderValue(string txt)
        {
            this.Text = txt;
            lblHeader.Text = txt;
        }

        void _LoadFormAtPanelContainer(Form frm)
        {
            if (frm == null)
                return;

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;


            if (!frm.IsDisposed)
            {
                gpnlFormContainer.Controls.Clear();

                gpnlFormContainer.Controls.Add(frm);
                frm.Show();
                frm.BringToFront();
            }
        }

        private void frmIncomeAndExpense_Load(object sender, EventArgs e)
        {
            gbtnVouchers.PerformClick();
        }

        private void gbtnVouchers_Click(object sender, EventArgs e)
        {
            ciiExepnsesReturn.Visible = false;

            switch (_voucherType)
            {
                case enVoucherType.Incomes:
                    ChangeHeaderValue("مستندات الإيرادات");
                    break;

                case enVoucherType.Expenses:
                    ChangeHeaderValue("مستندات المصروفات");
                    break;

                case enVoucherType.ExpensesReturn:
                    ChangeHeaderValue("مستندات مرتجعات المصروفات");
                    break;
            }

            _LoadFormAtPanelContainer(new frmVouhcersList(_voucherType));
        }

        private void gbtnCategories_Click(object sender, EventArgs e)
        {
            bool isIncome = false;

            switch (_voucherType)
            {
                case enVoucherType.Incomes:
                    ciiExepnsesReturn.Visible = false;
                    ChangeHeaderValue("فئات الإيرادات");
                    isIncome = true;
                    break;

                case enVoucherType.Expenses:
                    ciiExepnsesReturn.Visible = false;
                    ChangeHeaderValue("فئات المصروفات");
                    isIncome = false;
                    break;
                case enVoucherType.ExpensesReturn:
                    ciiExepnsesReturn.Visible = true;
                    ChangeHeaderValue("فئات المصروفات");
                    isIncome = false;
                    break;

            }

            _LoadFormAtPanelContainer(new frmCategoriesList(isIncome));
        }
    }
}
