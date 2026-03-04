using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using KhaledControlLibrary1;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Shared.DTOs.FinTransaction;
using MoneyMindManager.Shared.DTOs.FinVoucher;
using MoneyMindManager.Shared.DTOs.IncomeAndExpenseCategory;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager.UI.Properties;
using MoneyMindManager_Presentation.Global;

namespace MoneyMindManager_Presentation.Income_And_Expense.Categories
{
    public partial class frmAddUpdateFinTransction : Form
    {
        private IUserSession _userSession;
        private IMessageBoxService _messageBoxService;
        private IFormDisplayer _formDisplayer;
        private IFinTransactionApiClient _finTransactionApi;
        private IFinVoucherApiClient _finVoucherApi;
        private IFinCategoryApiClient _finCategoryApi;
        private bool isInitialized = false;

        /// <summary>
        /// TransactionID
        /// </summary>
        public event Action<int> OnCloseAndSaved;

        //int _VoucherID { get; }

        bool _isSaved = false;
        bool _isLocked;

        //bool _isIncome;
        //bool _isReturn;
        FinVoucherDTO _Voucher;
        enum enMode { AddNew, Update };
        enMode Mode { get; set; }

        public frmAddUpdateFinTransction(IUserSession userSession, IMessageBoxService messageBoxService, IFormDisplayer formDisplayer,
            IFinTransactionApiClient finTransactionApiClient,IFinVoucherApiClient finVoucherApiClient,IFinCategoryApiClient finCategoryApiClient)
        {
            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._formDisplayer = formDisplayer;
            this._finTransactionApi = finTransactionApiClient;
            this._finVoucherApi = finVoucherApiClient;
            this._finCategoryApi = finCategoryApiClient;

            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }
            InitializeComponent();
            _TransactionID = null;
            _Transaction = null;
            _Voucher = null;
            Mode = enMode.AddNew;
        }

        public bool Initialize(int transactionID)
        {
            this.isInitialized = true;
            Mode = enMode.Update;
            this._TransactionID = transactionID;
            return true;
        }
        public bool Initialize(FinVoucherDTO voucher)
        {
            if (voucher is null)
                return false;

            this.isInitialized = true;
            this._Voucher = voucher;
            return true;
        }

        bool _CheckPermissions()
        {
            if (_userSession.IsHasPermissions(enPermissions.AddUpdateIETVoucher_Transactions))
                return true;

            _messageBoxService.DisplayError("ليس لديك صلاحية إضافة/تعديل مستندات - معاملات (واردات - مصروفات - مرتجعات مصروفات)");
            return false;
        }

        private int? _TransactionID { get; set; }

        private FinTransactionDTO _Transaction { get; set; }

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
                //_SetReadOnlyAtTextBox(kgtxtCategoryName);
                _SetReadOnlyAtTextBox(kgtxtPurpose);
                _SetReadOnlyAtTextBox(kgtxtAmount);

                ctrlInfoIcon_Status_IsLocked.IconImage = Resources.lock__1_;
                ctrlInfoIcon_Status_IsLocked.ToolTipText = "المعاملة مغلقة لايمكن التعديل عليها";
            }
            else
            {
                //_CancelReadOnlyAtTextBox(kgtxtCategoryName);
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
            _Transaction = new FinTransactionDTO();
            lblTransactionID.Text = "N/A";
            kgtxtCategoryName.Text = null;
            kgtxtCategoryName.Tag = null;
            kgtxtPurpose.Text = null;
            kgtxtAmount.Text = null;
            _isLocked = false;
            LockAndUnLockMode(_isLocked);
            ctrlInfoIcon_Status_IsLocked.Visible = false;
            gibtnDeleteTransaction.Enabled = false;
            kgtxtCategoryName.Focus();
        }

        async Task _UpdateMode()
        {
            var transactionResult = await _finTransactionApi.Get(Convert.ToInt32(_TransactionID), Convert.ToInt32(_userSession.UserID));

            if (!transactionResult.IsSuccess || transactionResult.Data is null)
            {
                _messageBoxService.DisplayError("فشل تحميل بيانات المعاملة\n" + transactionResult.ErrorMessage);
                this.Close();
                return;
            }

            var voucherResult = await _finVoucherApi.Get(Convert.ToInt32(transactionResult.Data.VoucherID), Convert.ToInt32(_userSession.UserID));

            if (!voucherResult.IsSuccess || voucherResult.Data is null)
            {
                _messageBoxService.DisplayError("فشل تحميل بيانات المستند\n" + voucherResult.ErrorMessage);
                this.Close();
                return;
            }

            var searchedTransaction = transactionResult.Data;
            var voucherInfo = voucherResult.Data;

            this._Transaction = searchedTransaction;

            this._Voucher = voucherInfo;

            switch (_Voucher.VoucherType)
            {
                case enVoucherType.Incomes:
                    ChangeHeaderValue("تعديل بيانات معاملة واردات");
                    break;

                case enVoucherType.Expenses:
                    ChangeHeaderValue("تعديل بيانات معاملة مصروفات");
                    break;

                case enVoucherType.ExpensesReturn:
                    ChangeHeaderValue("تعديل بيانات معاملة مرتجعات مصروفات");
                    break;
            }

            lblTransactionID.Text = _Transaction.MainTransactionID.ToString();
            kgtxtCategoryName.Text = _Transaction.CategoryInfo?.CategoryName;
            kgtxtCategoryName.Tag = _Transaction.CategoryID;
            kgtxtPurpose.Text = _Transaction?.Purpose;
            kgtxtAmount.Text = _Transaction.Amount.ToString();
            kgtxtAmount.RefreshNumber_DateTimeFormattedText();

            _isLocked = _Transaction.IsLocked;
            LockAndUnLockMode(_Transaction.IsLocked);

            gibtnDeleteTransaction.Enabled = !_Transaction.IsLocked;

            gtswNewTransactionAfterAdd.Checked = false;
            gtswNewTransactionAfterAdd.Enabled = false;
            gbtnNewTransaction.Enabled = false;
            this.Focus();
        }

        void _ResteObject()
        {
            _Transaction = new FinTransactionDTO();
        }

        void _ShowChooseCategoryForm()
        {
            if (_isLocked)
                return;

            _formDisplayer.OpenDialog<frmSelectCategory>(frm =>
            {
                if (!frm.Initialize(Convert.ToBoolean(Convert.ToBoolean(_Voucher.IsIncome))))
                    return false;
                frm.OnCategorySelected += Frm_OnCategorySelected;
                return true;
            });
        }
        async Task _Save()
        {
            if (_isLocked || !gbtnSave.Enabled)
            {
                lblUserMessage.Text = "المعاملة مغلقة لايمكن التعديل عليها";
                lblUserMessage.Visible = true;
                return;
            }

            gbtnSave.Enabled = false;

            if (!ValidateChildren())
            {
                _messageBoxService.ShowValidateChildrenFailedMessage();
                lblUserMessage.Text = "تم العثور على حقول غير صالحة. ضع المؤشر على العلامات الحمراء لعرض سبب الخطأ.";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            if (int.TryParse(kgtxtCategoryName.Tag?.ToString(), out int CategoryID))
            {
                _Transaction.CategoryID = CategoryID;
            }
            else
            {
                _messageBoxService.DisplayError("فشل تحويل معرف الفئة, برجاء التواصل مع منشئ البرنامج");
                _ResteObject();
                return;
            }

            _Transaction.Purpose = kgtxtPurpose.ValidatedText;
            _Transaction.Amount = Convert.ToDecimal(kgtxtAmount.ValidatedText);

            _Transaction.TransactionDate = _Voucher.VoucherDate;

            if (!_Voucher.IsIncome)
            {
                var isExeedResult = await _finCategoryApi.IsExceedMonthlyBudget(new BudgetCheckDTO(Convert.ToInt32(_Transaction.CategoryID),
               _Transaction.MainTransactionID, _Transaction.Amount, _Transaction.TransactionDate, _Voucher.IsReturn), Convert.ToInt32(_userSession.UserID));

                if (!isExeedResult.IsSuccess)
                {
                    _messageBoxService.DisplayError(isExeedResult.ErrorMessage);
                    return;
                }

                if (isExeedResult.Data)
                {

                    if (_messageBoxService.Display("بهذا المبلغ ستتخطى الميزانية الشهرية!. هل تود الإستمرار ؟",
                        "تحذير", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                        return;
                }
            }


            if (Mode == enMode.AddNew)
            {
                _Transaction.VoucherID = Convert.ToInt32(_Voucher.VoucherID);

                var result = await _finTransactionApi.Add(_Transaction, _Voucher.IsReturn, Convert.ToInt32(_userSession.UserID));

                if (!result.IsSuccess || result.Data is null)
                {
                    _messageBoxService.DisplayError(result.ErrorMessage);
                    _ResteObject();
                    return;
                }

                _Transaction = result.Data;
                _messageBoxService.Display($"تم إضافة المعاملة بنجاج بمعرف [{_Transaction.MainTransactionID}]", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (gtswNewTransactionAfterAdd.Checked && gtswNewTransactionAfterAdd.Enabled)
                {
                    gbtnNewTransaction.PerformClick();
                }
                else
                {
                    Mode = enMode.Update;
                    _TransactionID = _Transaction.MainTransactionID;
                    lblTransactionID.Text = _TransactionID.ToString();
                    ChangeHeaderValue("تعديل بيانات المعاملة");
                    gibtnDeleteTransaction.Enabled = !_Transaction.IsLocked;
                }

                _isSaved = true;
            }
            else if (Mode == enMode.Update)
            {
                var result = await _finTransactionApi.Update(_Transaction, Convert.ToInt32(_userSession.UserID));

                if (!result.IsSuccess || !result.Data)
                {
                    _messageBoxService.DisplayError("فشل تحديث المعاملة\n" + result.ErrorMessage);
                    return;
                }

                _messageBoxService.Display("تم تعديل بيانات المعاملة بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                        bool result = false;

                        switch (_Voucher.VoucherType)
                        {
                            case enVoucherType.Incomes:
                                result = _userSession.CurrentUserSettings.IncomeTransaction_AutoAddNewDefault;
                                ChangeHeaderValue("إضافة معاملة واردات");
                                break;

                            case enVoucherType.Expenses:
                                result = _userSession.CurrentUserSettings.ExpenseTransaction_AutoAddNewDefault;
                                ChangeHeaderValue("إضافة معاملة مصروفات");
                                break;

                            case enVoucherType.ExpensesReturn:
                                result = _userSession.CurrentUserSettings.ExpenseReturnTransaction_AutoAddNewDefault;
                                ChangeHeaderValue("إضافة معاملة مرتجعات مصروفات");
                                break;
                        }

                        gtswNewTransactionAfterAdd.Checked = result;

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
                OnCloseAndSaved?.Invoke(Convert.ToInt32(_Transaction.MainTransactionID));

            this.Close();
        }

        private void Frm_OnCategorySelected(object sender, frmSelectCategory.SelecteCategoryEventArgs e)
        {
            if (_isLocked)
                return;

            kgtxtCategoryName.Text = e.CategoryName;
            kgtxtCategoryName.Tag = e.CategoryID;
        }

        private void gbtnNewTransaction_Click(object sender, EventArgs e)
        {
            if (!gbtnNewTransaction.Enabled)
                return;

            Mode = enMode.AddNew;
            _AddNewMode();
        }

        private void gibtnChooseCategory_Click(object sender, EventArgs e)
        {
            _ShowChooseCategoryForm();
        }

        private async void gibtnDeleteTransaction_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.AddNew || _TransactionID == null)
                return;

            bool asking = true;

            switch (_Voucher.VoucherType)
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
                if (_messageBoxService.Display("هل أنت متأكد من رغبتك حذف المعاملة ؟ ", "طلب موافقة", MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    return;

            var result = await _finTransactionApi.Delete(Convert.ToInt32(_TransactionID), Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || !result.Data)
            {
                _messageBoxService.DisplayError("فشل حذف المعاملة\n" + result.ErrorMessage);
                return;
            }

            _isSaved = true;
            gbtnClose.PerformClick();
        }


        private void kgtxtCategoryName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                _ShowChooseCategoryForm();
            }
        }
    }
}
