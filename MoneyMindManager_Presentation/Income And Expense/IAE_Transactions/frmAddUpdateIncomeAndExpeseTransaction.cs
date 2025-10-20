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

        int _VoucherID { get; }

        bool _isSaved = false;

        bool _isIncome;

        bool _isLocked;
        enum enMode { AddNew, Update };
        enMode Mode { get; set; }

        public frmAddUpdateIncomeAndExpeseTransction(bool isIncome,int voucherID)
        {
            InitializeComponent();
            Mode = enMode.AddNew;
            this._VoucherID = voucherID;
            _isIncome = isIncome;
            _TransactionID = null;
            _Transaction = new clsIncomeAndExpenseTransaction();
        }

        public frmAddUpdateIncomeAndExpeseTransction(int transactionID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            this._TransactionID = transactionID;
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
            int currentUserID = Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID);

            var searchedTransaction = await clsIncomeAndExpenseTransaction.FindTransactionByTransactionID(Convert.ToInt32(_TransactionID), currentUserID);

            if (searchedTransaction == null)
            {
                clsGlobalMessageBoxs.ShowErrorMessage("فشل تحميل بيانات المعاملة");
                this.Close();
                return;
            }

            //this._TransactionID = searchedTransaction.MainTransactionID;
            this._Transaction = searchedTransaction;
            this._isIncome = searchedTransaction.VouhcerInfo.IsIncome;
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

            var frm = new frmSelectCategory(Convert.ToBoolean(_isIncome));
            frm.OnCategorySelected += Frm_OnCategorySelected;
            //frm.ShowDialog(clsGlobal_UI.MainForm);
            clsGlobal_UI.MainForm.AddNewFormAsDialog(frm);
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
                clsGlobalMessageBoxs.ShowValidateChildrenFailedMessage();
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
                clsGlobalMessageBoxs.ShowErrorMessage("فشل تحويل معرف الفئة, برجاء التواصل مع منشئ البرنامج");
                _ResteObject();
                return;
            }

            _Transaction.Purpose = kgtxtPurpose.ValidatedText;
            _Transaction.Amount = Convert.ToDecimal(kgtxtAmount.ValidatedText);

            if (Mode == enMode.AddNew)
            {
                if (!_Transaction.AssignVoucherIDAtAddMode(_VoucherID))
                {
                    clsGlobalMessageBoxs.ShowErrorMessage("فشل تسجيل معرف المستند !");
                    _ResteObject();
                    return;
                }
            }


            if (await _Transaction.Save(Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID)))
            {
                if (Mode == enMode.AddNew)
                {
                    clsGlobalMessageBoxs.ShowMessage($"تم إضافة المعاملة بنجاج بمعرف [{_Transaction.MainTransactionID}]", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    clsGlobalMessageBoxs.ShowMessage("تم تعديل بيانات المعاملة بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string errorMessage = clsUtils.GetValidationErrorTypeString(e.validationErrorType, kgtxtBox);

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

            if (clsGlobalMessageBoxs.ShowMessage("هل أنت متأكد من رغبتك حذف المعاملة ؟ ", "طلب مواقفقة", MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (await clsIncomeAndExpenseTransaction.DeleteIncomeAndExpenseTransactionByID(Convert.ToInt32(_TransactionID), Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID)))
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
