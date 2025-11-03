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
using static MoneyMindManager_Business.clsBLLGlobal;

namespace MoneyMindManager_Presentation.People
{
    public partial class frmPeople : Form
    {
        public frmPeople()
        {
            if (!clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.PeopleList,
                "ليس لديك صلاحية قائمة الأشخاص."))
            {
                this.Dispose();
                return;
            }

            InitializeComponent();
        }

        enum enFilterBy { All, PersonID, PersonName,Email,Phone };

        enFilterBy _filterBy = enFilterBy.All;

        bool _IsHeaderCreated = false;
        bool _searchByPageNumber = false;

        int _pageNumber = 1;

        bool _CheckValidationChildren()
        {
            if (!ValidateChildren())
            {
                gdgvPeople.DataSource = null;
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

            clsDataColumns.PersonClasses.clsGetAllPeople result = null;


            if (filterBy == enFilterBy.All || string.IsNullOrEmpty(kgtxtFilterValue.ValidatedText))
            {
                result = await clsPerson.GetAllPeople(textSearchMode,_pageNumber);
            }
            else if (filterBy == enFilterBy.PersonID)
            {
                int personID = Convert.ToInt32(kgtxtFilterValue.ValidatedText);
                result = await clsPerson.GetAllPeopleByPersonID(personID,textSearchMode, _pageNumber);
            }
            else if (filterBy == enFilterBy.PersonName)
            {
                string personName = kgtxtFilterValue.ValidatedText;
                result = await clsPerson.GetAllPeopleByPersonName(personName, textSearchMode, _pageNumber);
            }
            else if (filterBy == enFilterBy.Email)
            {
                string email = kgtxtFilterValue.ValidatedText;
                result = await clsPerson.GetAllPeopleByEmail(email, textSearchMode, _pageNumber);
            }
            else if (filterBy == enFilterBy.Phone)
            {
                string phone = kgtxtFilterValue.ValidatedText;
                result = await clsPerson.GetAllPeopleByPhone(phone, textSearchMode, _pageNumber);
            }
            else
                return;

            if (result == null)
                return;

            if (result.dtPeople.Rows.Count == 0)
            {
                lblNoRecordsFoundMessage.Visible = true;
                gdgvPeople.DataSource = null;
                _IsHeaderCreated = false;
                _pageNumber = 1;
            }
            else
            {
                lblNoRecordsFoundMessage.Visible = false;
                gdgvPeople.DataSource = result.dtPeople;
            }

            lblUserMessage.Visible = false;
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
                gdgvPeople.Columns["PersonID"].Width = 130;

                gdgvPeople.Columns["PersonName"].HeaderText = "اسم الشخص";
                gdgvPeople.Columns["PersonName"].Width = 300;

                gdgvPeople.Columns["Address"].HeaderText = "العنوان";
                gdgvPeople.Columns["Address"].Width = 285;

                gdgvPeople.Columns["Email"].HeaderText = "البريد الإلكتروني";
                gdgvPeople.Columns["Email"].Width = 290;

                gdgvPeople.Columns["Phone"].HeaderText = "رقم الهاتف";
                gdgvPeople.Columns["Phone"].Width = 175;

                _IsHeaderCreated = true;
            }
        }

        void _AddNewPerson()
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.OnCloseAndSaved += x => _Refresh();
            clsPL_Global.MainForm.AddNewFormAtContainer(frm);
        }

        async void _Refresh()
        {
            _pageNumber = 1;
            _searchByPageNumber = false;
            kgtxtFilterValue.Text = "";
            _searchByPageNumber = true;

            await _LoadDataAtDataGridView(_filterBy);
        }

        void _ShowPersonInfo()
        {
            int personID = Convert.ToInt32(gdgvPeople.CurrentRow.Cells[0].Value);

            frmPersonInfo frm = new frmPersonInfo(personID);
            frm.OnEditingPersonAndFormClosed += _Refresh;
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
        private void frmPeople_Load(object sender, EventArgs e)
        {
            _IsHeaderCreated = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = "1";
            lblNoRecordsFoundMessage.Visible = false;
            lblUserMessage.Visible = false;
            gcbFilterBy.SelectedIndex = 0;
            
        }
        private async void frmPeople_Shown(object sender, EventArgs e)
        {
            await _LoadDataAtDataGridView(enFilterBy.All);
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

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value)
            {
                //e.CellStyle.BackColor = Color.LightYellow; // خلفية
                e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.SelectionForeColor = Color.Orange;
            }
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

            if (gcbFilterBy.Text == "معرف الشخص")
            {
                _filterBy = enFilterBy.PersonID;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
                kgtxtFilterValue.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
                kgtxtFilterValue.AllowWhiteSpace = false;
                kgtxtFilterValue.TrimEnd = true;
                kgtxtFilterValue.NumberProperties.IntegerNumberProperties.AllowNegative = false;
                kgtxtFilterValue.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            }
            else if (gcbFilterBy.Text == "اسم الشخص")
            {
                _filterBy = enFilterBy.PersonName;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
                kgtxtFilterValue.AllowWhiteSpace = true;
                kgtxtFilterValue.TrimEnd = false;
            }
            else if (gcbFilterBy.Text == "البريد الإلكتروني")
            {
                _filterBy = enFilterBy.Email;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
                kgtxtFilterValue.AllowWhiteSpace = false;
                kgtxtFilterValue.TrimEnd = true;
            }
            else if (gcbFilterBy.Text == "رقم الهاتف")
            {
                _filterBy = enFilterBy.Phone;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Text;
                kgtxtFilterValue.TextProperties.TextFormat = KhaledGuna2TextBox.clsText.enTextFormat.Phone;
                kgtxtFilterValue.TextProperties.PhoneProperties.AllowPlusSign = false;
                kgtxtFilterValue.TextProperties.PhoneProperties.MaxPhoneLength = 16;
                kgtxtFilterValue.AllowWhiteSpace = false;
                kgtxtFilterValue.TrimEnd = true;
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

        private void gbtnAddPerson_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }

        private void gtsmAddPerson_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }

        private void gtsmEditPerson_Click(object sender, EventArgs e)
        {
            int personID = Convert.ToInt32(gdgvPeople.CurrentRow.Cells[0].Value);

            frmAddUpdatePerson frm = new frmAddUpdatePerson(personID);
            frm.OnCloseAndSaved += x => _Refresh();
            clsPL_Global.MainForm.AddNewFormAtContainer(frm);
        }

        private async void gtsmDeletePerson_Click(object sender, EventArgs e)
        {
            if (clsPL_Global.CurrentUserSettings.AskBeforeDeletePerson)
                if (clsPL_MessageBoxs.ShowMessage("هل أنت متأكد من رغبتك حذف هذا الشخص", "طلب موافقة", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    return;

            int personID = Convert.ToInt32(gdgvPeople.CurrentRow.Cells[0].Value);

            if (await clsPerson.DeletePersonByID(personID))
            {
                _Refresh();
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

        private async void gibtnRefreshData_Click(object sender, EventArgs e)
        {
            _pageNumber = 1;
            await _LoadDataAtDataGridView(_filterBy);
        }

    }
}
