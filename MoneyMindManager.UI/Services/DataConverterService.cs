using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MoneyMindManager.UI.Abstractions;

namespace MoneyMindManager.UI.Services
{
    public class DataConverterService : IDataConverter
    {
        public DataTable ToDataTable<T>(IEnumerable<T> data)
        {
            if (data is null)
                return null;

            DataTable dt = new DataTable();

            var proprties = typeof(T).GetProperties();

            foreach (var property in proprties)
            {
                dt.Columns.Add(property.Name, property.PropertyType);
            }

            foreach (var item in data)
            {
                var dr = dt.NewRow();
                foreach (var propery in proprties)
                {
                    dr[propery.Name] = propery.GetValue(item);
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }
    }
}
