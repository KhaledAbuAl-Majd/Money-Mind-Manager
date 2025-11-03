using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KhaledControlLibrary1;
using MoneyMindManager_Business;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Properties;
using static MoneyMindManager_Business.clsIncomeAndExpenseVoucher;

namespace MoneyMindManager_Presentation.Income_And_Expense.Categories
{
    public partial class frmAddUpdateDebtPayment : Form
    {
        /// <summary>
        /// TransactionID
        /// </summary>
        public event Action<int> OnCloseAndSaved;

        int _DebtID { get; }

        bool _isSaved = false;

        //bool _isIncome;

        bool _isLocked;
        enum enMode { AddNew, Update };
        enMode Mode { get; set; }

        public frmAddUpdateDebtPayment(bool isLending, int debtId)
        {
            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }

            InitializeComponent();
            Mode = enMode.AddNew;
            this._DebtID = debtId;
            _TransactionID = null;
            _DebtPayment = new clsDebtPayment();
        }

        public frmAddUpdateDebtPayment(int transactionID)
        {
            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }

            InitializeComponent();
            Mode = enMode.Update;
            this._TransactionID = transactionID;
        }

        bool _CheckPermissions()
        {
            return clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.AddUpdateDebt_Payments,
                "ليس لديك صلاحية إضافة/تعديل (سندات - معاملات سداد) الديون.");
        }
        private int? _TransactionID { get; set; }

        private clsDebtPayment _DebtPayment { get; set; }

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
            _DebtPayment = new clsDebtPayment();
            lblTransactionID.Text = "N/A";
            kgtxtPaymentDate.RefreshNumber_DateTimeFormattedText((clsPL_Global.CurrentUserSettings.DebtPayments_TodayAsDefaultDate) ? DateTime.Today.ToString() : null);
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
            ChangeHeaderValue("تعديل بيانات معاملة سداد دين");

            var searchedDebtPayment = await clsDebtPayment.FindDebtPaymentByTransactionID(Convert.ToInt32(_TransactionID));

            if (searchedDebtPayment == null)
            {
                clsPL_MessageBoxs.ShowErrorMessage("فشل تحميل بيانات معاملة سداد الدين");
                this.Close();
                return;
            }

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
            _DebtPayment = new clsDebtPayment();
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
                if (!_DebtPayment.AssignDebtIDAtAddMode(_DebtID))
                {
                    clsPL_MessageBoxs.ShowErrorMessage("فشل تسجيل معرف سند الدين !");
                    _ResteObject();
                    return;
                }
            }


            if (await _DebtPayment.Save())
            {
                if (Mode == enMode.AddNew)
                {
                    clsPL_MessageBoxs.ShowMessage($"تم إضافة معاملة السداد بنجاج بمعرف [{_DebtPayment.MainTransactionID}]", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                }
                else if (Mode == enMode.Update)
                {
                    clsPL_MessageBoxs.ShowMessage("تم تعديل بيانات معاملة السداد بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _isSaved = true;
            }
            else if (Mode == enMode.AddNew)
                _ResteObject();
        }

        private async void frmAddUpdateIncomeAndExpenseTransaction_Load(object sender, EventArgs e)
        {
            lblUserMessage.Visible = false;

            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        ChangeHeaderValue("إضافة معاملة سداد دين");
                        gtswNewTransactionAfterAdd.Checked = clsPL_Global.CurrentUserSettings.DebtPayment_AutoAddNewDefault;

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

            if (clsPL_Global.CurrentUserSettings.AskBeforeDeleteDebtPayments)
                if (clsPL_MessageBoxs.ShowMessage("هل أنت متأكد من رغبتك حذف معاملة السداد هذه ؟ ", "طلب موافقة", MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    return;

            if (await clsDebtPayment.DeleteDebtPaymentByID(Convert.ToInt32(_TransactionID)))
            {
                _isSaved = true;
                gbtnClose.PerformClick();
            }
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblUserMessage_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gtswNewTransactionAfterAdd_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
