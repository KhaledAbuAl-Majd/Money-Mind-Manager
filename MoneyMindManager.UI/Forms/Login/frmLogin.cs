using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using KhaledControlLibrary1;
using MoneyMindManager_Business;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Main;
using MoneyMindManagerGlobal;
using static Guna.UI2.Native.WinApi;

namespace MoneyMindManager_Presentation.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            //to user doubled buffered and avoid flickers when change mode or Move form

            this.SetStyle(ControlStyles.UserPaint |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        enum enMode { Login, CreateAccount };

        enMode _Mode;
        async Task _ChangeMode(enMode mode)
        {
            _Mode = mode;

            await _ModeChanged();
        }

        bool _enableShowPasswordAfterBeEmpty = false;

        bool _loadCredentials = true;

        void _resetgpnlLoginControls()
        {
            kgtxtLoginUserName.Text = null;
            kgtxtLogin_password.Text = null;
            gtswLogin_ShowPassword.Checked = false;
            gchkLogin_RemeberMe.Checked = true;
        }
        void _resetgpnlCreateAccountControls()
        {
            kgtxtCreateAccount_PersonName.Text = null;
            kgtxtCreateAccount_UserName.Text = null;
            kgtxtCreateAccount_AccountName.Text = null;
            kgtxtCreateAccount_Password.Text = null;
            kgtxtCreatAccount_ConfirmPassowrd.Text = null;
            gtswCreateAccount_ShowPassword.Checked = false;
        }

        async Task _ModeChanged()
        {
            switch (_Mode)
            {
                case enMode.Login:
                    {
                        gpnlLogin.Enabled = true;
                        gpnlLogin.Visible = true;
                        gpnlLogin.BringToFront();
                        gpnlCreateAccount.Enabled = false;
                        gpnlCreateAccount.Visible = false;
                        _resetgpnlLoginControls();
                        gbtnMode.Text = "إنشاء حساب";
                        await _LoadLoginCredential();
                        kgtxtLoginUserName.Focus();
                        break;
                    }

                case enMode.CreateAccount:
                    {
                        gpnlCreateAccount.Enabled = true;
                        gpnlCreateAccount.Visible = true;
                        gpnlCreateAccount.BringToFront();
                        gpnlLogin.Enabled = false;
                        gpnlLogin.Visible = false;
                        _resetgpnlCreateAccountControls();
                        gbtnMode.Text = "تسجيل الدخول";
                        await _LoadCurrenciesAtComboBox();
                        kgtxtCreateAccount_PersonName.Focus();
                        break;
                    }
            }
        }

        async Task _LoadLoginCredential()
        {
            if (!_loadCredentials)
                return;

            string userName = null, password = null;

            var funResult = await  clsPL_Global.GetStoredCredential();
            userName = funResult.UserName;
            password = funResult.Password;

            if (funResult.Result && userName != null && password != null)
            {
                kgtxtLoginUserName.Text = userName;
                kgtxtLogin_password.Text = password;

                if (gtswLogin_ShowPassword.Checked)
                    gtswLogin_ShowPassword.Checked = false;

                gtswLogin_ShowPassword.Enabled = false;
                _enableShowPasswordAfterBeEmpty = true;
            }
        }

        async Task _LoadCurrenciesAtComboBox()
        {
            DataTable dtCurrencies = await clsCurrency.GetAllCurrencies();

            gcbCreateAccount_DefaultCurrency.DataSource = dtCurrencies;
            gcbCreateAccount_DefaultCurrency.DisplayMember = "CurrencyName";
            gcbCreateAccount_DefaultCurrency.ValueMember = "CurrencyID";
            gcbCreateAccount_DefaultCurrency.SelectedIndex = gcbCreateAccount_DefaultCurrency.FindStringExact("جنيه مصري");
        }

        private async void frmLogin_Load(object sender, EventArgs e)
        {
            clsPL_Global.ActiveForm = this;
            _enableShowPasswordAfterBeEmpty = false;
            _loadCredentials = true;
            await _ChangeMode(enMode.Login);

            _ = clsBLLGlobal.RoutineMaintenance();
        }

        private void gtswLogin_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            kgtxtLogin_password.UseSystemPasswordChar = !gtswLogin_ShowPassword.Checked;
        }

        private void kgtxt_OnValidationError(object sender, KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            KhaledGuna2TextBox kgtxtBox = (KhaledGuna2TextBox)sender;

            if (kgtxtBox.Visible && kgtxtBox.Enabled)
            {

                e.CancelEventArgs.Cancel = true;
                string errorMessage = clsPL_Utils.GetValidationErrorTypeString(e.validationErrorType, kgtxtBox);

                errorProvider1.SetError(kgtxtBox, errorMessage);
                return;
            }
            else
            {
                kgtxt_OnValidationSuccess(sender, e.CancelEventArgs);
            }
        }

        private void kgtxt_OnValidationSuccess(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            errorProvider1.SetError((KhaledGuna2TextBox)sender, null);
        }

        private void gtswCreateAccount_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            kgtxtCreateAccount_Password.UseSystemPasswordChar = !gtswCreateAccount_ShowPassword.Checked;
            kgtxtCreatAccount_ConfirmPassowrd.UseSystemPasswordChar = kgtxtCreateAccount_Password.UseSystemPasswordChar;
        }

        private void kgtxtCreateAccount_UserName_After_kgtxt_Validating(object sender, KhaledGuna2TextBox.AfterMyValidatingEventArgs e)
        {
            if (e.ValidationgResult)
            {
                string userName = kgtxtCreateAccount_UserName.ValidatedText;

                if (_Mode == enMode.CreateAccount)
                {
                    if (clsUser.IsUserExistByUserName(userName))
                    {
                        e.CancelEventArgs.Cancel = true;
                        errorProvider1.SetError(kgtxtCreateAccount_UserName, "اسم المستخدم مستخدم, قم بتجربة اسم آخر");
                    }
                    else
                    {
                        e.CancelEventArgs.Cancel = false;
                        errorProvider1.SetError(kgtxtCreateAccount_UserName, null);
                    }
                }
            }
        }

        private void kgtxtCreateAccount_AccountName_After_kgtxt_Validating(object sender, KhaledGuna2TextBox.AfterMyValidatingEventArgs e)
        {
            if (e.ValidationgResult)
            {
                string accountName = kgtxtCreateAccount_AccountName.ValidatedText;

                if (_Mode == enMode.CreateAccount)
                {
                    if (clsAccount.IsAccountExistByAccountName(accountName))
                    {
                        e.CancelEventArgs.Cancel = true;
                        errorProvider1.SetError(kgtxtCreateAccount_AccountName, "اسم الحساب مستخدم, قم بتجربة اسم آخر");
                    }
                    else
                    {
                        e.CancelEventArgs.Cancel = false;
                        errorProvider1.SetError(kgtxtCreateAccount_AccountName, null);
                    }
                }
            }
        }

        private async void ggbtnLogin_Click(object sender, EventArgs e)
        {
            if (this.UseWaitCursor)
                return;

            if (!ValidateChildren())
            {
                clsPL_MessageBoxs.ShowValidateChildrenFailedMessage();
                return;
            }
            string userName = kgtxtLoginUserName.ValidatedText;
            string password = kgtxtLogin_password.ValidatedText;


            this.UseWaitCursor = true;

            clsUser user = await clsUser.FindUserByUserNameAndPassword_Login(userName, password);

            this.UseWaitCursor = false;
            this.Cursor = Cursors.Default;

            if (user == null)
                return;


            if (gchkLogin_RemeberMe.Checked)
            {
               _= clsPL_Global.RememberUsernameAndPassword(userName, password);
            }
            else
            {
               _= clsPL_Global.RememberUsernameAndPassword(null, null);
            }

            _ = Task.Run(() => clsLogger.LogAtEventLog($"[LOGIN SUCCESS] User ID = {user.UserID}, Username = {user.UserName}, Login Time = {DateTime.Now}",System.Diagnostics.EventLogEntryType.Information));

            frmMain frm = new frmMain();

            if (!await clsPL_Global.Login(user, frm))
            {
                clsPL_Global.ActiveForm = this;
                clsPL_MessageBoxs.ShowErrorMessage("فشل تسجيل الدخول !");
                return;
            }

            this.Hide();

            frm.OnCloseProgramm += frmMain_OnCloseProgramm;
            frm.ShowDialog();

            if (!this.IsDisposed)
            {
                clsPL_Global.ActiveForm = this;
                this.Show();
                await _ChangeMode(enMode.Login);
            }
        }

        private void frmMain_OnCloseProgramm()
        {
            clsPL_Global.ActiveForm = this;
            this.Close();
        }

        private async void gbtnCreateAccount_Click(object sender, EventArgs e)
        {
            if (this.UseWaitCursor)
                return;

            if (!ValidateChildren())
            {
                clsPL_MessageBoxs.ShowValidateChildrenFailedMessage();
                return;
            }

            string personName = kgtxtCreateAccount_PersonName.ValidatedText;
            string userName = kgtxtCreateAccount_UserName.ValidatedText;
            string accountName = kgtxtCreateAccount_AccountName.ValidatedText;
            string password = kgtxtCreateAccount_Password.ValidatedText;
            byte defaultCurrencyID = Convert.ToByte(gcbCreateAccount_DefaultCurrency.SelectedValue);

            this.UseWaitCursor = true;

            int? newAccountID = await clsAccount.CreateAccount(accountName, defaultCurrencyID, null, personName, null, null, null, null, userName, password);

            this.UseWaitCursor = false;
            this.Cursor = Cursors.Default;

            if (newAccountID != null)
            {
#pragma warning disable CS4014
                Task.Run(() => clsLogger.LogAtEventLog($"New Account created with ID {newAccountID} at {DateTime.Now}"));
#pragma warning restore CS4014

                clsPL_MessageBoxs.ShowMessage($"تم إنشاء الحساب بنجاح مع معرف حساب  [ {newAccountID} ]  , قم بتسجيل الدخول", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _loadCredentials = false;
                await _ChangeMode(enMode.Login);
                _loadCredentials = true;
            }

        }

        private async void gbtnMode_Click(object sender, EventArgs e)
        {
            if (this.UseWaitCursor)
                return;

            enMode mode = (_Mode == enMode.Login) ? enMode.CreateAccount : enMode.Login;
            await _ChangeMode(mode);
        }

        private void kgtxtCreatAccount_ConfirmPassowrd_After_kgtxt_Validating(object sender, KhaledGuna2TextBox.AfterMyValidatingEventArgs e)
        {
            if (e.ValidationgResult && _Mode == enMode.CreateAccount)
            {
                if (kgtxtCreatAccount_ConfirmPassowrd.ValidatedText != kgtxtCreateAccount_Password.ValidatedText)
                {
                    e.CancelEventArgs.Cancel = true;
                    errorProvider1.SetError(kgtxtCreatAccount_ConfirmPassowrd, "كلمة السر يجب أن تكون متطابقة");
                }
                else
                {
                    e.CancelEventArgs.Cancel = false;
                    errorProvider1.SetError(kgtxtCreatAccount_ConfirmPassowrd, null);
                }
            }
        }

        private void kgtxtLogin_password_TextChanged(object sender, EventArgs e)
        {
            if (_enableShowPasswordAfterBeEmpty && string.IsNullOrEmpty(kgtxtLogin_password.Text))
            {
                _enableShowPasswordAfterBeEmpty = false;
                gtswLogin_ShowPassword.Enabled = true;
            }
        }

        private void kgtxtCreateAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                gbtnCreateAccount.PerformClick();
        }

        private void kgtxtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                gbtnLogin.PerformClick();
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }

        private void gpnlLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gpnlCreateAccount_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
