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
using MoneyMindManager_Presentation.Users;

namespace MoneyMindManager_Presentation.Transactions.Controls
{
    public partial class ctrlMainTransactionInfo : UserControl
    {
        public ctrlMainTransactionInfo()
        {
            InitializeComponent();
        }

        public clsMainTransaction MainTransaction { get; private set; }
        public async Task<bool> LoadMainTransaction(int transactionID)
        {

            MainTransaction = await clsMainTransaction.FindMainTransactionInfoByID(transactionID);

            if (MainTransaction == null)
            {
                ResetControls();
                return false;
            }

            _ShowData();

            return true;
        }

        public bool  LoadMainTransaction(clsMainTransaction _mainTransaction)
        {
            MainTransaction = _mainTransaction;

            if (MainTransaction == null)
            {
                ResetControls();
                return false;
            }

            _ShowData();

            return true;
        }

        void _ShowData()
        {
            kgtxtTransactionID.Text = MainTransaction?.MainTransactionID?.ToString();
            kgtxtAmount.RefreshNumber_DateTimeFormattedText(MainTransaction?.Amount.ToString());
            kgtxtTransactionDate.RefreshNumber_DateTimeFormattedText(MainTransaction?.TransactionDate.ToString());
            kgtxtCreatedDate.RefreshNumber_DateTimeFormattedText(MainTransaction?.CreatedDate.ToString());
            kgtxtCreatedByUserName.RefreshNumber_DateTimeFormattedText(MainTransaction?.CreatedByUserInfo?.UserName.ToString());
            kgtxtTransactionType.RefreshNumber_DateTimeFormattedText(MainTransaction?.TransactionTypeInfo?.TransactionTypeName.ToString());
            kgtxtPurpose.Text = MainTransaction?.Purpose?.ToString();
        }

        /// <summary>
        /// Reset Controls With Start Value
        /// </summary>
        public void ResetControls()
        {
            MainTransaction = null;

            kgtxtTransactionID.Text = null;
            kgtxtAmount.Text = null;
            kgtxtTransactionDate.Text = null;
            kgtxtCreatedDate.Text = null;
            kgtxtCreatedByUserName.Text = null;
            kgtxtTransactionType.Text = null;
            kgtxtPurpose.Text = null;
        }

        private void kgtxtCreatedByUserName_IconRightClick(object sender, EventArgs e)
        {
            if (MainTransaction == null)
                return;

            frmUserInfo frm = new frmUserInfo(Convert.ToInt32(MainTransaction?.CreatedByUserID));
            clsGlobal_UI.MainForm.AddNewFormAtContainer(frm);
        }
    }
}
