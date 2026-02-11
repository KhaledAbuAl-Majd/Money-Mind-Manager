using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Wordprocessing;
using KhaledControlLibrary1;
using MoneyMindManager_Business;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Users;
using MoneyMindManagerGlobal;

namespace MoneyMindManager_Presentation
{
    public partial class frmSettings : Form
    {
        enum enMode { UpdatAble, ReadOnly };
        enMode _Mode = enMode.ReadOnly;
        public frmSettings()
        {
            InitializeComponent();
        }

        private clsUserSettings _Settings;

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

            if (await _Settings.Save())
            {
                clsPL_Global.CurrentUserSettings.AssingNewSettings(_Settings);
                clsPL_MessageBoxs.ShowMessage("تم حفظ الإعدادات بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (clsPL_Global.CurrentUserSettings == null)
            {
                this.Close();
                return;
            }

            this._Settings = clsPL_Global.CurrentUserSettings.Clone();

            _LoadSettings();
        }

        private async void gbtnSave_Click(object sender, EventArgs e)
        {
            await _Save();
            gbtnSave.Enabled = true;
        }

        private void gbtnResetSettings_Click(object sender, EventArgs e)
        {
            _Settings.ResetSettings();
            _LoadSettings();
        }
    }
}
