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
    public partial class frmDebtsList : Form
    {
        public frmDebtsList()
        { 
            InitializeComponent();
        }
        enum enFilterBy { All, DebtID, PersonName };

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
  

            clsDataColumns.clsDebtsClasses.clsGetAllDebts result = null;

            bool filterByCreatedDate = false;

            if (gcbFilterByDate.Text == "تاريخ الإنشاء")
                filterByCreatedDate = true;
            else if (gcbFilterByDate.Text == "تاريخ المستند")
                filterByCreatedDate = false;
            else
                return;

            bool? isLending = null;

            if (gcbFilterByDebtType.Text == "إقراض")
                isLending = true;
            else if (gcbFilterByDate.Text == "إقتراض")
                isLending = false;
            else
                isLending = null;

            bool? isPaid = null;

            if (gcbFilterbyPaymentStatus.Text == "مسدد")
                isPaid = true;  
            else if (gcbFilterbyPaymentStatus.Text == "غير مسدد")
                isPaid = false;
            else
                isPaid = null;

            int currentUserID = Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID);

            if (filterBy == enFilterBy.All || string.IsNullOrEmpty(kgtxtFilterValue.ValidatedText))
            {
                result = await clsDebt.GetAllDebts(isLending, filterByCreatedDate, kgtxtFromData.ValidatedText, kgtxtToDate.ValidatedText,
                    isPaid, currentUserID, _pageNumber);
            }
            else if (filterBy == enFilterBy.DebtID)
            {
                int debtID = Convert.ToInt32(kgtxtFilterValue.ValidatedText);
                result = await clsDebt.GetAllDebts(debtID,isLending, filterByCreatedDate, kgtxtFromData.ValidatedText, kgtxtToDate.ValidatedText,
                      isPaid, currentUserID, _pageNumber);
            }
            else if (filterBy == enFilterBy.PersonName)
            {
                string personName = kgtxtFilterValue.ValidatedText;
                result = await clsDebt.GetAllDebts(personName,isLending, filterByCreatedDate, kgtxtFromData.ValidatedText, kgtxtToDate.ValidatedText,
                    isPaid, currentUserID, _pageNumber);
            }
            else
                return;

            if (result == null)
                return;

            if (result.dtDebts.Rows.Count == 0)
            {
                lblNoRecordsFoundMessage.Visible = true;
                gdgvVouchers.DataSource = null;
                _IsHeaderCreated = false;
                _pageNumber = 1;
            }
            else
            {
                lblNoRecordsFoundMessage.Visible = false;
                gdgvVouchers.DataSource = result.dtDebts;
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

            klblAllVouchersValue.Text = result.TotalDebtsValue.ToString();
            klblCurrentPageVouchersValue.Text = result.CurrentPageDebtsValue.ToString();
            //

            if (!_IsHeaderCreated && gdgvVouchers.Rows.Count > 0)
            {
                gdgvVouchers.Columns["DebtID"].HeaderText = "معرف المستند";
                gdgvVouchers.Columns["DebtID"].Width = 125;

                gdgvVouchers.Columns["PersonName"].HeaderText = "اسم الشخص";
                gdgvVouchers.Columns["PersonName"].Width = 280;

                gdgvVouchers.Columns["DebtValue"].HeaderText = "قيمة الدين";
                gdgvVouchers.Columns["DebtValue"].Width = 250;
                gdgvVouchers.Columns["DebtValue"].DefaultCellStyle.Format = "N4";

                gdgvVouchers.Columns["RemainingAmount"].HeaderText = "القيمة المتبقية";
                gdgvVouchers.Columns["RemainingAmount"].Width = 250;
                gdgvVouchers.Columns["RemainingAmount"].DefaultCellStyle.Format = "N4";

                gdgvVouchers.Columns["DebtDate"].HeaderText = "تاريخ المستند";
                gdgvVouchers.Columns["DebtDate"].Width = 150;
                gdgvVouchers.Columns["DebtDate"].DefaultCellStyle.Format = "dd-MM-yyyy";

                gdgvVouchers.Columns["CreatedDate"].HeaderText = "تاريخ الإنشاء";
                gdgvVouchers.Columns["CreatedDate"].Width = 250;
                gdgvVouchers.Columns["CreatedDate"].DefaultCellStyle.Format = "hh:mm:ss tt dd-MM-yyyy";

                gdgvVouchers.Columns["DebtType"].HeaderText = "نوع الدين";
                gdgvVouchers.Columns["DebtType"].Width = 280;

                _IsHeaderCreated = true;

            }
        }

        void _AddNewVoucher()
        {
            //frmAddUpdateVoucher frm = new frmAddUpdateVoucher(_voucherType);
            //frm.OnCloseAndSaved += _RefreshFilter;
            //clsGlobal_UI.MainForm.AddNewFormAtContainer(frm);
        }

        void _UpdateVoucher()
        {
            if (gdgvVouchers.SelectedRows.Count < 1)
                return;

            //int voucherID = Convert.ToInt32(gdgvVouchers.SelectedRows[0].Cells[0].Value);

            //frmAddUpdateVoucher frm = new frmAddUpdateVoucher(voucherID);
            //frm.OnCloseAndSaved += _RefreshFilter;
            //clsGlobal_UI.MainForm.AddNewFormAtContainer(frm);
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
                _SetReadOnlyAtTextBox(kgtxtFilterValue);
                _filterBy = enFilterBy.All;
                await _LoadDataAtDataGridView(_filterBy);
                return;
            }

            _CancelReadOnlyAtTextBox(kgtxtFilterValue);
            kgtxtFilterValue.IsRequired = false;
            kgtxtFilterValue.TrimStart = false;
            kgtxtFilterValue.TrimEnd = true;

            if (gcbFilterBy.Text == "معرف المستند")
            {
                _filterBy = enFilterBy.DebtID;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
                kgtxtFilterValue.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
                kgtxtFilterValue.AllowWhiteSpace = false;
                kgtxtFilterValue.NumberProperties.IntegerNumberProperties.AllowNegative = false;
                kgtxtFilterValue.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            }
            else if (gcbFilterBy.Text == "اسم الشخص")
            {
                _filterBy = enFilterBy.PersonName;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
                kgtxtFilterValue.AllowWhiteSpace = true;
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

        private async void gcbFilterByDebtType_SelectedIndexChanged(object sender, EventArgs e)
        {
            await _LoadDataAtDataGridView(_filterBy);
        }

        private async void gcbFilterbyPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            await _LoadDataAtDataGridView(_filterBy);
        }
    }
}
