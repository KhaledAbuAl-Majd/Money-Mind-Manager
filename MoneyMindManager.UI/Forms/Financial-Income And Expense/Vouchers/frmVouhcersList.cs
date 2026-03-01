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
using MoneyMindManager.Core.Models.FinVoucher;
using MoneyMindManager.Shared.DTOs.FinVoucher;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.Global;
namespace MoneyMindManager_Presentation.Income_And_Expense.Vouchers
{
    public partial class frmVouhcersList : Form
    {
        private readonly IUserSession _userSession;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IFormDisplayer _formDisplayer;
        private readonly IFinVoucherApiClient _finVoucherApi;
        private readonly IDataConverter _dataConverter;
        private readonly IExportWithDialogService _exportWithDialogService;
        private bool isInitialized = false;
        public frmVouhcersList(IUserSession userSession, IMessageBoxService messageBoxService, IFormDisplayer formDisplayer, IFinVoucherApiClient finVoucherApiClient,
            IDataConverter dataConverter, IExportWithDialogService exportWithDialogService)
        {
            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }

            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._formDisplayer = formDisplayer;
            this._finVoucherApi = finVoucherApiClient;
            this._dataConverter = dataConverter;
            this._exportWithDialogService = exportWithDialogService;

            InitializeComponent();
        }

        public bool Initialize(enVoucherType voucherType)
        {
            if (voucherType == enVoucherType.UnKnown)
            {
                _messageBoxService.DisplayError("نوع المستند غير معروف !");
                return false;
            }

            this._voucherType = voucherType;
            this.isInitialized = true;
            return true;
        }
        bool _CheckPermissions()
        {
            string errorMessage = "";
            enPermissions permission;

            switch (_voucherType)
            {
                case enVoucherType.Incomes:
                    errorMessage = "ليس لديك صلاحية قائمة مستندات الواردات.";
                    permission = enPermissions.IncomeVouchersList;
                    break;

                case enVoucherType.Expenses:
                    errorMessage = "ليس لديك صلاحية قائمة مستندات المصروفات.";
                    permission = enPermissions.ExpenseVouchersList;
                    break;

                case enVoucherType.ExpensesReturn:
                    errorMessage = "ليس لديك صلاحية قائمة مستندات مرتجعات المصروفات.";
                    permission = enPermissions.ExpenseReturnVouchersList;
                    break;

                default:
                    return false;
            }

            if (_userSession.IsHasPermissions(permission))
                return true;

            _messageBoxService.DisplayError(errorMessage);
            return false;
        }

        enVoucherType _voucherType;
        enum enFilterBy { All, VoucherID, VoucherName, UserName };

        enFilterBy _filterBy = enFilterBy.All;

        bool _IsHeaderCreated = false;
        bool _searchByPageNumber = false;

        int _pageNumber = 1;

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


            enTextSearchMode textSearchMode = enTextSearchMode.WordsPrefix_Fast;

            if (grbTextSearchMode_WordsPrefix.Checked)
                textSearchMode = enTextSearchMode.WordsPrefix_Fast;
            else if (grbTextSearchMode_SubString.Checked)
                textSearchMode = enTextSearchMode.Substring_Slow;

            bool filterByCreatedDate = false;

            if (gcbFilterByDate.Text == "تاريخ الإنشاء")
            {
                filterByCreatedDate = true;
            }
            else if (gcbFilterByDate.Text == "تاريخ المستند")
                filterByCreatedDate = false;
            else
                return;

            var filterDTO = new FinVoucherPagedFilterDTO();
            filterDTO.IsByCreatedDate = filterByCreatedDate;
            filterDTO.FromDateString = kgtxtFromData.ValidatedText;
            filterDTO.ToDateString = kgtxtToDate.ValidatedText;
            filterDTO.VoucherType = _voucherType;
            filterDTO.TextSearchMode = textSearchMode;
            filterDTO.PageNumber = _pageNumber;

            if (filterBy == enFilterBy.All || string.IsNullOrEmpty(kgtxtFilterValue.ValidatedText))
            {

            }
            else if (filterBy == enFilterBy.VoucherID)
            {
                int voucherID = Convert.ToInt32(kgtxtFilterValue.ValidatedText);
                filterDTO.VoucherID = voucherID;
            }
            else if (filterBy == enFilterBy.VoucherName)
            {
                string voucherName = kgtxtFilterValue.ValidatedText;
                filterDTO.VoucherName = voucherName;
            }
            else if (filterBy == enFilterBy.UserName)
            {
                string userName = kgtxtFilterValue.ValidatedText;
                filterDTO.UserName = userName;
            }
            else
                return;

            var result = await _finVoucherApi.GetAllPaged(filterDTO, Convert.ToInt32(_userSession.UserID));

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
                gdgvVouchers.DataSource = null;
                _IsHeaderCreated = false;
                _pageNumber = 1;
            }
            else
            {
                lblNoRecordsFoundMessage.Visible = false;
                gdgvVouchers.DataSource = DTO.Data;
            }

            lblUserMessage.Visible = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = _pageNumber.ToString();
            _searchByPageNumber = true;

            lblTotalRecordsNumber.Text = DTO.TotalRecords.ToString();
            lblCurrentPageOfNumberOfPages.Text = string.Concat(_pageNumber, "   من   ", DTO.TotalPages, "  صفحات");
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = true;
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = (DTO.TotalPages < 1) ? 1 : DTO.TotalPages;
            lblCurrentPageRecordsCount.Text = gdgvVouchers.Rows.Count.ToString();

            gibtnNextPage.Enabled = (_pageNumber < DTO.TotalPages);
            gibtnPreviousPage.Enabled = (_pageNumber > 1);

            klblAllVouchersValue.Text = DTO.TotalValue.ToString();
            klblCurrentPageVouchersValue.Text = DTO.CurrentPageValue.ToString();
            //

            if (!_IsHeaderCreated && gdgvVouchers.Rows.Count > 0)
            {

                gdgvVouchers.Columns[nameof(FinVoucherViewSummary.VoucherID)].HeaderText = "معرف المستند";
                gdgvVouchers.Columns[nameof(FinVoucherViewSummary.VoucherID)].Width = 125;

                gdgvVouchers.Columns[nameof(FinVoucherViewSummary.VoucherName)].HeaderText = "اسم المستند";
                gdgvVouchers.Columns[nameof(FinVoucherViewSummary.VoucherName)].Width = 265;

                gdgvVouchers.Columns[nameof(FinVoucherViewSummary.VoucherValue)].HeaderText = "قيمة المستند";
                gdgvVouchers.Columns[nameof(FinVoucherViewSummary.VoucherValue)].Width = 250;
                gdgvVouchers.Columns[nameof(FinVoucherViewSummary.VoucherValue)].DefaultCellStyle.Format = "N2";

                gdgvVouchers.Columns[nameof(FinVoucherViewSummary.TransactionsCount)].HeaderText = "عدد المعاملات";
                gdgvVouchers.Columns[nameof(FinVoucherViewSummary.TransactionsCount)].Width = 125;

                gdgvVouchers.Columns[nameof(FinVoucherViewSummary.VoucherDate)].HeaderText = "تاريخ المستند";
                gdgvVouchers.Columns[nameof(FinVoucherViewSummary.VoucherDate)].Width = 135;
                gdgvVouchers.Columns[nameof(FinVoucherViewSummary.VoucherDate)].DefaultCellStyle.Format = "dd-MM-yyyy";

                gdgvVouchers.Columns[nameof(FinVoucherViewSummary.CreatedDate)].HeaderText = "تاريخ الإنشاء";
                gdgvVouchers.Columns[nameof(FinVoucherViewSummary.CreatedDate)].Width = 235;
                gdgvVouchers.Columns[nameof(FinVoucherViewSummary.CreatedDate)].DefaultCellStyle.Format = "hh:mm:ss tt dd-MM-yyyy";

                gdgvVouchers.Columns[nameof(FinVoucherViewSummary.CreatedByUserName)].HeaderText = "اسم المستخدم المنشئ";
                gdgvVouchers.Columns[nameof(FinVoucherViewSummary.CreatedByUserName)].Width = 265;

                _IsHeaderCreated = true;

            }
        }

        void _AddNewVoucher()
        {
            _formDisplayer.OpenAtContainer<frmAddUpdateVoucher>(frm =>
            {
                if (!frm.Initilize(_voucherType)) return false;
                frm.OnCloseAndSaved += _Refresh;
                return true;
            });
        }

        void _UpdateVoucher()
        {
            if (gdgvVouchers.SelectedRows.Count < 1)
                return;

            int voucherID = Convert.ToInt32(gdgvVouchers.SelectedRows[0].Cells[0].Value);

            _formDisplayer.OpenAtContainer<frmAddUpdateVoucher>(frm =>
            {
                if (!frm.Initilize(voucherID)) return false;
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


        private void VouhcersList_Load(object sender, EventArgs e)
        {
            if (!isInitialized)
            {
                this.Close();
                return;
            }

            _IsHeaderCreated = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = "1";
            lblNoRecordsFoundMessage.Visible = false;
            lblUserMessage.Visible = false;
            gcbFilterBy.SelectedIndex = 0;
        }

        private async void frmVoucherList_Shown(object sender, EventArgs e)
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
            _AddNewVoucher();
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

            enTextSearchMode textSearchMode = enTextSearchMode.WordsPrefix_Fast;

            if (grbTextSearchMode_WordsPrefix.Checked)
                textSearchMode = enTextSearchMode.WordsPrefix_Fast;
            else if (grbTextSearchMode_SubString.Checked)
                textSearchMode = enTextSearchMode.Substring_Slow;

            bool filterByCreatedDate = false;

            if (gcbFilterByDate.Text == "تاريخ الإنشاء")
            {
                filterByCreatedDate = true;
            }
            else if (gcbFilterByDate.Text == "تاريخ المستند")
                filterByCreatedDate = false;
            else
                return;


            var filterDTO = new FinVoucherFilterDTO();
            filterDTO.IsByCreatedDate = filterByCreatedDate;
            filterDTO.FromDateString = kgtxtFromData.ValidatedText;
            filterDTO.ToDateString = kgtxtToDate.ValidatedText;
            filterDTO.VoucherType = _voucherType;
            filterDTO.TextSearchMode = textSearchMode;

            if (_filterBy == enFilterBy.All || string.IsNullOrEmpty(kgtxtFilterValue.ValidatedText))
            {

            }
            else if (_filterBy == enFilterBy.VoucherID)
            {
                int voucherID = Convert.ToInt32(kgtxtFilterValue.ValidatedText);
                filterDTO.VoucherID = voucherID;
            }
            else if (_filterBy == enFilterBy.VoucherName)
            {
                string voucherName = kgtxtFilterValue.ValidatedText;
                filterDTO.VoucherName = voucherName;
            }
            else if (_filterBy == enFilterBy.UserName)
            {
                string userName = kgtxtFilterValue.ValidatedText;
                filterDTO.UserName = userName;
            }
            else
                return;

            var result = await _finVoucherApi.GetAll(filterDTO, Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || result.Data is null)
            {
                _messageBoxService.DisplayError(result.ErrorMessage);
                return;
            }

            DataTable dt = _dataConverter.ToDataTable<FinVoucherExportSummary>(result.Data);

            dt.Columns[nameof(FinVoucherExportSummary.VoucherID)].ColumnName = "معرف المستند";
            dt.Columns[nameof(FinVoucherExportSummary.VoucherName)].ColumnName = "اسم المستند";
            dt.Columns[nameof(FinVoucherExportSummary.VoucherValue)].ColumnName = "قيمة المستند";
            dt.Columns[nameof(FinVoucherExportSummary.TransactionsCount)].ColumnName = "عدد المعاملات";
            dt.Columns[nameof(FinVoucherExportSummary.VoucherDate)].ColumnName = "تاريخ المستند";
            dt.Columns[nameof(FinVoucherExportSummary.CreatedDate)].ColumnName = "تاريخ الإنشاء";
            dt.Columns[nameof(FinVoucherExportSummary.CreatedByUserID)].ColumnName = "معرف المستخدم المنشئ";
            dt.Columns[nameof(FinVoucherExportSummary.CreatedByUserName)].ColumnName = "اسم المستخدم المنشئ";
            dt.Columns[nameof(FinVoucherExportSummary.AccountID)].ColumnName = "معرف الحساب";

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

            await _exportWithDialogService.ExportToExcel(dt, $"تقرير مستندات {vouchersTypeName}");
        }

    }
}
