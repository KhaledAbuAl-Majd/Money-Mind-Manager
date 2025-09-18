using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KhaledControlLibrary1;
using MoneyMindManager_Business;
using MoneyMindManager_Presentation.Global;
using MoneyMindManagerGlobal;

namespace MoneyMindManager_Presentation.Income_And_Expense.Categories
{
    public partial class frmSelectCategory : Form
    {
        public class SelecteCategoryEventArgs : EventArgs
        {
            public int CategoryID { get; }
            public string CategoryName { get; }

            public SelecteCategoryEventArgs(int categoryID,string categoryName)
            {
                this.CategoryID = categoryID;
                this.CategoryName = categoryName;
            }
        }

        public event EventHandler<SelecteCategoryEventArgs> OnCategorySelected;
        public frmSelectCategory(bool isIncome)
        {
            InitializeComponent();
            this._isIncome = isIncome;
        }


        bool _isIncome;
        bool _IsHeaderCreated = false;
        void _RaiseOnCategorySelectedEvnet()
        {
            if(gdgvCategories.SelectedRows.Count > 0)
            {
                int categoryID = Convert.ToInt32(gdgvCategories.SelectedRows[0].Cells[0].Value);
                string categoryName = gdgvCategories.SelectedRows[0].Cells[1].Value as string;

                OnCategorySelected?.Invoke(this, new SelecteCategoryEventArgs(categoryID, categoryName));
                this.Close();
            }
            else
            {
                lblUserMessage.Text = "من فضلك اختر صف أولا .";
                lblUserMessage.Visible = true;
            }
        }


        bool _CheckValidationChildren()
        {
            if (!ValidateChildren())
            {
                gdgvCategories.DataSource = null;
                _IsHeaderCreated = false;
                lblNoRecordsFoundMessage.Visible = true;
                lblUserMessage.Text = "تم العثور على حقول غير صالحة. ضع المؤشر على العلامات الحمراء لعرض سبب الخطأ.";
                lblUserMessage.Visible = true;
                //clsGlobal_Presentation.ShowMessage("تم العثور على حقول غير صالحة. ضع المؤشر على العلامات الحمراء لعرض سبب الخطأ.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTotalRecordsNumber.Text = "0";
                return false;
            }

            return true;
        }
        async Task _LoadDataAtDataGridView()
        {
            if (!_CheckValidationChildren())
                return;

            //_pageNumber = Convert.ToInt16(kgtxtPageNumber.ValidatedText);

            DataTable dtCategories = null;

            int currentUserID = Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID);

            if (string.IsNullOrEmpty(kgtxtFilterValue.ValidatedText))
            {
                dtCategories = await clsIncomeAndExpenseCategory.GetAllCategoriesForSearch(_isIncome, currentUserID);
            }
            else 
            {
                string categoryName = kgtxtFilterValue.ValidatedText;
                dtCategories = await clsIncomeAndExpenseCategory.GetAllCategoriesForSearch(categoryName, _isIncome, currentUserID);
            }


            if (dtCategories == null)
                return;

            if (dtCategories.Rows.Count == 0)
            {
                lblNoRecordsFoundMessage.Visible = true;
                //lblUserMessage.Visible = true;
                gdgvCategories.DataSource = null;
                _IsHeaderCreated = false;
            }
            else
            {
                lblNoRecordsFoundMessage.Visible = false;
                gdgvCategories.DataSource =dtCategories;
            }

            lblUserMessage.Visible = false;

            lblTotalRecordsNumber.Text = dtCategories.Rows.Count.ToString();
            //

            if (!_IsHeaderCreated && gdgvCategories.Rows.Count > 0)
            {
                gdgvCategories.Columns["CategoryID"].HeaderText = "معرف الفئة";
                gdgvCategories.Columns["CategoryID"].Width = 120;

                gdgvCategories.Columns["CategoryName"].HeaderText = "اسم الفئة";
                gdgvCategories.Columns["CategoryName"].Width = 280;

                gdgvCategories.Columns["ParentCategoryName"].HeaderText = "الفئة التابعة لها";
                gdgvCategories.Columns["ParentCategoryName"].Width = 260;

                gdgvCategories.Columns["MainCategoryName"].HeaderText = "الفئة الرئيسية التابعة لها";
                gdgvCategories.Columns["MainCategoryName"].Width = 260;

                _IsHeaderCreated = true;
            }
        }

        private async void frmSelectCategory_Load(object sender, EventArgs e)
        {
            _IsHeaderCreated = false;
            lblNoRecordsFoundMessage.Visible = false;
            lblUserMessage.Visible = false;

            await _LoadDataAtDataGridView();

            kgtxtFilterValue.Focus();
        }

        private async void kgtxtFilterValue_TextChanged(object sender, EventArgs e)
        {
           await _LoadDataAtDataGridView();
        }

        private void kgtxt_OnValidationError(object sender, KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.CancelEventArgs.Cancel = true;
            errorProvider1.SetError(kgtxt, clsUtils.GetValidationErrorTypeString(e.validationErrorType, kgtxt));
        }

        private void kgtxt_OnValidationSuccess(object arg1, CancelEventArgs arg2)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)arg1;
            arg2.Cancel = false;
            errorProvider1.SetError(kgtxt, null);
        }

        
        private void gdgvCategories_DoubleClick(object sender, EventArgs e)
        {
            _RaiseOnCategorySelectedEvnet();
        }

        private void gdgvCategories_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value)
            {
                //e.CellStyle.BackColor = Color.LightYellow; // خلفية
                e.CellStyle.ForeColor = Color.Red;
            }
        }

        private void frmSelectCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                _RaiseOnCategorySelectedEvnet();
        }

    }
}
