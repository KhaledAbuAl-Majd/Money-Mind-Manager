using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyMindManager_Business;
using KhaledControlLibrary1;
using MoneyMindManager_Presentation.Global;

namespace MoneyMindManager_Presentation.People
{
    public partial class frmAddUpdatePerson : Form
    {
        /// <summary>
        /// PersonID
        /// </summary>
        public event Action<int> OnCloseAndSaved;

        bool _isSaved = false;
        enum enMode { AddNew, Update };
        enMode Mode { get; set; }

        private int? _PersonID { get; set; }
        private clsPerson _Person { get; set; }
        public frmAddUpdatePerson()
        {
            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }

            InitializeComponent();
            Mode = enMode.AddNew;
            _PersonID = null;
            _Person = new clsPerson();
        }
        public frmAddUpdatePerson(int personID)
        {
            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }

            InitializeComponent();
            Mode = enMode.Update;
            this._PersonID = personID;
        }

        bool _CheckPermissions()
        {
            return clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.AddUpdatePerson,
                 "ليس لديك صلاحية إضافة/تعديل شخص.");
        }

        void ChangeHeaderValue(string txt)
        {
            this.Text = txt;
            lblHeader.Text = txt;
        }

        void _AddNewMode()
        {
            ChangeHeaderValue("إضافة شخص");
            _PersonID = null;
            _Person = new clsPerson();
            lblPersonID.Text = "N/A";
            kgtxtPersonName.Focus();
        }

        async Task _UpdateMode()
        {
            ChangeHeaderValue("تعديل بيانات شخص");

            clsPerson searchedPerson = await clsPerson.FindPersonByID(Convert.ToInt32(_PersonID));

            if (searchedPerson == null)
            {
                clsPL_MessageBoxs.ShowErrorMessage("فشل تحميل بيانات الشخص");
                this.Close();
                return;
            }

            this._PersonID = searchedPerson.PersonID;
            this._Person = searchedPerson;

            lblPersonID.Text = _PersonID.ToString();
            kgtxtPersonName.Text = _Person.PersonName;
            kgtxtEmail.Text = _Person.Email;
            kgtxtPhone.Text = _Person.Phone;
            kgtxtNotes.Text = _Person.Notes;
            kgtxtAddress.Text = _Person.Address;
        }

        void _ResteObject()
        {
            _Person = new clsPerson();
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

            _Person.PersonName = kgtxtPersonName.ValidatedText;
            _Person.Email = kgtxtEmail.ValidatedText;
            _Person.Phone = kgtxtPhone.ValidatedText;

            if (Mode == enMode.AddNew)
            {
                if (!_Person.EnterAccountIDAtAddMode(Convert.ToInt16(clsPL_Global.CurrentUser.AccountID)))
                {
                    clsPL_MessageBoxs.ShowErrorMessage("فشل تسجيل معرف الحساب للمستخدم");
                    _ResteObject();
                    return;
                }

                if (!_Person.EnterCreatedByUserIDAtAddMode(Convert.ToInt32(clsPL_Global.CurrentUser.UserID)))
                {
                    clsPL_MessageBoxs.ShowErrorMessage("فشل تسجيل معرف منشئ الحساب");
                    _ResteObject();
                    return;
                }
            }

            _Person.Address = kgtxtAddress.ValidatedText;
            _Person.Notes = kgtxtNotes.ValidatedText;

            if (await _Person.Save())
            {
                if (Mode == enMode.AddNew)
                {
                    clsPL_MessageBoxs.ShowMessage($"تم إضافة الشخص بنجاج بمعرف [{_Person.PersonID}]", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Mode = enMode.Update;
                    _PersonID = _Person.PersonID;
                    lblPersonID.Text = _PersonID.ToString();
                    ChangeHeaderValue("تعديل بيانات شخص");
                }
                else if (Mode == enMode.Update)
                {
                    clsPL_MessageBoxs.ShowMessage("تم تعديل بيانات الشخص بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _isSaved = true;
            }
            else if (Mode == enMode.AddNew)
                _ResteObject();
        }

        private async void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
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

        private void kgtxtPersonName_OnValidationError(object sender, KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            KhaledGuna2TextBox kgtxtBox = (KhaledGuna2TextBox)sender;
            e.CancelEventArgs.Cancel = true;
            string errorMessage = clsPL_Utils.GetValidationErrorTypeString(e.validationErrorType, kgtxtBox);

            errorProvider1.SetError(kgtxtBox, errorMessage);
        }

        private void kgtxtPersonName_OnValidationSuccess(object arg1, CancelEventArgs arg2)
        {
            arg2.Cancel = false;
            errorProvider1.SetError((KhaledGuna2TextBox)arg1, null);

        }

        private async void gbtnSave_Click(object sender, EventArgs e)
        {
            await _Save();
            gbtnSave.Enabled = true;
        }

        private void gbtnClose_Click(object sender, EventArgs e)
        {
            if (_isSaved)
                OnCloseAndSaved?.Invoke(Convert.ToInt32(_Person.PersonID));

            this.Close();
        }

        private void kgtxtNotes_TextChanged(object sender, EventArgs e)
        {

        }

        private void kgtxtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void kgtxtPersonName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
