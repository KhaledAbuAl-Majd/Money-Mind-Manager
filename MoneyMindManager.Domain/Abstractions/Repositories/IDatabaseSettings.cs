using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManager.Domain.Abstractions
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; }
    }
}
