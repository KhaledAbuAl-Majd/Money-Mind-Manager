using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KhaledControlLibrary1;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Models.DebtPayment;
using MoneyMindManager.Core.Models.FinTransaction;
using MoneyMindManager.Shared.DTOs.Debt;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Income_And_Expense.Categories;
using MoneyMindManager_Presentation.Transactions;

namespace MoneyMindManager.UI.Forms.Debts.DebtPayment
{
    public partial class ctrDebtPaymentsList : UserControl
    {

        private IUserSession _userSession;
        private IMessageBoxService _messageBoxService;
        private IFormDisplayer _formDisplayer;
        private IDebtPaymentApiClient _debtPaymentApi;
        private IDataConverter _dataConverter;
        private IExportWithDialogService _exportWithDialogService;

        /// <summary>
        /// Returning RemainingAmount
        /// </summary>
        public event Action<decimal> OnLoading;

        private bool isInitialized = false;
        int? _DebtID;
        public DebtDTO _Debt { get; set; }

        bool _IsHeaderCreated = false;
        bool _searchByPageNumber = false;
        int _pageNumber = 1;

        public bool IsLocked { get; set; }
        public ctrDebtPaymentsList()
        {
            InitializeComponent();
            _DebtID = null;
            _Debt = null;
            IsLocked = true;

            this.SetStyle(ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.OptimizedDoubleBuffer, true);
                    this.UpdateStyles();
        }

        public bool Initialize(IUserSession userSession, IMessageBoxService messageBoxService, IFormDisplayer formDisplayer,
            IDebtPaymentApiClient debtPaymentApiClient, IDataConverter dataConverter, IExportWithDialogService exportWithDialogService)
        {
            this.isInitialized = true;
            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._formDisplayer = formDisplayer;
            this._debtPaymentApi = debtPaymentApiClient;
            this._dataConverter = dataConverter;
            this._exportWithDialogService = exportWithDialogService;

            _searchByPageNumber = false;
            kgtxtPageNumber.Text = "1";
            _searchByPageNumber = true;

            return true;
        }

        public async Task<bool> LoadData(DebtDTO debt)
        {
            if (debt is null)
                return false;

            if (!isInitialized)
                return false;

            this.IsLocked = debt.IsLocked;
            this._Debt = debt;
            this._DebtID = debt.DebtID;

            _searchByPageNumber = false;
            kgtxtPageNumber.Text = "1";
            _searchByPageNumber = true;
            lblUserMessage.Visible = false;

            return await _LoadDataAtDataGridView();
        }

        bool _CheckValidationChildren()
        {
            if (!ValidateChildren())
            {
                gdgvDebtPaymentTransctions.DataSource = null;
                _IsHeaderCreated = false;
                lblUserMessage.Text = "تم العثور على حقول غير صالحة. ضع المؤشر على العلامات الحمراء لعرض سبب الخطأ.";
                lblUserMessage.Visible = true;
                lblCurrentPageRecordsCount.Text = "0";
                lblTotalRecordsNumber.Text = "0";
                lblCurrentPageOfNumberOfPages.Text = string.Concat("1", "   من   ", "0", "  صفحات");
                _pageNumber = 1;
                gibtnNextPage.Enabled = false;
                gibtnNextPage.Enabled = false;
                return false;
            }

            return true;
        }

        async Task<bool> _LoadDataAtDataGridView()
        {
            if (_DebtID is null || !isInitialized)
                return false;

            if (!_CheckValidationChildren())
                return false;

            var result = await _debtPaymentApi.GetAllPagedForDebt(Convert.ToInt32(_Debt.DebtID), Convert.ToInt32(_userSession.UserID), _pageNumber);

            if (!result.IsSuccess)
            {
                _messageBoxService.DisplayError(result.ErrorMessage);
                return false;
            }

            var DTO = result.Data;

            if (DTO == null)
                return false;

            if (DTO.Data.Count() == 0)
            {
                lblNoTransactionsFoundMessage.Visible = true;
                gdgvDebtPaymentTransctions.DataSource = null;
                _IsHeaderCreated = false;
                _pageNumber = 1;
            }
            else
            {
                lblNoTransactionsFoundMessage.Visible = false;
                gdgvDebtPaymentTransctions.DataSource = DTO.Data;
            }

            if (!_Debt.IsLocked)
                lblUserMessage.Visible = false;

            _searchByPageNumber = false;
            kgtxtPageNumber.Text = _pageNumber.ToString();
            _searchByPageNumber = true;

            lblTotalRecordsNumber.Text = DTO.TotalRecords.ToString();
            lblCurrentPageOfNumberOfPages.Text = string.Concat(_pageNumber, "   من   ", DTO.TotalPages, "  صفحات");
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = true;
            kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = (DTO.TotalPages < 1) ? 1 : DTO.TotalPages;
            lblCurrentPageRecordsCount.Text = gdgvDebtPaymentTransctions.Rows.Count.ToString();

            gibtnNextPage.Enabled = (_pageNumber < DTO.TotalPages);
            gibtnPreviousPage.Enabled = (_pageNumber > 1);
            //

            if (!_IsHeaderCreated && gdgvDebtPaymentTransctions.Rows.Count > 0)
            {

                gdgvDebtPaymentTransctions.Columns[nameof(DebtTransactionsViewSummary.MainTransactionID)].HeaderText = "معرف المعاملة";
                gdgvDebtPaymentTransctions.Columns[nameof(DebtTransactionsViewSummary.MainTransactionID)].Width = 125;

                gdgvDebtPaymentTransctions.Columns[nameof(DebtTransactionsViewSummary.Amount)].HeaderText = "المبلغ";
                gdgvDebtPaymentTransctions.Columns[nameof(DebtTransactionsViewSummary.Amount)].Width = 250;
                gdgvDebtPaymentTransctions.Columns[nameof(DebtTransactionsViewSummary.Amount)].DefaultCellStyle.Format = "N2";

                gdgvDebtPaymentTransctions.Columns[nameof(DebtTransactionsViewSummary.DebtDate)].HeaderText = "تاريخ المعاملة";
                gdgvDebtPaymentTransctions.Columns[nameof(DebtTransactionsViewSummary.DebtDate)].Width = 130;
                gdgvDebtPaymentTransctions.Columns[nameof(DebtTransactionsViewSummary.DebtDate)].DefaultCellStyle.Format = "dd-MM-yyyy";

                gdgvDebtPaymentTransctions.Columns[nameof(DebtTransactionsViewSummary.CreatedDate)].HeaderText = "تاريخ الإنشاء";
                gdgvDebtPaymentTransctions.Columns[nameof(DebtTransactionsViewSummary.CreatedDate)].Width = 250;
                gdgvDebtPaymentTransctions.Columns[nameof(DebtTransactionsViewSummary.CreatedDate)].DefaultCellStyle.Format = "hh:mm:ss tt dd-MM-yyyy";

                gdgvDebtPaymentTransctions.Columns[nameof(DebtTransactionsViewSummary.CreatedByUserName)].HeaderText = "اسم المستخدم المنشئ";
                gdgvDebtPaymentTransctions.Columns[nameof(DebtTransactionsViewSummary.CreatedByUserName)].Width = 250;

                gdgvDebtPaymentTransctions.Columns[nameof(DebtTransactionsViewSummary.Purpose)].HeaderText = "البيان";
                gdgvDebtPaymentTransctions.Columns[nameof(DebtTransactionsViewSummary.Purpose)].Width = 300;

                _IsHeaderCreated = true;
            }

            //kgtxtRemainingAmount.RefreshNumber_DateTimeFormattedText(DTO.Value.ToString());
            _Debt.RemainingAmount = DTO.Value;
            this.Focus();

            OnLoading?.Invoke((DTO.Value));
            return true;
        }

        private void ctrDebtPaymentsList_Load(object sender, EventArgs e)
        {
            //_IsHeaderCreated = false;
            //_searchByPageNumber = false;
            //kgtxtPageNumber.Text = "1";
            //_searchByPageNumber = true;
            //lblUserMessage.Visible = false;

            //gibtnNextPage.Enabled = false;
            //gibtnPreviousPage.Enabled = false;
            //kgtxtPageNumber.Enabled = false;

            //lblNoTransactionsFoundMessage.Visible = true;
        }

        void _EditTransaction()
        {

            if (gdgvDebtPaymentTransctions.SelectedRows.Count < 1 || _DebtID == null)
            {
                lblUserMessage.Text = "قم بإختيار معاملة سداد أولا ; لتتمكن من تعديلها";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            int transactionID = Convert.ToInt32(gdgvDebtPaymentTransctions.SelectedRows[0].Cells[0].Value);

            _formDisplayer.OpenAtContainer<frmAddUpdateDebtPayment>(frm =>
            {
                if (!frm.Initialize(transactionID))
                    return false;
                frm.OnCloseAndSaved += FrmAddUpdateDebtPayment_OnCloseAndSaved;
                return true;
            });
        }

        private async void FrmAddUpdateDebtPayment_OnCloseAndSaved(int obj)
        {
            _pageNumber = 1;
            await _LoadDataAtDataGridView();
        }

        void _AddDebtPayment()
        {
            if (_DebtID == null)
            {
                lblUserMessage.Text = "قم بإضافة مستند الدين أولا ; لتتمكن من إضافة معاملة سداد";
                lblUserMessage.Visible = true;
                return;
            }

            if (IsLocked)
            {
                lblUserMessage.Text = "مستند الدين هذا مغلق; لا يمكن إضافة معاملات!";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            _formDisplayer.OpenAtContainer<frmAddUpdateDebtPayment>(frm =>
            {
                if (!frm.Initialize(Convert.ToBoolean(_Debt.IsLending), Convert.ToInt32(_DebtID)))
                    return false;
                frm.OnCloseAndSaved += FrmAddUpdateDebtPayment_OnCloseAndSaved;
                return true;
            });
        }
        void _ShowTransactionInfo()
        {
            if (gdgvDebtPaymentTransctions.SelectedRows.Count < 1 || _DebtID == null)
            {
                lblUserMessage.Text = "قم بإختيار معاملة سداد أولا ; لتتمكن من رؤية معلوماتها";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            int transactionID = Convert.ToInt32(gdgvDebtPaymentTransctions.SelectedRows[0].Cells[0].Value);

            _formDisplayer.OpenAtContainer<frmMainTransactionInfo>(frm =>
            {
                return frm.Initialize(transactionID);
            });
        }
        private async void gibtnNextPage_Click(object sender, EventArgs e)
        {
            if (_DebtID is null || !isInitialized)
                return;
            ++_pageNumber;
            await _LoadDataAtDataGridView();
        }

        private async void gibtnPreviousPage_Click(object sender, EventArgs e)
        {

            if (_DebtID is null || !isInitialized)
                return;
            --_pageNumber;
            await _LoadDataAtDataGridView();
        }

        private void kgtxtPageNumber_TextChanged(object sender, EventArgs e)
        {
            if (_DebtID is null || !isInitialized)
                return;

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

        private void kgtxt_OnValidationError(object sender, KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.CancelEventArgs.Cancel = true;
            errorProvider1.SetError(kgtxt, clsPL_Utils.GetValidationErrorTypeString(e.validationErrorType, kgtxt));
        }

        private void kgtxt_OnValidationSuccess(object sender, CancelEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.Cancel = false;
            errorProvider1.SetError(kgtxt, null);
        }
        private void gbtnAddTransaction_Click(object sender, EventArgs e)
        {
            _AddDebtPayment();
        }

        private void gtsmAddTransactions_Click(object sender, EventArgs e)
        {
            _AddDebtPayment();
        }

        private void gtsmEdit_Click(object sender, EventArgs e)
        {
            _EditTransaction();
        }

        private async void gtsmDelete_Click(object sender, EventArgs e)
        {
            if (_DebtID is null || !isInitialized)
                return;

            if (gdgvDebtPaymentTransctions.SelectedRows.Count < 1 || _DebtID == null || IsLocked)
                return;

            if (_userSession.CurrentUserSettings.AskBeforeDeleteDebtPayments)
                if (_messageBoxService.Display("هل أنت متأكد من رغبتك حذف معاملة السداد هذه ؟ ", "طلب موافقة", MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    return;

            int transactionID = Convert.ToInt32(gdgvDebtPaymentTransctions.SelectedRows[0].Cells[0].Value);

            var result = await _debtPaymentApi.Delete(transactionID, Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || !result.Data)
            {
                _messageBoxService.DisplayError("فشل حذف المعاملة\n" + result.ErrorMessage);
                return;
            }
            _pageNumber = 1;
            await _LoadDataAtDataGridView();
        }
        private void gtsmTransactionInfo_Click(object sender, EventArgs e)
        {
            if (_DebtID is null || !isInitialized)
                return;
            _ShowTransactionInfo();
        }

        private void gdgvTransactions_DoubleClick(object sender, EventArgs e)
        {
            if (_DebtID is null || !isInitialized)
                return;
            _EditTransaction();
        }

        private void gdgvTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value)
            {
                //e.CellStyle.BackColor = Color.LightYellow; // خلفية
                e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.SelectionForeColor = Color.Orange;
            }
        }

        private async void gtsmExportExcel_Click(object sender, EventArgs e)
        {
            if (!_CheckValidationChildren())
                return;

            if (_DebtID is null || !isInitialized)
                return;

            if (gdgvDebtPaymentTransctions.Rows.Count < 1)
            {
                lblUserMessage.Text = "لا يوجد صفوف لتصديرها !";
                lblUserMessage.Visible = true;
                return;
            }

            lblUserMessage.Visible = false;

            var result = await _debtPaymentApi.GetAllForDebt(Convert.ToInt32(_Debt.DebtID), Convert.ToInt32(_userSession.UserID));

            if (!result.IsSuccess || result.Data is null)
            {
                _messageBoxService.DisplayError(result.ErrorMessage);
                return;
            }

            DataTable dt = _dataConverter.ToDataTable<DebtTransactionsExportSummary>(result.Data);

            dt.Columns[nameof(FinTransactionExportSummary.MainTransactionID)].ColumnName = "معرف المعاملة";
            dt.Columns[nameof(FinTransactionExportSummary.Amount)].ColumnName = "المبلغ";
            dt.Columns[nameof(FinTransactionExportSummary.TransactionDate)].ColumnName = "تاريخ المعاملة";
            dt.Columns[nameof(FinTransactionExportSummary.CreatedDate)].ColumnName = "تاريخ الإنشاء";
            dt.Columns[nameof(FinTransactionExportSummary.Purpose)].ColumnName = "البيان";
            dt.Columns[nameof(FinTransactionExportSummary.CreatedByUserID)].ColumnName = "معرف المستخدم المنشئ";
            dt.Columns[nameof(FinTransactionExportSummary.CreatedByUserName)].ColumnName = "اسم المستخدم المنشئ";
            dt.Columns[nameof(FinTransactionExportSummary.AccountID)].ColumnName = "معرف الحساب";

            await _exportWithDialogService.ExportToExcel(dt, $"تقرير معاملات سداد لمستند  [ {_DebtID?.ToString()} ]");
        }

        private async void gibtnRefreshData_Click(object sender, EventArgs e)
        {
            await _LoadDataAtDataGridView();
        }
    }
}
