using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Shared.DTOs.User;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.People.Controls;

namespace MoneyMindManager_Presentation.Users
{
    public partial class ctrlUserCard : UserControl
    {
        private IPersonApiClient _personApiClient;
        private IUserSession _userSession;
        private IMessageBoxService _messageBoxService;
        private IUserApiClient _userApiClient;
        private IFormDisplayer _formDisplayer;

        private bool isInitialized = false;
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public bool Initialize(IPersonApiClient personApiClient, IUserSession userSession, IMessageBoxService messageBoxService,
           IUserApiClient userApiClient, IFormDisplayer formDisplayer)
        {
            if (personApiClient is null || userSession is null || messageBoxService is null || userApiClient is null || formDisplayer is null)
                return false;

            if (!ctrlPersonCard1.Initialize(_personApiClient, _userSession, _messageBoxService, _userApiClient, _formDisplayer))
                return false;
            this._personApiClient = personApiClient;
            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._userApiClient = userApiClient;
            this._formDisplayer = formDisplayer;
            isInitialized = true;
            return true;
        }

        public event Action OnEditingPerson
        {
            add { ctrlPersonCard1.OnEditingPerson += value; }

            remove { ctrlPersonCard1.OnEditingPerson -= value; }
        }

        public event Action OnEditingUser;

        public UserDTO User { get; private set; }

        public async Task<bool> LoadUser(int userID)
        {
            if (!isInitialized)
                return false;

            gbtnEditUser.Enabled = false;

            var result = await _userApiClient.GetByUserID(Convert.ToInt32(userID));

            if (!result.IsSuccess || result.Data is null)
            {
                _messageBoxService.DisplayError(result.ErrorMessage);
                ResetControls();
                return false;
            }

            User = result.Data;

            var userResult = await _userApiClient.GetByUserID(Convert.ToInt32(result.Data.CreatedByUserID));

            if (!userResult.IsSuccess || userResult.Data is null)
            {
                _messageBoxService.DisplayError(userResult.ErrorMessage);
                ResetControls();
                return false;
            }

            if (!await ctrlPersonCard1.LoadPerson(Convert.ToInt32(User.PersonID)))
            {
                ResetControls();
                return false;
            }

            gbtnEditUser.Enabled = true;

            if (User.IsDeleted)
            {
                lbluserMessage.Text = "هذا المستخدم محذوف !";
                lbluserMessage.Visible = true;
            }

            await _ShowData(userResult.Data);

            return true;
        }

        async Task _ShowData(UserDTO userDTO)
        {
            lblUseID.Text = User.UserID.ToString();
            lblIsActive.Text = (User.IsActive) ? "فعال" : "موقوف";
            klblCreatedDate.Text = User.CreatedDate.ToString();
            kgtxtUserName.Text = User.UserName;
            kgtxtUserNameOfCreatedUser.Text = userDTO.UserName;
            kgtxtNotes.Text = User.Notes;
        }
        private void gbtnEditUser_Click(object sender, EventArgs e)
        {
            _formDisplayer.OpenAtContainer<frmAddUpdateUser>(frm =>
            {
                if (!frm.Initialize(Convert.ToInt32(User.UserID)))
                    return false;
                frm.OnCloseAndSavedOrEditing += FrmAddUpdateUser_OnCloseAndSaved;
                return true;
            });
        }
        private void ctrlUserCard_Load(object sender, EventArgs e)
        {
            lbluserMessage.Visible = false;
            gbtnEditUser.Enabled = false;

            kgtxtUserName.ReadOnly = true;
            kgtxtUserNameOfCreatedUser.ReadOnly = true;
            kgtxtNotes.ReadOnly = true;
        }

        private async void FrmAddUpdateUser_OnCloseAndSaved(int obj)
        {
            await LoadUser(Convert.ToInt32(User.UserID));
            OnEditingUser?.Invoke();
        }

        /// <summary>
        /// Reset Controls With Start Value
        /// </summary>
        public void ResetControls()
        {
            gbtnEditUser.Enabled = false;

            User = null;

            ctrlPersonCard1.ResetControls();

            lblUseID.Text = "N/A";
            lblIsActive.Text = "N/A";
            klblCreatedDate.Text = "N/A";
            kgtxtUserName.Text = null;
            kgtxtUserNameOfCreatedUser.Text = null;
            kgtxtNotes.Text = null;
        }

        private void kgtxtUserNameOfCreatedUser_IconRightClick(object sender, EventArgs e)
        {
            if (User == null)
                return;

            _formDisplayer.OpenAtContainer<frmUserInfo>(frm =>
            {
                if (!frm.Initialize(Convert.ToInt32(User?.CreatedByUserID)))
                    return false;
                return true;
            });
        }
    }
}
