using System;

namespace MoneyMindManager.Core.Abstractions
{
    public interface IFormateHelper
    {
        DateTime? TryConvertToDateTime(string dateString);
    }
}
