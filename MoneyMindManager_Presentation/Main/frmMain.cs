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
using MoneyMindManager_Presentation.People;
using static System.Net.Mime.MediaTypeNames;

namespace MoneyMindManager_Presentation.Main
{
    public partial class frmMain : Form
    {
        int _userID;
        public frmMain(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        public void AddNewForm(Form frm)
        {
            _LoadFormAtPanelContainer(frm, false);
        }

        void _LoadFormAtPanelContainer(Form frm,bool clearOldControls)
        {
            if (frm == null)
                return;

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            if (clearOldControls)
                gpnlFormContainer.Controls.Clear();

            gpnlFormContainer.Controls.Add(frm);
            frm.Show();
            frm.BringToFront();
        }

        private void gbtnOverOview_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("kk");
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            this.Enabled = false;

            clsUser user = await clsUser.FindUserByUserID(_userID);

            if (user == null)
            {
                this.Close();
                return;
            }

            this.Enabled = true;

            clsGlobal_Presentation.CurrentUser = user;
            clsGlobal_Presentation.MainForm = this;

            gbtnOverOview.PerformClick();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            _LoadFormAtPanelContainer(new frmPeople(),true);

            //MessageBox.Show(gpnlFormContainer.Controls.Count.ToString());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            _LoadFormAtPanelContainer(new frmAddUpdatePerson(),true);
        }

        private void gbtnUsers_Click(object sender, EventArgs e)
        {
            _LoadFormAtPanelContainer(new FrmUsers(), true);
        }
    }
}
