using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KhaledControlLibrary1;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Shared.DTOs.User;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Users;

namespace MoneyMindManager_Presentation
{
    public partial class FrmUsers : Form
    {
        private IUserSession _userSession;
        private IMessageBoxService _messageBoxService;
        private IUserApiClient _userApiClient;
        private IFormDisplayer _formDisplayer;
        public FrmUsers(IUserSession userSession, IMessageBoxService messageBoxService,
           IUserApiClient userApiClient, IFormDisplayer formDisplayer)
        {
            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._userApiClient = userApiClient;
            this._formDisplayer = formDisplayer;

            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }

            InitializeComponent();
        }

        bool _CheckPermissions()
        {
            if (_userSession.IsHasPermissions(enPermissions.UsersList))
                return true;

            _messageBoxService.DisplayError("ليس لديك صلاحية قائمة المستخدمين.");
            return false;
        }



        enum enFilterBy { All, UserID, UserName, PersonName };

        enFilterBy _filterBy = enFilterBy.All;

        bool _IsHeaderCreated = false;
        bool _searchByPageNumber = false;

        int _pageNumber = 1;

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

            var filterDTO = new UserFilterDTO();
            if (filterBy == enFilterBy.All || (string.IsNullOrEmpty(kgtxtFilterValue.ValidatedText)))
            {
                filterDTO.IsActive = isActive;
                filterDTO.TextSearchMode = textSearchMode;
                filterDTO.PageNumber = _pageNumber;
            }
            else if (filterBy == enFilterBy.UserID)
            {
                int userID = Convert.ToInt32(kgtxtFilterValue.ValidatedText);
                filterDTO.UserID = userID;
                filterDTO.IsActive = isActive;
                filterDTO.TextSearchMode = textSearchMode;
                filterDTO.PageNumber = _pageNumber;
            }
            else if (filterBy == enFilterBy.UserName)
            {
                string userName = kgtxtFilterValue.ValidatedText;
                filterDTO.UserName = userName;
                filterDTO.IsActive = isActive;
                filterDTO.TextSearchMode = textSearchMode;
                filterDTO.PageNumber = _pageNumber;
            }
            else if (filterBy == enFilterBy.PersonName)
            {
                string personName = kgtxtFilterValue.ValidatedText;
                filterDTO.PersonName = personName;
                filterDTO.IsActive = isActive;
                filterDTO.TextSearchMode = textSearchMode;
                filterDTO.PageNumber = _pageNumber;
            }
            else
                return;

            var result = await _userApiClient.GetAll(filterDTO, Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess)
            {
                _messageBoxService.DisplayError(result.ErrorMessage);
                return;
            }

            var DTO = result.Data;

            if (DTO == null)
                return;


            if (DTO.Data.Count() == 0)
            {
                lblNoRecordsFoundMessage.Visible = true;
                gdgvUser.DataSource = null;
                _IsHeaderCreated = false;
                _pageNumber = 1;
            }
            else
            {
                lblNoRecordsFoundMessage.Visible = false;
                gdgvUser.DataSource = DTO.Data;
            }

            lblUserMessage.Visible = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = _pageNumber.ToString();
            _searchByPageNumber = true;

            lblTotalRecordsNumber.Text = DTO.TotalRecords.ToString();
            lblCurrentPageOfNumberOfPages.Text = string.Concat(_pageNumber, "   من   ", DTO.TotalPages, "  صفحات");
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = true;
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = (DTO.TotalPages < 1) ? 1 : DTO.TotalPages;
            lblCurrentPageRecordsCount.Text = gdgvUser.Rows.Count.ToString();

            gibtnNextPage.Enabled = (_pageNumber < DTO.TotalPages);
            gibtnPreviousPage.Enabled = (_pageNumber > 1);
            //

            if (!_IsHeaderCreated && gdgvUser.Rows.Count > 0)
            {

                gdgvUser.Columns[nameof(UserSummary.UserID)].HeaderText = "معرف المستخدم";
                gdgvUser.Columns[nameof(UserSummary.UserID)].Width = 125;

                gdgvUser.Columns[nameof(UserSummary.UserName)].HeaderText = "اسم المستخدم";
                gdgvUser.Columns[nameof(UserSummary.UserName)].Width = 268;

                gdgvUser.Columns[nameof(UserSummary.PersonName)].HeaderText = "اسم الشخص";
                gdgvUser.Columns[nameof(UserSummary.PersonName)].Width = 260;

                gdgvUser.Columns[nameof(UserSummary.Phone)].HeaderText = "رقم الهاتف";
                gdgvUser.Columns[nameof(UserSummary.Phone)].Width = 175;

                gdgvUser.Columns[nameof(UserSummary.Email)].HeaderText = "البريد الإلكتروني";
                gdgvUser.Columns[nameof(UserSummary.Email)].Width = 270;

                gdgvUser.Columns[nameof(UserSummary.IsActive)].HeaderText = "الفعالية";
                gdgvUser.Columns[nameof(UserSummary.IsActive)].Width = 80;

                _IsHeaderCreated = true;
            }
        }

        void _AddNewUser()
        {
            _formDisplayer.OpenAtContainer<frmAddUpdateUser>(frm =>
            {
                if (!frm.Initialize())
                    return false;
                frm.OnCloseAndSavedOrEditing += x => _Refresh();
                return true;
            });
        }

        async void _Refresh()
        {
            _pageNumber = 1;
            _searchByPageNumber = false;
            kgtxtFilterValue.Text = "";
            _searchByPageNumber = true;

            await _LoadDataAtDataGridView(_filterBy);
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

            _formDisplayer.OpenAtContainer<frmUserInfo>(frm =>
            {
                if (!frm.Initialize(userID))
                    return false;
                frm.OnEditingUserAndFormClosed += _Refresh;
                return true;
            });

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

            _formDisplayer.OpenAtContainer<frmAddUpdateUser>(frm =>
            {
                if (!frm.Initialize(userID))
                    return false;
                frm.OnCloseAndSavedOrEditing += x => _Refresh();
                return true;
            });
        }

        private async void gtsmDeleteUser_Click(object sender, EventArgs e)
        {
            if (_userSession.CurrentUserSettings.AskBeforeDeleteUser)
                if (_messageBoxService.Display("هل أنت متأكد من رغبتك حذف هذا المستخدم", "طلب موافقة", MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    return;

            int userID = Convert.ToInt32(gdgvUser.CurrentRow.Cells[0].Value);

            if (userID == _userSession.UserID)
            {
                _messageBoxService.DisplayError("لا يمكنك حذف المستخدم الحالي");
                return;
            }

            var deleteResult = await _userApiClient.Delete(Convert.ToInt32(userID), Convert.ToInt32(_userSession.UserID));

            if (!deleteResult.IsSuccess || !deleteResult.Data)
            {
                _messageBoxService.DisplayError("فشل حذف المستخدم\n" + deleteResult.ErrorMessage);
                return;
            }

            _Refresh();
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
