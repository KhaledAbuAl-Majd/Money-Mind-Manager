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
using static MoneyMindManager_Business.clsBLLGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.clsIncomeAndExpenseCategoriesClasses;

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

        public frmSelectCategory()
        {
            InitializeComponent();
            this._isIncome = null;
        }

        bool? _isIncome;

        bool _searchByPageNumber = false;
        int _pageNumber = 1;
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

        void _ChangeEnablithForPagingControls(bool value)
        {
            kgtxtPageNumber.Enabled = value;
            kgtxtPageNumber.Visible = value;

            gibtnNextPage.Enabled = value;
            gibtnNextPage.Visible = value;

            gibtnPreviousPage.Enabled = value;
            gibtnPreviousPage.Visible = value;

            lblCurrentPageOfNumberOfPages.Visible = value;

            lblDescriptionOfCurrentPageNumOfRcords.Visible = value;

            lblCurrentPageRecordsCount.Visible = value;
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
                lblTotalRecordsNumber.Text = "0";   
                lblCurrentPageRecordsCount.Text = "0";
                lblCurrentPageOfNumberOfPages.Text = string.Concat("1", "   من   ", "0", "  صفحات");
                _pageNumber = 1;
                gibtnNextPage.Enabled = false;
                gibtnNextPage.Enabled = false;
                return false;
            }

            return true;
        }
        async Task _LoadDataAtDataGridView()
        {
            if (!_CheckValidationChildren())
                return;

            enTextSearchMode textSearchMode = enTextSearchMode.WordsPrefix_Fast;

            if (grbTextSearchMode_WordsPrefix.Checked)
                textSearchMode = enTextSearchMode.WordsPrefix_Fast;
            else if (grbTextSearchMode_SubString.Checked)
                textSearchMode = enTextSearchMode.Substring_Slow;

            clsGetAllCategories result = null;

            string categoryName = kgtxtFilterValue.ValidatedText;
            result = await clsIncomeAndExpenseCategory.GetAllCategoriesForSelectOne(categoryName, _isIncome, textSearchMode, _pageNumber);



            if (result == null)
                return;

            if (result.dtCategories.Rows.Count == 0)
            {
                lblNoRecordsFoundMessage.Visible = true;
                gdgvCategories.DataSource = null;
                _IsHeaderCreated = false;
                kgtxtFilterValue.Focus();
            }
            else
            {
                lblNoRecordsFoundMessage.Visible = false;
                gdgvCategories.DataSource = result.dtCategories;
            }

            lblUserMessage.Visible = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = _pageNumber.ToString();
            _searchByPageNumber = true;

            lblTotalRecordsNumber.Text = result.RecordsCount.ToString();
            lblCurrentPageOfNumberOfPages.Text = string.Concat(_pageNumber, "   من   ", result.NumberOfPages, "  صفحات");
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = true;
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = (result.NumberOfPages < 1) ? 1 : result.NumberOfPages;
            lblCurrentPageRecordsCount.Text = gdgvCategories.Rows.Count.ToString();

            gibtnNextPage.Enabled = (_pageNumber < result.NumberOfPages);
            gibtnPreviousPage.Enabled = (_pageNumber > 1);

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
            lblNoRecordsFoundMessage.Visible = false;
            _IsHeaderCreated = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = "1";
            lblUserMessage.Visible = false;

            await _LoadDataAtDataGridView();

            if (_isIncome == true)
                this.Text = "اختيار فئة واردات";
            else if (_isIncome == false)
                this.Text = "اختيار فئة مصروفات";
            else
                this.Text = "اختيار فئة";

            kgtxtFilterValue.Focus();
        }

        private void kgtxtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _pageNumber = 1;
            SearchAfterTimerFinish.Stop();
            SearchAfterTimerFinish.Start();
        }

        private async void SearchAfterTimerFinish_Tick(object sender, EventArgs e)
        {
            await _LoadDataAtDataGridView();
        }

        private void kgtxt_OnValidationError(object sender, KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.CancelEventArgs.Cancel = true;
            errorProvider1.SetError(kgtxt, clsPL_Utils.GetValidationErrorTypeString(e.validationErrorType, kgtxt));
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
                e.CellStyle.SelectionForeColor = Color.Orange;
            }
        }

        private void frmSelectCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _RaiseOnCategorySelectedEvnet();
                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true;
                return;
            }

            if (gdgvCategories.Focused == false && gdgvCategories.Rows.Count > 0)
            {
                int selectedRow = gdgvCategories.CurrentCell.RowIndex;

                switch (e.KeyCode)
                {
                    case Keys.Up:
                        if (selectedRow > 0)
                        {
                            gdgvCategories.CurrentCell = gdgvCategories.Rows[selectedRow - 1].Cells[0];
                            e.Handled = true;
                        }
                        break;

                    case Keys.Down:
                        if (selectedRow < gdgvCategories.Rows.Count - 1)
                        {
                            gdgvCategories.CurrentCell = gdgvCategories.Rows[selectedRow + 1].Cells[0];
                            e.Handled = true;
                        }
                        break;

                }
            }

        }


        private void gbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void gibtnNextPage_Click(object sender, EventArgs e)
        {
            ++_pageNumber;
            await _LoadDataAtDataGridView();
        }

        private async void gibtnPreviousPage_Click(object sender, EventArgs e)
        {
            --_pageNumber;
            await _LoadDataAtDataGridView();
        }
        private void kgtxtPageNumber_TextChanged(object sender, EventArgs e)
        {
            if (!_searchByPageNumber)
                return;

            if (int.TryParse(kgtxtPageNumber.Text, out int result))
            {
                _pageNumber = result;
            }
            else
                _pageNumber = 0;

            SearchAfterTimerFinish.Stop();
            SearchAfterTimerFinish.Start();
        }
    }
}
