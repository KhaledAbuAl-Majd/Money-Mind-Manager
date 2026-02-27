using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using KhaledControlLibrary1;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Shared.DTOs.User;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager.UI.Properties;
using MoneyMindManager_Presentation.Global;

namespace MoneyMindManager_Presentation.Users
{
    public partial class frmChangePassword : Form
    {
        private IPersonApiClient _personApiClient;
        private IUserSession _userSession;
        private IMessageBoxService _messageBoxService;
        private IUserApiClient _userApiClient;
        private IFormDisplayer _formDisplayer;
        private bool isInitialized = false;
        public frmChangePassword(IPersonApiClient personApiClient, IUserSession userSession, IMessageBoxService messageBoxService,
           IUserApiClient userApiClient, IFormDisplayer formDisplayer)
        {
            InitializeComponent();
            this._personApiClient = personApiClient;
            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._userApiClient = userApiClient;
            this._formDisplayer = formDisplayer;
        }



        public bool Initialize(int UserID)
        {
            if (!ctrlUserCard1.Initialize(_personApiClient, _userSession, _messageBoxService, _userApiClient, _formDisplayer))
                return false;

            this._userID = UserID;
            this.isInitialized = true;
            return true;
        }

        int _userID;

        UserDTO _User
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
                _messageBoxService.ShowValidateChildrenFailedMessage();
                return;
            }

            string oldPassword = kgtxtOldPassword.ValidatedText;
            string newPassword = kgtxtNewpassword.ValidatedText;

            var result = await _userApiClient.ChangePassword(_userID, oldPassword, newPassword, Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || !result.Data)
            {
                _messageBoxService.DisplayError("فشل تغيير كلمة السر !\n" + result.ErrorMessage);
                return;
            }

            _messageBoxService.Display($"تم تغيير كلمة السر بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

            kgtxtOldPassword.Text = null;
            kgtxtNewpassword.Text = null;
            kgtxtConfirmNewPassword.Text = null;
        }
        private async void frmChangePassword_Load(object sender, EventArgs e)
        {
            if (!isInitialized)
            {
                this.Close();
                return;
            }

            if (!await ctrlUserCard1.LoadUser(_userID))
                this.Close();
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
