using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KhaledControlLibrary1;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Shared.DTOs;
using MoneyMindManager.Shared.DTOs.IncomeAndExpenseCategory;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.Global;

namespace MoneyMindManager_Presentation.Income_And_Expense.Categories
{
    public partial class frmSelectCategory : Form
    {
        private IFinCategoryApiClient _finCategoryApi;
        private IUserSession _userSession;
        private IMessageBoxService _messageBoxService;
        private bool isInitialized = false;

        public class SelecteCategoryEventArgs : EventArgs
        {
            public int CategoryID { get; }
            public string CategoryName { get; }

            public SelecteCategoryEventArgs(int categoryID, string categoryName)
            {
                this.CategoryID = categoryID;
                this.CategoryName = categoryName;
            }
        }

        public event EventHandler<SelecteCategoryEventArgs> OnCategorySelected;

        public frmSelectCategory(IFinCategoryApiClient finCategoryApiClient, IUserSession userSession, IMessageBoxService messageBoxService)
        {
            InitializeComponent();
            this._isIncome = null;
            this._finCategoryApi = finCategoryApiClient;
            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
        }

        public bool Initialize(bool isIncome)
        {
            _isIncome = isIncome;
            this.isInitialized = true;
            return true;
        }
        public bool Initialize()
        {
            this.isInitialized = true;
            return true;
        }

        bool? _isIncome;

        bool _searchByPageNumber = false;
        int _pageNumber = 1;
        bool _IsHeaderCreated = false;
        void _RaiseOnCategorySelectedEvnet()
        {
            if (gdgvCategories.SelectedRows.Count > 0)
            {
                int categoryID = Convert.ToInt32(gdgvCategories.SelectedRows[0].Cells[0].Value);
                string categoryName = gdgvCategories.SelectedRows[0].Cells[1].Value as string;

                OnCategorySelected?.Invoke(this, new SelecteCategoryEventArgs(categoryID, categoryName));
                this.Close();
            }
            else
            {
                lblUserMessage.Text = "من فضلك اختر صف أولا .";
                lblUserMessage.Visible = true;
            }
        }

        void _ChangeEnablithForPagingControls(bool value)
        {
            kgtxtPageNumber.Enabled = value;
            kgtxtPageNumber.Visible = value;

            gibtnNextPage.Enabled = value;
            gibtnNextPage.Visible = value;

            gibtnPreviousPage.Enabled = value;
            gibtnPreviousPage.Visible = value;

            lblCurrentPageOfNumberOfPages.Visible = value;

            lblDescriptionOfCurrentPageNumOfRcords.Visible = value;

            lblCurrentPageRecordsCount.Visible = value;
        }

        bool _CheckValidationChildren()
        {
            if (!ValidateChildren())
            {
                gdgvCategories.DataSource = null;
                _IsHeaderCreated = false;
                lblNoRecordsFoundMessage.Visible = true;
                lblUserMessage.Text = "تم العثور على حقول غير صالحة. ضع المؤشر على العلامات الحمراء لعرض سبب الخطأ.";
                lblUserMessage.Visible = true;
                lblTotalRecordsNumber.Text = "0";
                lblCurrentPageRecordsCount.Text = "0";
                lblCurrentPageOfNumberOfPages.Text = string.Concat("1", "   من   ", "0", "  صفحات");
                _pageNumber = 1;
                gibtnNextPage.Enabled = false;
                gibtnNextPage.Enabled = false;
                return false;
            }

            return true;
        }
        async Task _LoadDataAtDataGridView()
        {
            if (!_CheckValidationChildren())
                return;

            enTextSearchMode textSearchMode = enTextSearchMode.WordsPrefix_Fast;

            if (grbTextSearchMode_WordsPrefix.Checked)
                textSearchMode = enTextSearchMode.WordsPrefix_Fast;
            else if (grbTextSearchMode_SubString.Checked)
                textSearchMode = enTextSearchMode.Substring_Slow;


            string categoryName = kgtxtFilterValue.ValidatedText;
            var filterDTO = new FinCategorySelectPagedFilterDTO(textSearchMode)
            {
                CategoryName = categoryName,
                IsIncome = _isIncome,
                PageNumber = _pageNumber
            };

            var result = await _finCategoryApi.GetAllForSelectOne(filterDTO, Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || result.Data is null)
            {
                _messageBoxService.DisplayError(result.ErrorMessage);
                return;
            }

            var DTO = result.Data;



            if (DTO == null)
                return;

            if (DTO.Data.Count() == 0)
            {
                lblNoRecordsFoundMessage.Visible = true;
                gdgvCategories.DataSource = null;
                _IsHeaderCreated = false;
                kgtxtFilterValue.Focus();
            }
            else
            {
                lblNoRecordsFoundMessage.Visible = false;
                gdgvCategories.DataSource = DTO.Data;
            }

            lblUserMessage.Visible = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = _pageNumber.ToString();
            _searchByPageNumber = true;

            lblTotalRecordsNumber.Text = DTO.TotalRecords.ToString();
            lblCurrentPageOfNumberOfPages.Text = string.Concat(_pageNumber, "   من   ", DTO.TotalPages, "  صفحات");
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = true;
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = (DTO.TotalPages < 1) ? 1 : DTO.TotalPages;
            lblCurrentPageRecordsCount.Text = gdgvCategories.Rows.Count.ToString();

            gibtnNextPage.Enabled = (_pageNumber < DTO.TotalPages);
            gibtnPreviousPage.Enabled = (_pageNumber > 1);

            if (!_IsHeaderCreated && gdgvCategories.Rows.Count > 0)
            {

                gdgvCategories.Columns[nameof(FinCategoryDTO.CategoryID)].HeaderText = "معرف الفئة";
                gdgvCategories.Columns[nameof(FinCategoryDTO.CategoryID)].Width = 120;

                gdgvCategories.Columns[nameof(FinCategoryDTO.CategoryName)].HeaderText = "اسم الفئة";
                gdgvCategories.Columns[nameof(FinCategoryDTO.CategoryName)].Width = 280;

                gdgvCategories.Columns[nameof(FinCategoryDTO.ParentCategoryName)].HeaderText = "الفئة التابعة لها";
                gdgvCategories.Columns[nameof(FinCategoryDTO.ParentCategoryName)].Width = 260;

                gdgvCategories.Columns[nameof(FinCategoryDTO.MainCategoryName)].HeaderText = "الفئة الرئيسية التابعة لها";
                gdgvCategories.Columns[nameof(FinCategoryDTO.MainCategoryName)].Width = 260;

                _IsHeaderCreated = true;
            }
        }

        private async void frmSelectCategory_Load(object sender, EventArgs e)
        {
            if (!isInitialized)
            {
                this.Close();
                return;
            }

            lblNoRecordsFoundMessage.Visible = false;
            _IsHeaderCreated = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = "1";
            lblUserMessage.Visible = false;

            await _LoadDataAtDataGridView();

            if (_isIncome == true)
                this.Text = "اختيار فئة واردات";
            else if (_isIncome == false)
                this.Text = "اختيار فئة مصروفات";
            else
                this.Text = "اختيار فئة";

            kgtxtFilterValue.Focus();
        }

        private void kgtxtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _pageNumber = 1;
            SearchAfterTimerFinish.Stop();
            SearchAfterTimerFinish.Start();
        }

        private async void SearchAfterTimerFinish_Tick(object sender, EventArgs e)
        {
            await _LoadDataAtDataGridView();
        }

        private void kgtxt_OnValidationError(object sender, KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.CancelEventArgs.Cancel = true;
            errorProvider1.SetError(kgtxt, clsPL_Utils.GetValidationErrorTypeString(e.validationErrorType, kgtxt));
        }

        private void kgtxt_OnValidationSuccess(object arg1, CancelEventArgs arg2)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)arg1;
            arg2.Cancel = false;
            errorProvider1.SetError(kgtxt, null);
        }


        private void gdgvCategories_DoubleClick(object sender, EventArgs e)
        {
            _RaiseOnCategorySelectedEvnet();
        }

        private void gdgvCategories_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value)
            {
                //e.CellStyle.BackColor = Color.LightYellow; // خلفية
                e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.SelectionForeColor = Color.Orange;
            }
        }

        private void frmSelectCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _RaiseOnCategorySelectedEvnet();
                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true;
                return;
            }

            if (gdgvCategories.Focused == false && gdgvCategories.Rows.Count > 0)
            {
                int selectedRow = gdgvCategories.CurrentCell.RowIndex;

                switch (e.KeyCode)
                {
                    case Keys.Up:
                        if (selectedRow > 0)
                        {
                            gdgvCategories.CurrentCell = gdgvCategories.Rows[selectedRow - 1].Cells[0];
                            e.Handled = true;
                        }
                        break;

                    case Keys.Down:
                        if (selectedRow < gdgvCategories.Rows.Count - 1)
                        {
                            gdgvCategories.CurrentCell = gdgvCategories.Rows[selectedRow + 1].Cells[0];
                            e.Handled = true;
                        }
                        break;

                }
            }

        }


        private void gbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void gibtnNextPage_Click(object sender, EventArgs e)
        {
            ++_pageNumber;
            await _LoadDataAtDataGridView();
        }

        private async void gibtnPreviousPage_Click(object sender, EventArgs e)
        {
            --_pageNumber;
            await _LoadDataAtDataGridView();
        }
        private void kgtxtPageNumber_TextChanged(object sender, EventArgs e)
        {
            if (!_searchByPageNumber)
                return;

            if (int.TryParse(kgtxtPageNumber.Text, out int result))
            {
                _pageNumber = result;
            }
            else
                _pageNumber = 0;

            SearchAfterTimerFinish.Stop();
            SearchAfterTimerFinish.Start();
        }
    }
}
