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

namespace MoneyMindManager_Presentation
{
    public partial class frmCurrentAccount : Form
    {
        enum enMode { UpdatAble, ReadOnly };
        enMode _Mode = enMode.ReadOnly;
        public frmCurrentAccount()
        {
            InitializeComponent();
        }

        clsAccount _AccountInfo;

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

        async Task _LoadData()
        {
            lblAccountID.Text = _AccountInfo.AccountID.ToString();
            kgtxtAccountName.Text = _AccountInfo.AccountName;
            kgtxtDiscription.Text = _AccountInfo.Description;
            kgtxtBalance.RefreshNumber_DateTimeFormattedText(_AccountInfo.Balance.ToString());
            kgtxtCreatedDate.RefreshNumber_DateTimeFormattedText(_AccountInfo.CreatedDate.ToString());
            var ownerUser = await _AccountInfo.GetCreatedbyUserInfo(Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID));
            kgtxtCreatedByUserName.Text = ownerUser.UserName;
            kgtxtDefaultCurrency.Text = _AccountInfo.DefaultCurrencyInfo?.CurrencyName;
        }
        private async void frmCurrentAccount_Load(object sender, EventArgs e)
        {
            if (!await clsGlobal_UI.RefreshCurrentUser())
                return;

            this._AccountInfo = clsGlobal_UI.CurrentUser?.AccountInfo;

            _SetReadOnlyAtTextBox(kgtxtBalance);
            _SetReadOnlyAtTextBox(kgtxtCreatedDate);
            _SetReadOnlyAtTextBox(kgtxtCreatedByUserName);
            _SetReadOnlyAtTextBox(kgtxtDefaultCurrency);

            if(_AccountInfo.AccountOwnerUserID == (Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID)))
            {
                _Mode = enMode.UpdatAble;
                _CancelReadOnlyAtTextBox(kgtxtAccountName);
                _CancelReadOnlyAtTextBox(kgtxtDiscription);
                gbtnSave.Enabled = true;
            }
            else
            {
                _Mode = enMode.ReadOnly;
                _SetReadOnlyAtTextBox(kgtxtAccountName);
                _SetReadOnlyAtTextBox(kgtxtDiscription);
                gbtnSave.Enabled = false;
            }

            await _LoadData();
        }

        private void gbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void gbtnSave_Click(object sender, EventArgs e)
        {
            if (!gbtnSave.Enabled || _Mode == enMode.ReadOnly)
                return;

            if (!ValidateChildren())
            {
                clsGlobalMessageBoxs.ShowValidateChildrenFailedMessage();
                return;
            }

            _AccountInfo.AccountName = kgtxtAccountName.ValidatedText;
            _AccountInfo.Description = kgtxtDiscription.ValidatedText;

            if (await _AccountInfo.Save())
            {
                clsGlobalMessageBoxs.ShowMessage("تم تعديل بيانات الحساب بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void kgtxt_OnValidationError(object sender, KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.CancelEventArgs.Cancel = true;
            errorProvider1.SetError(kgtxt, clsUtils.GetValidationErrorTypeString(e.validationErrorType, kgtxt));
        }

        private void kgtxt_OnValidationSuccess(object sender, CancelEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.Cancel = false;
            errorProvider1.SetError(kgtxt, null);
        }
    }
}
