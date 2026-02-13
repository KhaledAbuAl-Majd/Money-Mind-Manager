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
using MoneyMindManager_Presentation.People;
using MoneyMindManager_Presentation.Transactions;
using MoneyMindManagerGlobal;
using static MoneyMindManager_Business.clsBLLGlobal;
using static MoneyMindManager_Business.clsIncomeAndExpenseVoucher;

namespace MoneyMindManager_Presentation.Income_And_Expense.Vouchers
{
    public partial class frmMainTransactionsList : Form
    {
        public frmMainTransactionsList()
        {
            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }

            InitializeComponent();
        }

        bool _CheckPermissions()
        {
            return clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.MainTransactionsList,
                "ليس لديك صلاحية قائمة المعاملات.");
        }
        enum enFilterBy { All, TransactionID,UserName,Purpose};

        enFilterBy _filterBy = enFilterBy.All;

        bool _IsHeaderCreated = false;
        bool _searchByPageNumber = false;

        int _pageNumber = 1;

        void _SetForColorForLabels(KhaledLabel klbl,decimal amount)
        {
            if (amount > 0)
            {
                klbl.ForeColor = Color.Green;
            }
            else if (amount < 0)
            {
                klbl.ForeColor = Color.Red;
            }
            else
            {
                klbl.ForeColor = Color.Black;
            }
        }
        bool _CheckValidationChildren()
        {
            if (!ValidateChildren())
            {
                dgvTransactions.DataSource = null;
                _IsHeaderCreated = false;
                lblNoRecordsFoundMessage.Visible = true;
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

        List<int> _GetCheckedTransactionTypes()
        {
            List<int> selectedIDs = new List<int>();

            foreach(var item in chklbTransactionTypes.CheckedItems)
            {
                DataRowView rowView = item as DataRowView;

                if (rowView != null)
                {
                    object idValue = rowView["TransactionTypeID"];

                    if(int.TryParse(idValue?.ToString(),out int id))
                    {
                        selectedIDs.Add(id);
                    }
                }
            }

            return selectedIDs;
        }

        async Task _LoadDataAtDataGridView(enFilterBy filterBy)
        {
            SearchAfterTimerFinish.Stop();

            if (!_CheckValidationChildren())
                return;

            enTextSearchMode textSearchMode = enTextSearchMode.WordsPrefix_Fast;

            if (grbTextSearchMode_WordsPrefix.Checked)
                textSearchMode = enTextSearchMode.WordsPrefix_Fast;
            else if (grbTextSearchMode_SubString.Checked)
                textSearchMode = enTextSearchMode.Substring_Slow;

            clsDataColumns.clsMainTransactionClasses.clsGetAllMainTransactions result = null;

            bool filterByCreatedDate = false;

            if (gcbFilterByDate.Text == "تاريخ الإنشاء")
                filterByCreatedDate = true;
            else if (gcbFilterByDate.Text == "تاريخ المعاملة")
                filterByCreatedDate = false;
            else
                return;

            var transactionTypes = _GetCheckedTransactionTypes();

            if (filterBy == enFilterBy.All || string.IsNullOrEmpty(kgtxtFilterValue.ValidatedText))
            {
                result = await clsMainTransaction.GetAllTransactions(transactionTypes, filterByCreatedDate, kgtxtFromDate.ValidatedText,
                    kgtxtToDate.ValidatedText ,textSearchMode, _pageNumber);
            }
            else if (filterBy == enFilterBy.TransactionID)
            {
                int transactionID = Convert.ToInt32(kgtxtFilterValue.ValidatedText);

                result = await clsMainTransaction.GetAllTransactionsByTransactionID(transactionID,transactionTypes, filterByCreatedDate, kgtxtFromDate.ValidatedText,
                    kgtxtToDate.ValidatedText, textSearchMode, _pageNumber);
            }
            else if (filterBy == enFilterBy.UserName)
            {
                string userName = kgtxtFilterValue.ValidatedText;
                result = await clsMainTransaction.GetAllTransactionsByUserName(userName,transactionTypes, filterByCreatedDate, kgtxtFromDate.ValidatedText,
                    kgtxtToDate.ValidatedText, textSearchMode, _pageNumber);
            }
            else if (filterBy == enFilterBy.Purpose)
            {
                string purpose = kgtxtFilterValue.ValidatedText;
                result = await clsMainTransaction.GetAllTransactionsByPurpose(purpose, transactionTypes, filterByCreatedDate, kgtxtFromDate.ValidatedText,
                    kgtxtToDate.ValidatedText, textSearchMode, _pageNumber);
            }
            else
                return;

            if (result == null)
                return;

            if (result.dtTransactions.Rows.Count == 0)
            {
                lblNoRecordsFoundMessage.Visible = true;
                dgvTransactions.DataSource = null;
                _IsHeaderCreated = false;
                _pageNumber = 1;
            }
            else
            {
                lblNoRecordsFoundMessage.Visible = false;
                dgvTransactions.DataSource = result.dtTransactions;
            }

            lblUserMessage.Visible = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = _pageNumber.ToString();
            _searchByPageNumber = true;

            lblTotalRecordsNumber.Text = result.RecordsCount.ToString();
            lblCurrentPageOfNumberOfPages.Text = string.Concat(_pageNumber, "   من   ", result.NumberOfPages, "  صفحات");
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = true;
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = (result.NumberOfPages < 1) ? 1 : result.NumberOfPages;
            lblCurrentPageRecordsCount.Text = dgvTransactions.Rows.Count.ToString();

            gibtnNextPage.Enabled = (_pageNumber < result.NumberOfPages);
            gibtnPreviousPage.Enabled = (_pageNumber > 1);

            klblAllTransactionsAmount.Text = result.TotalAmount.ToString();
            klblCurrentPageTransactionsValue.Text = result.CurrentPageAmount.ToString();

            _SetForColorForLabels(klblAllTransactionsAmount, result.TotalAmount);
            _SetForColorForLabels(klblCurrentPageTransactionsValue, result.CurrentPageAmount);

            if (!_IsHeaderCreated && dgvTransactions.Rows.Count > 0)
            {
                dgvTransactions.Columns["TransactionID"].HeaderText = "معرف المعاملة";
                dgvTransactions.Columns["TransactionID"].Width = 125;

                dgvTransactions.Columns["Amount"].HeaderText = "قيمة المعاملة";
                dgvTransactions.Columns["Amount"].Width = 215;
                dgvTransactions.Columns["Amount"].DefaultCellStyle.Format = "N2";

                dgvTransactions.Columns["TransactionDate"].HeaderText = "تاريخ المعاملة";
                dgvTransactions.Columns["TransactionDate"].Width = 115;
                dgvTransactions.Columns["TransactionDate"].DefaultCellStyle.Format = "dd-MM-yyyy";

                dgvTransactions.Columns["CreatedDate"].HeaderText = "تاريخ الإنشاء";
                dgvTransactions.Columns["CreatedDate"].Width = 190;
                dgvTransactions.Columns["CreatedDate"].DefaultCellStyle.Format = "hh:mm:ss tt dd-MM-yyyy";

                dgvTransactions.Columns["TransactionTypeName"].HeaderText = "نوع المعاملة";
                dgvTransactions.Columns["TransactionTypeName"].Width = 100;

                dgvTransactions.Columns["CreatedByUserName"].HeaderText = "اسم المستخدم المنشئ";
                dgvTransactions.Columns["CreatedByUserName"].Width = 265;

                dgvTransactions.Columns["Purpose"].HeaderText = "البيان";
                dgvTransactions.Columns["Purpose"].Width = 265;

                _IsHeaderCreated = true;

            }
        }

        void _ShowTransactionInfo()
        {
            if (dgvTransactions.SelectedRows.Count < 1)
                return;

            int transactionID = Convert.ToInt32(dgvTransactions.SelectedRows[0].Cells[0].Value);

            var frm = new frmMainTransactionInfo(transactionID);
            clsPL_Global.MainForm.AddNewFormAtContainer(frm);
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

        async Task _LoadTransactionTypes()
        {
            var dt = await clsTransactionType.GetAllTransactionTypes();

            // NOTE:
            // Sometimes Windows Forms throws a non-critical internal exception when assigning
            // a DataSource to checked list controls (like CheckedListBox).
            // This happens inconsistently and does NOT affect the execution or data binding.
            // The code continues to work normally, so this warning can be safely ignored.

            chklbTransactionTypes.DataSource = dt;
            chklbTransactionTypes.DisplayMember = "TransactionTypeName";
            chklbTransactionTypes.ValueMember = "TransactionTypeID";

            for (byte i = 0; i < chklbTransactionTypes.Items.Count; i++)
            {
                chklbTransactionTypes.SetItemChecked(i, true);
            }
        }
        private  void frmMainTransactionsList_Load(object sender, EventArgs e)
        {    
            _IsHeaderCreated = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = "1";
            lblNoRecordsFoundMessage.Visible = false;
            lblUserMessage.Visible = false;
            gcbFilterBy.SelectedIndex = 0;       
        }

        private async void frmMainTransactionsList_Shown(object sender, EventArgs e)
        {
            await _LoadTransactionTypes();
            chklbTransactionTypes.ClearSelected();
            await  _LoadDataAtDataGridView(enFilterBy.All);
        }

        private void kgtxt_OnValidationError(object sender, KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.CancelEventArgs.Cancel = true;
            errorProvider1.SetError(kgtxt, clsPL_Utils.GetValidationErrorTypeString(e.validationErrorType, kgtxt));
        }

        private void kgtxt_OnValidationSuccess(object arg1, CancelEventArgs arg2)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)arg1;
            arg2.Cancel = false;
            errorProvider1.SetError(kgtxt, null);
        }

        private async void gibtnNextPage_Click(object sender, EventArgs e)
        {
            ++_pageNumber;
            await _LoadDataAtDataGridView(_filterBy);
        }

        private async void gibtnPreviousPage_Click(object sender, EventArgs e)
        {
            --_pageNumber;
            await _LoadDataAtDataGridView(_filterBy);
        }

        private async void gcbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string oldText = kgtxtFilterValue.Text;

            _pageNumber = 1;

            _searchByPageNumber = false;
            kgtxtFilterValue.Text = "";
            _searchByPageNumber = true;

            if (gcbFilterBy.Text == "بدون")
            {
                _SetReadOnlyAtTextBox(kgtxtFilterValue);
                _filterBy = enFilterBy.All;
                if (!string.IsNullOrWhiteSpace(oldText))
                    await _LoadDataAtDataGridView(_filterBy);
                return;
            }

            _CancelReadOnlyAtTextBox(kgtxtFilterValue);
            kgtxtFilterValue.IsRequired = false;
            kgtxtFilterValue.TrimStart = false;
            kgtxtFilterValue.TrimEnd = true;

            if (gcbFilterBy.Text == "معرف المعاملة")
            {
                _filterBy = enFilterBy.TransactionID;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
                kgtxtFilterValue.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
                kgtxtFilterValue.AllowWhiteSpace = false;
                kgtxtFilterValue.NumberProperties.IntegerNumberProperties.AllowNegative = false;
                kgtxtFilterValue.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            }
            else if (gcbFilterBy.Text == "اسم المستخدم")
            {
                _filterBy = enFilterBy.UserName;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
                kgtxtFilterValue.AllowWhiteSpace = false;
            }

            else if (gcbFilterBy.Text == "البيان")
            {
                _filterBy = enFilterBy.Purpose;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
                kgtxtFilterValue.AllowWhiteSpace = true;
            }

            if (!string.IsNullOrWhiteSpace(oldText))
                await _LoadDataAtDataGridView(_filterBy);
        }

        private void kgtxtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _pageNumber = 1;
            SearchAfterTimerFinish.Stop();
            SearchAfterTimerFinish.Start();
        }

        private async void SearchAfterTimerFinish_Tick(object sender, EventArgs e)
        {
            await _LoadDataAtDataGridView(_filterBy);
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

        private async void kgtxtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchAfterTimerFinish.Stop();
                _pageNumber = 1;
                await _LoadDataAtDataGridView(_filterBy);
            }
        }

        private async void gcbFilterByDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pageNumber = 1;
            await _LoadDataAtDataGridView(_filterBy);
        }

        private async void gibtnRefreshData_Click(object sender, EventArgs e)
        {
            _pageNumber = 1;
            await _LoadDataAtDataGridView(_filterBy);
        }

        private void gtsmTransactionInfo_Click(object sender, EventArgs e)
        {
            _ShowTransactionInfo();
        }

        private void gdgvTransactions_DoubleClick(object sender, EventArgs e)
        {
            _ShowTransactionInfo();
        }

        private void gdgvVouchers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value)
            {
                e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.SelectionForeColor = Color.Orange;
            }
            else 
            {
                if(e.ColumnIndex == 1)
                {
                    if(Convert.ToInt32(e.Value) > 0)
                    {
                        e.CellStyle.ForeColor = Color.Green;
                    }
                    else if (Convert.ToInt32(e.Value) < 0)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }


        private void chklbTransactionTypes_Leave(object sender, EventArgs e)
        {
            chklbTransactionTypes.ClearSelected();
        }


        private void chklbTransactionTypes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                _pageNumber = 1;
                SearchAfterTimerFinish.Stop();
                SearchAfterTimerFinish.Start();
            }
        }


        private void chklbTransactionTypes_MouseUp(object sender, MouseEventArgs e)
        {
            _pageNumber = 1;
            SearchAfterTimerFinish.Stop();
            SearchAfterTimerFinish.Start();
        }

        private async void gtsmExportExcel_Click(object sender, EventArgs e)
        {
            SearchAfterTimerFinish.Stop();

            if (!_CheckValidationChildren())
                return;

            if (dgvTransactions.Rows.Count < 1)
            {
                lblUserMessage.Text = "لا يوجد صفوف لتصديرها !";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            enTextSearchMode textSearchMode = enTextSearchMode.WordsPrefix_Fast;

            if (grbTextSearchMode_WordsPrefix.Checked)
                textSearchMode = enTextSearchMode.WordsPrefix_Fast;
            else if (grbTextSearchMode_SubString.Checked)
                textSearchMode = enTextSearchMode.Substring_Slow;

            DataTable dtTransactions = null;

            bool filterByCreatedDate = false;

            if (gcbFilterByDate.Text == "تاريخ الإنشاء")
                filterByCreatedDate = true;
            else if (gcbFilterByDate.Text == "تاريخ المعاملة")
                filterByCreatedDate = false;
            else
                return;

            var transactionTypes = _GetCheckedTransactionTypes();

            if (_filterBy == enFilterBy.All || string.IsNullOrEmpty(kgtxtFilterValue.ValidatedText))
            {
                dtTransactions = await clsMainTransaction.GetAllTransactionsWithoutPaging(transactionTypes, filterByCreatedDate, kgtxtFromDate.ValidatedText,
                    kgtxtToDate.ValidatedText,textSearchMode);
            }
            else if (_filterBy == enFilterBy.TransactionID)
            {
                int transactionID = Convert.ToInt32(kgtxtFilterValue.ValidatedText);

                dtTransactions = await clsMainTransaction.GetAllTransactionsWithoutPagingByTransactionID(transactionID, transactionTypes, filterByCreatedDate, kgtxtFromDate.ValidatedText,
                    kgtxtToDate.ValidatedText, textSearchMode);
            }
            else if (_filterBy == enFilterBy.UserName)
            {
                string userName = kgtxtFilterValue.ValidatedText;
                dtTransactions = await clsMainTransaction.GetAllTransactionsWithoutPagingByUserName(userName, transactionTypes, filterByCreatedDate, kgtxtFromDate.ValidatedText,
                    kgtxtToDate.ValidatedText, textSearchMode);
            }
            else if (_filterBy == enFilterBy.Purpose)
            {
                string purpose = kgtxtFilterValue.ValidatedText;
                dtTransactions = await clsMainTransaction.GetAllTransactionsWithoutPagingByPurpose(purpose, transactionTypes, filterByCreatedDate, kgtxtFromDate.ValidatedText,
                    kgtxtToDate.ValidatedText, textSearchMode);
            }
            else
                return;

            if (dtTransactions == null)
            {
                clsPL_MessageBoxs.ShowErrorMessage("فشل تصدير البيانات !");
                return;
            }

            dtTransactions.Columns["TransactionID"].ColumnName = "معرف المعاملة";
            dtTransactions.Columns["Amount"].ColumnName = "قيمة المعاملة";
            dtTransactions.Columns["TransactionDate"].ColumnName = "تاريخ المعاملة";
            dtTransactions.Columns["CreatedDate"].ColumnName = "تاريخ الإنشاء";
            dtTransactions.Columns["TransactionTypeID"].ColumnName = "معرف نوع المعاملة";
            dtTransactions.Columns["TransactionTypeName"].ColumnName = "نوع المعاملة";
            dtTransactions.Columns["CreatedByUserID"].ColumnName = "معرف المستخدم المنشئ";
            dtTransactions.Columns["CreatedByUserName"].ColumnName = "اسم المستخدم المنشئ";
            dtTransactions.Columns["Purpose"].ColumnName = "البيان";
            dtTransactions.Columns["AccountID"].ColumnName = "معرف الحساب";

           await clsExportHelper.ExportToExcelWithDialog(dtTransactions, "تقرير المعاملات");
        }

 
        private void kgtxtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                gibtnRefreshData.PerformClick();
        }
    }
}
