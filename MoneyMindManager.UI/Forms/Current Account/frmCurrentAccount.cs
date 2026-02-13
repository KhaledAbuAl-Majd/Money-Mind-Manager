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
using MoneyMindManager_Presentation.Users;

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

        async Task _Save()
        {
            if (!gbtnSave.Enabled || _Mode == enMode.ReadOnly)
                return;

            gbtnSave.Enabled = false;

            if (!ValidateChildren())
            {
                clsPL_MessageBoxs.ShowValidateChildrenFailedMessage();
                return;
            }

            _AccountInfo.AccountName = kgtxtAccountName.ValidatedText;
            _AccountInfo.Description = kgtxtDiscription.ValidatedText;

            if (await _AccountInfo.Save())
            {
                clsPL_MessageBoxs.ShowMessage("تم تعديل بيانات الحساب بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        async Task _DeleteAccount()
        {
            if (!gbtnDeleteAccount.Enabled || _Mode == enMode.ReadOnly)
                return;

            this.UseWaitCursor = true;

            gbtnDeleteAccount.Enabled = false;
            gbtnSave.Enabled = false;
            clsPL_Global.MainForm.Enabled = false;

            if (clsPL_MessageBoxs.ShowMessage("هل أنت متأكد من رغبتك حذف الحساب نهائيا !", "طلب موافقة", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (await _AccountInfo.DeleteAccount())
                {
                    clsPL_MessageBoxs.ShowMessage("تم حذف الحساب بنجاح, سيتم تسجيل خروجك", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clsPL_Global.Logout();
                    return;
                }
            }

            this.UseWaitCursor = false;
            gbtnDeleteAccount.Enabled = true;
            gbtnSave.Enabled = true;
            clsPL_Global.MainForm.Enabled = true;
        }

        async Task _LoadData()
        {
            lblAccountID.Text = _AccountInfo.AccountID.ToString();
            kgtxtAccountName.Text = _AccountInfo.AccountName;
            kgtxtDiscription.Text = _AccountInfo.Description;
            kgtxtBalance.RefreshNumber_DateTimeFormattedText(_AccountInfo.Balance.ToString());
            kgtxtCreatedDate.RefreshNumber_DateTimeFormattedText(_AccountInfo.CreatedDate.ToString());
            var ownerUser = await _AccountInfo.GetCreatedbyUserInfo();
            kgtxtCreatedByUserName.Text = ownerUser.UserName;
            kgtxtDefaultCurrency.Text = _AccountInfo.DefaultCurrencyInfo?.CurrencyName;
        }

        private async void frmCurrentAccount_Shown(object sender, EventArgs e)
        {
            if (!await clsPL_Global.RefreshCurrentUser())
            {
                this.Close();
                return;
            }

            this._AccountInfo = clsPL_Global.CurrentUser?.AccountInfo;

            _SetReadOnlyAtTextBox(kgtxtBalance);
            _SetReadOnlyAtTextBox(kgtxtCreatedDate);
            _SetReadOnlyAtTextBox(kgtxtCreatedByUserName);
            _SetReadOnlyAtTextBox(kgtxtDefaultCurrency);

            if (clsPL_Global.CurrentUser.IsAdmin)
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

            kgtxtBalance.UseSystemPasswordChar = !clsPL_Global.CurrentUser.IsHasPermission(clsUser.enPermissions.AccountBalance);

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

            frmUserInfo frm = new frmUserInfo(_AccountInfo.AccountOwnerUserID);
            clsPL_Global.MainForm.AddNewFormAtContainer(frm);
        }

        private async void gbtnDeleteAccount_Click(object sender, EventArgs e)
        {
            await _DeleteAccount();
        }
    }
}
