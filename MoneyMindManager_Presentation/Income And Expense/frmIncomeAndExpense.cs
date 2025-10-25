using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MoneyMindManager_Business;
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

            _voucherType = voucherType;
            InitializeComponent();

            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }
        }
        bool _CheckPermissions()
        {
            string errorMessage = "";
            clsUser.enPermissions permission;

            switch (_voucherType)
            {
                case enVoucherType.Incomes:
                    errorMessage = "ليس لديك صلاحية قائمة مستندات الواردات";
                    permission = clsUser.enPermissions.IncomeVouchersList;
                    break;

                case enVoucherType.Expenses:
                    errorMessage = "ليس لديك صلاحية قائمة مستندات المصروفات";
                    permission = clsUser.enPermissions.ExpenseVouchersList;
                    break;

                case enVoucherType.ExpensesReturn:
                    errorMessage = "ليس لديك صلاحية قائمة مستندات مرتجعات المصروفات";
                    permission = clsUser.enPermissions.ExpenseReturnVouchersList;
                    break;

                default:
                    return false;
            }

            if (clsUser.CheckLogedInUserPermissions(permission))
            {
                prevButton = gbtnVouchers;
                return true;
            }

            if (clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.CategoriesList,
                errorMessage + "/قائمة الفئات"))
            {
                prevButton = gbtnCategories;
                return true;
            }

            return false;
        }

        Guna2Button prevButton;

        enVoucherType _voucherType;

        void ChangeHeaderValue(string txt)
        {
            this.Text = txt;
            lblHeader.Text = txt;
        }

        bool _LoadFormAtPanelContainer(Form frm)
        {
            if (frm == null)
                return false;

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

        private void frmIncomeAndExpense_Load(object sender, EventArgs e)
        {
            prevButton.PerformClick();
        }

        private void gbtnVouchers_Click(object sender, EventArgs e)
        {
            if (_LoadFormAtPanelContainer(new frmVouhcersList(_voucherType)))
            {
                prevButton = gbtnVouchers;

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

            }
        }

        private void gbtnCategories_Click(object sender, EventArgs e)
        {
            bool isIncome = false;
            string headerText = "";

            switch (_voucherType)
            {
                case enVoucherType.Incomes:
                    ciiExepnsesReturn.Visible = false;
                    headerText= "فئات الإيرادات";
                    isIncome = true;
                    break;

                case enVoucherType.Expenses:
                    ciiExepnsesReturn.Visible = false;
                    headerText="فئات المصروفات";
                    isIncome = false;
                    break;
                case enVoucherType.ExpensesReturn:
                    ciiExepnsesReturn.Visible = true;
                    headerText = "فئات المصروفات";
                    isIncome = false;
                    break;

            }

            if (_LoadFormAtPanelContainer(new frmCategoriesList(isIncome)))
            {
                prevButton = gbtnCategories;
                ChangeHeaderValue(headerText);
            }
        }
    }
}
