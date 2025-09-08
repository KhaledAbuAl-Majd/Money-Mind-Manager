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

        bool _searchByPageNumber = false;

        short _pageNumber = 1;

        bool _CheckValidationChildren()
        {
            if (!ValidateChildren())
            {
                gdgvPeople.DataSource = null;
                lblNoRecordsFoundMessage.Visible = true;
                lblUserMessage.Text = "تم العثور على حقول غير صالحة. ضع المؤشر على العلامات الحمراء لعرض سبب الخطأ.";
                lblUserMessage.Visible = true;
                //clsGlobal_Presentation.ShowMessage("تم العثور على حقول غير صالحة. ضع المؤشر على العلامات الحمراء لعرض سبب الخطأ.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblCurrentPageRecordsCount.Text = "0";
                lblTotalRecordsNumber.Text = "0";
                lblCurrentPageOfNumberOfPages.Text = string.Concat("1", "   من   ", "0", "  صفحات");
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

            if (gcbFilterBy.Text == "بدون" || string.IsNullOrEmpty(kgtxtFilterValue.ValidatedText))
            {
                result = await clsPerson.GetAllPeople(2, _pageNumber);
            }
            else if (gcbFilterBy.Text == "معرف الشخص")
            {
                int personID = Convert.ToInt32(kgtxtFilterValue.ValidatedText);
                result = await clsPerson.GetAllPeopleByPersonID(2, _pageNumber, personID);
            }
            else if (gcbFilterBy.Text == "اسم الشخص")
            {
                string personName = kgtxtFilterValue.ValidatedText;
                result = await clsPerson.GetAllPeopleByPersonName(2, _pageNumber, personName);
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
            }
            else
            {
                lblNoRecordsFoundMessage.Visible = false;
                lblUserMessage.Visible = false;
                gdgvPeople.DataSource = result.dtPeople;
            }

            //MessageBox.Show(gdgvPeople.Rows.Count.ToString());


            //this._pageNumber = result.CurrentPageNumber;

            _searchByPageNumber = false;
            kgtxtPageNumber.Text = result.CurrentPageNumber.ToString();
            _searchByPageNumber = true;

            lblTotalRecordsNumber.Text = result.RecordsCount.ToString();
            lblCurrentPageOfNumberOfPages.Text = string.Concat(result.CurrentPageNumber, "   من   ", result.NumberOfPages, "  صفحات");
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = true;
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = (result.NumberOfPages < 1) ? 1 : result.NumberOfPages;
            lblCurrentPageRecordsCount.Text = gdgvPeople.Rows.Count.ToString();

            if (result.CurrentPageNumber >= result.NumberOfPages)
                gibtnNextPage.Enabled = false;

            if (result.CurrentPageNumber == 1 || result.CurrentPageNumber == 0)
                gibtnPreviousPage.Enabled = false;

            //

            if (gdgvPeople.Rows.Count > 0)
            {
                gdgvPeople.Columns["PersonID"].HeaderText = "معرف الشخص";
                gdgvPeople.Columns["PersonID"].Width = 120;

                gdgvPeople.Columns["PersonName"].HeaderText = "اسم الشخص";
                gdgvPeople.Columns["PersonName"].Width = 250;

                gdgvPeople.Columns["Address"].HeaderText = "العنوان";
                gdgvPeople.Columns["Address"].Width = 290;

                gdgvPeople.Columns["Email"].HeaderText = "البريد الإلكتروني";
                gdgvPeople.Columns["Email"].Width = 260;

                gdgvPeople.Columns["Phone"].HeaderText = "رقم الهاتف";
                gdgvPeople.Columns["Phone"].Width = 140;
            }
        }

        void _FilterData()
        {

        }

        private void frmPeople_Load(object sender, EventArgs e)
        {
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
            if(e.Value == null || e.Value == DBNull.Value)
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
            if(gcbFilterBy.Text == "بدون")
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
            if(e.KeyChar == (char)Keys.Enter)
            {
                SearchAfterTimerFinish.Stop();
                await _LoadDataAtDataGridView();
            }
        }
    }
}
