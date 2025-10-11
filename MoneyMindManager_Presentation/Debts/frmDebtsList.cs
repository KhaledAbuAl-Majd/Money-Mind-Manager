using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
        enum enFilterBy { All, DebtID, PersonName,UserName };

        enFilterBy _filterBy = enFilterBy.All;

        bool _IsHeaderCreated = false;
        bool _searchByPageNumber = false;

        short _pageNumber = 1;

        bool _CheckValidationChildren()
        {
            if (!ValidateChildren())
            {
                gdgvDebts.DataSource = null;
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
            else if (gcbFilterByDate.Text == "تاريخ السند")
                filterByCreatedDate = false;
            else
                return;

            bool? isLending = null;

            if (gcbFilterByDebtType.Text == "إقراض")
                isLending = true;
            else if (gcbFilterByDebtType.Text == "إقتراض")
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
            else if (filterBy == enFilterBy.UserName)
            {
                string userName = kgtxtFilterValue.ValidatedText;
                result = await clsDebt.GetAllDebtsByUserName(userName,isLending, filterByCreatedDate, kgtxtFromData.ValidatedText, kgtxtToDate.ValidatedText,
                    isPaid, currentUserID, _pageNumber);
            }
            else
                return;

            if (result == null)
                return;

            if (result.dtDebts.Rows.Count == 0)
            {
                lblNoRecordsFoundMessage.Visible = true;
                gdgvDebts.DataSource = null;
                _IsHeaderCreated = false;
                _pageNumber = 1;
            }
            else
            {
                lblNoRecordsFoundMessage.Visible = false;
                gdgvDebts.DataSource = result.dtDebts;
            }

            lblUserMessage.Visible = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = _pageNumber.ToString();
            _searchByPageNumber = true;

            lblTotalRecordsNumber.Text = result.RecordsCount.ToString();
            lblCurrentPageOfNumberOfPages.Text = string.Concat(_pageNumber, "   من   ", result.NumberOfPages, "  صفحات");
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = true;
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = (result.NumberOfPages < 1) ? 1 : result.NumberOfPages;
            lblCurrentPageRecordsCount.Text = gdgvDebts.Rows.Count.ToString();

            gibtnNextPage.Enabled = (_pageNumber < result.NumberOfPages);
            gibtnPreviousPage.Enabled = (_pageNumber > 1);

            klblAllVouchersValue.Text = result.TotalDebtsValue.ToString();
            klblCurrentPageVouchersValue.Text = result.CurrentPageDebtsValue.ToString();
            //

            if (!_IsHeaderCreated && gdgvDebts.Rows.Count > 0)
            {
                gdgvDebts.Columns["DebtID"].HeaderText = "معرف سند الدين";
                gdgvDebts.Columns["DebtID"].Width = 125;

                gdgvDebts.Columns["PersonName"].HeaderText = "اسم الشخص";
                gdgvDebts.Columns["PersonName"].Width = 265;

                gdgvDebts.Columns["DebtValue"].HeaderText = "قيمة الدين";
                gdgvDebts.Columns["DebtValue"].Width = 215;
                gdgvDebts.Columns["DebtValue"].DefaultCellStyle.Format = "N4";

                gdgvDebts.Columns["RemainingAmount"].HeaderText = "القيمة المتبقية للسداد";
                gdgvDebts.Columns["RemainingAmount"].Width = 215;
                gdgvDebts.Columns["RemainingAmount"].DefaultCellStyle.Format = "N4";

                gdgvDebts.Columns["DebtDate"].HeaderText = "تاريخ السند";
                gdgvDebts.Columns["DebtDate"].Width = 115;
                gdgvDebts.Columns["DebtDate"].DefaultCellStyle.Format = "dd-MM-yyyy";

                gdgvDebts.Columns["CreatedDate"].HeaderText = "تاريخ الإنشاء";
                gdgvDebts.Columns["CreatedDate"].Width = 190;
                gdgvDebts.Columns["CreatedDate"].DefaultCellStyle.Format = "hh:mm:ss tt dd-MM-yyyy";

                gdgvDebts.Columns["DebtType"].HeaderText = "نوع الدين";
                gdgvDebts.Columns["DebtType"].Width = 70;

                gdgvDebts.Columns["CreatedByUserName"].HeaderText = "اسم المستخدم المنشئ";
                gdgvDebts.Columns["CreatedByUserName"].Width = 265;

                _IsHeaderCreated = true;

            }
        }

        void _AddNewDebt()
        {
            frmAddUpdateDebt frm = new frmAddUpdateDebt();
            frm.OnCloseAndSaved += _RefreshFilter;
            clsGlobal_UI.MainForm.AddNewFormAtContainer(frm);
        }

        void _UpdateDebt()
        {
            if (gdgvDebts.SelectedRows.Count < 1)
                return;

            int debtID = Convert.ToInt32(gdgvDebts.SelectedRows[0].Cells[0].Value);

            frmAddUpdateDebt frm = new frmAddUpdateDebt(debtID);
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
                _SetReadOnlyAtTextBox(kgtxtFilterValue);
                _filterBy = enFilterBy.All;
                await _LoadDataAtDataGridView(_filterBy);
                return;
            }

            _CancelReadOnlyAtTextBox(kgtxtFilterValue);
            kgtxtFilterValue.IsRequired = false;
            kgtxtFilterValue.TrimStart = false;
            kgtxtFilterValue.TrimEnd = true;

            if (gcbFilterBy.Text == "معرف السند")
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
            _AddNewDebt();
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
            _AddNewDebt();
        }

        private void gtsmEdit_Click(object sender, EventArgs e)
        {
            _UpdateDebt();
        }

        private void gdgvVouchers_DoubleClick(object sender, EventArgs e)
        {
            _UpdateDebt();
        }

        private void gdgvVouchers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value)
            {
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


        private async void gtsmExportExcel_Click(object sender, EventArgs e)
        {
            SearchAfterTimerFinish.Stop();

            if (!_CheckValidationChildren())
                return;

            if (gdgvDebts.Rows.Count < 1)
            {
                lblUserMessage.Text = "لا يوجد صفوف لتصديرها !";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;


            DataTable dtDebts = null;

            bool filterByCreatedDate = false;

            if (gcbFilterByDate.Text == "تاريخ الإنشاء")
                filterByCreatedDate = true;
            else if (gcbFilterByDate.Text == "تاريخ السند")
                filterByCreatedDate = false;
            else
                return;

            bool? isLending = null;

            if (gcbFilterByDebtType.Text == "إقراض")
                isLending = true;
            else if (gcbFilterByDebtType.Text == "إقتراض")
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

            if (_filterBy == enFilterBy.All || string.IsNullOrEmpty(kgtxtFilterValue.ValidatedText))
            {
                dtDebts = await clsDebt.GetAllDebtsWithoutPaging(isLending, filterByCreatedDate, kgtxtFromData.ValidatedText, kgtxtToDate.ValidatedText,
                    isPaid, currentUserID);
            }
            else if (_filterBy == enFilterBy.DebtID)
            {
                int debtID = Convert.ToInt32(kgtxtFilterValue.ValidatedText);
                dtDebts = await clsDebt.GetAllDebtsWithoutPaging(debtID, isLending, filterByCreatedDate, kgtxtFromData.ValidatedText, kgtxtToDate.ValidatedText,
                      isPaid, currentUserID);
            }
            else if (_filterBy == enFilterBy.PersonName)
            {
                string personName = kgtxtFilterValue.ValidatedText;
                dtDebts = await clsDebt.GetAllDebtsWithoutPaging(personName, isLending, filterByCreatedDate, kgtxtFromData.ValidatedText, kgtxtToDate.ValidatedText,
                    isPaid, currentUserID);
            }
            else if (_filterBy == enFilterBy.UserName)
            {
                string userName = kgtxtFilterValue.ValidatedText;
                dtDebts = await clsDebt.GetAllDebtsByUserNameWithoutPaging(userName, isLending, filterByCreatedDate, kgtxtFromData.ValidatedText, kgtxtToDate.ValidatedText,
                    isPaid, currentUserID);
            }
            else
                return;

            if (dtDebts == null)
                return;

            if (dtDebts == null)
            {
                clsGlobalMessageBoxs.ShowErrorMessage("فشل تصدير البيانات !");
                return;
            }

            dtDebts.Columns["DebtID"].ColumnName = "معرف سند الدين";
            dtDebts.Columns["PersonID"].ColumnName = "معرف الشخص";
            dtDebts.Columns["PersonName"].ColumnName = "اسم الشخص";
            dtDebts.Columns["DebtValue"].ColumnName = "قيمة الدين";
            dtDebts.Columns["RemainingAmount"].ColumnName = "القيمة المتبقية للسداد";
            dtDebts.Columns["DebtDate"].ColumnName = "تاريخ سند الدين";
            dtDebts.Columns["CreatedDate"].ColumnName = "تاريخ الإنشاء";
            dtDebts.Columns["DebtType"].ColumnName = "نوع الدين";
            dtDebts.Columns["CreatedByUserID"].ColumnName = "معرف المستخدم المنشئ";
            dtDebts.Columns["CreatedByUserName"].ColumnName = "اسم المستخدم المنشئ";
            dtDebts.Columns["AccountID"].ColumnName = "معرف الحساب";

            await clsExportHelper.ExportToExcelWithDialog(dtDebts, "تقرير سند الديون");
        }
    }
}
