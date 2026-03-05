using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManager.Core.Abstractions
{
    public interface IResult<T>
    {
        bool IsSuccess { get; }
        T Data { get; }
        string ErrorMessage { get; }
    }   
}
