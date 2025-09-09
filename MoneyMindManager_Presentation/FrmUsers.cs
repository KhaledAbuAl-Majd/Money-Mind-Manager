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
using MoneyMindManagerGlobal;

namespace MoneyMindManager_Presentation
{
    public partial class FrmUsers : Form
    {
        public FrmUsers()
        {
            InitializeComponent();
        }

        bool _IsHeaderCreated = false;
        bool _searchByPageNumber = false;

        short _pageNumber = 1;

        bool _CheckValidationChildren()
        {
            if (!ValidateChildren())
            {
                gdgvUser.DataSource = null;
                _IsHeaderCreated = false;
                lblNoRecordsFoundMessage.Visible = true;
                lblUserMessage.Text = "تم العثور على حقول غير صالحة. ضع المؤشر على العلامات الحمراء لعرض سبب الخطأ.";
                lblUserMessage.Visible = true;
                //clsGlobal_Presentation.ShowMessage("تم العثور على حقول غير صالحة. ضع المؤشر على العلامات الحمراء لعرض سبب الخطأ.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        async Task _LoadDataAtDataGridView()
        {
            SearchAfterTimerFinish.Stop();

            if (!_CheckValidationChildren())
                return;

            //_pageNumber = Convert.ToInt16(kgtxtPageNumber.ValidatedText);

            clsDataColumns.clsUserClassess.clsGetAllUsers result = null;

            short accountID = Convert.ToInt16(clsGlobal_Presentation.CurrentUser.AccountID);

            if (gcbFilterBy.Text == "بدون" || string.IsNullOrEmpty(kgtxtFilterValue.ValidatedText))
            {
                result = await clsUser.GetAllUsers(accountID, _pageNumber);
            }
            //else if (gcbFilterBy.Text == "معرف الشخص")
            //{
            //    int personID = Convert.ToInt32(kgtxtFilterValue.ValidatedText);
            //    result = await clsPerson.GetAllPeopleByPersonID(accountID, _pageNumber, personID);
            //}
            //else if (gcbFilterBy.Text == "اسم الشخص")
            //{
            //    string personName = kgtxtFilterValue.ValidatedText;
            //    result = await clsPerson.GetAllPeopleByPersonName(accountID, _pageNumber, personName);
            //}
            else
                return;

            if (result == null)
                return;

            if (result.dtUsers.Rows.Count == 0)
            {
                lblNoRecordsFoundMessage.Visible = true;
                lblUserMessage.Visible = true;
                gdgvUser.DataSource = null;
                _IsHeaderCreated = false;
                _pageNumber = 1;
            }
            else
            {
                lblNoRecordsFoundMessage.Visible = false;
                lblUserMessage.Visible = false;
                gdgvUser.DataSource = result.dtUsers;
            }

            _searchByPageNumber = false;
            kgtxtPageNumber.Text = _pageNumber.ToString();
            _searchByPageNumber = true;

            lblTotalRecordsNumber.Text = result.RecordsCount.ToString();
            lblCurrentPageOfNumberOfPages.Text = string.Concat(_pageNumber, "   من   ", result.NumberOfPages, "  صفحات");
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = true;
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = (result.NumberOfPages < 1) ? 1 : result.NumberOfPages;
            lblCurrentPageRecordsCount.Text = gdgvUser.Rows.Count.ToString();

            gibtnNextPage.Enabled = (_pageNumber < result.NumberOfPages);
            gibtnPreviousPage.Enabled = (_pageNumber > 1);
            //

            if (!_IsHeaderCreated && gdgvUser.Rows.Count > 0)
            {
                gdgvUser.Columns["UserID"].HeaderText = "معرف المستخدم";
                gdgvUser.Columns["UserID"].Width = 120;

                gdgvUser.Columns["UserName"].HeaderText = "اسم المستخدم";
                gdgvUser.Columns["UserName"].Width = 250;

                gdgvUser.Columns["PersonName"].HeaderText = "اسم الشخص";
                gdgvUser.Columns["PersonName"].Width = 250;

                gdgvUser.Columns["Phone"].HeaderText = "رقم الهاتف";
                gdgvUser.Columns["Phone"].Width = 160;

                gdgvUser.Columns["Email"].HeaderText = "البريد الإلكتروني";
                gdgvUser.Columns["Email"].Width = 250;

                gdgvUser.Columns["IsActive"].HeaderText = "الفعالية";
                gdgvUser.Columns["IsActive"].Width = 77;

                _IsHeaderCreated = true;
            }
        }

        void _AddNewPerson()
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.OnCloseAndSaved += FrmAddUpdatePerson_OnCloseAndSaved;
            clsGlobal_Presentation.MainForm.AddNewForm(frm);
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            _IsHeaderCreated = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = "1";
            lblNoRecordsFoundMessage.Visible = false;
            lblUserMessage.Visible = false;
            gcbFilterBy.SelectedIndex = 0;
        }

        private void kgtxt_OnValidationError(object sender, KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.CancelEventArgs.Cancel = true;
            errorProvider1.SetError(kgtxt, clsUtils.GetValidationErrorTypeString(e.validationErrorType, kgtxt));
        }

        private void kgtxt_OnValidationSuccess(object arg1, CancelEventArgs arg2)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)arg1;
            arg2.Cancel = false;
            errorProvider1.SetError(kgtxt, null);
        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value)
            {
                //e.CellStyle.BackColor = Color.LightYellow; // خلفية
                e.CellStyle.ForeColor = Color.Red;
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

        private async void gcbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pageNumber = 1;
            if (gcbFilterBy.Text == "بدون")
            {
                kgtxtFilterValue.Visible = false;
                await _LoadDataAtDataGridView();
                return;
            }

            kgtxtFilterValue.Text = "";
            SearchAfterTimerFinish.Stop();
            await _LoadDataAtDataGridView();

            kgtxtFilterValue.Visible = true;

            if (gcbFilterBy.Text == "معرف الشخص")
            {
                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
                kgtxtFilterValue.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
                kgtxtFilterValue.AllowWhiteSpace = false;
                kgtxtFilterValue.IsRequired = false;
                kgtxtFilterValue.TrimEnd = false;
                kgtxtFilterValue.TrimStart = false;
                kgtxtFilterValue.NumberProperties.IntegerNumberProperties.AllowNegative = false;
                kgtxtFilterValue.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
                return;
            }

            if (gcbFilterBy.Text == "اسم الشخص")
            {
                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
                kgtxtFilterValue.AllowWhiteSpace = true;
                kgtxtFilterValue.IsRequired = false;
                kgtxtFilterValue.TrimEnd = false;
                kgtxtFilterValue.TrimStart = false;
                return;
            }

        }

        private void kgtxtFilterValue_TextChanged(object sender, EventArgs e)
        {
            SearchAfterTimerFinish.Stop();
            SearchAfterTimerFinish.Start();
        }

        private async void SearchAfterTimerFinish_Tick(object sender, EventArgs e)
        {
            await _LoadDataAtDataGridView();
        }

        private void kgtxtPageNumber_TextChanged(object sender, EventArgs e)
        {
            if (!_searchByPageNumber || !_CheckValidationChildren())
                return;

            _pageNumber = Convert.ToInt16(kgtxtPageNumber.ValidatedText);

            //await _LoadDataAtDataGridView();

            SearchAfterTimerFinish.Stop();
            SearchAfterTimerFinish.Start();
        }

        private async void kgtxtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchAfterTimerFinish.Stop();
                await _LoadDataAtDataGridView();
            }
        }

        private void gbtnAddPerson_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }

        private void FrmAddUpdatePerson_OnCloseAndSaved()
        {
            _pageNumber = 1;
            gcbFilterBy.SelectedIndex = (gcbFilterBy.SelectedIndex == 0) ? 1 : 0;
        }
    }
}
