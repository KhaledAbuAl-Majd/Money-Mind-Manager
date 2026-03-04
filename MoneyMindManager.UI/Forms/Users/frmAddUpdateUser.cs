using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using KhaledControlLibrary1;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Shared.DTOs.Permissions;
using MoneyMindManager.Shared.DTOs.User;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager.UI.Properties;
using MoneyMindManager_Presentation.Global;

namespace MoneyMindManager_Presentation.Users
{
    public partial class frmAddUpdateUser : Form
    {
        private IPersonApiClient _personApiClient;
        private IUserSession _userSession;
        private IMessageBoxService _messageBoxService;
        private IUserApiClient _userApiClient;
        private IFormDisplayer _formDisplayer;
        private bool isInitialized = false;
        public frmAddUpdateUser(IPersonApiClient personApiClient, IUserSession userSession, IMessageBoxService messageBoxService,
           IUserApiClient userApiClient, IFormDisplayer formDisplayer)
        {
            this._personApiClient = personApiClient;
            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._userApiClient = userApiClient;
            this._formDisplayer = formDisplayer;
            if (!_CheckUserPermissions())
            {
                this.Dispose();
                return;
            }

            InitializeComponent();
            Mode = enMode.AddNew;
            _UserID = null;
            _User = new UserDTO();
        }

        public bool Initialize()
        {
            if (!ctrlPersonCardWithFilter1.Initialize(_personApiClient, _userSession, _messageBoxService, _userApiClient, _formDisplayer))
                return false;
            this.isInitialized = true;
            return true;
        }

        public bool Initialize(int UserID)
        {
            if (!ctrlPersonCardWithFilter1.Initialize(_personApiClient, _userSession, _messageBoxService, _userApiClient, _formDisplayer))
                return false;
            Mode = enMode.Update;
            this._UserID = UserID;
            this.isInitialized = true;
            return true;
        }

        bool _CheckUserPermissions()
        {
            if (_userSession.IsHasPermissions(enPermissions.Admin))
                return true;

            _messageBoxService.DisplayError("ليس لديك صلاحية إضافة/تعديل المستخدمين.");
            return false;
        }

        bool _IsPersonEdited = false;

        /// <summary>
        /// When close and saved Event With UserID Parameter
        /// </summary>
        public event Action<int> OnCloseAndSavedOrEditing;

        bool _isSaved = false;
        enum enMode { AddNew, Update };
        enMode Mode { get; set; }

        private int? _UserID { get; set; }
        private UserDTO _User { get; set; }
        private void kgtxtpassword_IconRightClick(object sender, EventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;

            if (kgtxt.UseSystemPasswordChar)
            {
                kgtxt.UseSystemPasswordChar = false;
                kgtxt.IconRight = Resources.crossed_eye_icon_256370;
            }
            else
            {
                kgtxt.UseSystemPasswordChar = true;
                kgtxt.IconRight = Resources.eye_icon_256043;
            }
        }

        void ChangeHeaderValue(string txt)
        {
            this.Text = txt;
            lblHeader.Text = txt;
        }

        void _ResetUserControls()
        {
            lblUserID.Text = "N/A";
            gtswIsActive.Checked = true;
            kgtxtUserName.Text = null;
            kgtxtNotes.Text = null;
            kgtxtpassword.Text = null;
            kgtxtConfirmPassword.Text = null;
        }
        void _ChangeEnablityOfUserControls(bool value)
        {
            gbtnSave.Enabled = value;
            gtswIsActive.Enabled = value;
            gibtnDeleteUser.Enabled = value;
            kgtxtUserName.Enabled = value;
            kgtxtNotes.Enabled = value;

            kgtxtpassword.Enabled = (Mode == enMode.AddNew) ? value : false;
            kgtxtConfirmPassword.Enabled = kgtxtpassword.Enabled;

            chklbUserPermissions.Enabled = value;
        }

        async Task _AddNewMode()
        {
            _ChangeEnablityOfUserControls(false);
            kgtxtpassword.IsRequired = true;
            kgtxtConfirmPassword.IsRequired = true;

            ChangeHeaderValue("إضافة مستخدم");
            _UserID = null;
            _User = new UserDTO();

            var result = await _userApiClient.GetPermissionsMetadata();

            if (!result.IsSuccess)
            {
                _messageBoxService.DisplayError(result.ErrorMessage);
                this.Close();
                return;
            }

            _User.PermissionsList = result.Data;

            lblUserID.Text = "N/A";
            ctrlPersonCardWithFilter1.FocusOnTextBox();
        }

        async Task _UpdateMode()
        {
            ChangeHeaderValue("تعديل بيانات مستخدم");

            var result = await _userApiClient.GetByUserID(Convert.ToInt32(_UserID));

            if (!result.IsSuccess || result.Data is null)
            {
                _messageBoxService.DisplayError("فشل تحميل بيانات المستخدم\n" + result.ErrorMessage);
                this.Close();
                return;
            }

            UserDTO searchedUser = result.Data;

            this._UserID = searchedUser.UserID;
            this._User = searchedUser;

            if (!await this.ctrlPersonCardWithFilter1.LoadPerson(Convert.ToInt32(_User.PersonID)))
            {
                _messageBoxService.DisplayError("فشل تحميل بيانات الشخص");
                this.Close();
                return;
            }

            lblUserID.Text = _User.UserID.ToString();
            gtswIsActive.Checked = _User.IsActive;
            kgtxtUserName.Text = _User.UserName;
            kgtxtNotes.Text = _User.Notes;

            _ChangeEnablityOfUserControls(!_User.IsDeleted);
            kgtxtpassword.IsRequired = false;
            kgtxtConfirmPassword.IsRequired = false;
            kgtxtpassword.PlaceholderText = "غير متاح تغيير كلمة السر";
            kgtxtConfirmPassword.PlaceholderText = "غير متاح تغيير كلمة السر";

            if (_User.IsAdmin)
                chklbUserPermissions.SelectionMode = SelectionMode.None;

            if (_User.IsDeleted)
            {
                lbluserMessage.Text = "هذا المستخدم محذوف لا يمكن التعديل عليه !";
                lbluserMessage.Visible = true;
            }
        }

        void _ResteObject()
        {
            _User = new UserDTO();
        }

        List<int> _GetCheckedPermissions()
        {
            List<int> items = new List<int>();

            foreach (var item in chklbUserPermissions.CheckedItems)
            {
                var permissionItem = item as PermissionInfo;

                if (permissionItem != null)
                {
                    items.Add(permissionItem.ItemValue);
                }
            }

            return items;
        }

        async Task _Save()
        {
            if (!gbtnSave.Enabled)
                return;

            gbtnSave.Enabled = false;

            if (!ValidateChildren())
            {
                _messageBoxService.ShowValidateChildrenFailedMessage();
                return;
            }

            _User.IsActive = gtswIsActive.Checked;
            _User.UserName = kgtxtUserName.ValidatedText;
            _User.Notes = kgtxtNotes.ValidatedText;

            lbluserMessage.Visible = false;

            if (Mode == enMode.AddNew)
            {
                string password = kgtxtpassword.ValidatedText;
                var permissionsList = _GetCheckedPermissions();
                int personID = Convert.ToInt32(ctrlPersonCardWithFilter1.Person.PersonID);
                var createDTO = new CreateUserDTO(_User.UserName, personID, password, _User.IsActive, _User.Notes, Convert.ToInt32(-_userSession.UserID), permissionsList);

                var result = await _userApiClient.Add(createDTO, Convert.ToInt32(_userSession.UserID));

                if (!result.IsSuccess || result.Data is null)
                {
                    _messageBoxService.DisplayError(result.ErrorMessage);
                    _ResteObject();
                    return;
                }

                _User = result.Data;
                _messageBoxService.Display($"تم إضافة المستخدم بنجاج بمعرف [{_User.UserID}]", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);


                Mode = enMode.Update;
                _UserID = _User.UserID;
                lblUserID.Text = _UserID.ToString();
                ChangeHeaderValue("تعديل بيانات المستخدم");
                kgtxtpassword.Enabled = false;
                kgtxtConfirmPassword.Enabled = false;
                ctrlPersonCardWithFilter1.EnablityOfSearchPart = false;
                _isSaved = true;
            }
            else if (Mode == enMode.Update)
            {
                if (_User.UserID == _userSession.UserID && !_User.IsActive)
                {
                    lbluserMessage.Text = "لا يمكنك إلغاء نشاط المستخدم الحالي";
                    lbluserMessage.Visible = true;
                    return;
                }

                if (!_User.IsAdmin)
                {
                    var permissions = new HashSet<int>(_GetCheckedPermissions());
                    _User.PermissionsList.ForEach(item => item.Checked = permissions.Contains(item.ItemValue));
                }

                var result = await _userApiClient.Update(_User, Convert.ToInt32(_userSession.UserID));
                if (!result.IsSuccess || !result.Data)
                {
                    _messageBoxService.DisplayError("فشل تحديث بيانات المستخدم\n" + result.ErrorMessage);
                    return;
                }

                _messageBoxService.Display("تم تعديل بيانات المستخدم بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _isSaved = true;
            }
        }

        void _LoadUserPermissions()
        {
            // NOTE:
            // Sometimes Windows Forms throws a non-critical internal exception when assigning
            // a DataSource to checked list controls (like CheckedListBox).
            // This happens inconsistently and does NOT affect the execution or data binding.
            // The code continues to work normally, so this warning can be safely ignored.


            chklbUserPermissions.DataSource = _User.PermissionsList;
            chklbUserPermissions.DisplayMember = nameof(PermissionInfo.ItemName);
            chklbUserPermissions.ValueMember = nameof(PermissionInfo.ItemValue);

            byte index = 0;
            foreach (var item in _User.PermissionsList)
            {
                chklbUserPermissions.SetItemChecked(index, item.Checked);
                index++;
            }
        }

        private async void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            if(!isInitialized)
            {
                this.Close();
                return;
            }

            lbluserMessage.Visible = false;

            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        await _AddNewMode();
                        break;
                    }
                case enMode.Update:
                    {
                        await _UpdateMode();
                        break;
                    }
            }

            _LoadUserPermissions();
        }

        private void kgtxt_OnValidationError(object sender, KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            KhaledGuna2TextBox kgtxtBox = (KhaledGuna2TextBox)sender;
            e.CancelEventArgs.Cancel = true;
            string errorMessage = clsPL_Utils.GetValidationErrorTypeString(e.validationErrorType, kgtxtBox);

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

        private async void gbtnClose_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(_User.UserID);

            if (_isSaved || _IsPersonEdited)
                OnCloseAndSavedOrEditing?.Invoke(userID);

            if (userID == _userSession.UserID)
                await _userSession.Refresh();

            this.Close();
        }

        private void kgtxtUserName_After_kgtxt_Validating_1(object sender, KhaledGuna2TextBox.AfterMyValidatingEventArgs e)
        {
            if (e.ValidationgResult)
            {
                string userName = kgtxtUserName.ValidatedText;

                if ((Mode == enMode.AddNew) || (Mode == enMode.Update && _User.UserName != userName))
                {
                    //var result = _userApiClient.IsExistByUserName(userName).GetAwaiter().GetResult();

                    //if (!result.IsSuccess)
                    //{
                    //    _messageBoxService.DisplayError(result.ErrorMessage);
                    //    e.CancelEventArgs.Cancel = false;
                    //    errorProvider1.SetError(kgtxtUserName, null);
                    //    return;
                    //}

                    //if (result.Data)
                    //{
                    //    e.CancelEventArgs.Cancel = true;
                    //    errorProvider1.SetError(kgtxtUserName, "اسم المستخدم مستخدم, قم بتجربة اسم آخر");
                    //}
                    //else
                    //{
                    //    e.CancelEventArgs.Cancel = false;
                    //    errorProvider1.SetError(kgtxtUserName, null);
                    //}
                }
            }
        }

        private void kgtxtConfirmPassword_After_kgtxt_Validating(object sender, KhaledGuna2TextBox.AfterMyValidatingEventArgs e)
        {
            if (e.ValidationgResult && Mode == enMode.AddNew)
            {
                if (kgtxtConfirmPassword.ValidatedText != kgtxtpassword.ValidatedText)
                {
                    e.CancelEventArgs.Cancel = true;
                    errorProvider1.SetError(kgtxtConfirmPassword, "كلمة السر يجب أن تكون متطابقة");
                }
                else
                {
                    e.CancelEventArgs.Cancel = false;
                    errorProvider1.SetError(kgtxtConfirmPassword, null);
                }
            }
        }

        private void ctrlPersonCardWithFilter1_OnFailed()
        {
            _ChangeEnablityOfUserControls(false);
            _ResetUserControls();
        }

        private void ctrlPersonCardWithFilter1_OnSuccess()
        {
            _ChangeEnablityOfUserControls(true);
        }

        private void ctrlPersonCardWithFilter1_OnEditingPerson()
        {
            _IsPersonEdited = true;
        }

        private void kgtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                gbtnSave.PerformClick();
            }
        }

        private void chklbUserPermissions_Leave(object sender, EventArgs e)
        {
            chklbUserPermissions.ClearSelected();
        }

        private async void gibtnDeleteUser_Click(object sender, EventArgs e)
        {
            if (_UserID == null || Mode == enMode.AddNew)
            {
                lbluserMessage.Text = "لا يمكن حذف مستخدم لم يضف بعد !";
                lbluserMessage.Visible = true;
                return;
            }

            lbluserMessage.Visible = false;

            if (_userSession.CurrentUserSettings.AskBeforeDeleteUser)
                if (_messageBoxService.Display("هل أنت متأكد من رغبتك حذف هذا المستخدم", "طلب موافقة", MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    return;

            if (_UserID == _userSession.UserID)
            {
                _messageBoxService.DisplayError("لا يمكنك حذف المستخدم الحالي");
                return;
            }

            var deleteResult = await _userApiClient.Delete(Convert.ToInt32(_UserID), Convert.ToInt32(_userSession.UserID));

            if (!deleteResult.IsSuccess || !deleteResult.Data)
            {
                _messageBoxService.DisplayError("فشل حذف المستخدم\n" + deleteResult.ErrorMessage);
                return;
            }
            _isSaved = true;
            gbtnClose.PerformClick();
        }
    }
}
