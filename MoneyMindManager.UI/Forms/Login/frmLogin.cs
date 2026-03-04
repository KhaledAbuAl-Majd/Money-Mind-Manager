using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KhaledControlLibrary1;
using Microsoft.Extensions.DependencyInjection;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core;
using MoneyMindManager.Shared.DTOs.Account;
using MoneyMindManager.Shared.DTOs.Currency;
using MoneyMindManager.Shared.DTOs.User;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Main;

namespace MoneyMindManager_Presentation.Login
{
    public partial class frmLogin : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ICurrencyApiClient _currencyApi;
        private readonly IUserApiClient _userApiClient;
        private readonly IAccountApiClient _accountApiClient;
        private readonly IMessageBoxService _messageBoxService;
        private readonly ILogger _logger;
        private readonly IUserCredentialsService _userCredentailService;
        private readonly IActiveFormTracker _activeFormTracker;
        private readonly IDatabaseAppApiClient _databaseAppApiClient;

        public frmLogin(IServiceProvider serviceProvider, ICurrencyApiClient currencyApiClient, IMessageBoxService messageBoxService,
            ILogger logger, IUserCredentialsService userCredentialsService, IUserApiClient userApiClient, IAccountApiClient accountApiClient,
           IActiveFormTracker activeFormTracker, IDatabaseAppApiClient databaseAppApiClient)
        {
            InitializeComponent();
            this._serviceProvider = serviceProvider;
            this._currencyApi = currencyApiClient;
            this._userApiClient = userApiClient;
            this._accountApiClient = accountApiClient;
            this._messageBoxService = messageBoxService;
            this._logger = logger;
            this._userCredentailService = userCredentialsService;
            this._activeFormTracker = activeFormTracker;
            this._databaseAppApiClient = databaseAppApiClient;

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

            var funResult = await _userCredentailService.GetStoredCredential();
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
            //DataTable dtCurrencies = await clsCurrency.GetAllCurrencies();

            //gcbCreateAccount_DefaultCurrency.DataSource = dtCurrencies;
            //gcbCreateAccount_DefaultCurrency.DisplayMember = "CurrencyName";
            //gcbCreateAccount_DefaultCurrency.ValueMember = "CurrencyID";
            //gcbCreateAccount_DefaultCurrency.SelectedIndex = gcbCreateAccount_DefaultCurrency.FindStringExact("جنيه مصري");

            var result = await _currencyApi.GetAll();

            if (!result.IsSuccess)
            {
                _messageBoxService.DisplayError(result.ErrorMessage);
            }
            else
            {
                var currencies = result.Data;
                gcbCreateAccount_DefaultCurrency.DataSource = currencies.ToList();
                gcbCreateAccount_DefaultCurrency.DisplayMember = nameof(CurrencyDTO.CurrencyName);
                gcbCreateAccount_DefaultCurrency.ValueMember = nameof(CurrencyDTO.CurrencyID);
                gcbCreateAccount_DefaultCurrency.SelectedIndex = gcbCreateAccount_DefaultCurrency.FindStringExact("جنيه مصري");
            }
        }

        private async void frmLogin_Load(object sender, EventArgs e)
        {
            _activeFormTracker.ChangeActiveForm(this);
            _enableShowPasswordAfterBeEmpty = false;
            _loadCredentials = true;
            await _ChangeMode(enMode.Login);

            var result = await _databaseAppApiClient.RoutineMaintenance();

            if (!result.IsSuccess)
                _messageBoxService.DisplayError(result.ErrorMessage);
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
                    var result = _userApiClient.IsExistByUserName(userName).GetAwaiter().GetResult();
                    if (!result.IsSuccess)
                    {
                        _messageBoxService.DisplayError($"{result.ErrorMessage}\nبرجاء إعادة تشغيل البرنامج!");
                        return;
                    }

                    if (result.Data)
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

                var result = _accountApiClient.IsExistByAccountName(accountName).GetAwaiter().GetResult();
                if (!result.IsSuccess)
                {
                    _messageBoxService.DisplayError($"{result.ErrorMessage}\nبرجاء إعادة تشغيل البرنامج!");
                    return;
                }

                if (_Mode == enMode.CreateAccount)
                {
                    if (result.Data)
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
                _messageBoxService.ShowValidateChildrenFailedMessage();
                return;
            }
            string userName = kgtxtLoginUserName.ValidatedText;
            string password = kgtxtLogin_password.ValidatedText;


            this.UseWaitCursor = true;

            var userResult = await _userApiClient.Login(new LoginRequestDTO(userName, password));

            this.UseWaitCursor = false;
            this.Cursor = Cursors.Default;

            if (!userResult.IsSuccess)
            {
                _messageBoxService.DisplayError(userResult.ErrorMessage);
                return;
            }

            var user = userResult.Data;

            if (user == null)
                return;


            if (gchkLogin_RemeberMe.Checked)
            {
                var result = await _userCredentailService.RememberUsernameAndPassword(userName, password);
                if (!result)
                {
                    _messageBoxService.DisplayError("فشل حفظ اسم المتسخدم وكلمة السر!");
                }
            }
            else
            {
                _ = await _userCredentailService.RememberUsernameAndPassword(null, null);
            }

            _ = Task.Run(() => _logger.LogSuccess($"[LOGIN SUCCESS] User ID = {user.UserID}, Username = {user.UserName}, Login Time = {DateTime.Now}"));


            using (var scope = _serviceProvider.CreateScope())
            {
                frmMain frm = scope.ServiceProvider.GetRequiredService<frmMain>();
                frm.Initialize(user);

                this.Hide();

                frm.OnCloseProgramm += frmMain_OnCloseProgramm;
                _activeFormTracker.ChangeActiveForm(frm);
                frm.ShowDialog();

            }
            if (!this.IsDisposed)
            {
                await OnLogout();
            }
        }

        private async Task OnLogout()
        {
            _activeFormTracker.ChangeActiveForm(this);
            this.Show();
            await _ChangeMode(enMode.Login);
        }

        private void frmMain_OnCloseProgramm()
        {
            _activeFormTracker.ChangeActiveForm(this);
            this.Close();
        }

        private async void gbtnCreateAccount_Click(object sender, EventArgs e)
        {
            if (this.UseWaitCursor)
                return;

            if (!ValidateChildren())
            {
                _messageBoxService.ShowValidateChildrenFailedMessage();
                return;
            }

            string personName = kgtxtCreateAccount_PersonName.ValidatedText;
            string userName = kgtxtCreateAccount_UserName.ValidatedText;
            string accountName = kgtxtCreateAccount_AccountName.ValidatedText;
            string password = kgtxtCreateAccount_Password.ValidatedText;
            byte defaultCurrencyID = Convert.ToByte(gcbCreateAccount_DefaultCurrency.SelectedValue);

            this.UseWaitCursor = true;

            var creatingResult = await _accountApiClient.Add(new CreateAccountDTO(accountName, defaultCurrencyID, null, personName, null, null, null, null, userName, password));

            if (!creatingResult.IsSuccess)
            {
                _messageBoxService.DisplayError(creatingResult.ErrorMessage);
                return;
            }

            short? newAccountID = creatingResult.Data;

            _ = Task.Run(() => _logger.LogInfo($"New Account created with ID {newAccountID} at {DateTime.Now}"));

            this.UseWaitCursor = false;
            this.Cursor = Cursors.Default;

            if (newAccountID != null)
            {
                _messageBoxService.Display($"تم إنشاء الحساب بنجاح مع معرف حساب  [ {newAccountID} ]  , قم بتسجيل الدخول", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
    }
}
