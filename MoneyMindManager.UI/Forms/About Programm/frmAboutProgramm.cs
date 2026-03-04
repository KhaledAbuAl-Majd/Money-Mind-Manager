using System;
using System.Diagnostics;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace MoneyMindManager_Presentation.Global
{
    public partial class frmAboutProgramm : Form
    {
        public frmAboutProgramm()
        {
            InitializeComponent();
        }
        private void gibtnDevWebsite_Click(object sender, EventArgs e)
        {
            ((Guna2ImageButton)sender).Enabled = false;
            _OpenLink();
            ((Guna2ImageButton)sender).Enabled = true;
        }

        void _OpenLink()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = "https://khaledabual-majd.github.io/",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء محاولة فتح الرابط.\n\n" + ex.Message,
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor = Cursors.Default;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((LinkLabel)sender).Enabled = false;
            _OpenLink();
            ((LinkLabel)sender).Enabled = true;
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            ((LinkLabel)sender).Enabled = false;
            _OpenLink();
            ((LinkLabel)sender).Enabled = true;
        }
    }
}
