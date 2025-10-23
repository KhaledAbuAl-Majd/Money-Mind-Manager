using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyMindManager_Business;

namespace MoneyMindManager_Presentation.OverView
{
    public partial class frmOverView : Form
    {
        public frmOverView()
        {
            if (!clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.OverView,
                "ليس لديك صلاحية شاشة لمحة عامة."))
            {
                this.Dispose();
                return;
            }

            InitializeComponent();
        }

        void _LoadFormAtPanelContainer(Form frm)
        {
            if (frm == null)
                return;

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;


            if (!frm.IsDisposed)
            {
                gpnlFormContainer.Controls.Clear();

                gpnlFormContainer.Controls.Add(frm);
                frm.Show();
                frm.BringToFront();
            } 
        }
        private void frmOverView_Load(object sender, EventArgs e)
        {
            gbtnGeneral.PerformClick();
        }
        private void gbtnGeneral_Click(object sender, EventArgs e)
        {
            _LoadFormAtPanelContainer(new frmOverviewGeneral());
        }


        private void gbtnDebts_Click(object sender, EventArgs e)
        {
            _LoadFormAtPanelContainer(new frmOverViewDebts());
        }

        private void gbtnCategories_Click(object sender, EventArgs e)
        {
            _LoadFormAtPanelContainer(new frmOverViewCategories());
        }
    }
}
