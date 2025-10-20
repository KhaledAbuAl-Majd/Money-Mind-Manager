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
using MoneyMindManager_Presentation.People;
using MoneyMindManager_Presentation.Properties;
using MoneyMindManager_Presentation.Transactions;
using MoneyMindManagerGlobal;
using static Guna.UI2.Native.WinApi;
using static MoneyMindManager_Business.clsIncomeAndExpenseVoucher;

namespace MoneyMindManager_Presentation.Income_And_Expense.Vouchers
{
    public partial class frmAddUpdateDebt : Form
    {
        public enum enDebtMode { AddNew, Update };

        enDebtMode _DebtMode;

        public enum enDebtType { إقراض = 0, إقتراض = 1 };

        int? _PersonID;

        public event Action OnCloseAndSaved;

        bool _isSaved = false;

        clsDebt _Debt;
        int? _DebtID;

        public frmAddUpdateDebt()
        {
            InitializeComponent();
            this._DebtMode = enDebtMode.AddNew;
            this._DebtID = null;
            this._Debt = null;
            this._PersonID = null;
        }

        public frmAddUpdateDebt(int voucherID)
        {
            InitializeComponent();
            this._DebtMode = enDebtMode.Update;
            this._DebtID = voucherID;
        }

        bool _IsHeaderCreated = false;
        bool _searchByPageNumber = false;
        short _pageNumber = 1;

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


            int currentUserID = Convert.ToInt32(clsGlobal_UI.CurrentUser.UserID);

            var result = await _Debt.GetDebtPayments(currentUserID, _pageNumber);


            if (result == null)
                return;

            if (result.dtDebtPayment.Rows.Count == 0)
            {
                lblNoTransactionsFoundMessage.Visible = true;
                gdgvDebtPaymentTransctions.DataSource = null;
                _IsHeaderCreated = false;
                _pageNumber = 1;
            }
            else
            {
                lblNoTransactionsFoundMessage.Visible = false;
                gdgvDebtPaymentTransctions.DataSource = result.dtDebtPayment;
            }

            if (!_Debt.IsLocked)
                lblUserMessage.Visible = false;

            _searchByPageNumber = false;
            kgtxtPageNumber.Text = _pageNumber.ToString();
            _searchByPageNumber = true;

            lblTotalRecordsNumber.Text = result.RecordsCount.ToString();
            lblCurrentPageOfNumberOfPages.Text = string.Concat(_pageNumber, "   من   ", result.NumberOfPages, "  صفحات");
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = true;
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = (result.NumberOfPages < 1) ? 1 : result.NumberOfPages;
            lblCurrentPageRecordsCount.Text = gdgvDebtPaymentTransctions.Rows.Count.ToString();

            gibtnNextPage.Enabled = (_pageNumber < result.NumberOfPages);
            gibtnPreviousPage.Enabled = (_pageNumber > 1);
            //

            //if (result.NumberOfPages < 2)
            //{
            //    _ChangeEnablithForPagingControls(false);
            //}
            //else
            //{
            //    _searchByPageNumber = false;
            //    kgtxtPageNumber.Text = _pageNumber.ToString();
            //    _searchByPageNumber = true;
            //    kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = true;
            //    kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = (result.NumberOfPages < 1) ? 1 : result.NumberOfPages;
            //    lblCurrentPageRecordsCount.Text = gdgvDebtPaymentTransctions.Rows.Count.ToString();
            //    lblCurrentPageOfNumberOfPages.Text = string.Concat(_pageNumber, "   من   ", result.NumberOfPages, "  صفحات");
            //    _ChangeEnablithForPagingControls(true);
            //}

            if (!_IsHeaderCreated && gdgvDebtPaymentTransctions.Rows.Count > 0)
            {
                gdgvDebtPaymentTransctions.Columns["MainTransactionID"].HeaderText = "معرف المعاملة";
                gdgvDebtPaymentTransctions.Columns["MainTransactionID"].Width = 125;

                gdgvDebtPaymentTransctions.Columns["Amount"].HeaderText = "المبلغ";
                gdgvDebtPaymentTransctions.Columns["Amount"].Width = 250;
                gdgvDebtPaymentTransctions.Columns["Amount"].DefaultCellStyle.Format = "N2";

                gdgvDebtPaymentTransctions.Columns["DebtDate"].HeaderText = "تاريخ المعاملة";
                gdgvDebtPaymentTransctions.Columns["DebtDate"].Width = 130;
                gdgvDebtPaymentTransctions.Columns["DebtDate"].DefaultCellStyle.Format = "dd-MM-yyyy";

                gdgvDebtPaymentTransctions.Columns["CreatedDate"].HeaderText = "تاريخ الإنشاء";
                gdgvDebtPaymentTransctions.Columns["CreatedDate"].Width = 250;
                gdgvDebtPaymentTransctions.Columns["CreatedDate"].DefaultCellStyle.Format = "hh:mm:ss tt dd-MM-yyyy";

                gdgvDebtPaymentTransctions.Columns["CreatedByUserName"].HeaderText = "اسم المستخدم المنشئ";
                gdgvDebtPaymentTransctions.Columns["CreatedByUserName"].Width = 250;

                gdgvDebtPaymentTransctions.Columns["Purpose"].HeaderText = "البيان";
                gdgvDebtPaymentTransctions.Columns["Purpose"].Width = 300;

                _IsHeaderCreated = true;
            }

            kgtxtRemainingAmount.RefreshNumber_DateTimeFormattedText(result.RemainingAmount.ToString());

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

        void _ChangeEnablityForButton(Guna2Button btn,bool value)
        {
            btn.Enabled = value;
        }

        void _AddNewMode()
        {
            ChangeHeaderValue("إضافة سند دين");

            _DebtID = null;
            _PersonID = null;
            _ResetDebtObject();
            kgtxtPersonName.Text = null;
            kgtxtNotes.Text = null;

            kgtxtDebtDate.Text = null;
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
            int currentUserID = Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID);

            var searchedDebt = await clsDebt.FindDebtByDebtID(Convert.ToInt32(_DebtID), currentUserID);

            if (searchedDebt == null)
            {
                clsGlobalMessageBoxs.ShowErrorMessage("فشل تحميل بيانات السند");
                this.Close();
                return;
            }

            this._Debt = searchedDebt;
            this._PersonID = _Debt.PersonID;

            _UpdateModeChangesAtUi();

            kgtxtPersonName.Text = _Debt.PersonInfo?.PersonName;
            kgtxtNotes.Text = _Debt.Notes;
            kgtxtDebtDate.RefreshNumber_DateTimeFormattedText(_Debt.DebtDate?.ToString());
            kgtxtPaymentDueDate.RefreshNumber_DateTimeFormattedText(_Debt.PaymentDueDate?.ToString());
            kgtxtCreatedDate.RefreshNumber_DateTimeFormattedText(_Debt.CreatedDate?.ToString());
            kgtxtDebtValue.RefreshNumber_DateTimeFormattedText(_Debt.DebtValue?.ToString());
            kgtxtRemainingAmount.RefreshNumber_DateTimeFormattedText(_Debt.RemainingAmount.ToString());
            kgtxtCreatedByUserName.Text = _Debt.CreatedByUserInfo?.UserName;
            kgtxtDebtID.Text = _Debt.DebtID?.ToString();
            gcbDebtType.SelectedIndex = (_Debt.IsLending) ? (int)enDebtType.إقراض : (int)enDebtType.إقتراض;
            gchkIsLocked.Checked = _Debt.IsLocked;

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
                clsGlobalMessageBoxs.ShowValidateChildrenFailedMessage();
                return;
            }

            if (_DebtMode == enDebtMode.AddNew)
            {
                if (_PersonID == null || !_Debt.AssingPersonIDAtAddMode(Convert.ToInt32(_PersonID)))
                {
                    clsGlobalMessageBoxs.ShowErrorMessage("فشل تسجيل معرف الشخص !");
                    _ResetDebtObject();
                    return;
                }

                bool isLending = (gcbDebtType.SelectedIndex == (int)enDebtType.إقراض) ? true : false;

                if (!_Debt.AssingIsLendingAddMode(isLending))
                {
                    clsGlobalMessageBoxs.ShowErrorMessage("فشل تسجيل نوع الدين !");
                    _ResetDebtObject();
                    return;
                }

                if (!_Debt.AssingIsLockingAddMode(gchkIsLocked.Checked))
                {
                    clsGlobalMessageBoxs.ShowErrorMessage("فشل تسجيل قفل المستند !");
                    _ResetDebtObject();
                    return;
                }
            }
            // permissions

            _Debt.PaymentDueDate = clsFormat.TryConvertToDateTime(kgtxtPaymentDueDate.ValidatedText);

            decimal amount = Convert.ToDecimal(kgtxtDebtValue.ValidatedText);
            string notes = kgtxtNotes.ValidatedText;
            DateTime debtDate = Convert.ToDateTime(kgtxtDebtDate.ValidatedText);
            int currentUserID = Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID);

            if (await _Debt.Save(amount,notes,debtDate,currentUserID))
            {
                if (_DebtMode == enDebtMode.AddNew)
                {
                    clsGlobalMessageBoxs.ShowMessage($"تم إضافة سند الدين بنجاج بمعرف [{_Debt.DebtID}]", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _DebtMode = enDebtMode.Update;
                    _DebtID = _Debt.DebtID;

                    kgtxtCreatedByUserName.Text = _Debt.CreatedByUserInfo?.UserName;
                    kgtxtCreatedDate.RefreshNumber_DateTimeFormattedText(_Debt.CreatedDate?.ToString());
                    kgtxtDebtID.Text = _Debt.DebtID?.ToString();

                    _ChangeEnablityForButton(gbtnAddDebtPaymentTransaction, true);

                    _UpdateModeChangesAtUi();

                }
                else if (_DebtMode == enDebtMode.Update)
                {
                    clsGlobalMessageBoxs.ShowMessage("تم تعديل بيانات سند الدين بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                kgtxtRemainingAmount.RefreshNumber_DateTimeFormattedText(_Debt.RemainingAmount.ToString());
                _isSaved = true;
            }
            else if (_DebtMode == enDebtMode.AddNew)
                _ResetDebtObject();
        }

        void _ResetDebtObject()
        {
            _Debt = new clsDebt();
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

            var frm = new frmAddUpdateDebtPayment(Convert.ToBoolean(_Debt.IsLending), Convert.ToInt32(_DebtID));
            frm.OnCloseAndSaved += FrmAddUpdateDebtPayment_OnCloseAndSaved;
            clsGlobal_UI.MainForm.AddNewFormAtContainer(frm);
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

            var frm = new frmAddUpdateDebtPayment(transactionID);
            frm.OnCloseAndSaved += FrmAddUpdateDebtPayment_OnCloseAndSaved;
            clsGlobal_UI.MainForm.AddNewFormAtContainer(frm);
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

            var frm = new frmMainTransactionInfo(transactionID);
            clsGlobal_UI.MainForm.AddNewFormAtContainer(frm);
        }

        private async void frmAddUpdateVoucher_Load(object sender, EventArgs e)
        {
            _SetReadOnlyAtTextBox(kgtxtPersonName);
            _SetReadOnlyAtTextBox(kgtxtCreatedDate);
            _SetReadOnlyAtTextBox(kgtxtRemainingAmount);
            _SetReadOnlyAtTextBox(kgtxtCreatedByUserName);
            _SetReadOnlyAtTextBox(kgtxtDebtID);

            //_ChangeEnablithForPagingControls(false);
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

        private void kgtxt_OnValidationError(object sender, KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.CancelEventArgs.Cancel = true;
            errorProvider1.SetError(kgtxt, clsUtils.GetValidationErrorTypeString(e.validationErrorType, kgtxt));
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
            if(this._DebtMode == enDebtMode.Update)
            {
                if (await _Debt.ChangeLocking(gchkIsLocked.Checked, Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID)))
                {
                    LockAndUnLockMode(_Debt.IsLocked);
                }
                else
                {
                    clsGlobalMessageBoxs.ShowErrorMessage("فشل تغيير قفل المستند !");
                    gchkIsLocked.Checked = _Debt.IsLocked;
                }
            }
        }

        private async void gtsmDelete_Click(object sender, EventArgs e)
        {
            if (gdgvDebtPaymentTransctions.SelectedRows.Count < 1 || _DebtID == null || _Debt.IsLocked)
                return;

            if (clsGlobalMessageBoxs.ShowMessage("هل أنت متأكد من رغبتك حذف معاملة السداد هذه ؟ ", "طلب مواقفقة", MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                int transactionID = Convert.ToInt32(gdgvDebtPaymentTransctions.SelectedRows[0].Cells[0].Value);
                if(await clsDebtPayment.DeleteDebtPaymentByID(transactionID, Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID)))
                {
                    _pageNumber = 1;
                    _isSaved = true;
                    await _LoadDataAtDataGridView();
                }

            }

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

            if (clsGlobalMessageBoxs.ShowMessage("هل أنت متأكد من رغبتك حذف السند ؟ ", "طلب مواقفقة", MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (await clsDebt.DeleteDebtByDebtID(Convert.ToInt32(_DebtID), Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID)))
                {
                    _isSaved = true;
                    gbtnClose.PerformClick();
                }
            }

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

            var frm = new frmSelectPerson();
            frm.OnPersonSelected += FrmSelectPerson_OnPersonSelected;
            clsGlobal_UI.MainForm.AddNewFormAsDialog(frm);
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

            frmPersonInfo frm = new frmPersonInfo(Convert.ToInt32(_PersonID),false);
            clsGlobal_UI.MainForm.AddNewFormAtContainer(frm);
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


            int currentUserID = Convert.ToInt32(clsGlobal_UI.CurrentUser.UserID);

            var dt = await _Debt.GetDebtPaymentsWithoutPaging(currentUserID);


            if (dt == null)
                return;

            if (dt == null)
            {
                clsGlobalMessageBoxs.ShowErrorMessage("فشل تصدير البيانات !");
                return;
            }

            dt.Columns["MainTransactionID"].ColumnName = "معرف المعاملة";
            dt.Columns["Amount"].ColumnName = "المبلغ";
            dt.Columns["DebtDate"].ColumnName = "تاريخ المعاملة";
            dt.Columns["CreatedDate"].ColumnName = "تاريخ الإنشاء";
            dt.Columns["Purpose"].ColumnName = "البيان";
            dt.Columns["CreatedByUserID"].ColumnName = "معرف المستخدم المنشئ";
            dt.Columns["CreatedByUserName"].ColumnName = "اسم المستخدم المنشئ";
            dt.Columns["AccountID"].ColumnName = "معرف الحساب";

            await clsExportHelper.ExportToExcelWithDialog(dt, $"تقرير معاملات سداد سند الدين [ {_DebtID?.ToString()} ]");
        }

        private void lblCurrentPageRecordsCount_Click(object sender, EventArgs e)
        {

        }

        private void lblDescriptionOfCurrentPageNumOfRcords_Click(object sender, EventArgs e)
        {

        }

        private void lblCurrentPageOfNumberOfPages_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalRecordsNumber_Click(object sender, EventArgs e)
        {

        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }

        private void lblUserMessage_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void kgtxtDebtValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void kgtxtPaymentDueDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void gcbDebtType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void kgtxtPersonName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void kgtxtDebtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void kgtxtCreatedByUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void kgtxtRemainingAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void kgtxtCreatedDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void kgtxtNotes_TextChanged(object sender, EventArgs e)
        {

        }

        private void kgtxtDebtDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNoTransactionsFoundMessage_Click(object sender, EventArgs e)
        {

        }
    }
}
