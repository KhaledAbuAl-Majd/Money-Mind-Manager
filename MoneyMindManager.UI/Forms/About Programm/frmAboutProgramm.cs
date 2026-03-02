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
        void _OpenLink(Guna2ImageButton btn, string link)
        {
            btn.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = link,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء محاولة فتح الرابط.\n\n" + ex.Message,
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btn.Enabled = true;
            Cursor = Cursors.Default;
        }
        private void gibtnDevWebsite_Click(object sender, EventArgs e)
        {
            _OpenLink((Guna2ImageButton)sender, "https://khaledabual-majd.github.io/");
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gibtnDevWebsite_Click(sender, null);
        }
    }
}
