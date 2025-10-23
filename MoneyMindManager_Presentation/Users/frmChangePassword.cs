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

namespace MoneyMindManager_Presentation.Users
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        int _userID;

         clsUser _User
        {
            get
            {
                return ctrlUserCard1.User;
            }
        }

        async Task _Save()
        {
            if (!gbtnSave.Enabled)
                return;

            gbtnSave.Enabled = false;

            if (!ValidateChildren())
            {
                clsGlobalMessageBoxs.ShowValidateChildrenFailedMessage();
                return;
            }

            string oldPassword = kgtxtOldPassword.ValidatedText;
            string newPassword = kgtxtNewpassword.ValidatedText;

            if (await _User.ChangePassword(oldPassword,newPassword))
            {
                clsGlobalMessageBoxs.ShowMessage($"تم تغيير كلمة السر بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                kgtxtOldPassword.Text = null;
                kgtxtNewpassword.Text = null;
                kgtxtConfirmNewPassword.Text = null;
            }
        }
        private async void frmChangePassword_Load(object sender, EventArgs e)
        {
            if (!await ctrlUserCard1.LoadUser(_userID))
                this.Close();
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

        private void kgtxtConfirmPassword_OnValidationSuccess(object sender, CancelEventArgs e)
        {
            if (kgtxtConfirmNewPassword.ValidatedText != kgtxtNewpassword.ValidatedText)
            {
                e.Cancel = true;
                errorProvider1.SetError(kgtxtConfirmNewPassword, "كلمة السر يجب أن تكون متطابقة");
                return;
            }

            kgtxt_OnValidationSuccess(sender, e);
        }

        private async void gbtnSave_Click(object sender, EventArgs e)
        {
            await _Save();
            gbtnSave.Enabled = true;
        }

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

        private void gbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
