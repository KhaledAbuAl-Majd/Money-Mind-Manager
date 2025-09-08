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
using MoneyMindManager_Presentation.People;
using static System.Net.Mime.MediaTypeNames;

namespace MoneyMindManager_Presentation.Main
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
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
        }

        private void gbtnOverOview_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("kk");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            gbtnOverOview.PerformClick();

            //string text = "10.5";

            //bool result = int.TryParse(text, NumberStyles.AllowLeadingSign | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out int number);

            //MessageBox.Show(result.ToString());

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            _LoadFormAtPanelContainer(new frmPeople(),true);

            //new frmPeople().Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            _LoadFormAtPanelContainer(new frmAddUpdatePerson(),true);
        }
    }
}
