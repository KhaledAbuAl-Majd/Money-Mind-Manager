using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Shared.DTOs;
using MoneyMindManager.Shared.DTOs.User;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.Users;

namespace MoneyMindManager_Presentation.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        private IPersonApiClient _personApiClient;
        private IUserSession _userSession;
        private IMessageBoxService _messageBoxService;
        private IUserApiClient _userApiClient;
        private IFormDisplayer _formDisplayer;

        private bool isInitialized = false;
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public bool AllowEditingPerson
        {
            get
            {
                return gbtnEditPerson.Enabled;
            }

            set
            {
                gbtnEditPerson.Enabled = value;
            }
        }


        public event Action OnEditingPerson;

        public PersonDTO Person { get; private set; }


        public bool Initialize(IPersonApiClient personApiClient, IUserSession userSession, IMessageBoxService messageBoxService,
            IUserApiClient userApiClient, IFormDisplayer formDisplayer)
        {
            if (personApiClient is null || userSession is null || messageBoxService is null || userApiClient is null || formDisplayer is null)
                return false;

            this._personApiClient = personApiClient;
            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._userApiClient = userApiClient;
            this._formDisplayer = formDisplayer;
            isInitialized = true;
            return true;
        }

        public async Task<bool> LoadPerson(int personID)
        {
            if (!isInitialized)
                return false;

            gbtnEditPerson.Enabled = false;

            var result = await _personApiClient.Get(personID, Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || result.Data is null)
            {
                _messageBoxService.DisplayError(result.ErrorMessage);
                ResetControls();
                return false;
            }

            var userResult = await _userApiClient.GetByUserID(Convert.ToInt32(result.Data.CreatedByUserID));

            if (!userResult.IsSuccess || userResult.Data is null)
            {
                _messageBoxService.DisplayError(result.ErrorMessage);
                ResetControls();
                return false;
            }

            Person = result.Data;

            gbtnEditPerson.Enabled = true;

            await _ShowData(userResult.Data);

            return true;
        }

        async Task _ShowData(UserDTO userDTO)
        {
            lblPersonID.Text = Person.PersonID.ToString();
            klblCreatedDate.Text = Person.CreatedDate.ToString();
            kgtxtPersonName.Text = Person.PersonName;
            kgtxtPhoneNumber.Text = Person.Phone;
            kgtxtUserNameOfCreatedUser.Text = userDTO.UserName;
            kgtxtEmail.Text = Person.Email;
            kgtxtNotes.Text = Person.Notes;
            kgtxtAddress.Text = Person.Address;
            kgtxtReceivable.RefreshNumber_DateTimeFormattedText(Person.Receivable.ToString());
            kgtxtPayable.RefreshNumber_DateTimeFormattedText(Person.Payable.ToString());
        }

        private void gbtnEditPerson_Click(object sender, EventArgs e)
        {
            _formDisplayer.OpenAtContainer<frmAddUpdatePerson>((frm) =>
            {
                if (!frm.Initialize(Convert.ToInt32(Person.PersonID)))
                    return false;
                frm.OnCloseAndSaved += FrmAddEditPerson_OnCloseAndSaved;
                return true;
            });
        }

        private async void FrmAddEditPerson_OnCloseAndSaved(int personID)
        {
            await LoadPerson(Convert.ToInt32(Person.PersonID));
            OnEditingPerson?.Invoke();
        }

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {
            gbtnEditPerson.Enabled = false;

            kgtxtPersonName.ReadOnly = true;
            kgtxtPhoneNumber.ReadOnly = true;
            kgtxtUserNameOfCreatedUser.ReadOnly = true;
            kgtxtEmail.ReadOnly = true;
            kgtxtNotes.ReadOnly = true;
            kgtxtAddress.ReadOnly = true;
            kgtxtReceivable.ReadOnly = true;
            kgtxtPayable.ReadOnly = true;
        }

        /// <summary>
        /// Reset Controls With Start Value
        /// </summary>
        public void ResetControls()
        {
            gbtnEditPerson.Enabled = false;

            Person = null;

            lblPersonID.Text = "N/A";
            klblCreatedDate.Text = "N/A";
            kgtxtPersonName.Text = null;
            kgtxtPhoneNumber.Text = null;
            kgtxtUserNameOfCreatedUser.Text = null;
            kgtxtEmail.Text = null;
            kgtxtNotes.Text = null;
            kgtxtAddress.Text = null;
            kgtxtReceivable.Text = null;
            kgtxtPayable.Text = null;
        }

        private void kgtxtUserNameOfCreatedUser_IconRightClick(object sender, EventArgs e)
        {
            if (Person == null)
                return;

            _formDisplayer.OpenAtContainer<frmUserInfo>((frm) =>
            {
                return frm.Initialize(Convert.ToInt32(Person?.CreatedByUserID));
            });
        }
    }
}
