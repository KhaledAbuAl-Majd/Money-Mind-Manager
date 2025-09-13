using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using static MoneyMindManagerGlobal.clsDataColumns.clsTransactionTypeClasses;

namespace MoneyMindManager_Business
{
    public class clsTransactionType : clsTransactionTypeColumns
    {
        private clsTransactionType(byte transactionTypeID,string transactionName):base(transactionTypeID,transactionName)
        {

        }

        public static async Task<clsTransactionType> FindTransactionTypeByTransactionTypeID(byte transactionTypeID)
        {
            var TransactionTypeColumns = await clsTransactionTypeData.GetTransactionTypeInfoByID(transactionTypeID);

            if (TransactionTypeColumns == null)
                return null;

            return new clsTransactionType(transactionTypeID, TransactionTypeColumns.TransactionTypeName);
        }
        public static async Task<clsTransactionType> FindTransactionTypeByTransactionTypeName(string transactionTypeName)
        {
            var TransactionTypeColumns = await clsTransactionTypeData.GetTransactionTypeInfoByTransactionTypeName(transactionTypeName);

            if (TransactionTypeColumns == null)
                return null;

            return new clsTransactionType(TransactionTypeColumns.TransactionTypeID , transactionTypeName);
        }

      
    }
}
