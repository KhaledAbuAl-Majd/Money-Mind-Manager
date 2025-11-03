using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using KhaledControlLibrary1;
using MoneyMindManager_Business;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Properties;
using MoneyMindManagerGlobal;
using static Guna.UI2.Native.WinApi;

namespace MoneyMindManager_Presentation.Users
{
    public partial class frmAddUpdateUser : Form
    {
        public frmAddUpdateUser()
        {
            if (!_CheckUserPermissions())
            {
                this.Dispose();
                return;
            }

            InitializeComponent();
            Mode = enMode.AddNew;
            _UserID = null;
            _User = new clsUser();
        }

        public frmAddUpdateUser(int UserID)
        {
            if (!_CheckUserPermissions())
            {
                this.Dispose();
                return;
            }

            InitializeComponent();
            Mode = enMode.Update;
            this._UserID = UserID;
        }

        bool _CheckUserPermissions()
        {
            return clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.Admin,
                  "ليس لديك صلاحية إضافة/تعديل المستخدمين.");
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
        private clsUser _User { get; set; }
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

        void _AddNewMode()
        {
            _ChangeEnablityOfUserControls(false);
            kgtxtpassword.IsRequired = true;
            kgtxtConfirmPassword.IsRequired = true;

            ChangeHeaderValue("إضافة مستخدم");
            _UserID = null;
            _User = new clsUser();
            lblUserID.Text = "N/A";
            ctrlPersonCardWithFilter1.FocusOnTextBox();
        }

        async Task _UpdateMode()
        {
            ChangeHeaderValue("تعديل بيانات مستخدم");

            clsUser searchedUser = await clsUser.FindUserByUserID(Convert.ToInt32(_UserID));

            if (searchedUser == null)
            {
                clsPL_MessageBoxs.ShowErrorMessage("فشل تحميل بيانات المستخدم");
                this.Close();
                return;
            }

            this._UserID = searchedUser.UserID;
            this._User = searchedUser;

            if (!await this.ctrlPersonCardWithFilter1.LoadPerson(Convert.ToInt32(_User.PersonID)))
            {
                clsPL_MessageBoxs.ShowErrorMessage("فشل تحميل بيانات الشخص");
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
            _User = new clsUser();
        }

        List<int> _GetCheckedPermissions()
        {
            List<int> items = new List<int>();

            foreach (var item in chklbUserPermissions.CheckedItems)
            {
                var permissionItem = item as clsUser.clsPermissionItems;

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
                clsPL_MessageBoxs.ShowValidateChildrenFailedMessage();
                return;
            }

            _User.IsActive = gtswIsActive.Checked;
            _User.UserName = kgtxtUserName.ValidatedText;
            _User.Notes = kgtxtNotes.ValidatedText;

            if (Mode == enMode.AddNew)
            {
                if (!_User.EnterPasswordAtAddMode(kgtxtpassword.ValidatedText))
                {
                    clsPL_MessageBoxs.ShowErrorMessage("فشل تكوين كلمة المرور");
                    _ResteObject();
                    return;
                }

                if (!_User.EnterPersonIDAtAddMode(Convert.ToInt32(ctrlPersonCardWithFilter1.Person.PersonID)))
                {
                    clsPL_MessageBoxs.ShowErrorMessage("فشل تسجيل معرف الشخص للمستخدم");
                    _ResteObject();
                    return;
                }
            }
            else if (Mode == enMode.Update)
            {
                if (_User.UserID == clsGlobalSession.CurrentUserID && !_User.IsActive)
                {
                    lbluserMessage.Text = "لا يمكنك إلغاء نشاط المستخدم الحالي";
                    lbluserMessage.Visible = true;
                    return;
                }
            }

            if (!_User.IsAdmin)
                _User.AssingUserPermissions(_GetCheckedPermissions());

            lbluserMessage.Visible = false;

            if (await _User.Save())
            {
                if (Mode == enMode.AddNew)
                {
                    clsPL_MessageBoxs.ShowMessage($"تم إضافة المستخدم بنجاج بمعرف [{_User.UserID}]", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Mode = enMode.Update;
                    _UserID = _User.PersonID;
                    lblUserID.Text = _UserID.ToString();
                    ChangeHeaderValue("تعديل بيانات المستخدم");
                    kgtxtpassword.Enabled = false;
                    kgtxtConfirmPassword.Enabled = false;
                    ctrlPersonCardWithFilter1.EnablityOfSearchPart = false;
                }
                else if (Mode == enMode.Update)
                {
                    clsPL_MessageBoxs.ShowMessage("تم تعديل بيانات المستخدم بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _isSaved = true;
            }
            else if (Mode == enMode.AddNew)
                _ResteObject();
        }

        void _LoadUserPermissions()
        {
            var items = _User.GetUserPermissionItems();

            chklbUserPermissions.DataSource = items;
            chklbUserPermissions.DisplayMember = "ItemName";
            chklbUserPermissions.ValueMember = "ItemValue";

            byte index = 0;
            foreach (var item in items)
            {
                chklbUserPermissions.SetItemChecked(index, item.Checked);
                index++;
            }
        }
        private async void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            lbluserMessage.Visible = false;

            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        _AddNewMode();
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

            if (userID == clsGlobalSession.CurrentUserID)
                await clsPL_Global.RefreshCurrentUser();

            this.Close();
        }


        private void kgtxtUserName_After_kgtxt_Validating_1(object sender, KhaledGuna2TextBox.AfterMyValidatingEventArgs e)
        {
            if (e.ValidationgResult)
            {
                string userName = kgtxtUserName.ValidatedText;

                if ((Mode == enMode.AddNew) || (Mode == enMode.Update && _User.UserName != userName))
                {
                    if (clsUser.IsUserExistByUserName(userName))
                    {
                        e.CancelEventArgs.Cancel = true;
                        errorProvider1.SetError(kgtxtUserName, "اسم المستخدم مستخدم, قم بتجربة اسم آخر");
                    }
                    else
                    {
                        e.CancelEventArgs.Cancel = false;
                        errorProvider1.SetError(kgtxtUserName, null);
                    }
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

            if (clsPL_Global.CurrentUserSettings.AskBeforeDeleteUser)
                if (clsPL_MessageBoxs.ShowMessage("هل أنت متأكد من رغبتك حذف هذا المستخدم", "طلب موافقة", MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    return;

            if (Convert.ToInt32(_UserID) == clsGlobalSession.CurrentUserID)
            {
                clsPL_MessageBoxs.ShowErrorMessage("لا يمكنك حذف المستخدم الحالي");
                return;
            }

            if (await _User.DeleteUserByUserID())
            {
                _isSaved = true;
                gbtnClose.PerformClick();
            }

        }
    }
}
