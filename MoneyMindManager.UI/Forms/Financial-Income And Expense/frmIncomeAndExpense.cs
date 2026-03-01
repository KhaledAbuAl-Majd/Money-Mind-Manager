using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.Extensions.DependencyInjection;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.Global;
using MoneyMindManager_Presentation.Income_And_Expense.Categories;
using MoneyMindManager_Presentation.Income_And_Expense.Vouchers;


namespace MoneyMindManager_Presentation.Income_And_Expense
{
    public partial class frmIncomeAndExpense : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IUserSession _userSession;

        private bool isInitialized = false;
        public frmIncomeAndExpense(IServiceProvider serviceProvider, IMessageBoxService messageBoxService, IUserSession userSession)
        {
            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }

            this._serviceProvider = serviceProvider;
            this._messageBoxService = messageBoxService;
            this._userSession = userSession;

            InitializeComponent();

        }

        public bool Initilize(enVoucherType voucherType)
        {
            if (voucherType == enVoucherType.UnKnown)
            {
                _messageBoxService.DisplayError("نوع المستند غير معروف !");
                return false;
            }

            this._voucherType = voucherType;
            this.isInitialized = true;
            return true;
        }
        bool _CheckPermissions()
        {
            string errorMessage = "";
            enPermissions permission;

            switch (_voucherType)
            {
                case enVoucherType.Incomes:
                    errorMessage = "ليس لديك صلاحية قائمة مستندات الواردات";
                    permission = enPermissions.IncomeVouchersList;
                    break;

                case enVoucherType.Expenses:
                    errorMessage = "ليس لديك صلاحية قائمة مستندات المصروفات";
                    permission = enPermissions.ExpenseVouchersList;
                    break;

                case enVoucherType.ExpensesReturn:
                    errorMessage = "ليس لديك صلاحية قائمة مستندات مرتجعات المصروفات";
                    permission = enPermissions.ExpenseReturnVouchersList;
                    break;

                default:
                    return false;
            }

            if (_userSession.IsHasPermissions(permission))
            {
                prevButton = gbtnVouchers;
                return true;
            }

            if (_userSession.IsHasPermissions(enPermissions.CategoriesList))
            {
                prevButton = gbtnCategories;
                return true;
            }
            else
            {
                errorMessage += "/قائمة الفئات";
            }

            _messageBoxService.DisplayError(errorMessage);
            return false;
        }

        Guna2Button prevButton;

        enVoucherType _voucherType;

        void ChangeHeaderValue(string txt)
        {
            this.Text = txt;
            lblHeader.Text = txt;
        }


        private bool OpenAtContainer<T>(Func<T, bool> initialize = null) where T : Form
        {
            var frm = _serviceProvider.GetRequiredService<T>();

            if (initialize is null || !initialize.Invoke(frm))
            {
                frm?.Dispose();
                return false;
            }

            return _LoadFormAtPanelContainer(frm);
        }
        bool _LoadFormAtPanelContainer(Form frm)
        {
            if (frm == null)
                return false;

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;


            if (!frm.IsDisposed)
            {
                gpnlFormContainer.Controls.Clear();

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


        private void frmIncomeAndExpense_Load(object sender, EventArgs e)
        {
            if (!isInitialized)
            {
                this.Close();
                return;
            }

            prevButton.PerformClick();
        }

        private void gbtnVouchers_Click(object sender, EventArgs e)
        {
            var loading = OpenAtContainer<frmVouhcersList>(frm =>
            {
                return frm.Initialize(_voucherType);
            });

            if (loading)
            {
                prevButton = gbtnVouchers;

                ciiExepnsesReturn.Visible = false;

                switch (_voucherType)
                {
                    case enVoucherType.Incomes:
                        ChangeHeaderValue("مستندات الإيرادات");
                        break;

                    case enVoucherType.Expenses:
                        ChangeHeaderValue("مستندات المصروفات");
                        break;

                    case enVoucherType.ExpensesReturn:
                        ChangeHeaderValue("مستندات مرتجعات المصروفات");
                        break;
                }

            }
        }

        private void gbtnCategories_Click(object sender, EventArgs e)
        {
            bool isIncome = false;
            string headerText = "";

            switch (_voucherType)
            {
                case enVoucherType.Incomes:
                    ciiExepnsesReturn.Visible = false;
                    headerText = "فئات الإيرادات";
                    isIncome = true;
                    break;

                case enVoucherType.Expenses:
                    ciiExepnsesReturn.Visible = false;
                    headerText = "فئات المصروفات";
                    isIncome = false;
                    break;
                case enVoucherType.ExpensesReturn:
                    ciiExepnsesReturn.Visible = true;
                    headerText = "فئات المصروفات";
                    isIncome = false;
                    break;

            }

            var loading = OpenAtContainer<frmCategoriesList>(frm =>
            {
                return frm.Initialize(isIncome);
            });

            if (loading)
            {
                prevButton = gbtnCategories;
                ChangeHeaderValue(headerText);
            }
        }
    }
}
