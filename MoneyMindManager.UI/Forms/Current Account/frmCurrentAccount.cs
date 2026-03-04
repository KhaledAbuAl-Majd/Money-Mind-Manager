using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using KhaledControlLibrary1;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Shared.DTOs.Account;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Users;

namespace MoneyMindManager_Presentation
{
    public partial class frmCurrentAccount : Form
    {
        private readonly IAccountApiClient _accountApiClient;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IUserSession _userSession;
        private readonly IUserApiClient _userApiClient;
        private readonly IFormDisplayer _formDisplayer;

        enum enMode { UpdatAble, ReadOnly };
        enMode _Mode = enMode.ReadOnly;
        public frmCurrentAccount(IAccountApiClient accountApiClient, IMessageBoxService messageBoxService,
            IUserSession userSession, IUserApiClient userApiClient, IFormDisplayer formDisplayer)
        {
            InitializeComponent();
            this._accountApiClient = accountApiClient;
            this._messageBoxService = messageBoxService;
            this._userSession = userSession;
            this._userApiClient = userApiClient;
            this._formDisplayer = formDisplayer;
        }

        AccountBaseDTO _AccountInfo;

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

        async Task _Save()
        {
            if (!gbtnSave.Enabled || _Mode == enMode.ReadOnly)
                return;

            gbtnSave.Enabled = false;

            if (!ValidateChildren())
            {
                _messageBoxService.ShowValidateChildrenFailedMessage();
                return;
            }

            _AccountInfo.AccountName = kgtxtAccountName.ValidatedText;
            _AccountInfo.Description = kgtxtDiscription.ValidatedText;

            var updateResult = await _accountApiClient.Update(_AccountInfo, Convert.ToInt32(_userSession.UserID));

            if (updateResult.IsSuccess)
            {
                _messageBoxService.Display("تم تعديل بيانات الحساب بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _messageBoxService.DisplayError(updateResult.ErrorMessage);
            }
        }

        async Task _DeleteAccount()
        {
            if (!gbtnDeleteAccount.Enabled || _Mode == enMode.ReadOnly)
                return;

            this.UseWaitCursor = true;

            gbtnDeleteAccount.Enabled = false;
            gbtnSave.Enabled = false;
            //clsPL_Global.MainForm.Enabled = false;
            this.ParentForm.Enabled = false;

            if (_messageBoxService.Display("هل أنت متأكد من رغبتك حذف الحساب نهائيا !", "طلب موافقة", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {

                var deleteResult = await _accountApiClient.Delete(_AccountInfo.AccountID, Convert.ToInt32(_userSession.UserID));
                if (deleteResult.IsSuccess)
                {
                    _messageBoxService.Display("تم حذف الحساب بنجاح, سيتم تسجيل خروجك", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _userSession.ClearSession();
                    return;
                }
                else
                {
                    _messageBoxService.DisplayError(deleteResult.ErrorMessage);
                }
            }

            this.UseWaitCursor = false;
            gbtnDeleteAccount.Enabled = true;
            gbtnSave.Enabled = true;
            //clsPL_Global.MainForm.Enabled = true;
            this.ParentForm.Enabled = true;
        }

        async Task _LoadData()
        {
            lblAccountID.Text = _AccountInfo.AccountID.ToString();
            kgtxtAccountName.Text = _AccountInfo.AccountName;
            kgtxtDiscription.Text = _AccountInfo.Description;
            kgtxtBalance.RefreshNumber_DateTimeFormattedText(_AccountInfo.Balance.ToString());
            kgtxtCreatedDate.RefreshNumber_DateTimeFormattedText(_AccountInfo.CreatedDate.ToString());
            var result = await _userApiClient.GetByUserID(_AccountInfo.AccountOwnerUserID);
            if (result.IsSuccess)
            {
                var ownerUser = result.Data;
                kgtxtCreatedByUserName.Text = ownerUser.UserName;
                kgtxtDefaultCurrency.Text = _AccountInfo.DefaultCurrencyInfo?.CurrencyName;
            }
            else
                _messageBoxService.DisplayError(result.ErrorMessage);
        }

        private async void frmCurrentAccount_Shown(object sender, EventArgs e)
        {
            if (!await _userSession.Refresh())
            {
                this.Close();
                return;
            }

            this._AccountInfo = _userSession.CurrentUser?.AccountInfo;

            _SetReadOnlyAtTextBox(kgtxtBalance);
            _SetReadOnlyAtTextBox(kgtxtCreatedDate);
            _SetReadOnlyAtTextBox(kgtxtCreatedByUserName);
            _SetReadOnlyAtTextBox(kgtxtDefaultCurrency);

            if (_userSession.CurrentUser.IsAdmin)
            {
                _Mode = enMode.UpdatAble;
                _CancelReadOnlyAtTextBox(kgtxtAccountName);
                _CancelReadOnlyAtTextBox(kgtxtDiscription);
                gbtnSave.Enabled = true;
                gbtnDeleteAccount.Enabled = true;
            }
            else
            {
                _Mode = enMode.ReadOnly;
                _SetReadOnlyAtTextBox(kgtxtAccountName);
                _SetReadOnlyAtTextBox(kgtxtDiscription);
                gbtnSave.Enabled = false;
                gbtnDeleteAccount.Enabled = false;
            }

            kgtxtBalance.UseSystemPasswordChar = !_userSession.IsHasPermissions(enPermissions.AccountBalance);

            await _LoadData();
        }

        private async void gbtnSave_Click(object sender, EventArgs e)
        {
            await _Save();
            gbtnSave.Enabled = true;
        }

        private void kgtxt_OnValidationError(object sender, KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.CancelEventArgs.Cancel = true;
            errorProvider1.SetError(kgtxt, clsPL_Utils.GetValidationErrorTypeString(e.validationErrorType, kgtxt));
        }

        private void kgtxt_OnValidationSuccess(object sender, CancelEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.Cancel = false;
            errorProvider1.SetError(kgtxt, null);
        }

        private void kgtxtCreatedByUserName_IconRightClick(object sender, EventArgs e)
        {
            if (_AccountInfo == null)
                return;

            //frmUserInfo frm = new frmUserInfo(_AccountInfo.AccountOwnerUserID);
            //clsPL_Global.MainForm.AddNewFormAtContainer(frm);

            _formDisplayer.OpenAtContainer<frmUserInfo>((frm) =>
            {
                return frm.Initialize(_AccountInfo.AccountOwnerUserID);
            });
        }

        private async void gbtnDeleteAccount_Click(object sender, EventArgs e)
        {
            await _DeleteAccount();
        }
    }
}
