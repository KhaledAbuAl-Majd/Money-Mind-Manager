using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KhaledControlLibrary1;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Core.Models.Debt;
using MoneyMindManager.Shared.DTOs.Debt;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.Global;


namespace MoneyMindManager_Presentation.Income_And_Expense.Vouchers
{
    public partial class frmDebtsList : Form
    {
        private readonly IUserSession _userSession;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IFormDisplayer _formDisplayer;
        private readonly IDebtApiClient _debtApi;
        private readonly IDataConverter _dataConverter;
        private readonly IExportWithDialogService _exportWithDialogService;

        public frmDebtsList(IUserSession userSession, IMessageBoxService messageBoxService, IFormDisplayer formDisplayer,
             IDebtApiClient debtApiClient, IDataConverter dataConverter, IExportWithDialogService exportWithDialogService)
        {
            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._formDisplayer = formDisplayer;
            this._debtApi = debtApiClient;
            this._dataConverter = dataConverter;
            this._exportWithDialogService = exportWithDialogService;
            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }

            InitializeComponent();
        }

        bool _CheckPermissions()
        {
            if (_userSession.IsHasPermissions(enPermissions.DebtsList))
                return true;

            _messageBoxService.DisplayError("ليس لديك صلاحية قائمة سندات الديون.");
            return false;
        }
        enum enFilterBy { All, DebtID, PersonName, UserName };

        enFilterBy _filterBy = enFilterBy.All;

        bool _IsHeaderCreated = false;
        bool _searchByPageNumber = false;

        int _pageNumber = 1;

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
                klblAllDebtsValue.Text = "0";
                klblCurrentPageDebtsValue.Text = "0";
                klblTotalRemainingAmount.Text = "0";
                klblCurrentPageRemainingAmount.Text = "0";
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


            enTextSearchMode textSearchMode = enTextSearchMode.WordsPrefix_Fast;

            if (grbTextSearchMode_WordsPrefix.Checked)
                textSearchMode = enTextSearchMode.WordsPrefix_Fast;
            else if (grbTextSearchMode_SubString.Checked)
                textSearchMode = enTextSearchMode.Substring_Slow;

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

            var filterDTO = new DebtPagedFilterDTO();
            filterDTO.IsLending = isLending;
            filterDTO.IsByCreatedDate = filterByCreatedDate;
            filterDTO.FromDateString = kgtxtFromData.ValidatedText;
            filterDTO.ToDateString = kgtxtToDate.ValidatedText;
            filterDTO.IsPaid = isPaid;
            filterDTO.TextSearchMode = textSearchMode;
            filterDTO.PageNumber = _pageNumber;

            if (filterBy == enFilterBy.All || string.IsNullOrEmpty(kgtxtFilterValue.ValidatedText))
            {

            }
            else if (filterBy == enFilterBy.DebtID)
            {
                int debtID = Convert.ToInt32(kgtxtFilterValue.ValidatedText);
                filterDTO.DebtID = debtID;
            }
            else if (filterBy == enFilterBy.PersonName)
            {
                string personName = kgtxtFilterValue.ValidatedText;
                filterDTO.PersonName = personName;
            }
            else if (filterBy == enFilterBy.UserName)
            {
                string userName = kgtxtFilterValue.ValidatedText;
                filterDTO.UserName = userName;
            }
            else
                return;

            var result = await _debtApi.GetAllPaged(filterDTO, Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess)
            {
                _messageBoxService.DisplayError(result.ErrorMessage);
                return;
            }

            var DTO = result.Data;

            if (DTO == null)
                return;

            if (DTO.Data.Count() == 0)
            {
                lblNoRecordsFoundMessage.Visible = true;
                gdgvDebts.DataSource = null;
                _IsHeaderCreated = false;
                _pageNumber = 1;
            }
            else
            {
                lblNoRecordsFoundMessage.Visible = false;
                gdgvDebts.DataSource = DTO.Data;
            }

            lblUserMessage.Visible = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = _pageNumber.ToString();
            _searchByPageNumber = true;

            lblTotalRecordsNumber.Text = DTO.TotalRecords.ToString();
            lblCurrentPageOfNumberOfPages.Text = string.Concat(_pageNumber, "   من   ", DTO.TotalPages, "  صفحات");
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = true;
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = (DTO.TotalPages < 1) ? 1 : DTO.TotalPages;
            lblCurrentPageRecordsCount.Text = gdgvDebts.Rows.Count.ToString();

            gibtnNextPage.Enabled = (_pageNumber < DTO.TotalPages);
            gibtnPreviousPage.Enabled = (_pageNumber > 1);

            klblAllDebtsValue.Text = DTO.TotalValue.ToString();
            klblCurrentPageDebtsValue.Text = DTO.CurrentPageValue.ToString();
            klblTotalRemainingAmount.Text = DTO.TotalRemainingAmount.ToString();
            klblCurrentPageRemainingAmount.Text = DTO.CurrentPageRemainingAmount.ToString();
            //

            if (!_IsHeaderCreated && gdgvDebts.Rows.Count > 0)
            {

                gdgvDebts.Columns[nameof(DebtViewSummary.DebtID)].HeaderText = "معرف سند الدين";
                gdgvDebts.Columns[nameof(DebtViewSummary.DebtID)].Width = 125;

                gdgvDebts.Columns[nameof(DebtViewSummary.PersonName)].HeaderText = "اسم الشخص";
                gdgvDebts.Columns[nameof(DebtViewSummary.PersonName)].Width = 265;

                gdgvDebts.Columns[nameof(DebtViewSummary.DebtValue)].HeaderText = "قيمة الدين";
                gdgvDebts.Columns[nameof(DebtViewSummary.DebtValue)].Width = 215;
                gdgvDebts.Columns[nameof(DebtViewSummary.DebtValue)].DefaultCellStyle.Format = "N2";

                gdgvDebts.Columns[nameof(DebtViewSummary.RemainingAmount)].HeaderText = "القيمة المتبقية للسداد";
                gdgvDebts.Columns[nameof(DebtViewSummary.RemainingAmount)].Width = 215;
                gdgvDebts.Columns[nameof(DebtViewSummary.RemainingAmount)].DefaultCellStyle.Format = "N2";

                gdgvDebts.Columns[nameof(DebtViewSummary.DebtDate)].HeaderText = "تاريخ السند";
                gdgvDebts.Columns[nameof(DebtViewSummary.DebtDate)].Width = 115;
                gdgvDebts.Columns[nameof(DebtViewSummary.DebtDate)].DefaultCellStyle.Format = "dd-MM-yyyy";

                gdgvDebts.Columns[nameof(DebtViewSummary.CreatedDate)].HeaderText = "تاريخ الإنشاء";
                gdgvDebts.Columns[nameof(DebtViewSummary.CreatedDate)].Width = 190;
                gdgvDebts.Columns[nameof(DebtViewSummary.CreatedDate)].DefaultCellStyle.Format = "hh:mm:ss tt dd-MM-yyyy";

                gdgvDebts.Columns[nameof(DebtViewSummary.DebtType)].HeaderText = "نوع الدين";
                gdgvDebts.Columns[nameof(DebtViewSummary.DebtType)].Width = 70;

                gdgvDebts.Columns[nameof(DebtViewSummary.CreatedByUserName)].HeaderText = "اسم المستخدم المنشئ";
                gdgvDebts.Columns[nameof(DebtViewSummary.CreatedByUserName)].Width = 265;

                _IsHeaderCreated = true;

            }
        }

        void _AddNewDebt()
        {
            _formDisplayer.OpenAtContainer<frmAddUpdateDebt>(frm =>
            {
                if (!frm.Initialize()) return false;
                frm.OnCloseAndSaved += _Refresh;
                return true;
            });
        }

        void _UpdateDebt()
        {
            if (gdgvDebts.SelectedRows.Count < 1)
                return;

            int debtID = Convert.ToInt32(gdgvDebts.SelectedRows[0].Cells[0].Value);

            _formDisplayer.OpenAtContainer<frmAddUpdateDebt>(frm =>
            {
                if (!frm.Initialize(debtID)) return false;
                frm.OnCloseAndSaved += _Refresh;
                return true;
            });
        }

        async void _Refresh()
        {
            _pageNumber = 1;
            _searchByPageNumber = false;
            kgtxtFilterValue.Text = "";
            _searchByPageNumber = true;

            await _LoadDataAtDataGridView(_filterBy);
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


        private void DebtsList_Load(object sender, EventArgs e)
        {
            _IsHeaderCreated = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = "1";
            lblNoRecordsFoundMessage.Visible = false;
            lblUserMessage.Visible = false;
            gcbFilterBy.SelectedIndex = 0;
        }

        private async void frmDebtsList_Shown(object sender, EventArgs e)
        {
            await _LoadDataAtDataGridView(enFilterBy.All);
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
            string oldText = kgtxtFilterValue.Text;

            _pageNumber = 1;

            _searchByPageNumber = false;
            kgtxtFilterValue.Text = "";
            _searchByPageNumber = true;

            if (gcbFilterBy.Text == "بدون")
            {
                _SetReadOnlyAtTextBox(kgtxtFilterValue);
                _filterBy = enFilterBy.All;
                if (!string.IsNullOrWhiteSpace(oldText))
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

            if (!string.IsNullOrWhiteSpace(oldText))
                await _LoadDataAtDataGridView(_filterBy);
        }

        private void kgtxtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _pageNumber = 1;
            SearchAfterTimerFinish.Stop();
            SearchAfterTimerFinish.Start();
        }

        private async void SearchAfterTimerFinish_Tick(object sender, EventArgs e)
        {
            await _LoadDataAtDataGridView(_filterBy);
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

        private async void kgtxtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchAfterTimerFinish.Stop();
                _pageNumber = 1;
                await _LoadDataAtDataGridView(_filterBy);
            }
        }

        private void gbtnAddVoucher_Click(object sender, EventArgs e)
        {
            _AddNewDebt();
        }

        private async void gcbFilterByDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pageNumber = 1;
            await _LoadDataAtDataGridView(_filterBy);
        }

        private async void gibtnRefreshData_Click(object sender, EventArgs e)
        {
            _pageNumber = 1;
            await _LoadDataAtDataGridView(_filterBy);
        }


        private void kgtxtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                gibtnRefreshData.PerformClick();
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
            _pageNumber = 1;
            await _LoadDataAtDataGridView(_filterBy);
        }

        private async void gcbFilterbyPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pageNumber = 1;
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

            enTextSearchMode textSearchMode = enTextSearchMode.WordsPrefix_Fast;

            if (grbTextSearchMode_WordsPrefix.Checked)
                textSearchMode = enTextSearchMode.WordsPrefix_Fast;
            else if (grbTextSearchMode_SubString.Checked)
                textSearchMode = enTextSearchMode.Substring_Slow;

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

            var filterDTO = new DebtFilterDTO();
            filterDTO.IsLending = isLending;
            filterDTO.IsByCreatedDate = filterByCreatedDate;
            filterDTO.FromDateString = kgtxtFromData.ValidatedText;
            filterDTO.ToDateString = kgtxtToDate.ValidatedText;
            filterDTO.IsPaid = isPaid;
            filterDTO.TextSearchMode = textSearchMode;

            if (_filterBy == enFilterBy.All || string.IsNullOrEmpty(kgtxtFilterValue.ValidatedText))
            {

            }
            else if (_filterBy == enFilterBy.DebtID)
            {
                int debtID = Convert.ToInt32(kgtxtFilterValue.ValidatedText);
                filterDTO.DebtID = debtID;
            }
            else if (_filterBy == enFilterBy.PersonName)
            {
                string personName = kgtxtFilterValue.ValidatedText;
                filterDTO.PersonName = personName;
            }
            else if (_filterBy == enFilterBy.UserName)
            {
                string userName = kgtxtFilterValue.ValidatedText;
                filterDTO.UserName = userName;
            }
            else
                return;

            var result = await _debtApi.GetAll(filterDTO, Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || result.Data is null)
            {
                _messageBoxService.DisplayError(result.ErrorMessage);
                return;
            }

            DataTable dt = _dataConverter.ToDataTable<DebtExportSummary>(result.Data);

            dtDebts.Columns[nameof(DebtExportSummary.DebtID)].ColumnName = "معرف سند الدين";
            dtDebts.Columns[nameof(DebtExportSummary.PersonID)].ColumnName = "معرف الشخص";
            dtDebts.Columns[nameof(DebtExportSummary.PersonName)].ColumnName = "اسم الشخص";
            dtDebts.Columns[nameof(DebtExportSummary.DebtValue)].ColumnName = "قيمة الدين";
            dtDebts.Columns[nameof(DebtExportSummary.RemainingAmount)].ColumnName = "القيمة المتبقية للسداد";
            dtDebts.Columns[nameof(DebtExportSummary.DebtDate)].ColumnName = "تاريخ سند الدين";
            dtDebts.Columns[nameof(DebtExportSummary.CreatedDate)].ColumnName = "تاريخ الإنشاء";
            dtDebts.Columns[nameof(DebtExportSummary.DebtType)].ColumnName = "نوع الدين";
            dtDebts.Columns[nameof(DebtExportSummary.CreatedByUserID)].ColumnName = "معرف المستخدم المنشئ";
            dtDebts.Columns[nameof(DebtExportSummary.CreatedByUserName)].ColumnName = "اسم المستخدم المنشئ";
            dtDebts.Columns[nameof(DebtExportSummary.AccounntID)].ColumnName = "معرف الحساب";

            await _exportWithDialogService.ExportToExcel(dtDebts, "تقرير سند الديون");
        }
    }
}
