using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManagerGlobal
{
    public static  class clsFormat
    {
        /// <summary>
        /// try convert dateString to DateTime
        /// <returns>if success return Converted DateTime, else return null</returns>
        public static DateTime? TryConvertToDateTime(string dateString)
        {
            if (!string.IsNullOrWhiteSpace(dateString) && DateTime.TryParse(dateString, out DateTime result))
                return result;

            return null;
        }
    }
}
