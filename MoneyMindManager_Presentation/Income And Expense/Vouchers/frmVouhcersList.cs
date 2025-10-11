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
using MoneyMindManager_Presentation.People;
using MoneyMindManagerGlobal;
using static MoneyMindManager_Business.clsIncomeAndExpenseVoucher;

namespace MoneyMindManager_Presentation.Income_And_Expense.Vouchers
{
    public partial class frmVouhcersList : Form
    {
        public frmVouhcersList(enVoucherType voucherType)
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
        enum enFilterBy { All, VoucherID, VoucherName, UserName };

        enFilterBy _filterBy = enFilterBy.All;

        bool _IsHeaderCreated = false;
        bool _searchByPageNumber = false;

        short _pageNumber = 1;

        bool _CheckValidationChildren()
        {
            if (!ValidateChildren())
            {
                gdgvVouchers.DataSource = null;
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

            clsDataColumns.clsIncomeAndExpenseVoucherClasses.clsGetAllVouchers result = null;

            bool filterByCreatedDate = false;

            if (gcbFilterByDate.Text == "تاريخ الإنشاء")
            {
                filterByCreatedDate = true;
            }
            else if (gcbFilterByDate.Text == "تاريخ المستند")
                filterByCreatedDate = false;
            else
                return;

            int currentUserID = Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID);

            if (filterBy == enFilterBy.All || string.IsNullOrEmpty(kgtxtFilterValue.ValidatedText))
            {
                result = await clsIncomeAndExpenseVoucher.GetAllVouchers(filterByCreatedDate, kgtxtFromData.ValidatedText,
                    kgtxtToDate.ValidatedText, _voucherType,currentUserID,_pageNumber);
            }
            else if (filterBy == enFilterBy.VoucherID)
            {
         int voucherID = Convert.ToInt32(kgtxtFilterValue.ValidatedText);
                result = await clsIncomeAndExpenseVoucher.GetAllVouchersByVoucherID(voucherID, filterByCreatedDate, kgtxtFromData.ValidatedText,
                    kgtxtToDate.ValidatedText, _voucherType, currentUserID, _pageNumber);
            }
            else if (filterBy == enFilterBy.VoucherName)
            {
                string voucherName = kgtxtFilterValue.ValidatedText;
                result = await clsIncomeAndExpenseVoucher.GetAllVouchersByVoucherName(voucherName, filterByCreatedDate, kgtxtFromData.ValidatedText,
                    kgtxtToDate.ValidatedText, _voucherType, currentUserID, _pageNumber);
            }
            else if (filterBy == enFilterBy.UserName)
            {
                string userName = kgtxtFilterValue.ValidatedText;
                result = await clsIncomeAndExpenseVoucher.GetAllVouchersByUserName(userName, filterByCreatedDate, kgtxtFromData.ValidatedText,
                    kgtxtToDate.ValidatedText, _voucherType, currentUserID, _pageNumber);
            }
            else
                return;

            if (result == null)
                return;

            if (result.dtVouchers.Rows.Count == 0)
            {
                lblNoRecordsFoundMessage.Visible = true;
                //lblUserMessage.Visible = true;
                gdgvVouchers.DataSource = null;
                _IsHeaderCreated = false;
                _pageNumber = 1;
            }
            else
            {
                lblNoRecordsFoundMessage.Visible = false;
                gdgvVouchers.DataSource = result.dtVouchers;
            }

            lblUserMessage.Visible = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = _pageNumber.ToString();
            _searchByPageNumber = true;

            lblTotalRecordsNumber.Text = result.RecordsCount.ToString();
            lblCurrentPageOfNumberOfPages.Text = string.Concat(_pageNumber, "   من   ", result.NumberOfPages, "  صفحات");
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = true;
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = (result.NumberOfPages < 1) ? 1 : result.NumberOfPages;
            lblCurrentPageRecordsCount.Text = gdgvVouchers.Rows.Count.ToString();

            gibtnNextPage.Enabled = (_pageNumber < result.NumberOfPages);
            gibtnPreviousPage.Enabled = (_pageNumber > 1);

            klblAllVouchersValue.Text = result.TotalVouchersValue.ToString();
            klblCurrentPageVouchersValue.Text = result.CurrentPageVouchersValue.ToString();
            //

            if (!_IsHeaderCreated && gdgvVouchers.Rows.Count > 0)
            {
                gdgvVouchers.Columns["VoucherID"].HeaderText = "معرف المستند";
                gdgvVouchers.Columns["VoucherID"].Width = 125;

                gdgvVouchers.Columns["VoucherName"].HeaderText = "اسم المستند";
                gdgvVouchers.Columns["VoucherName"].Width = 265;

                gdgvVouchers.Columns["VoucherValue"].HeaderText = "قيمة المستند";
                gdgvVouchers.Columns["VoucherValue"].Width = 250;
                gdgvVouchers.Columns["VoucherValue"].DefaultCellStyle.Format = "N4";

                gdgvVouchers.Columns["TransactionsCount"].HeaderText = "عدد المعاملات";
                gdgvVouchers.Columns["TransactionsCount"].Width = 125;

                gdgvVouchers.Columns["VoucherDate"].HeaderText = "تاريخ المستند";
                gdgvVouchers.Columns["VoucherDate"].Width = 135;
                gdgvVouchers.Columns["VoucherDate"].DefaultCellStyle.Format = "dd-MM-yyyy";

                gdgvVouchers.Columns["CreatedDate"].HeaderText = "تاريخ الإنشاء";
                gdgvVouchers.Columns["CreatedDate"].Width = 235;
                gdgvVouchers.Columns["CreatedDate"].DefaultCellStyle.Format = "hh:mm:ss tt dd-MM-yyyy";

                gdgvVouchers.Columns["CreatedByUserName"].HeaderText = "اسم المستخدم المنشئ";
                gdgvVouchers.Columns["CreatedByUserName"].Width = 265;

                _IsHeaderCreated = true;

            }
        }

        void _AddNewVoucher()
        {
            frmAddUpdateVoucher frm = new frmAddUpdateVoucher(_voucherType);
            frm.OnCloseAndSaved += _RefreshFilter;
            clsGlobal_UI.MainForm.AddNewFormAtContainer(frm);
        }

        void _UpdateVoucher()
        {
            if (gdgvVouchers.SelectedRows.Count < 1)
                return;

            int voucherID = Convert.ToInt32(gdgvVouchers.SelectedRows[0].Cells[0].Value);

            frmAddUpdateVoucher frm = new frmAddUpdateVoucher(voucherID);
            frm.OnCloseAndSaved += _RefreshFilter;
            clsGlobal_UI.MainForm.AddNewFormAtContainer(frm);
        }

        async void _RefreshFilter()
        {
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


        private void VouhcersList_Load(object sender, EventArgs e)
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
                //kgtxtFilterValue.Visible = false;
                _SetReadOnlyAtTextBox(kgtxtFilterValue);
                _filterBy = enFilterBy.All;
                await _LoadDataAtDataGridView(_filterBy);
                return;
            }


            //kgtxtFilterValue.Visible = true;
            _CancelReadOnlyAtTextBox(kgtxtFilterValue);
            kgtxtFilterValue.IsRequired = false;
            kgtxtFilterValue.TrimStart = false;
            kgtxtFilterValue.TrimEnd = true;

            if (gcbFilterBy.Text == "معرف المستند")
            {
                _filterBy = enFilterBy.VoucherID;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
                kgtxtFilterValue.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
                kgtxtFilterValue.AllowWhiteSpace = false;
                kgtxtFilterValue.NumberProperties.IntegerNumberProperties.AllowNegative = false;
                kgtxtFilterValue.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            }
            else if (gcbFilterBy.Text == "اسم المستند")
            {
                _filterBy = enFilterBy.VoucherName;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
                kgtxtFilterValue.AllowWhiteSpace = true;
            }
            else if (gcbFilterBy.Text == "اسم المستخدم")
            {
                _filterBy = enFilterBy.UserName;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
                kgtxtFilterValue.AllowWhiteSpace = false;
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

        private void gbtnAddVoucher_Click(object sender, EventArgs e)
        {
            _AddNewVoucher();
        }

        private async void gcbFilterByDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            await _LoadDataAtDataGridView(_filterBy);
        }

        private async void gibtnRefreshData_Click(object sender, EventArgs e)
        {
            await _LoadDataAtDataGridView(_filterBy);
        }

        private async void kgtxtDataFrom_Leave(object sender, EventArgs e)
        {
            _pageNumber = 1;
            await _LoadDataAtDataGridView(_filterBy);
        }

        private void gtsmAddVoucher_Click(object sender, EventArgs e)
        {
            _AddNewVoucher();
        }

        private void gtsmEdit_Click(object sender, EventArgs e)
        {
            _UpdateVoucher();
        }

        private void gdgvVouchers_DoubleClick(object sender, EventArgs e)
        {
            _UpdateVoucher();
        }

        private void gdgvVouchers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value)
            {
                //e.CellStyle.BackColor = Color.LightYellow; // خلفية
                e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.SelectionForeColor = Color.Orange;
            }
        }

        private async void gtsmExportExcel_Click(object sender, EventArgs e)
        {
            SearchAfterTimerFinish.Stop();

            if (!_CheckValidationChildren())
                return;

            if (gdgvVouchers.Rows.Count < 1)
            {
                lblUserMessage.Text = "لا يوجد صفوف لتصديرها !";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false; 

            DataTable result = null;

            bool filterByCreatedDate = false;

            if (gcbFilterByDate.Text == "تاريخ الإنشاء")
            {
                filterByCreatedDate = true;
            }
            else if (gcbFilterByDate.Text == "تاريخ المستند")
                filterByCreatedDate = false;
            else
                return;

            int currentUserID = Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID);

            if (_filterBy == enFilterBy.All || string.IsNullOrEmpty(kgtxtFilterValue.ValidatedText))
            {
                result = await clsIncomeAndExpenseVoucher.GetAllVouchersWithoutPaging(filterByCreatedDate, kgtxtFromData.ValidatedText,
                    kgtxtToDate.ValidatedText, _voucherType, currentUserID);
            }
            else if (_filterBy == enFilterBy.VoucherID)
            {
                int voucherID = Convert.ToInt32(kgtxtFilterValue.ValidatedText);
                result = await clsIncomeAndExpenseVoucher.GetAllVouchersByVoucherIDWithoutPaging(voucherID, filterByCreatedDate, kgtxtFromData.ValidatedText,
                    kgtxtToDate.ValidatedText, _voucherType, currentUserID);
            }
            else if (_filterBy == enFilterBy.VoucherName)
            {
                string voucherName = kgtxtFilterValue.ValidatedText;
                result = await clsIncomeAndExpenseVoucher.GetAllVouchersByVoucherNameWithoutPaging(voucherName, filterByCreatedDate, kgtxtFromData.ValidatedText,
                    kgtxtToDate.ValidatedText, _voucherType, currentUserID);
            }
            else if (_filterBy == enFilterBy.UserName)
            {
                string userName = kgtxtFilterValue.ValidatedText;
                result = await clsIncomeAndExpenseVoucher.GetAllVouchersByUserNameWithoutPaging(userName, filterByCreatedDate, kgtxtFromData.ValidatedText,
                    kgtxtToDate.ValidatedText, _voucherType, currentUserID);
            }
            else
                return;

            if (result == null)
                return;

            if (result == null)
            {
                clsGlobalMessageBoxs.ShowErrorMessage("فشل تصدير البيانات !");
                return;
            }

            result.Columns["VoucherID"].ColumnName = "معرف المستند";
            result.Columns["VoucherName"].ColumnName = "اسم المستند";
            result.Columns["VoucherValue"].ColumnName = "قيمة المستند";
            result.Columns["TransactionsCount"].ColumnName = "عدد المعاملات";
            result.Columns["VoucherDate"].ColumnName = "تاريخ المستند";
            result.Columns["CreatedDate"].ColumnName = "تاريخ الإنشاء";
            result.Columns["CreatedByUserID"].ColumnName = "معرف المستخدم المنشئ";
            result.Columns["CreatedByUserName"].ColumnName = "اسم المستخدم المنشئ";
            result.Columns["AccountID"].ColumnName = "معرف الحساب";

            string vouchersTypeName = null;

            switch (_voucherType)
            {
                case enVoucherType.Incomes:
                    vouchersTypeName = "الواردات";
                    break;

                case enVoucherType.Expenses:
                    vouchersTypeName = "المصروفات";
                    break;

                case enVoucherType.ExpensesReturn:
                    vouchersTypeName = "مرتجعات المصروفات";
                    break;

                default:
                    vouchersTypeName = "";
                    break;
            }

            await clsExportHelper.ExportToExcelWithDialog(result, $"تقرير مستندات {vouchersTypeName}");
        }
    }
}
