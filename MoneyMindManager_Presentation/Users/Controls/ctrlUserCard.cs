using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyMindManager_Business;

namespace MoneyMindManager_Presentation.Users
{
    public partial class ctrlUserCard : UserControl
    {
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public event Action OnEditingPerson
        {
            add { ctrlPersonCard1.OnEditingPerson += value; }

            remove { ctrlPersonCard1.OnEditingPerson -= value; }
        }

        public event Action OnEditingUser;

        public clsUser User { get; private set; }

        public async Task<bool> LoadUser(int userID)
        {
            gbtnEditUser.Enabled = false;

            User = await clsUser.FindUserByUserID(userID);

            if (User == null)
            {
                ResetControls();
                return false;
            }

            if (!await ctrlPersonCard1.LoadPerson(Convert.ToInt32(User.PersonID)))
            {
                ResetControls();
                return false;
            }

            gbtnEditUser.Enabled = true;

            await _ShowData();

            return true;
        }

        async Task _ShowData()
        {
            lblUseID.Text = User.UserID.ToString();
            lblIsActive.Text = (User.IsActive) ? "فعال" : "موقوف";
            klblCreatedDate.Text =User.CreatedDate.ToString();
            kgtxtUserName.Text = User.UserName;
            clsUser creatingUser = await User.GetCreatedbyUserInfo();
            kgtxtUserNameOfCreatedUser.Text = creatingUser.UserName;
            kgtxtNotes.Text = User.Notes;
        }
        private void gbtnEditUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser(Convert.ToInt32(User.UserID));
            frm.OnCloseAndSavedOrEditing += FrmAddUpdateUser_OnCloseAndSaved;
            clsGlobal_UI.MainForm.AddNewFormAtContainer(frm);
        }
        private void ctrlUserCard_Load(object sender, EventArgs e)
        {
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

    }
}
