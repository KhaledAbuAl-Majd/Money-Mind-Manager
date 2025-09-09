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
using MoneyMindManagerGlobal;
using static Guna.UI2.Native.WinApi;

namespace MoneyMindManager_Presentation.People
{
    public partial class frmPeople : Form
    {
        public frmPeople()
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
                gdgvPeople.DataSource = null;
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

            clsDataColumns.PersonClassess.clsGetAllPeople result = null;

            short accountID = Convert.ToInt16(clsGlobal_Presentation.CurrentUser.AccountID);

            if (gcbFilterBy.Text == "بدون" || string.IsNullOrEmpty(kgtxtFilterValue.ValidatedText))
            {
                result = await clsPerson.GetAllPeople(accountID, _pageNumber);
            }
            else if (gcbFilterBy.Text == "معرف الشخص")
            {
                int personID = Convert.ToInt32(kgtxtFilterValue.ValidatedText);
                result = await clsPerson.GetAllPeopleByPersonID(accountID, _pageNumber, personID);
            }
            else if (gcbFilterBy.Text == "اسم الشخص")
            {
                string personName = kgtxtFilterValue.ValidatedText;
                result = await clsPerson.GetAllPeopleByPersonName(accountID, _pageNumber, personName);
            }
            else
                return;

            if (result == null)
                return;

            if (result.dtPeople.Rows.Count == 0)
            {
                lblNoRecordsFoundMessage.Visible = true;
                lblUserMessage.Visible = true;
                gdgvPeople.DataSource = null;
                _IsHeaderCreated = false;
                _pageNumber = 1;
            }
            else
            {
                lblNoRecordsFoundMessage.Visible = false;
                lblUserMessage.Visible = false;
                gdgvPeople.DataSource = result.dtPeople;
            }

            _searchByPageNumber = false;
            kgtxtPageNumber.Text = _pageNumber.ToString();
            _searchByPageNumber = true;

            lblTotalRecordsNumber.Text = result.RecordsCount.ToString();
            lblCurrentPageOfNumberOfPages.Text = string.Concat(_pageNumber, "   من   ", result.NumberOfPages, "  صفحات");
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = true;
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = (result.NumberOfPages < 1) ? 1 : result.NumberOfPages;
            lblCurrentPageRecordsCount.Text = gdgvPeople.Rows.Count.ToString();

            gibtnNextPage.Enabled = (_pageNumber < result.NumberOfPages);
            gibtnPreviousPage.Enabled = (_pageNumber > 1);
            //

            if (!_IsHeaderCreated && gdgvPeople.Rows.Count > 0)
            {
                gdgvPeople.Columns["PersonID"].HeaderText = "معرف الشخص";
                gdgvPeople.Columns["PersonID"].Width = 120;

                gdgvPeople.Columns["PersonName"].HeaderText = "اسم الشخص";
                gdgvPeople.Columns["PersonName"].Width = 267;

                gdgvPeople.Columns["Address"].HeaderText = "العنوان";
                gdgvPeople.Columns["Address"].Width = 280;

                gdgvPeople.Columns["Email"].HeaderText = "البريد الإلكتروني";
                gdgvPeople.Columns["Email"].Width = 280;

                gdgvPeople.Columns["Phone"].HeaderText = "رقم الهاتف";
                gdgvPeople.Columns["Phone"].Width = 160;

                _IsHeaderCreated = true;
            }
        }

        void _AddNewPerson()
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.OnCloseAndSaved += FrmAddUpdatePerson_OnCloseAndSaved;
            clsGlobal_Presentation.MainForm.AddNewForm(frm);
        }

        void _ShowPersonInfo()
        {
            int personID = Convert.ToInt32(gdgvPeople.CurrentRow.Cells[0].Value);

            frmPersonInfo frm = new frmPersonInfo(personID);
            frm.OnEditingPersonAndFormClosed += FrmAddUpdatePerson_OnCloseAndSaved;
            clsGlobal_Presentation.MainForm.AddNewForm(frm);
        }

        private void frmPeople_Load(object sender, EventArgs e)
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

        private void gtsmAddPerson_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }

        private void gtsmEditPerson_Click(object sender, EventArgs e)
        {
            int personID = Convert.ToInt32(gdgvPeople.CurrentRow.Cells[0].Value);

            frmAddUpdatePerson frm = new frmAddUpdatePerson(personID);
            frm.OnCloseAndSaved += FrmAddUpdatePerson_OnCloseAndSaved;
            clsGlobal_Presentation.MainForm.AddNewForm(frm);
        }

        private async void gtsmDeletePerson_Click(object sender, EventArgs e)
        {
            if (clsGlobalMessageBoxs.ShowMessage("هل أنت متأكد من رغبتك حذف هذا الشخص", "طلب مواقفقة", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                int personID = Convert.ToInt32(gdgvPeople.CurrentRow.Cells[0].Value);

                if (await clsPerson.DeletePersonByID(personID))
                {
                    _pageNumber = 1;
                    gcbFilterBy.SelectedIndex = (gcbFilterBy.SelectedIndex == 0) ? 1 : 0;
                }
            }

        }

        private void gtsmPersonData_Click(object sender, EventArgs e)
        {
            _ShowPersonInfo();
        }

        private void gdgvPeople_DoubleClick(object sender, EventArgs e)
        {
            _ShowPersonInfo();
        }
    }
}
