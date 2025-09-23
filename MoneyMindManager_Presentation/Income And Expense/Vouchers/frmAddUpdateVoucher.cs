using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using KhaledControlLibrary1;
using MoneyMindManager_Business;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Income_And_Expense.Categories;
using MoneyMindManager_Presentation.Main;
using MoneyMindManagerGlobal;
using static Guna.UI2.Native.WinApi;
using static MoneyMindManager_Business.clsIncomeAndExpenseVoucher;

namespace MoneyMindManager_Presentation.Income_And_Expense.Vouchers
{
    public partial class frmAddUpdateVoucher : Form
    {
        public enum enVoucherMode { AddNew, Update };

        enVoucherMode _voucherMode;

        public event Action OnCloseAndSaved;

        bool _isSaved = false;

        clsIncomeAndExpenseVoucher _Voucher;
        int? _VoucherID;

        //public enum enVoucherType { Incomes, Expenses, ExpensesReturn };
        enVoucherType _voucherType;
        public frmAddUpdateVoucher(enVoucherType voucherType)
        {
            InitializeComponent();
            this._voucherType = voucherType;
            this._voucherMode = enVoucherMode.AddNew;
            this._VoucherID = null;
            this._Voucher = null;
        }

        public frmAddUpdateVoucher(int voucherID)
        {
            InitializeComponent();
            this._voucherMode = enVoucherMode.Update;
            this._VoucherID = voucherID;
        }

        bool _IsHeaderCreated = false;
        bool _searchByPageNumber = false;
        short _pageNumber = 1;

        bool _CheckValidationChildren()
        {
            if (!ValidateChildren())
            {
                gdgvPeople.DataSource = null;
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


            //if (_pageNumber < 1)
            //    return;

            int currentUserID = Convert.ToInt32(clsGlobal_UI.CurrentUser.UserID);

            var result = await _Voucher.GetVoucheTransactions(currentUserID, _pageNumber);


            if (result == null)
                return;

            if (result.dtTransactions.Rows.Count == 0)
            {
                lblNoTransactionsFoundMessage.Visible = true;
                gdgvPeople.DataSource = null;
                _IsHeaderCreated = false;
                _pageNumber = 1;
            }
            else
            {
                lblNoTransactionsFoundMessage.Visible = false;
                gdgvPeople.DataSource = result.dtTransactions;
            }

            lblUserMessage.Visible = false;

            lblTotalRecordsNumber.Text = result.RecordsCount.ToString();

            gibtnNextPage.Enabled = (_pageNumber < result.NumberOfPages);
            gibtnPreviousPage.Enabled = (_pageNumber > 1);
            //

            if (result.NumberOfPages < 2)
            {
                _ChangeEnablithForPagingControls(false);
            }
            else
            {
                _searchByPageNumber = false;
                kgtxtPageNumber.Text = _pageNumber.ToString();
                _searchByPageNumber = true;
                kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = true;
                kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = (result.NumberOfPages < 1) ? 1 : result.NumberOfPages;
                lblCurrentPageRecordsCount.Text = gdgvPeople.Rows.Count.ToString();
                lblCurrentPageOfNumberOfPages.Text = string.Concat(_pageNumber, "   من   ", result.NumberOfPages, "  صفحات");
                _ChangeEnablithForPagingControls(true);
            } 

            if (!_IsHeaderCreated && gdgvPeople.Rows.Count > 0)
            {
                gdgvPeople.Columns["MainTransactionID"].HeaderText = "معرف الفئة";
                gdgvPeople.Columns["MainTransactionID"].Width = 120;

                gdgvPeople.Columns["CategoryName"].HeaderText = "اسم الفئة";
                gdgvPeople.Columns["CategoryName"].Width = 290;

                gdgvPeople.Columns["Amount"].HeaderText = "المبلغ";
                gdgvPeople.Columns["Amount"].Width = 250;
                gdgvPeople.Columns["Amount"].DefaultCellStyle.Format = "N4";

                gdgvPeople.Columns["CreatedDate"].HeaderText = "تاريخ الإنشاء";
                gdgvPeople.Columns["CreatedDate"].Width = 250;
                gdgvPeople.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss tt";

                gdgvPeople.Columns["Purpose"].HeaderText = "البيان";
                gdgvPeople.Columns["Purpose"].Width = 250;

                _IsHeaderCreated = true;
            }
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

        void _ChangeEnablityForButton(Guna2Button btn,bool value)
        {
            btn.Enabled = value;
        }
        void _AddNewMode()
        {
            switch (_voucherType)
            {
                case enVoucherType.Incomes:
                    ChangeHeaderValue("إضافة مستند إيرادات");
                    break;

                case enVoucherType.Expenses:
                    ChangeHeaderValue("إضافة مستند مصروفات");
                    break;

                case enVoucherType.ExpensesReturn:
                    ChangeHeaderValue("إضافة مستند مرتجع مصروفات");
                    break;
            }

            _VoucherID = null;
            _ResetVoucherObject();
            kgtxtVoucherName.Text = null;
            kgtxtNotes.Text = null;
            kgtxtVoucherDate.Text = null;

            kgtxtVoucherValue.Text = null;
            kgtxtCreatedByUserName.Text = null;
            kgtxtCreatedDate.Text = null;
            kgtxtVoucherID.Text = null;

            gchkIsLocked.Checked = false;
            kgtxtVoucherName.Focus();

            _ChangeEnablityForButton(gbtnAddTransaction, false);
           
            lblNoTransactionsFoundMessage.Visible = true;

            //kgtxtCreatedByUserName.Text = clsGlobal_UI.CurrentUser?.UserName;
            //kgtxtVoucherDate.RefreshNumber_DateTimeFormattedText(DateTime.Now.ToString()); 
            //kgtxtVoucherValue.Text = "0";
            //kgtxtVoucherValue.RefreshNumber_DateTimeFormattedText();
            //kgtxtCreatedDate.RefreshNumber_DateTimeFormattedText(DateTime.Now.ToString());
        }

        async Task _UpdateMode()
        {
            ChangeHeaderValue("تعديل بيانات المستند");
            int currentUserID = Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID);

            var searchedVoucher = await clsIncomeAndExpenseVoucher.FindVoucherByVoucherID(Convert.ToInt32(_VoucherID), currentUserID);

            if (searchedVoucher == null)
            {
                clsGlobalMessageBoxs.ShowErrorMessage("فشل تحميل بيانات المستند");
                this.Close();
                return;
            }

            this._Voucher = searchedVoucher;
            this._voucherType = searchedVoucher.VoucherType;

            kgtxtVoucherName.Text = _Voucher.VoucherName;
            kgtxtNotes.Text = _Voucher.Notes;
            kgtxtVoucherDate.RefreshNumber_DateTimeFormattedText(_Voucher.VoucherDate.ToString());
            kgtxtVoucherValue.RefreshNumber_DateTimeFormattedText(_Voucher.VoucherValue.ToString());
            kgtxtCreatedByUserName.Text = _Voucher.CreatedByUserInfo.UserName;
            kgtxtCreatedDate.RefreshNumber_DateTimeFormattedText(_Voucher.CreatedDate.ToString());
            kgtxtVoucherID.Text = _Voucher.VoucherID.ToString();
            gchkIsLocked.Checked = _Voucher.IsLocked;

            if (_Voucher.IsLocked)
            {
                _SetReadOnlyAtTextBox(kgtxtVoucherName);
                _SetReadOnlyAtTextBox(kgtxtNotes);
                _SetReadOnlyAtTextBox(kgtxtVoucherDate);
                _ChangeEnablityForButton(gbtnAddTransaction,false);
            }

            await _LoadDataAtDataGridView();
        }

        async Task _Save()
        {
            if (_Voucher.IsLocked)
            {
                lblUserMessage.Text = "المستند مغلق لايمكن التعديل عليه";
                lblUserMessage.Visible = true;
                return;
            }

            if (!ValidateChildren())
            {
                clsGlobalMessageBoxs.ShowValidateChildrenFailedMessage();
                return;
            }

            _Voucher.VoucherName = kgtxtVoucherName.ValidatedText;
            _Voucher.Notes = kgtxtNotes.Text;
            _Voucher.VoucherDate = Convert.ToDateTime(kgtxtVoucherDate.ValidatedText);


            if (_voucherMode == enVoucherMode.AddNew)
            {
                if (!_Voucher.AssingVoucherTypeAtAddMode(_voucherType))
                {
                    clsGlobalMessageBoxs.ShowErrorMessage("فشل تسجيل نوع المستند !");
                    _ResetVoucherObject();
                    return;
                }
            }
            // permissions
            _Voucher.IsLocked = gchkIsLocked.Checked;

            if (await _Voucher.Save(Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID)))
            {
                if (_voucherMode == enVoucherMode.AddNew)
                {
                    clsGlobalMessageBoxs.ShowMessage($"تم إضافة المستند بنجاج بمعرف [{_Voucher.VoucherID}]", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _voucherMode = enVoucherMode.Update;
                    _VoucherID = _Voucher.VoucherID;

                    kgtxtVoucherValue.RefreshNumber_DateTimeFormattedText(_Voucher.VoucherValue.ToString());
                    kgtxtCreatedByUserName.Text = _Voucher.CreatedByUserInfo.UserName;
                    kgtxtCreatedDate.RefreshNumber_DateTimeFormattedText(_Voucher.CreatedDate.ToString());
                    kgtxtVoucherID.Text = _Voucher.VoucherID.ToString();

                    _ChangeEnablityForButton(gbtnAddTransaction, true);

                    ChangeHeaderValue("تعديل بيانات المستند");

                }
                else if (_voucherMode == enVoucherMode.Update)
                {
                    clsGlobalMessageBoxs.ShowMessage("تم تعديل بيانات المستند بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _isSaved = true;
            }
            else if (_voucherMode == enVoucherMode.AddNew)
                _ResetVoucherObject();
        }

        void _ResetVoucherObject()
        {
            _Voucher = new clsIncomeAndExpenseVoucher();
            _Voucher.IsLocked = false;  
        }
        private async void frmAddUpdateVoucher_Load(object sender, EventArgs e)
        {
            _SetReadOnlyAtTextBox(kgtxtVoucherValue);
            _SetReadOnlyAtTextBox(kgtxtCreatedByUserName);
            _SetReadOnlyAtTextBox(kgtxtCreatedDate);
            _SetReadOnlyAtTextBox(kgtxtVoucherID);

            _ChangeEnablithForPagingControls(false);
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
        private async void kgtxtPageNumber_TextChanged(object sender, EventArgs e)
        {
            if (!_searchByPageNumber || !_CheckValidationChildren())
                return;

            _pageNumber = Convert.ToInt16(kgtxtPageNumber.ValidatedText);

            await _LoadDataAtDataGridView();
        }

        private void kgtxtPageNumber_OnValidationError(object sender, KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.CancelEventArgs.Cancel = true;
            errorProvider1.SetError(kgtxt, clsUtils.GetValidationErrorTypeString(e.validationErrorType, kgtxt));
        }

        private void kgtxtPageNumber_OnValidationSuccess(object sender, CancelEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.Cancel = false;
            errorProvider1.SetError(kgtxt, null);
        }

        private void gbtnAddTransaction_Click(object sender, EventArgs e)
        {
            if (!gbtnAddTransaction.Enabled || _VoucherID == null)
                return;

            var frm = new frmAddUpdateIncomeAndExpeseTransction(_Voucher.IsIncome, Convert.ToInt32(_VoucherID));
            frm.OnCloseAndSaved += FrmAddUpdateTransactions_OnCloseAndSaved;
            clsGlobal_UI.MainForm.AddNewFormAtContainer(frm);
        }

        private async void FrmAddUpdateTransactions_OnCloseAndSaved(int obj)
        {
           await _LoadDataAtDataGridView();
        }

        private async void gbtnSave_Click(object sender, EventArgs e)
        {
            await _Save();
        }

        private void gbtnClose_Click(object sender, EventArgs e)
        {
            if (_isSaved)
                OnCloseAndSaved?.Invoke();

            this.Close();
        }

    }
}
