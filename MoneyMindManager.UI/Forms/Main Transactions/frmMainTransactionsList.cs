using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KhaledControlLibrary1;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Shared.DTOs.MainTransaction;
using MoneyMindManager.Shared.DTOs.TransactionTypes;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Transactions;

namespace MoneyMindManager_Presentation.Income_And_Expense.Vouchers
{
    public partial class frmMainTransactionsList : Form
    {
        private IUserSession _userSession;
        private IMessageBoxService _messageBoxService;
        private IMainTransactionApiClient _mainTransactionApiClient;
        private IFormDisplayer _formDisplayer;
        private ITransactionTypeApiClient _transactionTypeApi;
        private IDataConverter _dataConverter;
        private IExportWithDialogService _exportWithDialogService;
        public frmMainTransactionsList(IUserSession userSession, IMessageBoxService messageBoxService, IMainTransactionApiClient mainTransactionApiClient
          , IFormDisplayer formDisplayer, ITransactionTypeApiClient transactionTypeApiClient, IDataConverter dataConverter, IExportWithDialogService exportWithDialogService)
        {
            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }

            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._mainTransactionApiClient = mainTransactionApiClient;
            this._formDisplayer = formDisplayer;
            this._transactionTypeApi = transactionTypeApiClient;
            this._dataConverter = dataConverter;
            this._exportWithDialogService = exportWithDialogService;

            InitializeComponent();
        }

        bool _CheckPermissions()
        {
            if (_userSession.IsHasPermissions(enPermissions.MainTransactionsList))
                return true;

            _messageBoxService.DisplayError("ليس لديك صلاحية قائمة المعاملات.");
            return false;
        }
        enum enFilterBy { All, TransactionID, UserName, Purpose };

        enFilterBy _filterBy = enFilterBy.All;

        bool _IsHeaderCreated = false;
        bool _searchByPageNumber = false;

        int _pageNumber = 1;

        void _SetForColorForLabels(KhaledLabel klbl, decimal amount)
        {
            if (amount > 0)
            {
                klbl.ForeColor = Color.Green;
            }
            else if (amount < 0)
            {
                klbl.ForeColor = Color.Red;
            }
            else
            {
                klbl.ForeColor = Color.Black;
            }
        }
        bool _CheckValidationChildren()
        {
            if (!ValidateChildren())
            {
                dgvTransactions.DataSource = null;
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

        List<int> _GetCheckedTransactionTypes()
        {
            List<int> selectedIDs = new List<int>();

            foreach (var item in chklbTransactionTypes.CheckedItems)
            {
                DataRowView rowView = item as DataRowView;

                if (rowView != null)
                {
                    object idValue = rowView["TransactionTypeID"];

                    if (int.TryParse(idValue?.ToString(), out int id))
                    {
                        selectedIDs.Add(id);
                    }
                }
            }

            return selectedIDs;
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
            else if (gcbFilterByDate.Text == "تاريخ المعاملة")
                filterByCreatedDate = false;
            else
                return;

            var transactionTypes = _GetCheckedTransactionTypes();

            var filterDTO = new MainTransactionPagedFilterDTO();
            if (filterBy == enFilterBy.All || string.IsNullOrEmpty(kgtxtFilterValue.ValidatedText))
            {
                filterDTO.TransactionTypes = transactionTypes;
                filterDTO.IsByCreatedDate = filterByCreatedDate;
                filterDTO.FromDateString = kgtxtFromDate.ValidatedText;
                filterDTO.ToDateString = kgtxtToDate.ValidatedText;
                filterDTO.TextSearchMode = textSearchMode;
                filterDTO.PageNumber = _pageNumber;
            }
            else if (filterBy == enFilterBy.TransactionID)
            {
                int transactionID = Convert.ToInt32(kgtxtFilterValue.ValidatedText);
                filterDTO.TransactionID = transactionID;
                filterDTO.TransactionTypes = transactionTypes;
                filterDTO.IsByCreatedDate = filterByCreatedDate;
                filterDTO.FromDateString = kgtxtFromDate.ValidatedText;
                filterDTO.ToDateString = kgtxtToDate.ValidatedText;
                filterDTO.TextSearchMode = textSearchMode;
                filterDTO.PageNumber = _pageNumber;
            }
            else if (filterBy == enFilterBy.UserName)
            {
                string userName = kgtxtFilterValue.ValidatedText;
                filterDTO.CreatedByUserName = userName;
                filterDTO.TransactionTypes = transactionTypes;
                filterDTO.IsByCreatedDate = filterByCreatedDate;
                filterDTO.FromDateString = kgtxtFromDate.ValidatedText;
                filterDTO.ToDateString = kgtxtToDate.ValidatedText;
                filterDTO.TextSearchMode = textSearchMode;
                filterDTO.PageNumber = _pageNumber;
            }
            else if (filterBy == enFilterBy.Purpose)
            {
                string purpose = kgtxtFilterValue.ValidatedText;
                filterDTO.Purpose = purpose;
                filterDTO.TransactionTypes = transactionTypes;
                filterDTO.IsByCreatedDate = filterByCreatedDate;
                filterDTO.FromDateString = kgtxtFromDate.ValidatedText;
                filterDTO.ToDateString = kgtxtToDate.ValidatedText;
                filterDTO.TextSearchMode = textSearchMode;
                filterDTO.PageNumber = _pageNumber;
            }
            else
                return;

            var result = await _mainTransactionApiClient.GetAllPaged(filterDTO, Convert.ToInt32(_userSession.UserID));

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
                dgvTransactions.DataSource = null;
                _IsHeaderCreated = false;
                _pageNumber = 1;
            }
            else
            {
                lblNoRecordsFoundMessage.Visible = false;
                dgvTransactions.DataSource = DTO.Data;
            }

            lblUserMessage.Visible = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = _pageNumber.ToString();
            _searchByPageNumber = true;

            lblTotalRecordsNumber.Text = DTO.TotalRecords.ToString();
            lblCurrentPageOfNumberOfPages.Text = string.Concat(_pageNumber, "   من   ", DTO.TotalPages, "  صفحات");
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = true;
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = (DTO.TotalPages < 1) ? 1 : DTO.TotalPages;
            lblCurrentPageRecordsCount.Text = dgvTransactions.Rows.Count.ToString();

            gibtnNextPage.Enabled = (_pageNumber < DTO.TotalPages);
            gibtnPreviousPage.Enabled = (_pageNumber > 1);

            klblAllTransactionsAmount.Text = DTO.TotalValue.ToString();
            klblCurrentPageTransactionsValue.Text = DTO.CurrentPageValue.ToString();

            _SetForColorForLabels(klblAllTransactionsAmount, DTO.TotalValue);
            _SetForColorForLabels(klblCurrentPageTransactionsValue, DTO.CurrentPageValue);

            if (!_IsHeaderCreated && dgvTransactions.Rows.Count > 0)
            {

                dgvTransactions.Columns[nameof(MainTransactionDTO.MainTransactionID)].HeaderText = "معرف المعاملة";
                dgvTransactions.Columns[nameof(MainTransactionDTO.MainTransactionID)].Width = 125;

                dgvTransactions.Columns[nameof(MainTransactionDTO.Amount)].HeaderText = "قيمة المعاملة";
                dgvTransactions.Columns[nameof(MainTransactionDTO.Amount)].Width = 215;
                dgvTransactions.Columns[nameof(MainTransactionDTO.Amount)].DefaultCellStyle.Format = "N2";

                dgvTransactions.Columns[nameof(MainTransactionDTO.TransactionDate)].HeaderText = "تاريخ المعاملة";
                dgvTransactions.Columns[nameof(MainTransactionDTO.TransactionDate)].Width = 115;
                dgvTransactions.Columns[nameof(MainTransactionDTO.TransactionDate)].DefaultCellStyle.Format = "dd-MM-yyyy";

                dgvTransactions.Columns[nameof(MainTransactionDTO.CreatedDate)].HeaderText = "تاريخ الإنشاء";
                dgvTransactions.Columns[nameof(MainTransactionDTO.CreatedDate)].Width = 190;
                dgvTransactions.Columns[nameof(MainTransactionDTO.CreatedDate)].DefaultCellStyle.Format = "hh:mm:ss tt dd-MM-yyyy";

                dgvTransactions.Columns[nameof(MainTransactionDTO.TransactionTypeName)].HeaderText = "نوع المعاملة";
                dgvTransactions.Columns[nameof(MainTransactionDTO.TransactionTypeName)].Width = 100;

                dgvTransactions.Columns[nameof(MainTransactionDTO.CreatedByUserName)].HeaderText = "اسم المستخدم المنشئ";
                dgvTransactions.Columns[nameof(MainTransactionDTO.CreatedByUserName)].Width = 265;

                dgvTransactions.Columns[nameof(MainTransactionDTO.Purpose)].HeaderText = "البيان";
                dgvTransactions.Columns[nameof(MainTransactionDTO.Purpose)].Width = 265;

                _IsHeaderCreated = true;

            }
        }

        void _ShowTransactionInfo()
        {
            if (dgvTransactions.SelectedRows.Count < 1)
                return;

            int transactionID = Convert.ToInt32(dgvTransactions.SelectedRows[0].Cells[0].Value);

            _formDisplayer.OpenAtContainer<frmMainTransactionInfo>(frm =>
            {
                return frm.Initilize(transactionID);
            });
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

        async Task _LoadTransactionTypes()
        {
            var result = await _transactionTypeApi.GetAll();

            if (!result.IsSuccess)
            {
                _messageBoxService.DisplayError(result.ErrorMessage);
                return;
            }

            // NOTE:
            // Sometimes Windows Forms throws a non-critical internal exception when assigning
            // a DataSource to checked list controls (like CheckedListBox).
            // This happens inconsistently and does NOT affect the execution or data binding.
            // The code continues to work normally, so this warning can be safely ignored.

            chklbTransactionTypes.DataSource = result.Data;
            chklbTransactionTypes.DisplayMember = nameof(TransactionTypeDTO.TransactionTypeName);
            chklbTransactionTypes.ValueMember = nameof(TransactionTypeDTO.TransactionTypeID);

            for (byte i = 0; i < chklbTransactionTypes.Items.Count; i++)
            {
                chklbTransactionTypes.SetItemChecked(i, true);
            }
        }
        private void frmMainTransactionsList_Load(object sender, EventArgs e)
        {
            _IsHeaderCreated = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = "1";
            lblNoRecordsFoundMessage.Visible = false;
            lblUserMessage.Visible = false;
            gcbFilterBy.SelectedIndex = 0;
        }

        private async void frmMainTransactionsList_Shown(object sender, EventArgs e)
        {
            await _LoadTransactionTypes();
            chklbTransactionTypes.ClearSelected();
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

            if (gcbFilterBy.Text == "معرف المعاملة")
            {
                _filterBy = enFilterBy.TransactionID;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
                kgtxtFilterValue.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
                kgtxtFilterValue.AllowWhiteSpace = false;
                kgtxtFilterValue.NumberProperties.IntegerNumberProperties.AllowNegative = false;
                kgtxtFilterValue.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            }
            else if (gcbFilterBy.Text == "اسم المستخدم")
            {
                _filterBy = enFilterBy.UserName;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
                kgtxtFilterValue.AllowWhiteSpace = false;
            }

            else if (gcbFilterBy.Text == "البيان")
            {
                _filterBy = enFilterBy.Purpose;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
                kgtxtFilterValue.AllowWhiteSpace = true;
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

        private void gtsmTransactionInfo_Click(object sender, EventArgs e)
        {
            _ShowTransactionInfo();
        }

        private void gdgvTransactions_DoubleClick(object sender, EventArgs e)
        {
            _ShowTransactionInfo();
        }

        private void gdgvVouchers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value)
            {
                e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.SelectionForeColor = Color.Orange;
            }
            else
            {
                if (e.ColumnIndex == 1)
                {
                    if (Convert.ToInt32(e.Value) > 0)
                    {
                        e.CellStyle.ForeColor = Color.Green;
                    }
                    else if (Convert.ToInt32(e.Value) < 0)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }


        private void chklbTransactionTypes_Leave(object sender, EventArgs e)
        {
            chklbTransactionTypes.ClearSelected();
        }


        private void chklbTransactionTypes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                _pageNumber = 1;
                SearchAfterTimerFinish.Stop();
                SearchAfterTimerFinish.Start();
            }
        }


        private void chklbTransactionTypes_MouseUp(object sender, MouseEventArgs e)
        {
            _pageNumber = 1;
            SearchAfterTimerFinish.Stop();
            SearchAfterTimerFinish.Start();
        }

        private async void gtsmExportExcel_Click(object sender, EventArgs e)
        {
            SearchAfterTimerFinish.Stop();

            if (!_CheckValidationChildren())
                return;

            if (dgvTransactions.Rows.Count < 1)
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
                filterByCreatedDate = true;
            else if (gcbFilterByDate.Text == "تاريخ المعاملة")
                filterByCreatedDate = false;
            else
                return;

            var transactionTypes = _GetCheckedTransactionTypes();

            var filterDTO = new MainTransactionFilterDTO();
            filterDTO.TransactionTypes = transactionTypes;
            filterDTO.IsByCreatedDate = filterByCreatedDate;
            filterDTO.FromDateString = kgtxtFromDate.ValidatedText;
            filterDTO.ToDateString = kgtxtToDate.ValidatedText;
            filterDTO.TextSearchMode = textSearchMode;

            if (_filterBy == enFilterBy.All || string.IsNullOrEmpty(kgtxtFilterValue.ValidatedText))
            {

            }
            else if (_filterBy == enFilterBy.TransactionID)
            {
                int transactionID = Convert.ToInt32(kgtxtFilterValue.ValidatedText);
                filterDTO.TransactionID = transactionID;
            }
            else if (_filterBy == enFilterBy.UserName)
            {
                string userName = kgtxtFilterValue.ValidatedText;
                filterDTO.CreatedByUserName = userName;
            }
            else if (_filterBy == enFilterBy.Purpose)
            {
                string purpose = kgtxtFilterValue.ValidatedText;
            }
            else
                return;

            var result = await _mainTransactionApiClient.GetAll(filterDTO, Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || result.Data is null)
            {
                _messageBoxService.DisplayError(result.ErrorMessage);
                return;
            }

            DataTable dt = _dataConverter.ToDataTable<MainTransactionDTO>(result.Data);

            dt.Columns[nameof(MainTransactionDTO.MainTransactionID)].ColumnName = "معرف المعاملة";
            dt.Columns[nameof(MainTransactionDTO.Amount)].ColumnName = "قيمة المعاملة";
            dt.Columns[nameof(MainTransactionDTO.TransactionDate)].ColumnName = "تاريخ المعاملة";
            dt.Columns[nameof(MainTransactionDTO.CreatedDate)].ColumnName = "تاريخ الإنشاء";
            dt.Columns[nameof(MainTransactionDTO.TransactionTypeID)].ColumnName = "معرف نوع المعاملة";
            dt.Columns[nameof(MainTransactionDTO.TransactionTypeName)].ColumnName = "نوع المعاملة";
            dt.Columns[nameof(MainTransactionDTO.CreatedByUserID)].ColumnName = "معرف المستخدم المنشئ";
            dt.Columns[nameof(MainTransactionDTO.CreatedByUserName)].ColumnName = "اسم المستخدم المنشئ";
            dt.Columns[nameof(MainTransactionDTO.Purpose)].ColumnName = "البيان";
            dt.Columns[nameof(MainTransactionDTO.AccountID)].ColumnName = "معرف الحساب";

            await _exportWithDialogService.ExportToExcel(dt, "تقرير المعاملات");
        }


        private void kgtxtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                gibtnRefreshData.PerformClick();
        }
    }
}
