using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyMindManager_Presentation.OverView
{
    public partial class frmOverView : Form
    {
        public frmOverView()
        {
            InitializeComponent();
        }

        void _LoadFormAtPanelContainer(Form frm, bool clearOldControls)
        {
            if (frm == null)
                return;

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            if (clearOldControls)
            {
                gpnlFormContainer.Controls.Clear();
                //clsGlobal_Presentation.RefreshCurrentUser();
            }

            gpnlFormContainer.Controls.Add(frm);

            if (!frm.IsDisposed)
            {
                frm.Show();
                frm.BringToFront();
            }
        }
        private void gbtnGeneral_Click(object sender, EventArgs e)
        {
            _LoadFormAtPanelContainer(new frmOverviewGeneral(), true);
        }

        private void frmOverView_Load(object sender, EventArgs e)
        {
            gbtnGeneral.PerformClick();
        }
    }
}
