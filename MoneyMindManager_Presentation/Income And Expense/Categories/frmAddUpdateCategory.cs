using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KhaledControlLibrary1;
using MoneyMindManager_Business;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Users;

namespace MoneyMindManager_Presentation.Income_And_Expense.Categories
{
    public partial class frmAddUpdateCategory : Form
    {
        /// <summary>
        /// PersonID
        /// </summary>
        public event Action<int> OnCloseAndSaved;

        bool _isSaved = false;

        bool? _isIncome;
        enum enMode { AddNew, Update };
        enMode Mode { get; set; }

        enum en_gcbIsInocmeItems { واردات = 0, مصروفات = 1 };


        public frmAddUpdateCategory()
        {
            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }

            InitializeComponent();
            Mode = enMode.AddNew;
            _CategoryID = null;
            _Category = new clsIncomeAndExpenseCategory();
            _isIncome = null;
        }

        /// <summary>
        /// AddNew _voucherMode and Specify Cateogry Type
        /// </summary>
        /// <param name="isIncome">Category Type</param>
        public frmAddUpdateCategory(bool isIncome)
        {
            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }

            InitializeComponent();
            Mode = enMode.AddNew;
            _CategoryID = null;
            _Category = new clsIncomeAndExpenseCategory();
            _isIncome = isIncome;
        }

        public frmAddUpdateCategory(int categoryID)
        {
            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }

            InitializeComponent();
            Mode = enMode.AddNew;
            Mode = enMode.Update;
            this._CategoryID = categoryID;
        }

        bool _CheckPermissions()
        {
            return clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.AddUpdateCategory,
                "ليس لديك صلاحية إضافة/تعديل فئة.");
        }

        private int? _CategoryID { get; set; }
        private clsIncomeAndExpenseCategory _Category { get; set; }

        void _SetCategoryType()
        {
            //AddNew _voucherMode And General
            if(_isIncome == null)
            {
                gcbIsIncome_CategroyType.Enabled = true;
                gcbIsIncome_CategroyType.SelectedIndex = (int)en_gcbIsInocmeItems.واردات;
                _isIncome = true;
                return;
            }

            gcbIsIncome_CategroyType.SelectedIndex = Convert.ToInt32((Convert.ToBoolean(_isIncome)) ? en_gcbIsInocmeItems.واردات : en_gcbIsInocmeItems.مصروفات);
            gcbIsIncome_CategroyType.Enabled = false;
        }

        void ChangeHeaderValue(string txt)
        {
            this.Text = txt;
            lblHeader.Text = txt;
        }

        void _SetReadOnlyAtTextBox(KhaledGuna2TextBox kgtxt)
        {
            kgtxt.ReadOnly = true;
            kgtxt.FillColor = SystemColors.ControlLight;
        }

        void _CancelReadOnlyAtTextBox(KhaledGuna2TextBox kgtxt)
        {
            kgtxt.ReadOnly = false;
            kgtxt.FillColor = Color.White;
        }

        void _AddNewMode()
        {
            ChangeHeaderValue("إضافة فئة");
            _CategoryID = null;
            _Category = new clsIncomeAndExpenseCategory();
            lblCategoryID.Text = "N/A";
            kgtxtCategoryName.Focus();
            //_isIncome = null;
            _SetCategoryType();
            gibtnDeleteVoucher.Enabled = false;
        }

        async Task _UpdateMode()
        {
            ChangeHeaderValue("تعديل بيانات الفئة");

            var searchedCategory = await clsIncomeAndExpenseCategory.FindCategoryByCategoryID(Convert.ToInt32(_CategoryID) );

            if (searchedCategory == null)
            {
                clsGlobalMessageBoxs.ShowErrorMessage("فشل تحميل بيانات الفئة");
                this.Close();
                return;
            }

            this._CategoryID = searchedCategory.CategoryID;
            this._Category = searchedCategory;
            this._isIncome = searchedCategory.IsIncome;

            kgtxtCategoryName.Text = _Category.CategoryName;
            kgtxtCategoryName.Tag = _Category.CategoryID;
            lblCategoryID.Text = _Category.CategoryID?.ToString();
            gtswIsActive.Checked = _Category.IsActive;
            kgtxtMonthlyBudget.Text = _Category.MonthlyBudget?.ToString();
            if (!(_Category.ParentCategoryID == null && _Category.IsIncome == false))
                _SetReadOnlyAtTextBox(kgtxtMonthlyBudget);

            kgtxtParentCategoryName.Text = (await _Category.GetParentCategoryInfo())?.CategoryName;
            _SetReadOnlyAtTextBox(kgtxtParentCategoryName);
            kgtxtNotes.Text = _Category.Notes;
            gcbIsIncome_CategroyType.SelectedIndex = Convert.ToInt32((Convert.ToBoolean(_isIncome)) ? en_gcbIsInocmeItems.واردات : en_gcbIsInocmeItems.مصروفات);
            gcbIsIncome_CategroyType.Enabled = false;

            gtxtMainCategoryName.Text = _Category.MainCategoryName;
            gtxtCategoryHierarchical.Text = _Category.CategoryHierarchical;
            kgtxtCreatedDate.RefreshNumber_DateTimeFormattedText(_Category.CreatedDate.ToString());
            kgtxtCreatedByUserName.Text = _Category?.CreatedByUserInfo?.UserName;

            gibtnDeleteVoucher.Enabled = true;
        }

        void _ResteObject()
        {
            _Category = new clsIncomeAndExpenseCategory();
        }

        void _ShowSelectCategoryForm()
        {
            if (Mode != enMode.AddNew || _isIncome == null)
                return;

            var frm = new frmSelectCategory(Convert.ToBoolean(_isIncome));
            frm.OnCategorySelected += Frm_OnCategorySelected;
            //frm.ShowDialog(clsGlobal_UI.MainForm);
            clsGlobal_UI.MainForm.AddNewFormAsDialog(frm);
        }
        async Task _Save()
        {
            if (!gbtnSave.Enabled)
                return;

            gbtnSave.Enabled = false;

            if (!ValidateChildren())
            {
                clsGlobalMessageBoxs.ShowValidateChildrenFailedMessage();
                return;
            }

            lblUserMessage.Visible = false;

            _Category.CategoryName = kgtxtCategoryName.ValidatedText;


            if (Mode == enMode.AddNew)
            {
                if (int.TryParse(kgtxtParentCategoryName.Tag?.ToString(), out int parentCategoryID))
                {
                    if (!string.IsNullOrWhiteSpace(kgtxtParentCategoryName.ValidatedText) && !_Category.AssignParentCateoryIDAtAddMode(Convert.ToInt32(parentCategoryID)))
                    {
                        clsGlobalMessageBoxs.ShowErrorMessage("فشل تسجيل معرف الفئة التابعة لها");
                        _ResteObject();
                        return;
                    }
                }

                if (!_Category.AssignIsIncome_CategoryType_AtAddMode(Convert.ToBoolean(_isIncome)))
                {
                    clsGlobalMessageBoxs.ShowErrorMessage("فشل تسجيل نوع الفئة");
                    _ResteObject();
                    return;
                }
            }

            if (Convert.ToBoolean(_isIncome))
                _Category.MonthlyBudget = null;
            else
            {
                if (string.IsNullOrWhiteSpace(kgtxtMonthlyBudget.ValidatedText))
                    _Category.MonthlyBudget = null;
                else
                    _Category.MonthlyBudget = Convert.ToDecimal(kgtxtMonthlyBudget.ValidatedText); 
                
            }

            _Category.Notes = kgtxtNotes.ValidatedText;

            if (await _Category.Save(gtswIsActive.Checked))
            {
                if (Mode == enMode.AddNew)
                {
                    clsGlobalMessageBoxs.ShowMessage($"تم إضافة الفئة بنجاج بمعرف [{_Category.CategoryID}]", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Mode = enMode.Update;
                    _CategoryID = _Category.CategoryID;
                    lblCategoryID.Text = _CategoryID.ToString();
                    ChangeHeaderValue("تعديل بيانات فئة");
                    _SetReadOnlyAtTextBox(kgtxtParentCategoryName);
                    gcbIsIncome_CategroyType.Enabled = false;

                    gtxtMainCategoryName.Text = _Category.MainCategoryName;
                    gtxtCategoryHierarchical.Text = _Category.CategoryHierarchical;
                    kgtxtCreatedDate.RefreshNumber_DateTimeFormattedText(_Category.CreatedDate.ToString());
                    kgtxtCreatedByUserName.Text = _Category?.CreatedByUserInfo?.UserName;
                    gibtnDeleteVoucher.Enabled = true;
                }
                else if (Mode == enMode.Update)
                {
                    clsGlobalMessageBoxs.ShowMessage("تم تعديل بيانات الفئة بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _isSaved = true;
            }
            else if (Mode == enMode.AddNew)
                _ResteObject();
        }

        private async void frmAddUpdateCategory_Load(object sender, EventArgs e)
        {
            lblUserMessage.Visible = false;

            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        _AddNewMode();
                        break;
                    }
                case enMode.Update:
                    {
                        await _UpdateMode();
                        break;
                    }
            }
        }

        private void kgtxt_OnValidationError(object sender, KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            KhaledGuna2TextBox kgtxtBox = (KhaledGuna2TextBox)sender;
            e.CancelEventArgs.Cancel = true;
            string errorMessage = clsUtils.GetValidationErrorTypeString(e.validationErrorType, kgtxtBox);

            errorProvider1.SetError(kgtxtBox, errorMessage);
        }

        private void kgtxt_OnValidationSuccess(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            errorProvider1.SetError((KhaledGuna2TextBox)sender, null);
        }

        private async void gbtnSave_Click(object sender, EventArgs e)
        {
            await _Save();
            gbtnSave.Enabled = true;
        }

        private void gbtnClose_Click(object sender, EventArgs e)
        {
            if (_isSaved)
                OnCloseAndSaved?.Invoke(Convert.ToInt32(_Category.CategoryID));

            this.Close();
        }

        private void kgtxtParentCategory_IconLeftClick(object sender, EventArgs e)
        {
            _ShowSelectCategoryForm();
        }

        private void Frm_OnCategorySelected(object sender, frmSelectCategory.SelecteCategoryEventArgs e)
        {
            if (Mode != enMode.AddNew || _isIncome == null)
                return;

            kgtxtParentCategoryName.Text = e.CategoryName;
            kgtxtParentCategoryName.Tag = e.CategoryID;
            kgtxtMonthlyBudget.Text = null;
            _SetReadOnlyAtTextBox(kgtxtMonthlyBudget);
        }

        private void kgtxtMonthlyBudget_OnValidationSuccess(object sender, CancelEventArgs e)
        {
            kgtxt_OnValidationSuccess(sender, e);

            // it's not( expense main category)
            if(!(_isIncome == false && string.IsNullOrWhiteSpace(kgtxtParentCategoryName.Text)) && !string.IsNullOrWhiteSpace(kgtxtMonthlyBudget.ValidatedText))
            {
                e.Cancel = true;
                string errorMessage = "الميزانية الشهرية متاحة فقط ل الفئات الرئيسية من نوع مصروفات";

                errorProvider1.SetError(kgtxtMonthlyBudget, errorMessage);
            }
        }

        private void gcbIsIncome_CategroyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gcbIsIncome_CategroyType.SelectedIndex == (int)en_gcbIsInocmeItems.واردات)
            {
                if (_isIncome == false)
                    kgtxtParentCategoryName_RightIconClear(null, null);

                _isIncome = true;
                if (Mode == enMode.AddNew)
                    _SetReadOnlyAtTextBox(kgtxtMonthlyBudget);
            }
            else if (gcbIsIncome_CategroyType.SelectedIndex == (int)en_gcbIsInocmeItems.مصروفات)
            {
                if (_isIncome == true)
                    kgtxtParentCategoryName_RightIconClear(null, null);

                _isIncome = false;
                if (Mode == enMode.AddNew && string.IsNullOrWhiteSpace(kgtxtParentCategoryName.Text))
                    _CancelReadOnlyAtTextBox(kgtxtMonthlyBudget);
            }
        }

        private void kgtxtParentCategoryName_RightIconClear(object sender, EventArgs e)
        {
            if (Mode != enMode.AddNew || _isIncome == null)
                return;

            kgtxtParentCategoryName.Text = null;
            kgtxtParentCategoryName.Tag = null;
            if (_isIncome == false)
                _CancelReadOnlyAtTextBox(kgtxtMonthlyBudget);
        }

        private void kgtxtCategoryName_OnValidationSuccess(object sender, CancelEventArgs e)
        {
            kgtxt_OnValidationSuccess(sender, e);

            string categoryName = kgtxtCategoryName.ValidatedText;

            if ((Mode == enMode.AddNew) || (Mode == enMode.Update && _Category.CategoryName != categoryName))
            {
                if (clsIncomeAndExpenseCategory.IsCategoryExistByCategoryName(categoryName))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(kgtxtCategoryName, "اسم الفئة مستخدم, قم بتجربة اسم آخر");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(kgtxtCategoryName, null);
                }
            }
        }

        private async void gibtnDeleteVoucher_Click(object sender, EventArgs e)
        {
            if (_CategoryID == null || Mode == enMode.AddNew)
                return;

            if (clsGlobalMessageBoxs.ShowMessage("هل أنت متأكد من رغبتك حذف الفئة ؟ ", "طلب مواقفقة", MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (await clsIncomeAndExpenseCategory.DeleteCategoryByCategoryID(Convert.ToInt32(_CategoryID)))
                {
                    _isSaved = true;
                    gbtnClose.PerformClick();
                }
            }
        }

        private void kgtxtParentCategoryName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                _ShowSelectCategoryForm();
            }
        }

        private void kgtxtCreatedByUserName_IconRightClick(object sender, EventArgs e)
        {
            if (_CategoryID == null || Mode == enMode.AddNew)
            {
                lblUserMessage.Text = "قم بإضافة فئة أولا";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            frmUserInfo frm = new frmUserInfo(Convert.ToInt32(_Category?.CreatedByUserID));
            clsGlobal_UI.MainForm.AddNewFormAtContainer(frm);
        }
    }
}
