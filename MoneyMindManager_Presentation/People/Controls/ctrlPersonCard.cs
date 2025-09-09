using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDPresentation.Global_Classes;
using MoneyMindManager_Business;

namespace MoneyMindManager_Presentation.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public event Action OnEditingPerson;

        public clsPerson Person { get; private set; }

        public async Task<bool> LoadPerson(int personID)
        {
            Person = await clsPerson.FindPersonByID(personID);

            if (Person == null)
                return false;

            gbtnEditPerson.Enabled = true;

            await _ShowData();

            return true;
        }

        async Task _ShowData()
        {
            lblPersonID.Text = Person.PersonID.ToString();
            lblCreatedDate.Text = clsFormat.DateToShort(Person.CreatedDate);
            kgtxtPersonName.Text = Person.PersonName;
            kgtxtPhoneNumber.Text = Person.Phone;
            clsUser CreatedUser = await Person.GetCreatedbyUserInfo();
            kgtxtUserNameOfCreatedUser.Text = CreatedUser.UserName;
            kgtxtEmail.Text = Person.Email;
            kgtxtNotes.Text = Person.Notes;
            kgtxtAddress.Text = Person.Address;
        }

        private void gbtnEditPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(Convert.ToInt32(Person.PersonID));
            frm.OnCloseAndSaved += FrmAddEditPerson_OnCloseAndSaved;
            clsGlobal_Presentation.MainForm.AddNewForm(frm);
        }

        private async void FrmAddEditPerson_OnCloseAndSaved()
        {
            await LoadPerson(Convert.ToInt32(Person.PersonID));
            OnEditingPerson?.Invoke();
        }

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {
            gbtnEditPerson.Enabled = false;

            gbtnEditPerson.Enabled = true;
            kgtxtPersonName.ReadOnly = true;
            kgtxtPhoneNumber.ReadOnly = true;
            kgtxtUserNameOfCreatedUser.ReadOnly = true;
            kgtxtEmail.ReadOnly = true;
            kgtxtNotes.ReadOnly = true;
            kgtxtAddress.ReadOnly = true;
        }
    }
}
