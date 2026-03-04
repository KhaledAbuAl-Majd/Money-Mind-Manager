using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using KhaledControlLibrary1;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Shared.DTOs;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Users;

namespace MoneyMindManager_Presentation.Income_And_Expense.Categories
{
    public partial class frmAddUpdateCategory : Form
    {
        private readonly IFinCategoryApiClient _finCategoryApi;
        private readonly IUserSession _userSession;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IFormDisplayer _formDisplayer;
        private bool isInitialized = false;

        /// <summary>
        /// PersonID
        /// </summary>
        public event Action<int> OnCloseAndSaved;

        bool _isSaved = false;

        bool? _isIncome;
        enum enMode { AddNew, Update };
        enMode Mode { get; set; }

        enum en_gcbIsInocmeItems { واردات = 0, مصروفات = 1 };


        public frmAddUpdateCategory(IFinCategoryApiClient finCategoryApiClient, IUserSession userSession, IMessageBoxService messageBoxService, IFormDisplayer formDisplayer)
        {
            this._finCategoryApi = finCategoryApiClient;
            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._formDisplayer = formDisplayer;

            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }

            InitializeComponent();
            Mode = enMode.AddNew;

            _CategoryID = null;
            _Category = new FinCategoryDTO();
            _isIncome = null;
        }

        public bool Initialize()
        {
            this.isInitialized = true;
            return true;
        }
        public bool Initialize(bool isIncome)
        {
            _isIncome = isIncome;
            this.isInitialized = true;
            return true;
        }
        public bool Initialize(int categoryID)
        {
            Mode = enMode.Update;
            this._CategoryID = categoryID;
            this.isInitialized = true;
            return true;
        }

        bool _CheckPermissions()
        {
            if (_userSession.IsHasPermissions(enPermissions.AddUpdateCategory))
                return true;

            _messageBoxService.DisplayError("ليس لديك صلاحية إضافة/تعديل فئة.");
            return false;
        }

        private int? _CategoryID { get; set; }
        private FinCategoryDTO _Category { get; set; }

        void _SetCategoryType()
        {
            //AddNew _voucherMode And General
            if (_isIncome == null)
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
            _Category = new FinCategoryDTO();
            lblCategoryID.Text = "N/A";
            kgtxtCategoryName.Focus();
            //_isIncome = null;
            _SetCategoryType();
            gibtnDeleteVoucher.Enabled = false;
        }

        async Task _UpdateMode()
        {
            ChangeHeaderValue("تعديل بيانات الفئة");

            var result = await _finCategoryApi.GetByID(Convert.ToInt32(Convert.ToInt32(_CategoryID)), Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || result.Data is null)
            {
                _messageBoxService.DisplayError("فشل تحميل بيانات البيئة\n" + result.ErrorMessage);
                this.Close();
                return;
            }

            var searchedCategory = result.Data;

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

            kgtxtParentCategoryName.Text = _Category.ParentCategoryName;
            _SetReadOnlyAtTextBox(kgtxtParentCategoryName);
            kgtxtNotes.Text = _Category.Notes;
            gcbIsIncome_CategroyType.SelectedIndex = Convert.ToInt32((Convert.ToBoolean(_isIncome)) ? en_gcbIsInocmeItems.واردات : en_gcbIsInocmeItems.مصروفات);
            gcbIsIncome_CategroyType.Enabled = false;

            gtxtMainCategoryName.Text = _Category.MainCategoryName;
            gtxtCategoryHierarchical.Text = _Category.CategoryHierarchical;
            kgtxtCreatedDate.RefreshNumber_DateTimeFormattedText(_Category.CreatedDate.ToString());
            kgtxtCreatedByUserName.Text = _Category?.UserInfo?.UserName;

            gibtnDeleteVoucher.Enabled = true;
        }

        void _ResteObject()
        {
            _Category = new FinCategoryDTO();
        }

        void _ShowSelectCategoryForm()
        {
            if (Mode != enMode.AddNew || _isIncome == null)
                return;

            _formDisplayer.OpenDialog<frmSelectCategory>(frm =>
            {
                if (!frm.Initialize(Convert.ToBoolean(_isIncome)))
                    return false;
                frm.OnCategorySelected += Frm_OnCategorySelected;
                return true;
            });
        }
        async Task _Save()
        {
            if (!gbtnSave.Enabled)
                return;

            gbtnSave.Enabled = false;

            if (!ValidateChildren())
            {
                _messageBoxService.ShowValidateChildrenFailedMessage();
                return;
            }

            lblUserMessage.Visible = false;

            _Category.CategoryName = kgtxtCategoryName.ValidatedText;

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

            if (Mode == enMode.AddNew)
            {
                if (int.TryParse(kgtxtParentCategoryName.Tag?.ToString(), out int parentCategoryID))
                {
                    if (!string.IsNullOrWhiteSpace(kgtxtParentCategoryName.ValidatedText))
                    {
                        _Category.ParentCategoryID = parentCategoryID;
                        _messageBoxService.DisplayError("فشل تسجيل معرف الفئة التابعة لها");
                        _ResteObject();
                        return;
                    }
                }

                _Category.IsIncome = Convert.ToBoolean(_isIncome);

                var result = await _finCategoryApi.Add(_Category, Convert.ToInt32(_userSession.UserID));

                if (!result.IsSuccess || result.Data is null)
                {
                    _messageBoxService.DisplayError(result.ErrorMessage);
                    _ResteObject();
                    return;
                }

                _Category = result.Data;
                Mode = enMode.Update;
                _CategoryID = _Category.CategoryID;
                lblCategoryID.Text = _CategoryID.ToString();
                ChangeHeaderValue("تعديل بيانات فئة");
                _SetReadOnlyAtTextBox(kgtxtParentCategoryName);
                gcbIsIncome_CategroyType.Enabled = false;

                gtxtMainCategoryName.Text = _Category.MainCategoryName;
                gtxtCategoryHierarchical.Text = _Category.CategoryHierarchical;
                kgtxtCreatedDate.RefreshNumber_DateTimeFormattedText(_Category.CreatedDate.ToString());
                kgtxtCreatedByUserName.Text = _Category?.UserInfo?.UserName;
                gibtnDeleteVoucher.Enabled = true;

                _messageBoxService.Display($"تم إضافة الفئة بنجاج بمعرف [{_Category.CategoryID}]", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _isSaved = true;
            }
            else if (Mode == enMode.Update)
            {
                var result = await _finCategoryApi.Update(_Category, Convert.ToInt32(_userSession.UserID));

                if (!result.IsSuccess || !result.Data)
                {
                    _messageBoxService.DisplayError("فشل تحديث بيانات الفئة\n" + result.ErrorMessage);
                    return;
                }

                _messageBoxService.Display("تم تعديل بيانات الفئة بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _isSaved = true;
            }
        }

        private async void frmAddUpdateCategory_Load(object sender, EventArgs e)
        {
            if (!isInitialized)
            {
                this.Close();
                return;
            }

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
            string errorMessage = clsPL_Utils.GetValidationErrorTypeString(e.validationErrorType, kgtxtBox);

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
            if (!(_isIncome == false && string.IsNullOrWhiteSpace(kgtxtParentCategoryName.Text)) && !string.IsNullOrWhiteSpace(kgtxtMonthlyBudget.ValidatedText))
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
                var result = _finCategoryApi.IsExistByName(categoryName, Convert.ToInt32(_userSession.UserID)).GetAwaiter().GetResult();

                if (!result.IsSuccess)
                {
                    _messageBoxService.DisplayError(result.ErrorMessage);
                    e.Cancel = false;
                    errorProvider1.SetError(kgtxtCategoryName, null);
                    return;
                }

                if (result.Data)
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

            if (_userSession.CurrentUserSettings.AskBeforeDeleteCategory)
                if (_messageBoxService.Display("هل أنت متأكد من رغبتك حذف الفئة ؟ ", "طلب موافقة", MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    return;

            var result = await _finCategoryApi.Delete(Convert.ToInt32(_CategoryID), Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || !result.Data)
            {
                _messageBoxService.DisplayError("فشل حذف الفئة\n" + result.ErrorMessage);
                return;
            }

            _isSaved = true;
            gbtnClose.PerformClick();
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

            _formDisplayer.OpenAtContainer<frmUserInfo>(frm =>
            {
                return frm.Initialize(Convert.ToInt32(_Category?.CreatedByUserID));
            });

        }
    }
}
