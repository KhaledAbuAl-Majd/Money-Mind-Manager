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
    public partial class frmAddUpdateIncomeAndExpeseTransction : Form
    {
        /// <summary>
        /// TransactionID
        /// </summary>
        public event Action<int> OnCloseAndSaved;

        //int _VoucherID { get; }

        bool _isSaved = false;
        bool _isLocked;

        //bool _isIncome;
        //bool _isReturn;
        clsIncomeAndExpenseVoucher _Voucher;
        enum enMode { AddNew, Update };
        enMode Mode { get; set; }

        public frmAddUpdateIncomeAndExpeseTransction(clsIncomeAndExpenseVoucher voucher)
        {
            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }

            if(voucher == null)
            {
                clsPL_MessageBoxs.ShowErrorMessage("المستند لا يمكن ان يكون بدون قيمة");
                this.Dispose();
                return;
            }

            InitializeComponent();
            Mode = enMode.AddNew;
            this._Voucher = voucher;
            _TransactionID = null;
            _Transaction = new clsIncomeAndExpenseTransaction();
        }

        public frmAddUpdateIncomeAndExpeseTransction(int transactionID)
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
            return clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.AddUpdateIETVoucher_Transactions,
                "ليس لديك صلاحية إضافة/تعديل مستندات - معاملات (واردات - مصروفات - مرتجعات مصروفات)");
        }

        private int? _TransactionID { get; set; }

        private clsIncomeAndExpenseTransaction _Transaction { get; set; }

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
            ChangeHeaderValue("إضافة معاملة");
            _TransactionID = null;
            _Transaction = new clsIncomeAndExpenseTransaction();
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
            ChangeHeaderValue("تعديل بيانات المعاملة");

            var searchedTransaction = await clsIncomeAndExpenseTransaction.FindTransactionByTransactionID(Convert.ToInt32(_TransactionID));

            if (searchedTransaction == null)
            {
                clsPL_MessageBoxs.ShowErrorMessage("فشل تحميل بيانات المعاملة");
                this.Close();
                return;
            }

            this._Transaction = searchedTransaction;

            this._Voucher = _Transaction.VouhcerInfo;

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
            _Transaction = new clsIncomeAndExpenseTransaction();
        }

        void _ShowChooseCategoryForm()
        {
            if (_isLocked)
                return;

            var frm = new frmSelectCategory(Convert.ToBoolean(_Voucher.IsIncome));
            frm.OnCategorySelected += Frm_OnCategorySelected;
            //frm.ShowDialog(clsGlobal_UI.MainForm);
            clsPL_Global.MainForm.AddNewFormAsDialog(frm);
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
                clsPL_MessageBoxs.ShowValidateChildrenFailedMessage();
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
                clsPL_MessageBoxs.ShowErrorMessage("فشل تحويل معرف الفئة, برجاء التواصل مع منشئ البرنامج");
                _ResteObject();
                return;
            }

            _Transaction.Purpose = kgtxtPurpose.ValidatedText;
            _Transaction.Amount = Convert.ToDecimal(kgtxtAmount.ValidatedText);



            if (Mode == enMode.AddNew)
            {
                if (!_Transaction.AssignVoucherIDAtAddMode(Convert.ToInt32(_Voucher.VoucherID)))
                {
                    clsPL_MessageBoxs.ShowErrorMessage("فشل تسجيل معرف المستند !");
                    _ResteObject();
                    return;
                }
            }

            _Transaction.TransactionDate = _Voucher.VoucherDate;

            bool isExceededBudget = false;

            if (!_Voucher.IsIncome)
            {
                if (await _Transaction.IsExceedCategoryMonthlyBudget(_Voucher.IsReturn))
                {
                    isExceededBudget = true;

                    if (clsPL_MessageBoxs.ShowMessage("بهذا المبلغ ستتخطى الميزانية الشهرية!. هل تود الإستمرار ؟",
                        "تحذير", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                        return;
                }
            }


            if (await _Transaction.Save(isExceededBudget))
            {
                if (Mode == enMode.AddNew)
                {
                    clsPL_MessageBoxs.ShowMessage($"تم إضافة المعاملة بنجاج بمعرف [{_Transaction.MainTransactionID}]", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (gtswNewTransactionAfterAdd.Checked)
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
                }
                else if (Mode == enMode.Update)
                {
                    clsPL_MessageBoxs.ShowMessage("تم تعديل بيانات المعاملة بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (clsPL_MessageBoxs.ShowMessage("هل أنت متأكد من رغبتك حذف المعاملة ؟ ", "طلب مواقفقة", MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (await clsIncomeAndExpenseTransaction.DeleteIncomeAndExpenseTransactionByID(Convert.ToInt32(_TransactionID)))
                {
                    _isSaved = true;
                    gbtnClose.PerformClick();
                }
            }
        }


        private void kgtxtCategoryName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                _ShowChooseCategoryForm();
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
