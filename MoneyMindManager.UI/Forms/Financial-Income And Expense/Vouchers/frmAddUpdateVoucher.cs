using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using KhaledControlLibrary1;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Core.Models.FinTransaction;
using MoneyMindManager.Shared.DTOs.FinVoucher;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Income_And_Expense.Categories;
using MoneyMindManager_Presentation.Transactions;
using MoneyMindManager_Presentation.Users;

namespace MoneyMindManager_Presentation.Income_And_Expense.Vouchers
{
    public partial class frmAddUpdateVoucher : Form
    {
        private readonly IUserSession _userSession;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IFormDisplayer _formDisplayer;
        private readonly IFinTransactionApiClient _finTransactionApi;
        private readonly IFinVoucherApiClient _finVoucherApi;
        private readonly IDataConverter _dataConverter;
        private readonly IExportWithDialogService _exportWithDialogService;

        private bool isInitialized = false;
        public enum enVoucherMode { AddNew, Update };

        enVoucherMode _voucherMode;

        public event Action OnCloseAndSaved;

        bool _isSaved = false;

        FinVoucherDTO _Voucher;
        int? _VoucherID;

        //public enum enVoucherType { Incomes, Expenses, ExpensesReturn };
        enVoucherType _voucherType;

        public frmAddUpdateVoucher(IUserSession userSession, IMessageBoxService messageBoxService, IFormDisplayer formDisplayer,
            IFinTransactionApiClient finTransactionApiClient, IFinVoucherApiClient finVoucherApiClient, IDataConverter dataConverter, IExportWithDialogService exportWithDialogService)
        {
            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }

            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._formDisplayer = formDisplayer;
            this._finTransactionApi = finTransactionApiClient;
            this._finVoucherApi = finVoucherApiClient;
            this._dataConverter = dataConverter;
            this._exportWithDialogService = exportWithDialogService;

            InitializeComponent();
            this._voucherMode = enVoucherMode.AddNew;
            this._VoucherID = null;
            this._Voucher = null;
        }

        public bool Initialize(int voucherID)
        {
            this.isInitialized = true;
            this._voucherMode = enVoucherMode.Update;
            this._VoucherID = voucherID;
            return true;
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
            this._voucherMode = enVoucherMode.AddNew;
            return true;
        }

        bool _CheckPermissions()
        {
            if (_userSession.IsHasPermissions(enPermissions.AddUpdateIETVoucher_Transactions))
                return true;

            _messageBoxService.DisplayError("ليس لديك صلاحية إضافة/تعديل مستندات - معاملات (واردات - مصروفات - مرتجعات مصروفات)");
            return false;
        }

        bool _IsHeaderCreated = false;
        bool _searchByPageNumber = false;
        int _pageNumber = 1;
        bool _LockingChangingEvent = false;

        bool _CheckValidationChildren()
        {
            if (!ValidateChildren())
            {
                gdgvTransactions.DataSource = null;
                _IsHeaderCreated = false;
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

        async Task _LoadDataAtDataGridView()
        {
            if (!_CheckValidationChildren())
                return;


            //if (_pageNumber < 1)
            //    return;

            var result = await _finTransactionApi.GetAllPagedForVoucher(Convert.ToInt32(_Voucher.VoucherID), Convert.ToInt32(_userSession.UserID), _pageNumber);

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
                lblNoTransactionsFoundMessage.Visible = true;
                gdgvTransactions.DataSource = null;
                _IsHeaderCreated = false;
                _pageNumber = 1;
            }
            else
            {
                lblNoTransactionsFoundMessage.Visible = false;
                gdgvTransactions.DataSource = DTO.Data;
            }

            if (!_Voucher.IsLocked)
                lblUserMessage.Visible = false;

            _searchByPageNumber = false;
            kgtxtPageNumber.Text = _pageNumber.ToString();
            _searchByPageNumber = true;

            lblTotalRecordsNumber.Text = DTO.TotalRecords.ToString();
            lblCurrentPageOfNumberOfPages.Text = string.Concat(_pageNumber, "   من   ", DTO.TotalPages, "  صفحات");
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = true;
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = (DTO.TotalPages < 1) ? 1 : DTO.TotalPages;
            lblCurrentPageRecordsCount.Text = gdgvTransactions.Rows.Count.ToString();

            gibtnNextPage.Enabled = (_pageNumber < DTO.TotalPages);
            gibtnPreviousPage.Enabled = (_pageNumber > 1);


            if (!_IsHeaderCreated && gdgvTransactions.Rows.Count > 0)
            {
                gdgvTransactions.Columns[nameof(FinTransactionViewSummary.MainTransactionID)].HeaderText = "معرف المعاملة";
                gdgvTransactions.Columns[nameof(FinTransactionViewSummary.MainTransactionID)].Width = 125;

                gdgvTransactions.Columns[nameof(FinTransactionViewSummary.CategoryName)].HeaderText = "اسم الفئة";
                gdgvTransactions.Columns[nameof(FinTransactionViewSummary.CategoryName)].Width = 280;

                gdgvTransactions.Columns[nameof(FinTransactionViewSummary.Amount)].HeaderText = "المبلغ";
                gdgvTransactions.Columns[nameof(FinTransactionViewSummary.Amount)].Width = 250;
                gdgvTransactions.Columns[nameof(FinTransactionViewSummary.Amount)].DefaultCellStyle.Format = "N2";

                gdgvTransactions.Columns[nameof(FinTransactionViewSummary.CreatedDate)].HeaderText = "تاريخ الإنشاء";
                gdgvTransactions.Columns[nameof(FinTransactionViewSummary.CreatedDate)].Width = 235;
                gdgvTransactions.Columns[nameof(FinTransactionViewSummary.CreatedDate)].DefaultCellStyle.Format = "hh:mm:ss tt dd-MM-yyyy";

                gdgvTransactions.Columns[nameof(FinTransactionViewSummary.CreatedByUserName)].HeaderText = "اسم المستخدم المنشئ";
                gdgvTransactions.Columns[nameof(FinTransactionViewSummary.CreatedByUserName)].Width = 260;

                gdgvTransactions.Columns[nameof(FinTransactionViewSummary.Purpose)].HeaderText = "البيان";
                gdgvTransactions.Columns[nameof(FinTransactionViewSummary.Purpose)].Width = 250;

                _IsHeaderCreated = true;
            }

            kgtxtVoucherValue.RefreshNumber_DateTimeFormattedText(DTO.Value.ToString());

            this.Focus();
        }

        void ChangeHeaderValue(string txt)
        {
            this.Text = txt;
            lblHeader.Text = txt;
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

        void LockAndUnLockMode(bool isLocked)
        {
            if (isLocked)
            {
                _SetReadOnlyAtTextBox(kgtxtVoucherName);
                _SetReadOnlyAtTextBox(kgtxtNotes);
                _SetReadOnlyAtTextBox(kgtxtVoucherDate);
                _ChangeEnablityForButton(gbtnAddTransaction, false);
                _ChangeEnablityForButton(gbtnSave, false);
                lblUserMessage.Text = "المستند مغلق لايمكن التعديل عليه";
                lblUserMessage.Visible = true;
            }
            else
            {
                _CancelReadOnlyAtTextBox(kgtxtVoucherName);
                _CancelReadOnlyAtTextBox(kgtxtNotes);
                _CancelReadOnlyAtTextBox(kgtxtVoucherDate);
                _ChangeEnablityForButton(gbtnAddTransaction, true);
                _ChangeEnablityForButton(gbtnSave, true);
                lblUserMessage.Visible = false;
            }

            gibtnDeleteVoucher.Enabled = !isLocked;
        }

        void _ChangeEnablityForButton(Guna2Button btn, bool value)
        {
            btn.Enabled = value;
        }
        void _AddNewMode()
        {
            bool result = true;

            switch (_voucherType)
            {
                case enVoucherType.Incomes:
                    ChangeHeaderValue("إضافة مستند واردات");
                    result = _userSession.CurrentUserSettings.Income_TodayAsDefaultDate;
                    break;

                case enVoucherType.Expenses:
                    ChangeHeaderValue("إضافة مستند مصروفات");
                    result = _userSession.CurrentUserSettings.Expense_TodayAsDefaultDate;
                    break;

                case enVoucherType.ExpensesReturn:
                    ChangeHeaderValue("إضافة مستند مرتجع مصروفات");
                    result = _userSession.CurrentUserSettings.ExpenseReturn_TodayAsDefaultDate;
                    break;
            }

            _Voucher = new FinVoucherDTO();

            _VoucherID = null;
            _ResetObject();
            kgtxtVoucherName.Text = null;
            kgtxtNotes.Text = null;
            kgtxtVoucherDate.RefreshNumber_DateTimeFormattedText((result) ? DateTime.Today.ToString() : null);

            kgtxtVoucherValue.Text = null;
            kgtxtCreatedByUserName.Text = null;
            kgtxtCreatedDate.Text = null;
            kgtxtVoucherID.Text = null;

            gchkIsLocked.Checked = false;
            kgtxtVoucherName.Focus();

            _ChangeEnablityForButton(gbtnAddTransaction, false);

            gibtnNextPage.Enabled = false;
            gibtnPreviousPage.Enabled = false;
            kgtxtPageNumber.Enabled = false;

            lblNoTransactionsFoundMessage.Visible = true;
            gibtnDeleteVoucher.Enabled = false;
        }

        void _UpdateModeChangesAtUi()
        {
            switch (_voucherType)
            {
                case enVoucherType.Incomes:
                    ChangeHeaderValue("تعديل مستند إيرادات");
                    break;

                case enVoucherType.Expenses:
                    ChangeHeaderValue("تعديل مستند مصروفات");
                    break;

                case enVoucherType.ExpensesReturn:
                    ChangeHeaderValue("تعديل مستند مرتجعات مصروفات");
                    break;
            }

            LockAndUnLockMode(_Voucher.IsLocked);
        }

        async Task _UpdateMode()
        {
            var result = await _finVoucherApi.Get(Convert.ToInt32(_VoucherID), Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || result.Data is null)
            {
                _messageBoxService.DisplayError("فشل تحميل بيانات المستند\n" + result.ErrorMessage);
                this.Close();
                return;
            }

            var searchedVoucher = result.Data;


            this._Voucher = searchedVoucher;
            this._voucherType = _Voucher.VoucherType;

            _UpdateModeChangesAtUi();

            kgtxtVoucherName.Text = _Voucher.VoucherName;
            kgtxtNotes.Text = _Voucher.Notes;
            kgtxtVoucherDate.RefreshNumber_DateTimeFormattedText(_Voucher.VoucherDate.ToString());
            kgtxtVoucherValue.RefreshNumber_DateTimeFormattedText(_Voucher.VoucherValue.ToString());
            kgtxtCreatedByUserName.Text = _Voucher.UserInfo.UserName;
            kgtxtCreatedDate.RefreshNumber_DateTimeFormattedText(_Voucher.CreatedDate.ToString());
            kgtxtVoucherID.Text = _Voucher.VoucherID.ToString();
            _LockingChangingEvent = false;
            gchkIsLocked.Checked = _Voucher.IsLocked;
            _LockingChangingEvent = true;

            await _LoadDataAtDataGridView();
        }

        async Task _Save()
        {
            if ((_Voucher.IsLocked && _voucherMode == enVoucherMode.Update) || !gbtnSave.Enabled)
            {
                lblUserMessage.Text = "المستند مغلق لايمكن التعديل عليه";
                lblUserMessage.Visible = true;
                return;
            }

            gbtnSave.Enabled = false;

            lblUserMessage.Visible = false;

            if (!ValidateChildren())
            {
                _messageBoxService.ShowValidateChildrenFailedMessage();
                return;
            }

            _Voucher.VoucherName = kgtxtVoucherName.ValidatedText;
            _Voucher.Notes = kgtxtNotes.Text;
            _Voucher.VoucherDate = Convert.ToDateTime(kgtxtVoucherDate.ValidatedText);


            if (_voucherMode == enVoucherMode.AddNew)
            {
                _Voucher.VoucherType = _voucherType;
                _Voucher.IsLocked = gchkIsLocked.Checked;

                var result = await _finVoucherApi.Add(_Voucher, Convert.ToInt32(_userSession.UserID));

                if (!result.IsSuccess || result.Data is null)
                {
                    _messageBoxService.DisplayError(result.ErrorMessage);
                    _ResetObject();
                    return;
                }

                _Voucher = result.Data;

                _messageBoxService.Display($"تم إضافة المستند بنجاج بمعرف [{_Voucher.VoucherID}]", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _voucherMode = enVoucherMode.Update;
                _VoucherID = _Voucher.VoucherID;

                kgtxtVoucherValue.RefreshNumber_DateTimeFormattedText(_Voucher.VoucherValue.ToString());
                kgtxtCreatedByUserName.Text = _Voucher.UserInfo.UserName;
                kgtxtCreatedDate.RefreshNumber_DateTimeFormattedText(_Voucher.CreatedDate.ToString());
                kgtxtVoucherID.Text = _Voucher.VoucherID.ToString();

                _ChangeEnablityForButton(gbtnAddTransaction, true);

                _UpdateModeChangesAtUi();

                _isSaved = true;
            }
            else if (_voucherMode == enVoucherMode.Update)
            {
                var result = await _finVoucherApi.Update(_Voucher, Convert.ToInt32(_userSession.UserID));

                if (!result.IsSuccess || !result.Data)
                {
                    _messageBoxService.DisplayError("فشل تحديث المستند\n" + result.ErrorMessage);
                    return;
                }

                _messageBoxService.Display("تم تعديل بيانات المستند بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _isSaved = true;
            }
        }

        void _ResetObject()
        {
            _Voucher = new FinVoucherDTO();
        }

        void _AddTransaction()
        {
            if (!gbtnAddTransaction.Enabled || _VoucherID == null)
            {
                lblUserMessage.Text = "قم بإضافة مستند أولا ; لتتمكن من إضافة معاملة";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            _formDisplayer.OpenAtContainer<frmAddUpdateFinTransction>(frm =>
            {
                if (!frm.Initialize(_Voucher))
                    return false;
                frm.OnCloseAndSaved += FrmAddUpdateTransactions_OnCloseAndSaved;
                return true;
            });
        }

        void _EditTransaction()
        {
            if (gdgvTransactions.SelectedRows.Count < 1 || _VoucherID == null)
            {
                lblUserMessage.Text = "قم بإختيار معاملة أولا ; لتتمكن من تعديلها";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            int transactionID = Convert.ToInt32(gdgvTransactions.SelectedRows[0].Cells[0].Value);

            _formDisplayer.OpenAtContainer<frmAddUpdateFinTransction>(frm =>
            {
                if (!frm.Initialize(transactionID))
                    return false;
                frm.OnCloseAndSaved += FrmAddUpdateTransactions_OnCloseAndSaved;
                return true;
            });
        }

        void _ShowTransactionInfo()
        {
            if (gdgvTransactions.SelectedRows.Count < 1 || _VoucherID == null)
            {
                lblUserMessage.Text = "قم بإختيار معاملة أولا ; لتتمكن من رؤية معلوماتها";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            int transactionID = Convert.ToInt32(gdgvTransactions.SelectedRows[0].Cells[0].Value);

            _formDisplayer.OpenAtContainer<frmFinTransactionInfo>(frm =>
            {
                if (!frm.Initilize(transactionID))
                    return false;
                return true;
            });
        }

        private async void frmAddUpdateVoucher_Load(object sender, EventArgs e)
        {
            if (!isInitialized)
            {
                this.Close();
                return;
            }

            _SetReadOnlyAtTextBox(kgtxtVoucherValue);
            _SetReadOnlyAtTextBox(kgtxtCreatedByUserName);
            _SetReadOnlyAtTextBox(kgtxtCreatedDate);
            _SetReadOnlyAtTextBox(kgtxtVoucherID);

            //_ChangeEnablithForPagingControls(false);
            _IsHeaderCreated = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = "1";
            lblUserMessage.Visible = false;

            switch (_voucherMode)
            {
                case enVoucherMode.AddNew:
                    {
                        _AddNewMode();
                        break;
                    }
                case enVoucherMode.Update:
                    {
                        await _UpdateMode();
                        break;
                    }
            }

            _LockingChangingEvent = true;
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

        private void kgtxtPageNumber_OnValidationError(object sender, KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.CancelEventArgs.Cancel = true;
            errorProvider1.SetError(kgtxt, clsPL_Utils.GetValidationErrorTypeString(e.validationErrorType, kgtxt));
        }

        private void kgtxtPageNumber_OnValidationSuccess(object sender, CancelEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.Cancel = false;
            errorProvider1.SetError(kgtxt, null);
        }

        private void gbtnAddTransaction_Click(object sender, EventArgs e)
        {
            _AddTransaction();
        }

        private async void FrmAddUpdateTransactions_OnCloseAndSaved(int obj)
        {
            _pageNumber = 1;
            _isSaved = true;
            await _LoadDataAtDataGridView();
        }

        private async void gbtnSave_Click(object sender, EventArgs e)
        {
            await _Save();
            gbtnSave.Enabled = true;
        }

        private void gbtnClose_Click(object sender, EventArgs e)
        {
            if (_isSaved)
                OnCloseAndSaved?.Invoke();

            this.Close();
        }

        private void gtsmAddTransactions_Click(object sender, EventArgs e)
        {
            _AddTransaction();
        }

        private void gtsmEdit_Click(object sender, EventArgs e)
        {
            _EditTransaction();
        }

        private async void gchkIsLocked_CheckedChanged(object sender, EventArgs e)
        {
            if (this._voucherMode == enVoucherMode.Update && _LockingChangingEvent)
            {
                var result = await _finVoucherApi.ChangeLockingByID(Convert.ToInt32(_VoucherID), _Voucher.IsLocked, Convert.ToInt32(_userSession.UserID));

                if (!result.IsSuccess)
                {
                    _messageBoxService.DisplayError(result.ErrorMessage);
                    return;
                }

                if (result.Data)
                {
                    LockAndUnLockMode(_Voucher.IsLocked);
                }
                else
                {
                    _LockingChangingEvent = false;
                    gchkIsLocked.Checked = _Voucher.IsLocked;
                    _LockingChangingEvent = true;
                }
            }
        }

        private async void gtsmDelete_Click(object sender, EventArgs e)
        {
            if (gdgvTransactions.SelectedRows.Count < 1 || _VoucherID == null || _Voucher.IsLocked)
                return;

            bool asking = true;

            switch (_voucherType)
            {
                case enVoucherType.Incomes:
                    asking = _userSession.CurrentUserSettings.AskBeforeDeleteIncomeTransactions;
                    break;

                case enVoucherType.Expenses:
                    asking = _userSession.CurrentUserSettings.AskBeforeDeleteExpenseTransactions;
                    break;

                case enVoucherType.ExpensesReturn:
                    asking = _userSession.CurrentUserSettings.AskBeforeDeleteExpenseReturnTransactions;
                    break;
            }

            if (asking)
                if (_messageBoxService.Display("هل أنت متأكد من رغبتك حذف هذه المعاملة ؟ ", "طلب موافقة", MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    return;

            int transactionID = Convert.ToInt32(gdgvTransactions.SelectedRows[0].Cells[0].Value);

            var result = await _finTransactionApi.Delete(transactionID, Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || !result.Data)
            {
                _messageBoxService.DisplayError("فشل حذف المعاملة\n" + result.ErrorMessage);
                return;
            }

            _isSaved = true;
            _pageNumber = 1;
            await _LoadDataAtDataGridView();
        }

        private async void gibtnDeleteVoucher_Click(object sender, EventArgs e)
        {
            if (_VoucherID == null || gdgvTransactions.Rows.Count > 0)
            {
                lblUserMessage.Text = "لتتمكن من حذف المستند قم بحذف جميع المعاملات أولا !";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            bool asking = true;

            switch (_voucherType)
            {
                case enVoucherType.Incomes:
                    asking = _userSession.CurrentUserSettings.AskBeforeDeleteIncomeVoucher;
                    break;

                case enVoucherType.Expenses:
                    asking = _userSession.CurrentUserSettings.AskBeforeDeleteExpenseVoucher;
                    break;

                case enVoucherType.ExpensesReturn:
                    asking = _userSession.CurrentUserSettings.AskBeforeDeleteExpenseReturnVoucher;
                    break;
            }


            if (asking)
                if (_messageBoxService.Display("هل أنت متأكد من رغبتك حذف المستند ؟ ", "طلب موافقة", MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    return;


            var result = await _finVoucherApi.Delete(Convert.ToInt32(_VoucherID), Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || !result.Data)
            {
                _messageBoxService.DisplayError("فشل حذف المستند\n" + result.ErrorMessage);
                return;
            }

            _isSaved = true;
            gbtnClose.PerformClick();

        }

        private void gdgvTransactions_DoubleClick(object sender, EventArgs e)
        {
            _EditTransaction();
        }

        private void gdgvTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
            if (!_CheckValidationChildren())
                return;

            if (gdgvTransactions.Rows.Count < 1)
            {
                lblUserMessage.Text = "لا يوجد صفوف لتصديرها !";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            var result = await _finTransactionApi.GetAllForVoucher(Convert.ToInt32(_Voucher.VoucherID), Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || result.Data is null)
            {
                _messageBoxService.DisplayError(result.ErrorMessage);
                return;
            }

            DataTable dt = _dataConverter.ToDataTable<FinTransactionExportSummary>(result.Data);

            dt.Columns[nameof(FinTransactionExportSummary.MainTransactionID)].ColumnName = "معرف المعاملة";
            dt.Columns[nameof(FinTransactionExportSummary.CategoryID)].ColumnName = "معرف الفئة";
            dt.Columns[nameof(FinTransactionExportSummary.CategoryName)].ColumnName = "اسم الفئة";
            dt.Columns[nameof(FinTransactionExportSummary.Amount)].ColumnName = "المبلغ";
            dt.Columns[nameof(FinTransactionExportSummary.TransactionDate)].ColumnName = "تاريخ المعاملة";
            dt.Columns[nameof(FinTransactionExportSummary.CreatedDate)].ColumnName = "تاريخ الإنشاء";
            dt.Columns[nameof(FinTransactionExportSummary.CreatedByUserID)].ColumnName = "معرف المستخدم المنشئ";
            dt.Columns[nameof(FinTransactionExportSummary.CreatedByUserName)].ColumnName = "اسم المستخدم المنشئ";
            dt.Columns[nameof(FinTransactionExportSummary.Purpose)].ColumnName = "البيان";
            dt.Columns[nameof(FinTransactionExportSummary.AccountID)].ColumnName = "معرف الحساب";

            //

            string vouchersTypeName = null;

            switch (_voucherType)
            {
                case enVoucherType.Incomes:
                    vouchersTypeName = "واردات";
                    break;

                case enVoucherType.Expenses:
                    vouchersTypeName = "مصروفات";
                    break;

                case enVoucherType.ExpensesReturn:
                    vouchersTypeName = "مرتجعات مصروفات";
                    break;

                default:
                    vouchersTypeName = "";
                    break;
            }

            await _exportWithDialogService.ExportToExcel(dt, $"تقرير معاملات مستند {vouchersTypeName} [ {_VoucherID?.ToString()} ]");
        }

        private void gtsmTransactionInfo_Click(object sender, EventArgs e)
        {
            _ShowTransactionInfo();
        }

        private void kgtxtCreatedByUserName_IconRightClick(object sender, EventArgs e)
        {
            if (_VoucherID == null || _voucherMode == enVoucherMode.AddNew)
            {
                lblUserMessage.Text = "قم بإضافة مستند أولا";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            _formDisplayer.OpenAtContainer<frmUserInfo>(frm =>
            {
                return !frm.Initialize(Convert.ToInt32(_Voucher?.CreatedByUserID));
            });
        }
    }
}
