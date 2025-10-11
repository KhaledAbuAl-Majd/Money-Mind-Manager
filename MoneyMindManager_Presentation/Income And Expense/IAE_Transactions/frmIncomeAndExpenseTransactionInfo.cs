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

namespace MoneyMindManager_Presentation.Transactions
{
    public partial class frmIncomeAndExpenseTransactionInfo : Form
    {
        public frmIncomeAndExpenseTransactionInfo(int transactionID)
        {
            InitializeComponent();
            this._transactionID = transactionID;
        }

        int _transactionID;

        clsIncomeAndExpenseTransaction _IAETransactionInfo;

        private async void frmMainTransactionInfo_Load(object sender, EventArgs e)
        {
            _IAETransactionInfo = await clsIncomeAndExpenseTransaction.FindTransactionByTransactionID(_transactionID, Convert.ToInt32(clsGlobal_UI.CurrentUser.UserID));

            if (_IAETransactionInfo == null)
                this.Close();

            if (!ctrlMainTransactionInfo1.LoadMainTransaction((clsMainTransaction)_IAETransactionInfo))
                this.Close();

            this.kgtxtCategoryName.Text = _IAETransactionInfo.CategoryInfo?.CategoryName;
        }

        private void gbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
