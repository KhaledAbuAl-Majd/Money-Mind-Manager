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
using MoneyMindManager_Presentation.Income_And_Expense.Vouchers;
using MoneyMindManagerGlobal;
using static MoneyMindManager_Business.clsIncomeAndExpenseVoucher;

namespace MoneyMindManager_Presentation.Income_And_Expense.Categories
{
    public partial class frmCategoriesList : Form
    {
        public frmCategoriesList(bool isIncome)
        {
            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }

            InitializeComponent();
            this._IsIncome = isIncome;
        }

        bool _CheckPermissions()
        {
            return clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.CategoriesList,
                "ليس لديك صلاحية قائمة الفئات.");
        }

        bool _IsIncome;
        enum enFilterBy { All, CategoryID, CategoryName,ParentCategoryName,MainCategoryName };

        enFilterBy _filterBy = enFilterBy.All;

        bool _IsHeaderCreated = false;
        bool _searchByPageNumber = false;

        short _pageNumber = 1;

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
                lblCurrentPageRecordsCount.Text = "0";
                lblTotalRecordsNumber.Text = "0";
                lblCurrentPageOfNumberOfPages.Text = string.Concat("1", "   من   ", "0", "  صفحات");
                _pageNumber = 1;
                gibtnNextPage.Enabled = false;
                gibtnNextPage.Enabled = false;
                return false;
            }

            return true;
        }

        async Task _LoadDataAtDataGridView(enFilterBy filterBy)
        {
            SearchAfterTimerFinish.Stop();

            if (!_CheckValidationChildren())
                return;

            //_pageNumber = Convert.ToInt16(kgtxtPageNumber.ValidatedText);

            clsDataColumns.clsIncomeAndExpenseCategoriesClasses.clsGetAllCategories result = null;

            bool? isActive = null;

            if (gcbIsActive.Text == "الكل")
                isActive = null;
            else if (gcbIsActive.Text == "فعال")
                isActive = true;
            else if (gcbIsActive.Text == "موقوف")
                isActive = false;

            bool includeMainCategories = gchkIncludeMainCategory.Checked;
            bool includeSubCategories = gchkIncludeSubCategories.Checked;

            if (filterBy == enFilterBy.All || string.IsNullOrEmpty(kgtxtFilterValue.ValidatedText))
            {
                result = await clsIncomeAndExpenseCategory.GetAllCategories(_IsIncome, isActive, includeMainCategories,
                    includeSubCategories, _pageNumber);
            }
            else if (filterBy == enFilterBy.CategoryID)
            {
                int categoryID = Convert.ToInt32(kgtxtFilterValue.ValidatedText);
                result = await clsIncomeAndExpenseCategory.GetAllCategoriesByCategoryID(categoryID, _IsIncome, isActive,
                    includeMainCategories, includeSubCategories, _pageNumber);
            }
            else if (filterBy == enFilterBy.CategoryName)
            {
                string categoryName = kgtxtFilterValue.ValidatedText;
                result = await clsIncomeAndExpenseCategory.GetAllCategoriesByCategoryName(categoryName, _IsIncome, isActive,
                     includeMainCategories, includeSubCategories, _pageNumber);
            }
            else if (filterBy == enFilterBy.ParentCategoryName)
            {
                string parentCategoryName = kgtxtFilterValue.ValidatedText;
                result = await clsIncomeAndExpenseCategory.GetAllCategoriesByParentCategoryName(parentCategoryName, _IsIncome, isActive,
                     includeMainCategories, includeSubCategories, _pageNumber);
            }
            else if (filterBy == enFilterBy.MainCategoryName)
            {
                string mainCategoryName = kgtxtFilterValue.ValidatedText;
                result = await clsIncomeAndExpenseCategory.GetAllCategoriesByMainCategoryName(mainCategoryName, _IsIncome, isActive,
                     includeMainCategories, includeSubCategories, _pageNumber);
            }
            else
                return;

            if (result == null)
                return;

            if (result.dtCategories.Rows.Count == 0)
            {
                lblNoRecordsFoundMessage.Visible = true;
                //lblUserMessage.Visible = true;
                gdgvCategories.DataSource = null;
                _IsHeaderCreated = false;
                _pageNumber = 1;
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

            //

            if (!_IsHeaderCreated && gdgvCategories.Rows.Count > 0)
            {
                gdgvCategories.Columns["CategoryID"].HeaderText = "معرف الفئة";
                gdgvCategories.Columns["CategoryID"].Width = 120;

                gdgvCategories.Columns["CategoryName"].HeaderText = "اسم الفئة";
                gdgvCategories.Columns["CategoryName"].Width = 270;

                gdgvCategories.Columns["ParentCategoryName"].HeaderText = "الفئة التابعة لها";
                gdgvCategories.Columns["ParentCategoryName"].Width = 250;

                gdgvCategories.Columns["MainCategoryName"].HeaderText = "الفئة الرئيسية التابعة لها";
                gdgvCategories.Columns["MainCategoryName"].Width = 250;

                gdgvCategories.Columns["CreatedDate"].HeaderText = "تاريخ الإنشاء";
                gdgvCategories.Columns["CreatedDate"].Width = 220;
                gdgvCategories.Columns["CreatedDate"].DefaultCellStyle.Format = "hh:mm:ss tt dd-MM-yyyy";

                gdgvCategories.Columns["IsActive"].HeaderText = "الفعالية";
                gdgvCategories.Columns["IsActive"].Width = 70;

                _IsHeaderCreated = true;

            }
        }

        void _AddNewCategory()
        {
            frmAddUpdateCategory frm = new frmAddUpdateCategory(_IsIncome);
            frm.OnCloseAndSaved += x => _RefreshFilter();
            clsGlobal_UI.MainForm.AddNewFormAtContainer(frm);
        }

        void _UpdateCategory()
        {
            if (gdgvCategories.SelectedRows.Count < 1)
                return;

            int categoryID = Convert.ToInt32(gdgvCategories.SelectedRows[0].Cells[0].Value);

            frmAddUpdateCategory frm = new frmAddUpdateCategory(categoryID);
            frm.OnCloseAndSaved += x => _RefreshFilter();
            clsGlobal_UI.MainForm.AddNewFormAtContainer(frm);
        }

        async void _RefreshFilter()
        {
            _pageNumber = 1;

            if (gcbFilterBy.SelectedIndex == 0)
                await _LoadDataAtDataGridView(enFilterBy.All);
            else
                gcbFilterBy.SelectedIndex = 0;
        }

        void _SetReadOnlyAtTextBox(KhaledGuna2TextBox kgtxt)
        {
            kgtxt.ReadOnly = true;
            kgtxt.FillColor = SystemColors.ControlLight;
        }

        void _CancelReadOnlyAtTextBox(KhaledGuna2TextBox kgtxt)
        {
            kgtxt.ReadOnly = false;
            kgtxt.FillColor = Color.White;
        }

        private void frmCategoriesList_Load(object sender, EventArgs e)
        {
            _IsHeaderCreated = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = "1";
            lblNoRecordsFoundMessage.Visible = false;
            lblUserMessage.Visible = false;
            gcbFilterBy.SelectedIndex = 0;
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

        private async void gibtnNextPage_Click(object sender, EventArgs e)
        {
            ++_pageNumber;
            await _LoadDataAtDataGridView(_filterBy);
        }

        private async void gibtnPreviousPage_Click(object sender, EventArgs e)
        {
            --_pageNumber;
            await _LoadDataAtDataGridView(_filterBy);
        }

        private async void gcbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pageNumber = 1;

            _searchByPageNumber = false;
            kgtxtFilterValue.Text = "";
            _searchByPageNumber = true;

            if (gcbFilterBy.Text == "بدون")
            {
                /*kgtxtFilterValue.Visible = false*/;
                _SetReadOnlyAtTextBox(kgtxtFilterValue);
                _filterBy = enFilterBy.All;
                await _LoadDataAtDataGridView(_filterBy);
                return;
            }


            //kgtxtFilterValue.Visible = true;
            _CancelReadOnlyAtTextBox(kgtxtFilterValue);
            kgtxtFilterValue.IsRequired = false;
            kgtxtFilterValue.TrimStart = false;

            if (gcbFilterBy.Text == "معرف الفئة")
            {
                _filterBy = enFilterBy.CategoryID;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
                kgtxtFilterValue.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
                kgtxtFilterValue.AllowWhiteSpace = false;
                kgtxtFilterValue.TrimEnd = true;
                kgtxtFilterValue.NumberProperties.IntegerNumberProperties.AllowNegative = false;
                kgtxtFilterValue.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            }
            else if (gcbFilterBy.Text == "اسم الفئة")
            {
                _filterBy = enFilterBy.CategoryName;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
                kgtxtFilterValue.AllowWhiteSpace = true;
                kgtxtFilterValue.TrimEnd = false;
            }
            else if (gcbFilterBy.Text == "الفئة التابعة لها")
            {
                _filterBy = enFilterBy.ParentCategoryName;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
                kgtxtFilterValue.AllowWhiteSpace = true;
                kgtxtFilterValue.TrimEnd = false;
            }
            else if (gcbFilterBy.Text == "الفئة الرئيسية")
            {
                _filterBy = enFilterBy.MainCategoryName;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
                kgtxtFilterValue.AllowWhiteSpace = true;
                kgtxtFilterValue.TrimEnd = false;
            }

            await _LoadDataAtDataGridView(_filterBy);
        }

        private void kgtxtFilterValue_TextChanged(object sender, EventArgs e)
        {
            SearchAfterTimerFinish.Stop();
            SearchAfterTimerFinish.Start();
        }

        private async void SearchAfterTimerFinish_Tick(object sender, EventArgs e)
        {
            await _LoadDataAtDataGridView(_filterBy);
        }

        private void kgtxtPageNumber_TextChanged(object sender, EventArgs e)
        {
            if (!_searchByPageNumber || !_CheckValidationChildren())
                return;

            _pageNumber = Convert.ToInt16(kgtxtPageNumber.ValidatedText);

            //await _LoadDataAtDataGridView();

            SearchAfterTimerFinish.Stop();
            SearchAfterTimerFinish.Start();
        }

        private async void kgtxtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchAfterTimerFinish.Stop();
                await _LoadDataAtDataGridView(_filterBy);
            }
        }

        private void gbtnAddCategory_Click(object sender, EventArgs e)
        {
            _AddNewCategory();
        }

        private async void gcbFilterByIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pageNumber = 1;
            await _LoadDataAtDataGridView(_filterBy);
        }
        private async void gchkIncludeCategory_CheckedChanged(object sender, EventArgs e)
        {
            _pageNumber = 1;
            await _LoadDataAtDataGridView(_filterBy);
        }

        private async void gibtnRefreshData_Click(object sender, EventArgs e)
        {
            await _LoadDataAtDataGridView(_filterBy);
        }

        private void gtsmAddVoucher_Click(object sender, EventArgs e)
        {
            _AddNewCategory();
        }

        private void gtsmEdit_Click(object sender, EventArgs e)
        {
            _UpdateCategory();
        }

        private void gdgvCategories_DoubleClick(object sender, EventArgs e)
        {
            _UpdateCategory();
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
        private void gtsmShowCategoryMonthlyFlow_Click(object sender, EventArgs e)
        {
            int categoryID = Convert.ToInt32(gdgvCategories.SelectedRows[0].Cells[0].Value);

            var frm = new frmCategoryMonthlyFlow(categoryID);
            clsGlobal_UI.MainForm.AddNewFormAtContainer(frm);
        }
    }
}
