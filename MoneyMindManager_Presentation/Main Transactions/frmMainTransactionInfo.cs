using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyMindManager_Presentation.Transactions
{
    public partial class frmMainTransactionInfo : Form
    {
        public frmMainTransactionInfo(int transactionID)
        {
            InitializeComponent();
            this._transactionID = transactionID;
        }

        int _transactionID;

        private async void frmMainTransactionInfo_Load(object sender, EventArgs e)
        {
            if (!await this.ctrlMainTransactionInfo1.LoadMainTransaction(_transactionID))
                this.Close();
        }

        private void gbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
