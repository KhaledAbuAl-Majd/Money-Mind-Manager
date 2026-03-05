using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManager.Application.Abstractions.Handlers
{
    public interface IResultFactory
    {
        IResultHandler<T> Create<T>();
    }
}
