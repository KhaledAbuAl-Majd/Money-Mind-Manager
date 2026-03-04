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
                var propertyType = property.PropertyType;

                if(propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    propertyType = Nullable.GetUnderlyingType(propertyType);
                }

                dt.Columns.Add(property.Name,propertyType);
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
