using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.Extensions.DependencyInjection;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Shared.DTOs.User;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Income_And_Expense;
using MoneyMindManager_Presentation.Income_And_Expense.Vouchers;
using MoneyMindManager_Presentation.OverView;
using MoneyMindManager_Presentation.People;
using MoneyMindManager_Presentation.Users;


namespace MoneyMindManager_Presentation.Main
{
    public partial class frmMain : Form, IFormDisplayer
    {
        public event Action OnCloseProgramm;

        private readonly IServiceProvider _serviceProvider;
        private readonly IUserSession _userSession;

        private bool isInitialized = false;
        public frmMain(IServiceProvider serviceProvider, IUserSession userSession)
        {
            InitializeComponent();
            this._serviceProvider = serviceProvider;
            this._userSession = userSession;
        }

        Guna2Button prevButton;
        private void LoadMainFormLabels()
        {
            lblCurrentUserName.Text = _userSession.CurrentUser?.UserName;
        }



        UserDTO user;
        public bool Initialize(UserDTO userDTO)
        {
            this.user = userDTO;
            this.isInitialized = true;
            return true;
        }

        public bool OpenDialog<T>(Func<T, bool> initialize = null) where T : Form
        {
            var frm = _serviceProvider.GetRequiredService<T>();

            if (initialize is null || !initialize.Invoke(frm))
            {
                frm?.Dispose();
                return false;
            }

            frm.ShowDialog(this);
            return true;
        }

        public bool OpenAtContainer<T>(Func<T, bool> initialize = null) where T : Form
        {
            return OpenAtContainer<T>(initialize, false);
        }

        private bool OpenAtContainer<T>(Func<T, bool> initialize = null, bool clearOldControls = false) where T : Form
        {
            var frm = _serviceProvider.GetRequiredService<T>();

            if (initialize is null || !initialize.Invoke(frm))
            {
                frm?.Dispose();
                return false;
            }

            return _LoadFormAtPanelContainer(frm, clearOldControls);
        }

        bool _LoadFormAtPanelContainer(Form frm, bool clearOldControls)
        {
            if (frm == null)
                return false;

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            if (!frm.IsDisposed)
            {
                if (clearOldControls)
                {
                    gpnlFormContainer.Controls.Clear();
                }
                gpnlFormContainer.Controls.Add(frm);

                frm.Show();
                frm.BringToFront();
            }
            else
            {
                if (prevButton != null)
                {
                    prevButton.Checked = true;
                    prevButton.Focus();
                }

                return false;
            }

            return true;
        }


        private async void frmMain_Load(object sender, EventArgs e)
        {
            if (!isInitialized)
            {
                this.Close();
                return;
            }

            if (!await _userSession.StartSession(user))
            {
                this.Close();
                return;
            }

            _userSession.OnSessionExpired += () =>
            {
                this.Close();
                return;
            };

            LoadMainFormLabels();

            prevButton = null;

            _userSession.OnUserRefreshed += LoadMainFormLabels;

            prevButton = gbtnAccount;
            gbtnAccount.PerformClick();
        }

        private void llblCurrentUserInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llblCurrentUserInfo.Enabled = false;

            OpenAtContainer<frmUserInfo>((frm) =>
            {
                if (!frm.Initialize(Convert.ToInt32(_userSession.UserID)))
                    return false;

                frm.FormClosed += (x, y) => llblCurrentUserInfo.Enabled = true;
                return true;
            });
        }

        private void llblChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llblChangePassword.Enabled = false;

            OpenAtContainer<frmChangePassword>((frm) =>
            {
                if (!frm.Initialize(Convert.ToInt32(_userSession.UserID)))
                    return false;

                frm.FormClosed += (x, y) => llblChangePassword.Enabled = true;
                return true;
            });
        }

        private void gbtnOverOview_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();

            var result = OpenAtContainer<frmOverView>(frm =>
            {
                return true;
            }, true);

            if (result)
                prevButton = gbtnOverOview;
        }
        private void gbtnPeople_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();

            var result = OpenAtContainer<frmPeople>(frm =>
            {
                return true;
            }, true);

            if (result)
                prevButton = gbtnPeople;
        }

        private void gbtnUsers_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();

            var result = OpenAtContainer<FrmUsers>(frm =>
            {
                return true;
            }, true);

            if (result)
                prevButton = gbtnUsers;
        }


        private void gbtnIncome_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();

            var result = OpenAtContainer<frmIncomeAndExpense>(frm =>
            {
                return frm.Initialize(enVoucherType.Incomes);
            }, true);

            if (result)
                prevButton = gbtnIncome;
        }

        private void gbtnExpense_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();

            var result = OpenAtContainer<frmIncomeAndExpense>(frm =>
            {
                return frm.Initialize(enVoucherType.Expenses);
            }, true);

            if (result)
                prevButton = gbtnExpense;
        }

        private void gbtnExpensesReturn_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();

            var result = OpenAtContainer<frmIncomeAndExpense>(frm =>
            {
                return frm.Initialize(enVoucherType.ExpensesReturn);
            }, true);

            if (result)
                prevButton = gbtnExpensesReturn;
        }

        private void gbtnDebts_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();
            var result = OpenAtContainer<frmDebtsList>(frm =>
            {
                return true;
            }, true);

            if (result)
                prevButton = gbtnDebts;
        }

        private void gbtnTransactions_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();

            var result = OpenAtContainer<frmMainTransactionsList>(frm =>
            {
                return true;
            }, true);
            if (result)
                prevButton = gbtnTransactions;
        }

        private void gbtnAccount_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();
            var result = OpenAtContainer<frmCurrentAccount>(frm =>
            {
                return true;
            }, true);

            if (result)
                prevButton = gbtnAccount;
        }

        private void gbtnSettings_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();
            var result = OpenAtContainer<frmSettings>(frm =>
            {
                return true;
            }, true);

            if (result)
                prevButton = gbtnSettings;
        }

        private void gbtnAboutProgramm_Click(object sender, EventArgs e)
        {
            ((Guna2Button)sender).Focus();

            var result = OpenAtContainer<frmAboutProgramm>(frm =>
            {
                return true;
            }, true);

            if (result)
                prevButton = gbtnAboutProgramm;
        }

        private void gbtnLogout_Click(object sender, EventArgs e)
        {
            _userSession.ClearSession();
        }


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_userSession.CurrentUser != null)
                OnCloseProgramm?.Invoke();
        }
    }
}
