using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using KhaledControlLibrary1;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Shared.DTOs.DebtPayment;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager.UI.Properties;
using MoneyMindManager_Presentation.Global;

namespace MoneyMindManager.UI.Forms.Debts.DebtEntry
{
    public partial class frmAddUpdateDebtEntry : Form
    {
        private readonly IUserSession _userSession;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IFormDisplayer _formDisplayer;
        private readonly IDebtEntryApiClient _debtEntryApi;
        private bool isInitialized = false;

        /// <summary>
        /// TransactionID
        /// </summary>
        public event Action<int> OnCloseAndSaved;

        int _DebtID { get; set; }

        bool _isSaved = false;

        //bool _isIncome;

        bool _isLocked;
        enum enMode { AddNew, Update };
        enMode Mode { get; set; }

        public frmAddUpdateDebtEntry(IUserSession userSession, IMessageBoxService messageBoxService, IFormDisplayer formDisplayer,
            IDebtEntryApiClient debtEntryApiClient)
        {
            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._formDisplayer = formDisplayer;
            this._debtEntryApi = debtEntryApiClient;
            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }


            InitializeComponent();
            Mode = enMode.AddNew;
            _TransactionID = null;
            _DebtEntry = null;
        }

        public bool Initialize(int transactionID)
        {
            this.isInitialized = true;
            Mode = enMode.Update;
            this._TransactionID = transactionID;
            return true;
        }
        public bool Initialize(bool isLending, int debtId)
        {
            this.isInitialized = true;
            this._DebtID = debtId;
            return true;
        }

        bool _CheckPermissions()
        {
            if (_userSession.IsHasPermissions(enPermissions.AddUpdateDebt_DebtTransactions))
                return true;

            _messageBoxService.DisplayError("ليس لديك صلاحية إضافة/تعديل (سندات - معاملات سداد) الديون.");
            return false;
        }
        private int? _TransactionID { get; set; }

        private DebtTransactionDTO _DebtEntry { get; set; }

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
                _SetReadOnlyAtTextBox(kgtxtDebtDate);
                _SetReadOnlyAtTextBox(kgtxtPurpose);
                _SetReadOnlyAtTextBox(kgtxtAmount);

                ctrlInfoIcon_Status_IsLocked.IconImage = Resources.lock__1_;
                ctrlInfoIcon_Status_IsLocked.ToolTipText = "المعاملة مغلقة لايمكن التعديل عليها";
            }
            else
            {
                _CancelReadOnlyAtTextBox(kgtxtDebtDate);
                _CancelReadOnlyAtTextBox(kgtxtPurpose);
                _CancelReadOnlyAtTextBox(kgtxtAmount);

                ctrlInfoIcon_Status_IsLocked.IconImage = Resources.unlocked__1_;
                ctrlInfoIcon_Status_IsLocked.ToolTipText = "المعاملة ليست مغلقة, يمكن التعديل عليها";
            }

            gbtnSave.Enabled = !isLocked;
        }

        void _AddNewMode()
        {
            _TransactionID = null;
            _DebtEntry = new DebtTransactionDTO();
            lblTransactionID.Text = "N/A";
            kgtxtDebtDate.RefreshNumber_DateTimeFormattedText((_userSession.CurrentUserSettings.DebtPayments_TodayAsDefaultDate) ? DateTime.Today.ToString() : null);
            kgtxtPurpose.Text = null;
            kgtxtAmount.Text = null;
            _isLocked = false;
            LockAndUnLockMode(_isLocked);
            ctrlInfoIcon_Status_IsLocked.Visible = false;
            gibtnDeleteTransaction.Enabled = false;
            kgtxtDebtDate.Focus();
            ChangeHeaderValue("إضافة معاملة سند دين");
        }

        async Task _UpdateMode()
        {
            var transactionResult = await _debtEntryApi.Get(Convert.ToInt32(_TransactionID), Convert.ToInt32(_userSession.UserID));

            if (!transactionResult.IsSuccess || transactionResult.Data is null)
            {
                _messageBoxService.DisplayError("فشل تحميل بيانات المعاملة\n" + transactionResult.ErrorMessage);
                this.Close();
                return;
            }

            ChangeHeaderValue("تعديل بيانات معاملة سند دين");

            var searchedDebtEntry = transactionResult.Data;


            this._DebtEntry = searchedDebtEntry;

            lblTransactionID.Text = _DebtEntry.MainTransactionID.ToString();
            kgtxtDebtDate.Text = _DebtEntry.TransactionDate.ToString();
            kgtxtDebtDate.RefreshNumber_DateTimeFormattedText();
            kgtxtPurpose.Text = _DebtEntry?.Purpose;
            kgtxtAmount.Text = _DebtEntry.Amount.ToString();
            kgtxtAmount.RefreshNumber_DateTimeFormattedText();

            _isLocked = _DebtEntry.IsLocked;
            LockAndUnLockMode(_DebtEntry.IsLocked);

            gibtnDeleteTransaction.Enabled = !_DebtEntry.IsLocked;

            gtswNewTransactionAfterAdd.Checked = false;
            gtswNewTransactionAfterAdd.Enabled = false;
            gbtnNewTransaction.Enabled = false;
            this.Focus();
        }

        void _ResteObject()
        {
            _DebtEntry = new DebtTransactionDTO();
        }

        async Task _Save()
        {
            if (_isLocked || !gbtnSave.Enabled)
            {
                lblUserMessage.Text = "المعاملة مغلقة لايمكن التعديل عليها";
                lblUserMessage.Visible = true;
                return;
            }

            if (!ValidateChildren())
            {
                _messageBoxService.ShowValidateChildrenFailedMessage();
                lblUserMessage.Text = "تم العثور على حقول غير صالحة. ضع المؤشر على العلامات الحمراء لعرض سبب الخطأ.";
                lblUserMessage.Visible = true;
                return;
            }

            gbtnSave.Enabled = false;

            lblUserMessage.Visible = false;

            _DebtEntry.TransactionDate = Convert.ToDateTime(kgtxtDebtDate.ValidatedText);
            _DebtEntry.Purpose = kgtxtPurpose.ValidatedText;
            _DebtEntry.Amount = Convert.ToDecimal(kgtxtAmount.ValidatedText);

            if (Mode == enMode.AddNew)
            {
                _DebtEntry.DebtID = _DebtID;

                var result = await _debtEntryApi.Add(_DebtEntry, Convert.ToInt32(_userSession.UserID));

                if (!result.IsSuccess || result.Data is null)
                {
                    _messageBoxService.DisplayError(result.ErrorMessage);
                    _ResteObject();
                    return;
                }

                _DebtEntry = result.Data;

                _messageBoxService.Display($"تم إضافة معاملة سند الدين بنجاج بمعرف [{_DebtEntry.MainTransactionID}]", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (gtswNewTransactionAfterAdd.Checked && gtswNewTransactionAfterAdd.Enabled)
                {
                    gbtnNewTransaction.PerformClick();
                }
                else
                {
                    Mode = enMode.Update;
                    _TransactionID = _DebtEntry.MainTransactionID;
                    lblTransactionID.Text = _TransactionID.ToString();
                    ChangeHeaderValue("تعديل بيانات معاملة سند دين");
                    gibtnDeleteTransaction.Enabled = !_DebtEntry.IsLocked;
                }

                _isSaved = true;
            }
            else if (Mode == enMode.Update)
            {
                var result = await _debtEntryApi.Update(_DebtEntry, Convert.ToInt32(_userSession.UserID));

                if (!result.IsSuccess || !result.Data)
                {
                    _messageBoxService.DisplayError("فشل تحديث المعاملة\n" + result.ErrorMessage);
                    return;
                }

                _messageBoxService.Display("تم تعديل بيانات معاملة سند الدين بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _isSaved = true;
            }
        }

        private async void frmAddUpdateIncomeAndExpenseTransaction_Load(object sender, EventArgs e)
        {
            if (!isInitialized)
            {
                this.Close();
                return;
            }

            lblUserMessage.Visible = false;

            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        ChangeHeaderValue("إضافة معاملة سداد دين");
                        gtswNewTransactionAfterAdd.Checked = _userSession.CurrentUserSettings.DebtPayment_AutoAddNewDefault;

                        _AddNewMode();
                        break;
                    }
                case enMode.Update:
                    {
                        await _UpdateMode();
                        break;
                    }
            }
        }

        private void kgtxt_OnValidationError(object sender, KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            KhaledGuna2TextBox kgtxtBox = (KhaledGuna2TextBox)sender;
            e.CancelEventArgs.Cancel = true;
            string errorMessage = clsPL_Utils.GetValidationErrorTypeString(e.validationErrorType, kgtxtBox);

            errorProvider1.SetError(kgtxtBox, errorMessage);
        }

        private void kgtxt_OnValidationSuccess(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            errorProvider1.SetError((KhaledGuna2TextBox)sender, null);
        }

        private async void gbtnSave_Click(object sender, EventArgs e)
        {
            await _Save();
            gbtnSave.Enabled = true;
        }

        private void gbtnClose_Click(object sender, EventArgs e)
        {
            if (_isSaved)
                OnCloseAndSaved?.Invoke(Convert.ToInt32(_DebtEntry.MainTransactionID));

            this.Close();
        }

        private void gbtnNewTransaction_Click(object sender, EventArgs e)
        {
            if (!gbtnNewTransaction.Enabled)
                return;

            Mode = enMode.AddNew;
            _AddNewMode();
        }

        private async void gibtnDeleteTransaction_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.AddNew || _TransactionID == null)
                return;

            if (_userSession.CurrentUserSettings.AskBeforeDeleteDebtPayments)
                if (_messageBoxService.Display("هل أنت متأكد من رغبتك حذف معاملة سند الدين هذه ؟ ", "طلب موافقة", MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    return;

            var result = await _debtEntryApi.Delete(Convert.ToInt32(_TransactionID), Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || !result.Data)
            {
                _messageBoxService.DisplayError("فشل حذف المعاملة\n" + result.ErrorMessage);
                return;
            }

            _isSaved = true;
            gbtnClose.PerformClick();
        }

    }
}
