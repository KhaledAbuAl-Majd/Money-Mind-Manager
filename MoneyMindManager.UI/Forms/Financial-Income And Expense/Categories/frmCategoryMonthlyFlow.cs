using System;
using System.Windows.Forms;

namespace MoneyMindManager_Presentation.Income_And_Expense.Categories
{
    public partial class frmCategoryMonthlyFlow : Form
    {
        private bool isInitialized = false;
        public frmCategoryMonthlyFlow()
        {
            InitializeComponent();
        }


        public bool Initialize(int categoryID)
        {
            this.CategoryID = categoryID;
            this.isInitialized = true;
            return true;
        }

        int CategoryID;

        private async void frmCategoryMonthlyFlow_Load(object sender, EventArgs e)
        {
            if (!isInitialized)
            {
                this.Close();
                return;
            }

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
