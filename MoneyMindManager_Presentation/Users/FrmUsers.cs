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
using MoneyMindManager_Presentation.Users;
using MoneyMindManagerGlobal;
using static MoneyMindManager_Business.clsBLLGlobal;

namespace MoneyMindManager_Presentation
{
    public partial class FrmUsers : Form
    {
        public FrmUsers()
        {
            if (!clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.UsersList,
                "ليس لديك صلاحية قائمة المستخدمين."))
            {
                this.Dispose();
                return;
            }

            InitializeComponent();
        }



        enum enFilterBy { All,UserID, UserName, PersonName };

        enFilterBy _filterBy = enFilterBy.All;

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
        async Task _LoadDataAtDataGridView(enFilterBy filterBy)
        {
            SearchAfterTimerFinish.Stop();

            if (!_CheckValidationChildren())
                return;

            bool? isActive = null;

            if (gcbIsActive.Text == "الكل")
                isActive = null;
            else if (gcbIsActive.Text == "فعال")
                isActive = true;
            else if (gcbIsActive.Text == "موقوف")
                isActive = false;


            enTextSearchMode textSearchMode = enTextSearchMode.WordsPrefix_Fast;

            if (grbTextSearchMode_WordsPrefix.Checked)
                textSearchMode = enTextSearchMode.WordsPrefix_Fast;
            else if (grbTextSearchMode_SubString.Checked)
                textSearchMode = enTextSearchMode.Substring_Slow;

            clsDataColumns.clsUserClasses.clsGetAllUsers result = null;

            if (filterBy == enFilterBy.All || (string.IsNullOrEmpty(kgtxtFilterValue.ValidatedText)))
            {
                result = await clsUser.GetAllUsers(isActive, textSearchMode, _pageNumber);
            }
            else if (filterBy == enFilterBy.UserID)
            {
                int userID = Convert.ToInt32(kgtxtFilterValue.ValidatedText);
                result = await clsUser.GetAllUsersByUserID(userID,isActive, textSearchMode, _pageNumber);
            }
            else if (filterBy == enFilterBy.UserName)
            {
                string userName = kgtxtFilterValue.ValidatedText;
                result = await clsUser.GetAllUsersByUserName(userName, isActive, textSearchMode, _pageNumber);
            }
            else if (filterBy == enFilterBy.PersonName)
            {
                string personName = kgtxtFilterValue.ValidatedText;
                result = await clsUser.GetAllUsersByPersonName(personName, isActive, textSearchMode, _pageNumber);

            }
            else
                return;

            if (result == null)
                return;


            if (result.dtUsers.Rows.Count == 0)
            {
                lblNoRecordsFoundMessage.Visible = true;
                gdgvUser.DataSource = null;
                _IsHeaderCreated = false;
                _pageNumber = 1;
            }
            else
            {
                lblNoRecordsFoundMessage.Visible = false;
                gdgvUser.DataSource = result.dtUsers;
            }

            lblUserMessage.Visible = false;
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
                gdgvUser.Columns["UserID"].Width = 125;

                gdgvUser.Columns["UserName"].HeaderText = "اسم المستخدم";
                gdgvUser.Columns["UserName"].Width = 268;

                gdgvUser.Columns["PersonName"].HeaderText = "اسم الشخص";
                gdgvUser.Columns["PersonName"].Width = 260;

                gdgvUser.Columns["Phone"].HeaderText = "رقم الهاتف";
                gdgvUser.Columns["Phone"].Width = 175;

                gdgvUser.Columns["Email"].HeaderText = "البريد الإلكتروني";
                gdgvUser.Columns["Email"].Width = 270;

                gdgvUser.Columns["IsActive"].HeaderText = "الفعالية";
                gdgvUser.Columns["IsActive"].Width = 80;

                _IsHeaderCreated = true;
            }
        }

        void _AddNewUser()
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.OnCloseAndSavedOrEditing += x => _RefreshFilter();
            clsPL_Global.MainForm.AddNewFormAtContainer(frm);
        }

        async void _RefreshFilter()
        {
            if (gcbFilterBy.SelectedIndex == 0)
                await _LoadDataAtDataGridView(enFilterBy.All);
            else
                gcbFilterBy.SelectedIndex = 0;
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


        void _ShowUserInfo()
        {
            int userID = Convert.ToInt32(gdgvUser.CurrentRow.Cells[0].Value);

            frmUserInfo frm = new frmUserInfo(userID);
            frm.OnEditingUserAndFormClosed += _RefreshFilter;
            clsPL_Global.MainForm.AddNewFormAtContainer(frm);
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
        private async void FrmUsers_Shown(object sender, EventArgs e)
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
                //kgtxtFilterValue.Visible = false;
                _SetReadOnlyAtTextBox(kgtxtFilterValue);
                _filterBy = enFilterBy.All;
                if (!string.IsNullOrWhiteSpace(oldText))
                    await _LoadDataAtDataGridView(_filterBy);
                return;
            }

            //kgtxtFilterValue.Visible = true;
            _CancelReadOnlyAtTextBox(kgtxtFilterValue);
            kgtxtFilterValue.IsRequired = false;
            kgtxtFilterValue.TrimStart = false;

            if (gcbFilterBy.Text == "معرف المستخدم")
            {
                _filterBy = enFilterBy.UserID;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
                kgtxtFilterValue.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
                kgtxtFilterValue.AllowWhiteSpace = false;
                kgtxtFilterValue.TrimEnd = true;
                kgtxtFilterValue.NumberProperties.IntegerNumberProperties.AllowNegative = false;
                kgtxtFilterValue.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            }
            else if (gcbFilterBy.Text == "اسم المستخدم")
            {
                _filterBy = enFilterBy.UserName;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
                kgtxtFilterValue.AllowWhiteSpace = false;
                kgtxtFilterValue.TrimEnd = true;
            }
            else if (gcbFilterBy.Text == "اسم الشخص")
            {
                _filterBy = enFilterBy.PersonName;

                kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
                kgtxtFilterValue.AllowWhiteSpace = true;
                kgtxtFilterValue.TrimEnd = false;
            }

            if (!string.IsNullOrWhiteSpace(oldText))
                await _LoadDataAtDataGridView(_filterBy);
        }

        private async void gcbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pageNumber = 1;
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
                _pageNumber = 1;
                await _LoadDataAtDataGridView(_filterBy);
            }
        }

        private void gbtnAddUser_Click(object sender, EventArgs e)
        {
            _AddNewUser();
        }

        private void gtsmUserInfo_Click(object sender, EventArgs e)
        {
            _ShowUserInfo();
        }

        private void gtsmAddUser_Click(object sender, EventArgs e)
        {
            _AddNewUser();
        }

        private void gtsmEditUser_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(gdgvUser.CurrentRow.Cells[0].Value);

            frmAddUpdateUser frm = new frmAddUpdateUser(userID);
            frm.OnCloseAndSavedOrEditing += x => _RefreshFilter();
            clsPL_Global.MainForm.AddNewFormAtContainer(frm);
        }

        private async void gtsmDeleteUser_Click(object sender, EventArgs e)
        {
            if (clsPL_MessageBoxs.ShowMessage("هل أنت متأكد من رغبتك حذف هذا المستخدم", "طلب مواقفقة", MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                int userID = Convert.ToInt32(gdgvUser.CurrentRow.Cells[0].Value);

                if(userID == clsGlobalSession.CurrentUserID)
                {
                    clsPL_MessageBoxs.ShowErrorMessage("لا يمكنك حذف المستخدم الحالي");
                    return;
                }

                if (await clsUser.DeleteUserByUserID(userID))
                {
                    _RefreshFilter();
                }
            }
        }

        private void gdgvUser_DoubleClick(object sender, EventArgs e)
        {
            _ShowUserInfo();
        }

        private async void gibtnRefreshData_Click(object sender, EventArgs e)
        {
            _pageNumber = 1;
            await _LoadDataAtDataGridView(_filterBy);
        }

    }
}
