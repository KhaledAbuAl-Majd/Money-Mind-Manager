using System;
using MoneyMindManager.Core.Abstractions;

namespace MoneyMindManager.Infrastructure.General_Services.Utils
{
    public class FormateHelper : IFormateHelper
    {
        public DateTime? TryConvertToDateTime(string dateString)
        {
            if (!string.IsNullOrWhiteSpace(dateString) && DateTime.TryParse(dateString, out DateTime result))
                return result;

            return null;
        }
    }
}
