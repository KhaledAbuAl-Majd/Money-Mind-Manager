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
using MoneyMindManager_Presentation.Properties;
using static Guna.UI2.Native.WinApi;

namespace MoneyMindManager_Presentation.Users
{
    public partial class frmAddUpdateUser : Form
    {
        public frmAddUpdateUser()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
            _UserID = null;
            _User = new clsUser();
        }

        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            this._UserID = UserID;
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
            kgtxtUserName.Enabled = value;
            kgtxtNotes.Enabled = value;

            gpnlPasswordPart.Enabled = (Mode == enMode.AddNew) ? value : false;

            //if(_ChangeMode == enMode.AddNew)
            //{
            //    gpnlPasswordPart.Enabled = value;
            //    kgtxtpassword.IsRequired = true;
            //    kgtxtConfirmPassword.IsRequired = true;
            //}
            //else
            //{
            //    gpnlPasswordPart.Enabled = false;
            //    kgtxtpassword.IsRequired = false;
            //    kgtxtConfirmPassword.IsRequired = false;
            //}
        }

        void _AddNewMode()
        {
            _ChangeEnablityOfUserControls(false);
            kgtxtpassword.IsRequired = true;
            kgtxtConfirmPassword.IsRequired = true;
            //gbtnSave.Enabled = false;
            //gpnlUserPart.Enabled = false;
            ChangeHeaderValue("إضافة مستخدم");
            _UserID = null;
            _User = new clsUser();
            lblUserID.Text = "N/A";
            ctrlPersonCardWithFilter1.FocusOnTextBox();
        }

        async Task _UpdateMode()
        {
            ChangeHeaderValue("تعديل بيانات مستخدم");

            clsUser searchedUser = await clsUser.FindUserByUserID(Convert.ToInt32(_UserID), Convert.ToInt32(clsGlobal_Presentation.CurrentUser.UserID));

            if (searchedUser == null)
            {
                clsGlobalMessageBoxs.ShowErrorMessage("فشل تحميل بيانات المستخدم");
                this.Close();
                return;
            }

            this._UserID = searchedUser.UserID;
            this._User = searchedUser;

            if (!await this.ctrlPersonCardWithFilter1.LoadPerson(Convert.ToInt32(_User.PersonID)))
            {
                clsGlobalMessageBoxs.ShowErrorMessage("فشل تحميل بيانات الشخص");
                this.Close();
                return;
            }

            lblUserID.Text = _User.UserID.ToString();
            gtswIsActive.Checked = _User.IsActive;
            kgtxtUserName.Text = _User.UserName;
            kgtxtNotes.Text = _User.Notes;

            _ChangeEnablityOfUserControls(true);
            kgtxtpassword.IsRequired = false;
            kgtxtConfirmPassword.IsRequired = false;
        }

        async Task _Save()
        {
            if (!ValidateChildren())
            {
                clsGlobalMessageBoxs.ShowValidateChildrenFailedMessage();
                return;
            }

            _User.IsActive = gtswIsActive.Checked;
            _User.UserName = kgtxtUserName.ValidatedText;
            _User.Notes = kgtxtNotes.ValidatedText;

            if (Mode == enMode.AddNew)
            {
                if (!_User.EnterPasswordAtAddMode(kgtxtpassword.ValidatedText))
                {
                    clsGlobalMessageBoxs.ShowErrorMessage("فشل تكوين كلمة المرور");
                    return;
                }

                if (!_User.EnterPersonIDAtAddMode(Convert.ToInt32(ctrlPersonCardWithFilter1.Person.PersonID)))
                {
                    clsGlobalMessageBoxs.ShowErrorMessage("فشل تسجيل معرف الشخص للمستخدم");
                    return;
                }

                if (!_User.EnterAccountIDAtAddMode(Convert.ToInt16(clsGlobal_Presentation.CurrentUser.AccountID)))
                {
                    clsGlobalMessageBoxs.ShowErrorMessage("فشل تسجيل معرف الحساب للمستخدم");
                    return;
                }

                if (!_User.EnterCreatedByUserIDAtAddMode(Convert.ToInt32(clsGlobal_Presentation.CurrentUser.UserID)))
                {
                    clsGlobalMessageBoxs.ShowErrorMessage("فشل تسجيل معرف منشئ الحساب");
                    return;
                }
            }
            else if (Mode == enMode.Update)
            {
                if (_User.UserID == clsGlobal_Presentation.CurrentUser.UserID && !_User.IsActive)
                {
                    //gtswIsActive.Checked = true;
                    lbluserMessage.Text = "لا يمكنك إلغاء نشاط المستخدم الحالي";
                    lbluserMessage.Visible = true;
                    return;
                }
            }

            lbluserMessage.Visible = false;

            if (await _User.Save(Convert.ToInt32(clsGlobal_Presentation.CurrentUser.UserID)))
            {
                if (Mode == enMode.AddNew)
                {
                    clsGlobalMessageBoxs.ShowMessage($"تم إضافة المستخدم بنجاج بمعرف [{_User.UserID}]", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Mode = enMode.Update;
                    _UserID = _User.PersonID;
                    lblUserID.Text = _UserID.ToString();
                    ChangeHeaderValue("تعديل بيانات المستخدم");
                    gpnlPasswordPart.Enabled = false;
                    ctrlPersonCardWithFilter1.EnablityOfSearchPart = false;
                    //gpnlPasswordPart.Visible = false;
                }
                else if (Mode == enMode.Update)
                {
                    clsGlobalMessageBoxs.ShowMessage("تم تعديل بيانات المستخدم بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _isSaved = true;
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
        }

        private void kgtxt_OnValidationError(object sender, KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            KhaledGuna2TextBox kgtxtBox = (KhaledGuna2TextBox)sender;
            e.CancelEventArgs.Cancel = true;
            string errorMessage = clsUtils.GetValidationErrorTypeString(e.validationErrorType, kgtxtBox);

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
        }

        private void gbtnClose_Click(object sender, EventArgs e)
        {
            if (_isSaved || _IsPersonEdited)
                OnCloseAndSavedOrEditing?.Invoke(Convert.ToInt32(_User.UserID));

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
            // Creat With DataBase When Adding New User 

            //if(_ChangeMode == enMode.AddNew && await clsUser.IsUserExistByPersonIDAsync(Convert.ToInt32(ctrlPersonCardWithFilter1.Person.PersonID)))
            //{
            //    clsGlobalMessageBoxs.ShowErrorMessage("هذا الشخص مرتبط بمستخدم بالفعل");
            //    _ChangeEnablityOfUserControls(false);
            //    _ResetUserControls();
            //    ctrlPersonCardWithFilter1.ResetControls();
            //    return;
            //}

            _ChangeEnablityOfUserControls(true);
        }

        private void ctrlPersonCardWithFilter1_OnEditingPerson()
        {
            _IsPersonEdited = true;
        }

        private void kgtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                gbtnSave.PerformClick();
            }
        }
    }
}
