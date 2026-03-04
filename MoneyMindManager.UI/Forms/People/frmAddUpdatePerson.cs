using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using KhaledControlLibrary1;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Shared.DTOs;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.Global;

namespace MoneyMindManager_Presentation.People
{
    public partial class frmAddUpdatePerson : Form
    {
        private IPersonApiClient _personApiClient;
        private IUserSession _userSession;
        private IMessageBoxService _messageBoxService;

        private bool isInitialized = false;
        /// <summary>
        /// PersonID
        /// </summary>
        public event Action<int> OnCloseAndSaved;

        bool _isSaved = false;
        enum enMode { AddNew, Update };
        enMode Mode { get; set; }

        private int? _PersonID { get; set; }
        private PersonDTO _Person { get; set; }
        public frmAddUpdatePerson(IPersonApiClient personApiClient, IUserSession userSession, IMessageBoxService messageBoxService)
        {
            InitializeComponent();
            this._personApiClient = personApiClient;
            this._userSession = userSession;
            this._messageBoxService = messageBoxService;

            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }

            Mode = enMode.AddNew;
            _PersonID = null;
            _Person = new PersonDTO();
        }
        public bool Initialize(int personID)
        {
            Mode = enMode.Update;
            this._PersonID = personID;
            this.isInitialized = true;
            return true;
        }

        public bool Initialize()
        {
            this.isInitialized = true;
            return true;
        }

        bool _CheckPermissions()
        {
            if (_userSession.IsHasPermissions(enPermissions.AddUpdatePerson))
                return true;

            _messageBoxService.DisplayError("ليس لديك صلاحية إضافة/تعديل شخص.");
            return false;
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
            _Person = new PersonDTO();
            lblPersonID.Text = "N/A";
            kgtxtPersonName.Focus();
        }

        async Task _UpdateMode()
        {
            ChangeHeaderValue("تعديل بيانات شخص");


            var result = await _personApiClient.Get(Convert.ToInt32(_PersonID), Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || result.Data is null)
            {
                _messageBoxService.DisplayError("فشل تحميل بيانات الشخص\n" + result.ErrorMessage);
                this.Close();
                return;
            }

            PersonDTO searchedPerson = result.Data;

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
            _Person = new PersonDTO();
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

            _Person.PersonName = kgtxtPersonName.ValidatedText;
            _Person.Email = kgtxtEmail.ValidatedText;
            _Person.Phone = kgtxtPhone.ValidatedText;

            _Person.Address = kgtxtAddress.ValidatedText;
            _Person.Notes = kgtxtNotes.ValidatedText;

            if (Mode == enMode.AddNew)
            {
                _Person.AccountID = _userSession.CurrentUser?.AccountID;
                _Person.CreatedByUserID = _userSession.UserID;

                var result = await _personApiClient.Add(_Person, Convert.ToInt32(_userSession.UserID));

                if (!result.IsSuccess || result.Data is null)
                {
                    _messageBoxService.DisplayError(result.ErrorMessage);
                    _ResteObject();
                    return;
                }

                _Person = result.Data;
                _messageBoxService.Display($"تم إضافة الشخص بنجاج بمعرف [{_Person.PersonID}]", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mode = enMode.Update;
                _PersonID = _Person.PersonID;
                lblPersonID.Text = _PersonID.ToString();
                ChangeHeaderValue("تعديل بيانات شخص");

                _isSaved = true;
            }
            else
            {
                var result = await _personApiClient.Update(_Person, Convert.ToInt32(_userSession.UserID));

                if (!result.IsSuccess || !result.Data)
                {
                    _messageBoxService.DisplayError("فشل تحديث بيانات الشخص\n" + result.ErrorMessage);
                    return;
                }

                _messageBoxService.Display("تم تعديل بيانات الشخص بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _isSaved = true;
            }
        }

        private async void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            if (!isInitialized)
            {
                this.Close();
                return;
            }

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
    }
}
