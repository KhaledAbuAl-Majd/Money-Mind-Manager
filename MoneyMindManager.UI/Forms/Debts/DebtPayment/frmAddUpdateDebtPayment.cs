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


namespace MoneyMindManager_Presentation.Income_And_Expense.Categories
{
    public partial class frmAddUpdateDebtPayment : Form
    {
        private readonly IUserSession _userSession;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IFormDisplayer _formDisplayer;
        private readonly IDebtPaymentApiClient _debtPaymentApi;
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

        public frmAddUpdateDebtPayment(IUserSession userSession, IMessageBoxService messageBoxService, IFormDisplayer formDisplayer,
            IDebtPaymentApiClient debtPaymentApiClient)
        {
            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }

            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._formDisplayer = formDisplayer;
            this._debtPaymentApi = debtPaymentApiClient;

            InitializeComponent();
            Mode = enMode.AddNew;
            _TransactionID = null;
            _DebtPayment = null;
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
            if (_userSession.IsHasPermissions(enPermissions.AddUpdateDebt_Payments))
                return true;

            _messageBoxService.DisplayError("ليس لديك صلاحية إضافة/تعديل (سندات - معاملات سداد) الديون.");
            return false;
        }
        private int? _TransactionID { get; set; }

        private DebtPaymentDTO _DebtPayment { get; set; }

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
                _SetReadOnlyAtTextBox(kgtxtPaymentDate);
                _SetReadOnlyAtTextBox(kgtxtPurpose);
                _SetReadOnlyAtTextBox(kgtxtAmount);

                ctrlInfoIcon_Status_IsLocked.IconImage = Resources.lock__1_;
                ctrlInfoIcon_Status_IsLocked.ToolTipText = "المعاملة مغلقة لايمكن التعديل عليها";
            }
            else
            {
                _CancelReadOnlyAtTextBox(kgtxtPaymentDate);
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
            _DebtPayment = new DebtPaymentDTO();
            lblTransactionID.Text = "N/A";
            kgtxtPaymentDate.RefreshNumber_DateTimeFormattedText((_userSession.CurrentUserSettings.DebtPayments_TodayAsDefaultDate) ? DateTime.Today.ToString() : null);
            kgtxtPurpose.Text = null;
            kgtxtAmount.Text = null;
            _isLocked = false;
            LockAndUnLockMode(_isLocked);
            ctrlInfoIcon_Status_IsLocked.Visible = false;
            gibtnDeleteTransaction.Enabled = false;
            kgtxtPaymentDate.Focus();
        }

        async Task _UpdateMode()
        {
            var transactionResult = await _debtPaymentApi.Get(Convert.ToInt32(_TransactionID), Convert.ToInt32(_userSession.UserID));

            if (!transactionResult.IsSuccess || transactionResult.Data is null)
            {
                _messageBoxService.DisplayError("فشل تحميل بيانات المعاملة\n" + transactionResult.ErrorMessage);
                this.Close();
                return;
            }

            ChangeHeaderValue("تعديل بيانات معاملة سداد دين");

            var searchedDebtPayment = transactionResult.Data;


            this._DebtPayment = searchedDebtPayment;

            lblTransactionID.Text = _DebtPayment.MainTransactionID.ToString();
            kgtxtPaymentDate.Text = _DebtPayment.TransactionDate.ToString();
            kgtxtPaymentDate.RefreshNumber_DateTimeFormattedText();
            kgtxtPurpose.Text = _DebtPayment?.Purpose;
            kgtxtAmount.Text = _DebtPayment.Amount.ToString();
            kgtxtAmount.RefreshNumber_DateTimeFormattedText();

            _isLocked = _DebtPayment.IsLocked;
            LockAndUnLockMode(_DebtPayment.IsLocked);

            gibtnDeleteTransaction.Enabled = !_DebtPayment.IsLocked;

            gtswNewTransactionAfterAdd.Checked = false;
            gtswNewTransactionAfterAdd.Enabled = false;
            gbtnNewTransaction.Enabled = false;
            this.Focus();
        }

        void _ResteObject()
        {
            _DebtPayment = new DebtPaymentDTO();
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
                clsPL_MessageBoxs.ShowValidateChildrenFailedMessage();
                lblUserMessage.Text = "تم العثور على حقول غير صالحة. ضع المؤشر على العلامات الحمراء لعرض سبب الخطأ.";
                lblUserMessage.Visible = true;
                return;
            }

            gbtnSave.Enabled = false;

            lblUserMessage.Visible = false;

            _DebtPayment.TransactionDate = Convert.ToDateTime(kgtxtPaymentDate.ValidatedText);
            _DebtPayment.Purpose = kgtxtPurpose.ValidatedText;
            _DebtPayment.Amount = Convert.ToDecimal(kgtxtAmount.ValidatedText);

            if (Mode == enMode.AddNew)
            {
                _DebtPayment.DebtID = _DebtID;

                var result = await _debtPaymentApi.Add(_DebtPayment, Convert.ToInt32(_userSession.UserID));

                if (!result.IsSuccess || result.Data is null)
                {
                    _messageBoxService.DisplayError(result.ErrorMessage);
                    _ResteObject();
                    return;
                }

                _DebtPayment = result.Data;

                _messageBoxService.Display($"تم إضافة معاملة السداد بنجاج بمعرف [{_DebtPayment.MainTransactionID}]", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (gtswNewTransactionAfterAdd.Checked && gtswNewTransactionAfterAdd.Enabled)
                {
                    gbtnNewTransaction.PerformClick();
                }
                else
                {
                    Mode = enMode.Update;
                    _TransactionID = _DebtPayment.MainTransactionID;
                    lblTransactionID.Text = _TransactionID.ToString();
                    ChangeHeaderValue("تعديل بيانات معاملة سداد دين");
                    gibtnDeleteTransaction.Enabled = !_DebtPayment.IsLocked;
                }

                _isSaved = true;
            }
            else if (Mode == enMode.Update)
            {
                var result = await _debtPaymentApi.Update(_DebtPayment, Convert.ToInt32(_userSession.UserID));

                if (!result.IsSuccess || !result.Data)
                {
                    _messageBoxService.DisplayError("فشل تحديث المعاملة\n" + result.ErrorMessage);
                    return;
                }

                _messageBoxService.Display("تم تعديل بيانات معاملة السداد بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                OnCloseAndSaved?.Invoke(Convert.ToInt32(_DebtPayment.MainTransactionID));

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
                if (_messageBoxService.Display("هل أنت متأكد من رغبتك حذف معاملة السداد هذه ؟ ", "طلب موافقة", MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    return;

            var result = await _debtPaymentApi.Delete(Convert.ToInt32(_TransactionID), Convert.ToInt32(_userSession.UserID));

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
