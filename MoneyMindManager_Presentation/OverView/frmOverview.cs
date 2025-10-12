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
    public partial class frmOverview : Form
    {
        public frmOverview()
        {
            InitializeComponent();
        }

        private async void frmOverview_Load(object sender, EventArgs e)
        {
          await  ctrlTest1.LoadData();
        }
    }
}
