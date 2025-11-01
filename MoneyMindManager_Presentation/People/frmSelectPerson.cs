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
using MoneyMindManagerGlobal;
using static MoneyMindManager_Business.clsBLLGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.clsIncomeAndExpenseCategoriesClasses;

namespace MoneyMindManager_Presentation.Income_And_Expense.Categories
{
    public partial class frmSelectPerson : Form
    {
        public class SelectPersonEventArgs : EventArgs
        {
            public int PersonID { get; }
            public string PersonName { get; }

            public SelectPersonEventArgs(int personID,string personName)
            {
                this.PersonID = personID;
                this.PersonName = personName;
            }
        }

        public event EventHandler<SelectPersonEventArgs> OnPersonSelected;
        public frmSelectPerson()
        {
            InitializeComponent();
        }


        bool _searchByPageNumber = false;
        short _pageNumber = 1;
        bool _IsHeaderCreated = false;
        void _RaiseOnPersonSelectedEvnet()
        {
            if(gdgvPeople.SelectedRows.Count > 0)
            {
                int categoryID = Convert.ToInt32(gdgvPeople.SelectedRows[0].Cells[0].Value);
                string categoryName = gdgvPeople.SelectedRows[0].Cells[1].Value as string;

                OnPersonSelected?.Invoke(this, new SelectPersonEventArgs(categoryID, categoryName));
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
                gdgvPeople.DataSource = null;
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


            clsDataColumns.PersonClasses.clsGetAllPeople result = null;

            enTextSearchMode textSearchMode = enTextSearchMode.WordsPrefix_Fast;

            if (grbTextSearchMode_WordsPrefix.Checked)
                textSearchMode = enTextSearchMode.WordsPrefix_Fast;
            else if (grbTextSearchMode_SubString.Checked)
                textSearchMode = enTextSearchMode.Substring_Slow;

            string personName = kgtxtFilterValue.ValidatedText;
            result = await clsPerson.GetAllPeopleForSelectOne(personName, textSearchMode, _pageNumber);           

            if (result == null)
                return;

            if (result.dtPeople.Rows.Count == 0)
            {
                lblNoRecordsFoundMessage.Visible = true;
                gdgvPeople.DataSource = null;
                _IsHeaderCreated = false;
                kgtxtFilterValue.Focus();
            }
            else
            {
                lblNoRecordsFoundMessage.Visible = false;
                gdgvPeople.DataSource = result.dtPeople;
            }

            lblUserMessage.Visible = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = _pageNumber.ToString();
            _searchByPageNumber = true;

            lblTotalRecordsNumber.Text = result.RecordsCount.ToString();
            lblCurrentPageOfNumberOfPages.Text = string.Concat(_pageNumber, "   من   ", result.NumberOfPages, "  صفحات");
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = true;
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = (result.NumberOfPages < 1) ? 1 : result.NumberOfPages;
            lblCurrentPageRecordsCount.Text = gdgvPeople.Rows.Count.ToString();

            gibtnNextPage.Enabled = (_pageNumber < result.NumberOfPages);
            gibtnPreviousPage.Enabled = (_pageNumber > 1);

            if (!_IsHeaderCreated && gdgvPeople.Rows.Count > 0)
            {
                gdgvPeople.Columns["PersonID"].HeaderText = "معرف الشخص";
                gdgvPeople.Columns["PersonID"].Width = 150;

                gdgvPeople.Columns["PersonName"].HeaderText = "اسم الشخص";
                gdgvPeople.Columns["PersonName"].Width = 670;

                _IsHeaderCreated = true;
            }
        }

        private async void frmSelectPerson_Load(object sender, EventArgs e)
        {
            lblNoRecordsFoundMessage.Visible = false;
            _IsHeaderCreated = false;
            _searchByPageNumber = false;
            kgtxtPageNumber.Text = "1";
            lblUserMessage.Visible = false;

            await _LoadDataAtDataGridView();

            this.Text = "اختيار شخص";

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
            _RaiseOnPersonSelectedEvnet();
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

        private void frmSelectPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _RaiseOnPersonSelectedEvnet();
                e.Handled = true;
                return;
            }

            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true;
                return;
            }

            if(gdgvPeople.Focused == false && gdgvPeople.Rows.Count > 0)
            {
                int selectedRow = gdgvPeople.CurrentCell.RowIndex;

                switch (e.KeyCode)
                {
                    case Keys.Up:
                        if (selectedRow > 0)
                        {
                            gdgvPeople.CurrentCell = gdgvPeople.Rows[selectedRow - 1].Cells[0];
                            e.Handled = true;
                        }
                        break;

                    case Keys.Down:
                        if (selectedRow < gdgvPeople.Rows.Count - 1)
                        {
                            gdgvPeople.CurrentCell = gdgvPeople.Rows[selectedRow + 1].Cells[0];
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
        private async void kgtxtPageNumber_TextChanged(object sender, EventArgs e)
        {
            if (!_searchByPageNumber || !_CheckValidationChildren())
                return;

            _pageNumber = Convert.ToInt16(kgtxtPageNumber.ValidatedText);

            await _LoadDataAtDataGridView();
        }
    }
}
