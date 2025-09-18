using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDPresentation.Global_Classes;
using MoneyMindManager_Business;
using MoneyMindManager_Presentation.Global;

namespace MoneyMindManager_Presentation.Income_And_Expense.Categories
{
    public partial class ctrlCategoryInfo : UserControl
    {
        public ctrlCategoryInfo()
        {
            InitializeComponent();
        }
        public clsIncomeAndExpenseCategory Category { get; private set; }

        public async Task<bool> LoadCategory(int categoryID)
        {
            gbtnEditCategory.Enabled = false;

            clsIncomeAndExpenseCategory category = await clsIncomeAndExpenseCategory.FindCategoryByCategoryID(categoryID, Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID));

            return await _LoadData(category);
        }

        public async Task<bool> LoadCategory(string categoryName)
        {
            gbtnEditCategory.Enabled = false;

            clsIncomeAndExpenseCategory category = await clsIncomeAndExpenseCategory.FindCategoryByCategoryName(categoryName, Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID));

            return await _LoadData(category);
        }

        async Task<bool> _LoadData(clsIncomeAndExpenseCategory category)
        {
            if (category == null)
            {
                ResetControls();
                return false;
            }

            gbtnEditCategory.Enabled = true;

            Category = category;

            await _ShowData();

            return true;
        }

        async Task _ShowData()
        {
            lblCategoryID.Text = Category.CategoryID.ToString();
            lblCreatedDate.Text = clsFormat.DateToShort(Category.CreatedDate);
            lblIsActive.Text = (Category.IsActive) ? "فعال" : "موقوف";
            lblCategroyType.Text = (Category.IsIncome) ? "واردات" : "مصروفات";
            lblMonthlyBudget.Text = Category.MonthlyBudget?.ToString() ?? "N/A";
            gtxtCategoryName.Text = Category.CategoryName;
            gtxtParentCategoryName.Text = (await Category.GetParentCategoryInfo(Convert.ToInt32(clsGlobal_UI.CurrentUser?.UserID)))?.CategoryName;
            gtxtMainCategoryName.Text = Category.MainCategoryName;
            gtxtCreatedByUser.Text = Category.CreatedByUserInfo?.UserName;
            gtxtNotes.Text = Category.Notes;
            gtxtcategoryHierarchical.Text = Category.CategoryHierarchical;
        }

        /// <summary>
        /// Reset Controls With Start Value
        /// </summary>
        public void ResetControls()
        {
            gbtnEditCategory.Enabled = false;

            Category = null;

            lblCategoryID.Text = "N/A";
            lblCreatedDate.Text = "N/A";
            lblIsActive.Text = "N/A";
            lblMonthlyBudget.Text = "N/A";
            gtxtCategoryName.Text = null;
            gtxtParentCategoryName.Text = null;
            gtxtMainCategoryName.Text = null;
            gtxtCreatedByUser.Text = null;
            gtxtNotes.Text = null;
            gtxtcategoryHierarchical.Text = null;
        }

        private void ctrlCategoryInfo_Load(object sender, EventArgs e)
        {
            gbtnEditCategory.Enabled = false;

            gtxtCategoryName.ReadOnly = true;
            gtxtParentCategoryName.ReadOnly = true;
            gtxtMainCategoryName.ReadOnly = true;
            gtxtCreatedByUser.ReadOnly = true;
            gtxtNotes.ReadOnly = true;
            gtxtcategoryHierarchical.ReadOnly = true;
        }
    }
}
