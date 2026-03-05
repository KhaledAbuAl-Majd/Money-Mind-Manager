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
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Core.Models.DebtPayment;
using MoneyMindManager.Core.Models.FinTransaction;
using MoneyMindManager.Shared.DTOs.Debt;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Income_And_Expense.Categories;
using MoneyMindManager_Presentation.People;
using MoneyMindManager_Presentation.Transactions;
using MoneyMindManager_Presentation.Users;

namespace MoneyMindManager_Presentation.Income_And_Expense.Vouchers
{
    public partial class frmAddUpdateDebt : Form
    {
        private readonly IUserSession _userSession;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IFormDisplayer _formDisplayer;
        private readonly IDebtPaymentApiClient _debtPaymentApi;
        private readonly IDebtApiClient _debtApi;
        private readonly IDataConverter _dataConverter;
        private readonly IExportWithDialogService _exportWithDialogService;
        private IFormateHelper _formateHelper;

        private bool isInitialized = false;

        public enum enDebtMode { AddNew, Update };

        enDebtMode _DebtMode;

        public enum enDebtType { إقراض = 0, إقتراض = 1 };

        int? _PersonID;

        public event Action OnCloseAndSaved;

        bool _isSaved = false;

        DebtDTO _Debt;
        int? _DebtID;

        public frmAddUpdateDebt(IUserSession userSession, IMessageBoxService messageBoxService, IFormDisplayer formDisplayer,
            IDebtPaymentApiClient debtPaymentApiClient, IDebtApiClient debtApiClient, IDataConverter dataConverter,
            IExportWithDialogService exportWithDialogService, IFormateHelper formateHelper)
        {
            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._formDisplayer = formDisplayer;
            this._debtPaymentApi = debtPaymentApiClient;
            this._debtApi = debtApiClient;
            this._dataConverter = dataConverter;
            this._exportWithDialogService = exportWithDialogService;
            this._formateHelper = formateHelper;

            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }


            InitializeComponent();
            this._DebtMode = enDebtMode.AddNew;
            this._DebtID = null;
            this._Debt = null;
            this._PersonID = null;
        }

        public bool Initialize(int debtID)
        {
            this.isInitialized = true;
            this._DebtMode = enDebtMode.Update;
            this._DebtID = debtID;
            return true;
        }
        public bool Initialize()
        {
            this.isInitialized = true;
            return true;
        }

        bool _CheckPermissions()
        {
            if (_userSession.IsHasPermissions(enPermissions.AddUpdateDebt_Payments))
                return true;

            _messageBoxService.DisplayError("ليس لديك صلاحية إضافة/تعديل (سندات - معاملات سداد) الديون.");
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
                gdgvDebtPaymentTransctions.DataSource = null;
                _IsHeaderCreated = false;
                //lblNoTransactionsFoundMessage.Visible = true;
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

            var result = await _debtPaymentApi.GetAllPagedForDebt(Convert.ToInt32(_Debt.DebtID), Convert.ToInt32(_userSession.UserID), _pageNumber);

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
                gdgvDebtPaymentTransctions.DataSource = null;
                _IsHeaderCreated = false;
                _pageNumber = 1;
            }
            else
            {
                lblNoTransactionsFoundMessage.Visible = false;
                gdgvDebtPaymentTransctions.DataSource = DTO.Data;
            }

            if (!_Debt.IsLocked)
                lblUserMessage.Visible = false;

            _searchByPageNumber = false;
            kgtxtPageNumber.Text = _pageNumber.ToString();
            _searchByPageNumber = true;

            lblTotalRecordsNumber.Text = DTO.TotalRecords.ToString();
            lblCurrentPageOfNumberOfPages.Text = string.Concat(_pageNumber, "   من   ", DTO.TotalPages, "  صفحات");
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = true;
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = (DTO.TotalPages < 1) ? 1 : DTO.TotalPages;
            lblCurrentPageRecordsCount.Text = gdgvDebtPaymentTransctions.Rows.Count.ToString();

            gibtnNextPage.Enabled = (_pageNumber < DTO.TotalPages);
            gibtnPreviousPage.Enabled = (_pageNumber > 1);
            //

            if (!_IsHeaderCreated && gdgvDebtPaymentTransctions.Rows.Count > 0)
            {

                gdgvDebtPaymentTransctions.Columns[nameof(DebtPaymentViewSummary.MainTransactionID)].HeaderText = "معرف المعاملة";
                gdgvDebtPaymentTransctions.Columns[nameof(DebtPaymentViewSummary.MainTransactionID)].Width = 125;

                gdgvDebtPaymentTransctions.Columns[nameof(DebtPaymentViewSummary.Amount)].HeaderText = "المبلغ";
                gdgvDebtPaymentTransctions.Columns[nameof(DebtPaymentViewSummary.Amount)].Width = 250;
                gdgvDebtPaymentTransctions.Columns[nameof(DebtPaymentViewSummary.Amount)].DefaultCellStyle.Format = "N2";

                gdgvDebtPaymentTransctions.Columns[nameof(DebtPaymentViewSummary.DebtDate)].HeaderText = "تاريخ المعاملة";
                gdgvDebtPaymentTransctions.Columns[nameof(DebtPaymentViewSummary.DebtDate)].Width = 130;
                gdgvDebtPaymentTransctions.Columns[nameof(DebtPaymentViewSummary.DebtDate)].DefaultCellStyle.Format = "dd-MM-yyyy";

                gdgvDebtPaymentTransctions.Columns[nameof(DebtPaymentViewSummary.CreatedDate)].HeaderText = "تاريخ الإنشاء";
                gdgvDebtPaymentTransctions.Columns[nameof(DebtPaymentViewSummary.CreatedDate)].Width = 250;
                gdgvDebtPaymentTransctions.Columns[nameof(DebtPaymentViewSummary.CreatedDate)].DefaultCellStyle.Format = "hh:mm:ss tt dd-MM-yyyy";

                gdgvDebtPaymentTransctions.Columns[nameof(DebtPaymentViewSummary.CreatedByUserName)].HeaderText = "اسم المستخدم المنشئ";
                gdgvDebtPaymentTransctions.Columns[nameof(DebtPaymentViewSummary.CreatedByUserName)].Width = 250;

                gdgvDebtPaymentTransctions.Columns[nameof(DebtPaymentViewSummary.Purpose)].HeaderText = "البيان";
                gdgvDebtPaymentTransctions.Columns[nameof(DebtPaymentViewSummary.Purpose)].Width = 300;

                _IsHeaderCreated = true;
            }

            kgtxtRemainingAmount.RefreshNumber_DateTimeFormattedText(DTO.Value.ToString());

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
                _SetReadOnlyAtTextBox(kgtxtPersonName);
                _SetReadOnlyAtTextBox(kgtxtNotes);
                _SetReadOnlyAtTextBox(kgtxtDebtDate);
                _SetReadOnlyAtTextBox(kgtxtPaymentDueDate);
                _SetReadOnlyAtTextBox(kgtxtDebtValue);
                _ChangeEnablityForButton(gbtnAddDebtPaymentTransaction, false);
                _ChangeEnablityForButton(gbtnSave, false);
                lblUserMessage.Text = "سند الدين هذا مغلق لايمكن التعديل عليه";
                lblUserMessage.Visible = true;
            }
            else
            {
                _CancelReadOnlyAtTextBox(kgtxtPersonName);
                _CancelReadOnlyAtTextBox(kgtxtNotes);
                _CancelReadOnlyAtTextBox(kgtxtDebtDate);
                _CancelReadOnlyAtTextBox(kgtxtPaymentDueDate);
                _CancelReadOnlyAtTextBox(kgtxtDebtValue);
                _ChangeEnablityForButton(gbtnAddDebtPaymentTransaction, true);
                _ChangeEnablityForButton(gbtnSave, true);
                lblUserMessage.Visible = false;
            }

            gibtnDeleteDebt.Enabled = !isLocked;
        }

        void _ChangeEnablityForButton(Guna2Button btn, bool value)
        {
            btn.Enabled = value;
        }

        void _AddNewMode()
        {
            ChangeHeaderValue("إضافة سند دين");

            _Debt = new DebtDTO();
            _DebtID = null;
            _PersonID = null;
            _ResetObject();
            kgtxtPersonName.Text = null;
            kgtxtNotes.Text = null;

            kgtxtDebtDate.RefreshNumber_DateTimeFormattedText((_userSession.CurrentUserSettings.Debts_TodayAsDefaultDate) ? DateTime.Today.ToString() : null);

            kgtxtPaymentDueDate.Text = null;
            kgtxtCreatedDate.Text = null;

            kgtxtDebtValue.Text = null;
            kgtxtRemainingAmount.Text = null;
            kgtxtCreatedByUserName.Text = null;

            gcbDebtType.Enabled = true;
            kgtxtDebtID.Text = null;
            // settings
            gchkIsLocked.Checked = false;
            kgtxtPersonName.Focus();

            _ChangeEnablityForButton(gbtnAddDebtPaymentTransaction, false);

            gibtnNextPage.Enabled = false;
            gibtnPreviousPage.Enabled = false;
            kgtxtPageNumber.Enabled = false;

            lblNoTransactionsFoundMessage.Visible = true;
            gibtnDeleteDebt.Enabled = false;
        }

        void _UpdateModeChangesAtUi()
        {
            ChangeHeaderValue("تعديل بيانات سند دين");
            gcbDebtType.Enabled = false;
            LockAndUnLockMode(_Debt.IsLocked);
        }

        async Task _UpdateMode()
        {
            var result = await _debtApi.Get(Convert.ToInt32(_DebtID), Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || result.Data is null)
            {
                _messageBoxService.DisplayError("فشل تحميل بيانات السند\n" + result.ErrorMessage);
                this.Close();
                return;
            }

            var searchedDebt = result.Data;

            this._Debt = searchedDebt;
            this._PersonID = _Debt.PersonID;

            _UpdateModeChangesAtUi();

            kgtxtPersonName.Text = _Debt.PersonInfo?.PersonName;
            kgtxtNotes.Text = _Debt.Purpose;
            kgtxtDebtDate.RefreshNumber_DateTimeFormattedText(_Debt.TransactionDate.ToString());
            kgtxtPaymentDueDate.RefreshNumber_DateTimeFormattedText(_Debt.PaymentDueDate?.ToString());
            kgtxtCreatedDate.RefreshNumber_DateTimeFormattedText(_Debt.CreatedDate.ToString());
            kgtxtDebtValue.RefreshNumber_DateTimeFormattedText(_Debt.Amount.ToString());
            kgtxtRemainingAmount.RefreshNumber_DateTimeFormattedText(_Debt.RemainingAmount.ToString());
            kgtxtCreatedByUserName.Text = _Debt?.CreatedByUserName;
            kgtxtDebtID.Text = _Debt.DebtID?.ToString();
            gcbDebtType.SelectedIndex = (_Debt.IsLending) ? (int)enDebtType.إقراض : (int)enDebtType.إقتراض;
            _LockingChangingEvent = false;
            gchkIsLocked.Checked = _Debt.IsLocked;
            _LockingChangingEvent = true;

            await _LoadDataAtDataGridView();
        }

        async Task _Save()
        {
            if ((_Debt.IsLocked && _DebtMode == enDebtMode.Update) || !gbtnSave.Enabled)
            {
                lblUserMessage.Text = "سند الدين هذا مغلق لايمكن التعديل عليه";
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

            decimal amount = Convert.ToDecimal(kgtxtDebtValue.ValidatedText);
            string notes = kgtxtNotes.ValidatedText;
            DateTime debtDate = Convert.ToDateTime(kgtxtDebtDate.ValidatedText);

            _Debt.Amount = amount;
            _Debt.Purpose = notes;
            _Debt.TransactionDate = debtDate;

            _Debt.PaymentDueDate = _formateHelper.TryConvertToDateTime(kgtxtPaymentDueDate.ValidatedText);
            if (_DebtMode == enDebtMode.AddNew)
            {
                bool isLending = (gcbDebtType.SelectedIndex == (int)enDebtType.إقراض) ? true : false;

                _Debt.PersonID = Convert.ToInt32(_PersonID);
                _Debt.IsLending = isLending;
                _Debt.IsLocked = gchkIsLocked.Checked;

                var result = await _debtApi.Add(_Debt, Convert.ToInt32(_userSession.UserID));

                if (!result.IsSuccess || result.Data is null)
                {
                    _messageBoxService.DisplayError(result.ErrorMessage);
                    _ResetObject();
                    return;
                }

                _Debt = result.Data;

                _messageBoxService.Display($"تم إضافة سند الدين بنجاج بمعرف [{_Debt.DebtID}]", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _DebtMode = enDebtMode.Update;
                _DebtID = _Debt.DebtID;

                kgtxtCreatedByUserName.Text = _Debt?.CreatedByUserName;
                kgtxtCreatedDate.RefreshNumber_DateTimeFormattedText(_Debt.CreatedDate.ToString());
                kgtxtDebtID.Text = _Debt.DebtID?.ToString();

                _ChangeEnablityForButton(gbtnAddDebtPaymentTransaction, true);

                _UpdateModeChangesAtUi();

                kgtxtRemainingAmount.RefreshNumber_DateTimeFormattedText(_Debt.RemainingAmount.ToString());
                _isSaved = true;
            }
            else if (_DebtMode == enDebtMode.Update)
            {
                var result = await _debtApi.Update(_Debt, Convert.ToInt32(_userSession.UserID));

                if (!result.IsSuccess || !result.Data.UpdateResult)
                {
                    _messageBoxService.DisplayError("فشل تحديث سند الدين\n" + result.ErrorMessage);
                    return;
                }

                _Debt.RemainingAmount = result.Data.RemainingAmount;

                _messageBoxService.Display("تم تعديل بيانات السند بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                kgtxtRemainingAmount.RefreshNumber_DateTimeFormattedText(_Debt.RemainingAmount.ToString());
                _isSaved = true;
            }

        }

        void _ResetObject()
        {
            _Debt = new DebtDTO();
        }

        void _AddDebtPayment()
        {
            if (!gbtnAddDebtPaymentTransaction.Enabled || _DebtID == null)
            {
                lblUserMessage.Text = "قم بإضافة سند الدين أولا ; لتتمكن من إضافة معاملة سداد";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            _formDisplayer.OpenAtContainer<frmAddUpdateDebtPayment>(frm =>
            {
                if (!frm.Initialize(Convert.ToBoolean(_Debt.IsLending), Convert.ToInt32(_DebtID)))
                    return false;
                frm.OnCloseAndSaved += FrmAddUpdateDebtPayment_OnCloseAndSaved;
                return true;
            });
        }

        void _EditTransaction()
        {
            if (gdgvDebtPaymentTransctions.SelectedRows.Count < 1 || _DebtID == null)
            {
                lblUserMessage.Text = "قم بإختيار معاملة سداد أولا ; لتتمكن من تعديلها";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            int transactionID = Convert.ToInt32(gdgvDebtPaymentTransctions.SelectedRows[0].Cells[0].Value);

            _formDisplayer.OpenAtContainer<frmAddUpdateDebtPayment>(frm =>
            {
                if (!frm.Initialize(transactionID))
                    return false;
                frm.OnCloseAndSaved += FrmAddUpdateDebtPayment_OnCloseAndSaved;
                return true;
            });
        }

        void _ShowTransactionInfo()
        {
            if (gdgvDebtPaymentTransctions.SelectedRows.Count < 1 || _DebtID == null)
            {
                lblUserMessage.Text = "قم بإختيار معاملة سداد أولا ; لتتمكن من رؤية معلوماتها";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            int transactionID = Convert.ToInt32(gdgvDebtPaymentTransctions.SelectedRows[0].Cells[0].Value);

            _formDisplayer.OpenAtContainer<frmMainTransactionInfo>(frm =>
            {
                return frm.Initialize(transactionID);
            });
        }

        private async void frmAddUpdateVoucher_Load(object sender, EventArgs e)
        {
            if (!isInitialized)
            {
                this.Close();
                return;
            }

            _SetReadOnlyAtTextBox(kgtxtPersonName);
            _SetReadOnlyAtTextBox(kgtxtCreatedDate);
            _SetReadOnlyAtTextBox(kgtxtRemainingAmount);
            _SetReadOnlyAtTextBox(kgtxtCreatedByUserName);
            _SetReadOnlyAtTextBox(kgtxtDebtID);

            _IsHeaderCreated = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = "1";
            lblUserMessage.Visible = false;

            switch (_DebtMode)
            {
                case enDebtMode.AddNew:
                    {
                        _AddNewMode();
                        break;
                    }
                case enDebtMode.Update:
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

        private void kgtxt_OnValidationError(object sender, KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.CancelEventArgs.Cancel = true;
            errorProvider1.SetError(kgtxt, clsPL_Utils.GetValidationErrorTypeString(e.validationErrorType, kgtxt));
        }

        private void kgtxt_OnValidationSuccess(object sender, CancelEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.Cancel = false;
            errorProvider1.SetError(kgtxt, null);
        }

        private void gbtnAddTransaction_Click(object sender, EventArgs e)
        {
            _AddDebtPayment();
        }

        private async void FrmAddUpdateDebtPayment_OnCloseAndSaved(int obj)
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
            _AddDebtPayment();
        }

        private void gtsmEdit_Click(object sender, EventArgs e)
        {
            _EditTransaction();
        }

        private async void gchkIsLocked_CheckedChanged(object sender, EventArgs e)
        {
            if (this._DebtMode == enDebtMode.Update && _LockingChangingEvent)
            {
                bool isLocked = gchkIsLocked.Checked;
                var result = await _debtApi.ChangeLockingByID(Convert.ToInt32(_DebtID), isLocked, Convert.ToInt32(_userSession.UserID));

                if (!result.IsSuccess)
                {
                    _messageBoxService.DisplayError(result.ErrorMessage);
                    return;
                }

                if (result.Data)
                {
                    _Debt.IsLocked = isLocked;
                    LockAndUnLockMode(_Debt.IsLocked);
                }
                else
                {
                    _LockingChangingEvent = false;
                    gchkIsLocked.Checked = _Debt.IsLocked;
                    _LockingChangingEvent = true;
                }
            }
        }

        private async void gtsmDelete_Click(object sender, EventArgs e)
        {
            if (gdgvDebtPaymentTransctions.SelectedRows.Count < 1 || _DebtID == null || _Debt.IsLocked)
                return;

            if (_userSession.CurrentUserSettings.AskBeforeDeleteDebtPayments)
                if (_messageBoxService.Display("هل أنت متأكد من رغبتك حذف معاملة السداد هذه ؟ ", "طلب موافقة", MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    return;

            int transactionID = Convert.ToInt32(gdgvDebtPaymentTransctions.SelectedRows[0].Cells[0].Value);

            var result = await _debtPaymentApi.Delete(transactionID, Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || !result.Data)
            {
                _messageBoxService.DisplayError("فشل حذف المعاملة\n" + result.ErrorMessage);
                return;
            }
            _pageNumber = 1;
            _isSaved = true;
            await _LoadDataAtDataGridView();
        }
        private void gtsmTransactionInfo_Click(object sender, EventArgs e)
        {
            _ShowTransactionInfo();
        }

        private async void gibtnDeleteDebt_Click(object sender, EventArgs e)
        {
            if (_DebtID == null || gdgvDebtPaymentTransctions.Rows.Count > 0)
            {
                lblUserMessage.Text = "لتتمكن من حذف سند الدين قم بحذف جميع المعاملات أولا !";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            if (_userSession.CurrentUserSettings.AskBeforeDeleteDebts)
                if (_messageBoxService.Display("هل أنت متأكد من رغبتك حذف السند ؟ ", "طلب موافقة", MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    return;

            var result = await _debtApi.Delete(Convert.ToInt32(_DebtID), Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || !result.Data)
            {
                _messageBoxService.DisplayError("فشل حذف سند الدين\n" + result.ErrorMessage);
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

        private void kgtxtPersonName_SelectPerson_IconLeftClick(object sender, EventArgs e)
        {
            if (_DebtMode == enDebtMode.Update)
            {
                lblUserMessage.Text = "لا يمكن إختيار الشخص إلا في وضع الإضافة , لا يمكن تغيير الشخص";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            _formDisplayer.OpenDialog<frmSelectPerson>((frm) =>
            {
                frm.OnPersonSelected += FrmSelectPerson_OnPersonSelected;
                return true;
            });
        }

        private void FrmSelectPerson_OnPersonSelected(object sender, frmSelectPerson.SelectPersonEventArgs e)
        {
            kgtxtPersonName.Text = e.PersonName;
            this._PersonID = e.PersonID;
        }

        private void kgtxtPersonName_PersonInfo_IconRightClick(object sender, EventArgs e)
        {
            if (_PersonID == null)
            {
                lblUserMessage.Text = "قم بإختيار شخص أولا حتى تتمكن من رؤية بيانات الشخص";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            _formDisplayer.OpenAtContainer<frmPersonInfo>(frm =>
            {
                return frm.Initialize(Convert.ToInt32(_PersonID), false);
            });
        }

        private async void gtsmExportExcel_Click(object sender, EventArgs e)
        {
            if (!_CheckValidationChildren())
                return;

            if (gdgvDebtPaymentTransctions.Rows.Count < 1)
            {
                lblUserMessage.Text = "لا يوجد صفوف لتصديرها !";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            var result = await _debtPaymentApi.GetAllForDebt(Convert.ToInt32(_Debt.DebtID), Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || result.Data is null)
            {
                _messageBoxService.DisplayError(result.ErrorMessage);
                return;
            }

            DataTable dt = _dataConverter.ToDataTable<DebtPaymentExportSummary>(result.Data);

            dt.Columns[nameof(FinTransactionExportSummary.MainTransactionID)].ColumnName = "معرف المعاملة";
            dt.Columns[nameof(FinTransactionExportSummary.Amount)].ColumnName = "المبلغ";
            dt.Columns[nameof(FinTransactionExportSummary.TransactionDate)].ColumnName = "تاريخ المعاملة";
            dt.Columns[nameof(FinTransactionExportSummary.CreatedDate)].ColumnName = "تاريخ الإنشاء";
            dt.Columns[nameof(FinTransactionExportSummary.Purpose)].ColumnName = "البيان";
            dt.Columns[nameof(FinTransactionExportSummary.CreatedByUserID)].ColumnName = "معرف المستخدم المنشئ";
            dt.Columns[nameof(FinTransactionExportSummary.CreatedByUserName)].ColumnName = "اسم المستخدم المنشئ";
            dt.Columns[nameof(FinTransactionExportSummary.AccountID)].ColumnName = "معرف الحساب";

            await _exportWithDialogService.ExportToExcel(dt, $"تقرير معاملات سداد سند الدين [ {_DebtID?.ToString()} ]");
        }

        private void kgtxtCreatedByUserName_IconRightClick(object sender, EventArgs e)
        {
            if (_DebtID == null || _DebtMode == enDebtMode.AddNew)
            {
                lblUserMessage.Text = "قم بإضافة سند أولا";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            _formDisplayer.OpenAtContainer<frmUserInfo>(frm =>
            {
                return frm.Initialize(Convert.ToInt32(_Debt?.CreatedByUserID));
            });
        }
    }
}
