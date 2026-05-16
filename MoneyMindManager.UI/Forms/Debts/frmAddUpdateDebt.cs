using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using KhaledControlLibrary1;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Shared.DTOs.Debt;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Income_And_Expense.Categories;
using MoneyMindManager_Presentation.People;
using MoneyMindManager_Presentation.Users;

namespace MoneyMindManager_Presentation.Income_And_Expense.Vouchers
{
    public partial class frmAddUpdateDebt : Form
    {
        private readonly IUserSession _userSession;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IFormDisplayer _formDisplayer;
        private readonly IDebtPaymentApiClient _debtPaymentApi;
        private readonly IDebtEntryApiClient _debtEntryApi;
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
            IDebtPaymentApiClient debtPaymentApiClient,IDebtEntryApiClient debtEntryApiClient, IDebtApiClient debtApiClient, IDataConverter dataConverter,
            IExportWithDialogService exportWithDialogService, IFormateHelper formateHelper)
        {
            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._formDisplayer = formDisplayer;
            this._debtPaymentApi = debtPaymentApiClient;
            this._debtEntryApi = debtEntryApiClient;
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

            this.SetStyle(ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        public bool Initialize(int debtID)
        {
            if (!ctrDebtPaymentsList1.Initialize(_userSession, _messageBoxService, _formDisplayer,
                _debtPaymentApi, _dataConverter, _exportWithDialogService))
                return false;

            if (!ctrDebtEntriesList1.Initialize(_userSession, _messageBoxService, _formDisplayer,
               _debtEntryApi, _dataConverter, _exportWithDialogService))
                return false;

            this.isInitialized = true;
            this._DebtMode = enDebtMode.Update;
            this._DebtID = debtID;

            return true;
        }
        public bool Initialize()
        {
            if (!ctrDebtPaymentsList1.Initialize(_userSession, _messageBoxService, _formDisplayer,
                _debtPaymentApi, _dataConverter, _exportWithDialogService))
                return false;

            if (!ctrDebtEntriesList1.Initialize(_userSession, _messageBoxService, _formDisplayer,
                _debtEntryApi, _dataConverter, _exportWithDialogService))
                return false;

            this.isInitialized = true;
            return true;
        }

        bool _CheckPermissions()
        {
            if (_userSession.IsHasPermissions(enPermissions.AddUpdateDebt_DebtTransactions))
                return true;

            _messageBoxService.DisplayError("ليس لديك صلاحية إضافة/تعديل (سندات - معاملات سداد) الديون.");
            return false;
        }

        bool _LockingChangingEvent = false;

        async Task<bool> LoadDebtData()
        {
            var result = await _debtApi.Get(Convert.ToInt32(_DebtID), Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || result.Data is null)
            {
                _messageBoxService.DisplayError("فشل تحميل بيانات مستند الدين\n" + result.ErrorMessage);
                this.Close();
                return false;
            }

            var searchedDebt = result.Data;
            this._Debt = searchedDebt;
            this._PersonID = _Debt.PersonID;

            kgtxtPersonName.Text = _Debt.PersonInfo?.PersonName;
            kgtxtNotes.Text = _Debt.Notes;
            kgtxtDebtDate.RefreshNumber_DateTimeFormattedText(_Debt.DebtDate.ToString());
            kgtxtPaymentDueDate.RefreshNumber_DateTimeFormattedText(_Debt.PaymentDueDate?.ToString());
            kgtxtCreatedDate.RefreshNumber_DateTimeFormattedText(_Debt.CreatedDate.ToString());
            kgtxtRemainingAmount.RefreshNumber_DateTimeFormattedText(_Debt.RemainingAmount.ToString());
            kgtxtTotalValue.RefreshNumber_DateTimeFormattedText(_Debt.TotalValue.ToString());
            kgtxtTotalPaid.RefreshNumber_DateTimeFormattedText(_Debt.TotalPaid.ToString());
            kgtxtCreatedByUserName.Text = _Debt?.CreatedByUserName;
            kgtxtDebtID.Text = _Debt.DebtID?.ToString();
            gcbDebtType.SelectedIndex = (_Debt.IsLending) ? (int)enDebtType.إقراض : (int)enDebtType.إقتراض;
            _LockingChangingEvent = false;
            gchkIsLocked.Checked = _Debt.IsLocked;
            _LockingChangingEvent = true;

            ctrDebtPaymentsList1.IsLocked = _Debt.IsLocked;
            ctrDebtPaymentsList1._Debt = _Debt;

            ctrDebtEntriesList1.IsLocked = _Debt.IsLocked;
            ctrDebtEntriesList1._Debt = _Debt;

            return true;
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
                _ChangeEnablityForButton(gbtnSave, true);
                lblUserMessage.Visible = false;
            }

            ctrDebtPaymentsList1.IsLocked = isLocked;
            ctrDebtEntriesList1.IsLocked = isLocked;
            gibtnDeleteDebt.Enabled = !isLocked;
        }

        void _ChangeEnablityForButton(Guna2Button btn, bool value)
        {
            btn.Enabled = value;
        }

        void _AddNewMode()
        {
            ChangeHeaderValue("إضافة مستند دين");

            _Debt = new DebtDTO();
            _DebtID = null;
            _PersonID = null;
            _ResetObject();
            kgtxtPersonName.Text = null;
            kgtxtNotes.Text = null;

            kgtxtDebtDate.RefreshNumber_DateTimeFormattedText((_userSession.CurrentUserSettings.Debts_TodayAsDefaultDate) ? DateTime.Today.ToString() : null);

            kgtxtPaymentDueDate.Text = null;
            kgtxtCreatedDate.Text = null;

            kgtxtRemainingAmount.Text = null;
            kgtxtTotalValue.Text = null;
            kgtxtTotalPaid.Text = null;
            kgtxtCreatedByUserName.Text = null;

            gcbDebtType.Enabled = true;
            kgtxtDebtID.Text = null;
            // settings
            gchkIsLocked.Checked = false;
            kgtxtPersonName.Focus();


            //gibtnNextPage.Enabled = false;
            //gibtnPreviousPage.Enabled = false;
            //kgtxtPageNumber.Enabled = false;

            //lblNoTransactionsFoundMessage.Visible = true;
            gibtnDeleteDebt.Enabled = false;
        }

        void _UpdateModeChangesAtUi()
        {
            ChangeHeaderValue("تعديل بيانات مستند الدين");
            gcbDebtType.Enabled = false;
            LockAndUnLockMode(_Debt.IsLocked);
        }

        async Task _UpdateMode()
        {
            if (!await LoadDebtData())
                return;

            _UpdateModeChangesAtUi();

            await ctrDebtPaymentsList1.LoadData(_Debt);
            await ctrDebtEntriesList1.LoadData(_Debt);
        }

        async Task _Save()
        {
            if ((_Debt.IsLocked && _DebtMode == enDebtMode.Update) || !gbtnSave.Enabled)
            {
                lblUserMessage.Text = "مستند الدين هذا مغلق لايمكن التعديل عليه";
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

            string notes = kgtxtNotes.ValidatedText;
            DateTime debtDate = Convert.ToDateTime(kgtxtDebtDate.ValidatedText);

            _Debt.Notes = notes;
            _Debt.DebtDate = debtDate;

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

                _messageBoxService.Display($"تم إضافة مستند الدين بنجاج بمعرف [{_Debt.DebtID}]", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _DebtMode = enDebtMode.Update;
                _DebtID = _Debt.DebtID;

                kgtxtCreatedByUserName.Text = _Debt?.CreatedByUserName;
                kgtxtCreatedDate.RefreshNumber_DateTimeFormattedText(_Debt.CreatedDate.ToString());
                kgtxtDebtID.Text = _Debt.DebtID?.ToString();

                _UpdateModeChangesAtUi();

                kgtxtRemainingAmount.RefreshNumber_DateTimeFormattedText(_Debt.RemainingAmount.ToString());
                kgtxtTotalValue.RefreshNumber_DateTimeFormattedText(_Debt.TotalValue.ToString());
                kgtxtTotalPaid.RefreshNumber_DateTimeFormattedText(_Debt.TotalPaid.ToString());
                _isSaved = true;
            }
            else if (_DebtMode == enDebtMode.Update)
            {
                var result = await _debtApi.Update(_Debt, Convert.ToInt32(_userSession.UserID));

                if (!result.IsSuccess || !result.Data.UpdateResult)
                {
                    _messageBoxService.DisplayError("فشل تحديث مستند الدين\n" + result.ErrorMessage);
                    return;
                }

                //_Debt.RemainingAmount = result.Data.RemainingAmount;

                _messageBoxService.Display("تم تعديل بيانات مستند الدين بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //kgtxtRemainingAmount.RefreshNumber_DateTimeFormattedText(_Debt.RemainingAmount.ToString());
                //kgtxtTotalValue.RefreshNumber_DateTimeFormattedText(_Debt.TotalValue.ToString());
                //kgtxtTotalPaid.RefreshNumber_DateTimeFormattedText(_Debt.TotalPaid.ToString());
                _isSaved = true;
            }

        }

        void _ResetObject()
        {
            _Debt = new DebtDTO();
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
            _SetReadOnlyAtTextBox(kgtxtTotalValue);
            _SetReadOnlyAtTextBox(kgtxtTotalPaid);
            _SetReadOnlyAtTextBox(kgtxtCreatedByUserName);
            _SetReadOnlyAtTextBox(kgtxtDebtID);


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
        private async void ctrDebtTransactions_OnLoading(decimal remainingAmount)
        {
            decimal totalValue = _Debt.TotalValue;
            decimal totalPaid = _Debt.TotalPaid;

            await LoadDebtData();

            if (_Debt.TotalValue != totalValue || _Debt.TotalPaid != totalPaid)
                _isSaved = true;
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


        private async void gibtnDeleteDebt_Click(object sender, EventArgs e)
        {
            if (_DebtID is null)
                return;

            if (_Debt != null && (_Debt.TotalValue > 0) || _Debt.TotalPaid > 0)
            {
                lblUserMessage.Text = "لتتمكن من حذف مسنتد الدين قم بحذف جميع المعاملات أولا !";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            if (_userSession.CurrentUserSettings.AskBeforeDeleteDebts)
                if (_messageBoxService.Display("هل أنت متأكد من رغبتك حذف مستند الدين ؟ ", "طلب موافقة", MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    return;

            var result = await _debtApi.Delete(Convert.ToInt32(_DebtID), Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || !result.Data)
            {
                _messageBoxService.DisplayError("فشل حذف سند مستند الدين\n" + result.ErrorMessage);
                return;
            }

            _isSaved = true;
            gbtnClose.PerformClick();
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
