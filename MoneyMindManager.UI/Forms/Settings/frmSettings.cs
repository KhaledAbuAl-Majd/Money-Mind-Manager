using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager.UI.Models;

namespace MoneyMindManager_Presentation
{
    public partial class frmSettings : Form
    {
        private readonly IUserSession _userSession;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IUserSettingsService _userSettingsService;
        enum enMode { UpdatAble, ReadOnly };
        enMode _Mode = enMode.ReadOnly;
        public frmSettings(IUserSession userSession,IMessageBoxService messageBoxService, IUserSettingsService userSettingsService) 
        {
            InitializeComponent();
            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._userSettingsService = userSettingsService;
        }

        private UserSettings _Settings;

        async Task _Save()
        {
            if (!gbtnSave.Enabled)
                return;

            gbtnSave.Enabled = false;

            _Settings.AskBeforeDeletePerson = gtswAskBeforeDeletePerson.Checked;

            _Settings.AskBeforeDeleteUser = gtswAskBeforeDeleteUser.Checked;

            _Settings.AskBeforeDeleteIncomeVoucher = gtswAskBeforeDeleteIncomeVoucher.Checked;
            _Settings.AskBeforeDeleteIncomeTransactions = gtswAskBeforeDeleteIncomeTransactions.Checked;
            _Settings.Income_TodayAsDefaultDate = gtswIncome_TodayAsDefaultDate.Checked;
            _Settings.IncomeTransaction_AutoAddNewDefault = gtswIncomeTransaction_AutoAddNewDefault.Checked;

            _Settings.AskBeforeDeleteExpenseVoucher = gtswAskBeforeDeleteExpenseVoucher.Checked;
            _Settings.AskBeforeDeleteExpenseTransactions = gtswAskBeforeDeleteExpenseTransactions.Checked;
            _Settings.Expense_TodayAsDefaultDate = gtswExpense_TodayAsDefaultDate.Checked;
            _Settings.ExpenseTransaction_AutoAddNewDefault = gtswExpenseTransaction_AutoAddNewDefault.Checked;

            _Settings.AskBeforeDeleteExpenseReturnVoucher = gtswAskBeforeDeleteExpenseReturnVoucher.Checked;
            _Settings.AskBeforeDeleteExpenseReturnTransactions = gtswAskBeforeDeleteExpenseReturnTransactions.Checked;
            _Settings.ExpenseReturn_TodayAsDefaultDate = gtswExpenseReturn_TodayAsDefaultDate.Checked;
            _Settings.ExpenseReturnTransaction_AutoAddNewDefault = gtswExpenseReturnTransaction_AutoAddNewDefault.Checked;

            _Settings.AskBeforeDeleteDebts = gtswAskBeforeDeleteDebts.Checked;
            _Settings.AskBeforeDeleteDebtPayments = gtswAskBeforeDeleteDebtPayments.Checked;
            _Settings.Debts_TodayAsDefaultDate = gtswDebts_TodayAsDefaultDate.Checked;
            _Settings.DebtPayments_TodayAsDefaultDate = gtswDebtPayments_TodayAsDefaultDate.Checked;
            _Settings.DebtPayment_AutoAddNewDefault = gtswDebtPayment_AutoAddNewDefault.Checked;

            _Settings.AskBeforeDeleteCategory = gtswAskBeforeDeleteCategory.Checked;

            if (await _userSettingsService.Save(_Settings))
            {
                _userSession.RefreshSettings(_Settings);
                _messageBoxService.Display("تم حفظ الإعدادات بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void _LoadSettings()
        {
            gtswAskBeforeDeletePerson.Checked = _Settings.AskBeforeDeletePerson;

            gtswAskBeforeDeleteUser.Checked = _Settings.AskBeforeDeleteUser;

            gtswAskBeforeDeleteIncomeVoucher.Checked = _Settings.AskBeforeDeleteIncomeVoucher;
            gtswAskBeforeDeleteIncomeTransactions.Checked = _Settings.AskBeforeDeleteIncomeTransactions;
            gtswIncome_TodayAsDefaultDate.Checked = _Settings.Income_TodayAsDefaultDate;
            gtswIncomeTransaction_AutoAddNewDefault.Checked = _Settings.IncomeTransaction_AutoAddNewDefault;

            gtswAskBeforeDeleteExpenseVoucher.Checked = _Settings.AskBeforeDeleteExpenseVoucher;
            gtswAskBeforeDeleteExpenseTransactions.Checked = _Settings.AskBeforeDeleteExpenseTransactions;
            gtswExpense_TodayAsDefaultDate.Checked = _Settings.Expense_TodayAsDefaultDate;
            gtswExpenseTransaction_AutoAddNewDefault.Checked = _Settings.ExpenseTransaction_AutoAddNewDefault;

            gtswAskBeforeDeleteExpenseReturnVoucher.Checked = _Settings.AskBeforeDeleteExpenseReturnVoucher;
            gtswAskBeforeDeleteExpenseReturnTransactions.Checked = _Settings.AskBeforeDeleteExpenseReturnTransactions;
            gtswExpenseReturn_TodayAsDefaultDate.Checked = _Settings.ExpenseReturn_TodayAsDefaultDate;
            gtswExpenseReturnTransaction_AutoAddNewDefault.Checked = _Settings.ExpenseReturnTransaction_AutoAddNewDefault;

            gtswAskBeforeDeleteDebts.Checked = _Settings.AskBeforeDeleteDebts;
            gtswAskBeforeDeleteDebtPayments.Checked = _Settings.AskBeforeDeleteDebtPayments;
            gtswDebts_TodayAsDefaultDate.Checked = _Settings.Debts_TodayAsDefaultDate;
            gtswDebtPayments_TodayAsDefaultDate.Checked = _Settings.DebtPayments_TodayAsDefaultDate;
            gtswDebtPayment_AutoAddNewDefault.Checked = _Settings.DebtPayment_AutoAddNewDefault;

            gtswAskBeforeDeleteCategory.Checked = _Settings.AskBeforeDeleteCategory;
        }
        private void frmSettings_Load(object sender, EventArgs e)
        {
            if (_userSession.CurrentUserSettings == null)
            {
                this.Close();
                return;
            }

            this._Settings = _userSettingsService.Clone(_userSession.CurrentUserSettings);

            _LoadSettings();
        }

        private async void gbtnSave_Click(object sender, EventArgs e)
        {
            await _Save();
            gbtnSave.Enabled = true;
        }

        private void gbtnResetSettings_Click(object sender, EventArgs e)
        {
            _Settings = _userSettingsService.GetDefault(_Settings.UserID);
            _LoadSettings();
        }
    }
}
