using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManager.Domain.Entities.FinTransaction
{
    public class FinTransactionShort
    {
        public int? TransactionID { get; set; }
        public int? VoucherID { get; set; }
        public int? CategoryID { get; set; }

        public FinTransactionShort(int transactionID, int voucherID, int categoryID) 
        {
            this.VoucherID = voucherID;
            this.CategoryID = categoryID;
        }
    }
}
