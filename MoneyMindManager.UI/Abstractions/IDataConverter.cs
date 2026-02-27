using System.Collections.Generic;
using System.Data;

namespace MoneyMindManager.UI.Abstractions
{
    public interface IDataConverter
    {
        DataTable ToDataTable<T>(IEnumerable<T> data);
    }
}
