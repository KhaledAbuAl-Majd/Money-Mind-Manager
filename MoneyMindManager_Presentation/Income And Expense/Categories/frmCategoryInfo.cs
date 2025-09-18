using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyMindManager_Presentation.Income_And_Expense.Categories
{
    public partial class frmCategoryInfo : Form
    {
        public frmCategoryInfo()
        {
            InitializeComponent();
        }

        private async void frmCategoryInfo_Load(object sender, EventArgs e)
        {
            if (!await ctrlCategoryInfo1.LoadCategory(0))
            {
                this.Close();
            }
        }
    }
}
