using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyMindManager_Presentation.OverView.Controls;

namespace MoneyMindManager_Presentation.Income_And_Expense.Categories
{
    public partial class frmCategoryMonthlyFlow : Form
    {
        public frmCategoryMonthlyFlow(int categoryID)
        {
            InitializeComponent();
            this.CategoryID = categoryID;
        }

        int CategoryID;

        private async void frmCategoryMonthlyFlow_Load(object sender, EventArgs e)
        {
            guna2WinProgressIndicator1.BringToFront();
            guna2WinProgressIndicator1.Start();
            guna2WinProgressIndicator1.Show();
            this.UseWaitCursor = true;

            if (!await ctrlCategoryMonthlyFlow1.LoadData(CategoryID))
                this.Close();

            this.UseWaitCursor = false;
            guna2WinProgressIndicator1.Stop();
            guna2WinProgressIndicator1.Hide();
        }

        private void gbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
