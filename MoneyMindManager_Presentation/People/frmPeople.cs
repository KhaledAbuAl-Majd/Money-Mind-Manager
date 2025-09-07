using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyMindManager_Business;
using MoneyMindManager_Presentation.Global;

namespace MoneyMindManager_Presentation.People
{
    public partial class frmPeople : Form
    {
        public frmPeople()
        {
            InitializeComponent();
        }

        short _pageNumber = 1;
        async Task _LoadDataAtDataGridView(short pageNumber)
        {
            var result = await clsPerson.GetAllPeople(2, pageNumber);

            if (result == null)
                return;

            if (result.dtPeople.Rows.Count > 0)
            {
                lblNoRecordsMessage.Visible = false;
                guna2DataGridView1.DataSource = result.dtPeople;
            }
            else
            {
                lblNoRecordsMessage.Visible = true;
            }

                _pageNumber = result.CurrentPageNumber;
            kgtxtPageNumber.Text = result.CurrentPageNumber.ToString();
            lblTotalRecordsNumber.Text = result.RecordsCount.ToString();
            lblCurrentPageOfNumberOfPages.Text = string.Concat(result.CurrentPageNumber, "   من   ", result.NumberOfPages, "  صفحات");
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = true;
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = result.NumberOfPages;
            lblCurrentPageRecordsCount.Text = guna2DataGridView1.Rows.Count.ToString();

            if (result.CurrentPageNumber >= result.NumberOfPages)
                gibtnNextPage.Enabled = false;

            if (result.CurrentPageNumber == 1 || result.CurrentPageNumber == 0)
                gibtnPreviousPage.Enabled = false;

            //
            //guna2DataGridView1.Columns["PersonID"].HeaderText = "معرف الشخص";
            //guna2DataGridView1.Columns["PersonID"].Width = 120;

            //guna2DataGridView1.Columns["PersonName"].HeaderText = "اسم الشخص";
            //guna2DataGridView1.Columns["PersonName"].Width = 250;

            //guna2DataGridView1.Columns["Address"].HeaderText = "العنوان";
            //guna2DataGridView1.Columns["Address"].Width = 290;

            //guna2DataGridView1.Columns["Email"].HeaderText = "البريد الإلكتروني";
            //guna2DataGridView1.Columns["Email"].Width = 260;

            //guna2DataGridView1.Columns["Phone"].HeaderText = "رقم الهاتف";
            //guna2DataGridView1.Columns["Phone"].Width = 140;

            //guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private async void frmPeople_Load(object sender, EventArgs e)
        {
            lblNoRecordsMessage.Visible = false;
           await _LoadDataAtDataGridView(1);
            //guna2DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            if (guna2DataGridView1.Rows.Count > 0)
            {
                guna2DataGridView1.Columns["PersonID"].HeaderText = "معرف الشخص";
                guna2DataGridView1.Columns["PersonID"].Width = 120;

                guna2DataGridView1.Columns["PersonName"].HeaderText = "اسم الشخص";
                guna2DataGridView1.Columns["PersonName"].Width = 250;

                guna2DataGridView1.Columns["Address"].HeaderText = "العنوان";
                guna2DataGridView1.Columns["Address"].Width = 290;

                guna2DataGridView1.Columns["Email"].HeaderText = "البريد الإلكتروني";
                guna2DataGridView1.Columns["Email"].Width = 260;

                guna2DataGridView1.Columns["Phone"].HeaderText = "رقم الهاتف";
                guna2DataGridView1.Columns["Phone"].Width = 140;
            }
        }

        private void kgtxtPageNumber_OnValidationError(object sender, KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            e.CancelEventArgs.Cancel = true;
            errorProvider1.SetError(kgtxtPageNumber, clsUtils.GetValidationErrorTypeString(e.validationErrorType, kgtxtPageNumber));
        }

        private void kgtxtPageNumber_OnValidationSuccess(object arg1, CancelEventArgs arg2)
        {
            arg2.Cancel = false;
            errorProvider1.SetError(kgtxtPageNumber, null);
        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.Value == null || e.Value == DBNull.Value)
            {
                //e.CellStyle.BackColor = Color.LightYellow; // خلفية
                e.CellStyle.ForeColor = Color.Red;
            }
        }

        private async void gibtnNextPage_Click(object sender, EventArgs e)
        {
            ++_pageNumber;
            await _LoadDataAtDataGridView(_pageNumber);
        }

        private async void gibtnPreviousPage_Click(object sender, EventArgs e)
        {
            --_pageNumber;
            await _LoadDataAtDataGridView(_pageNumber);
        }
    }
}
