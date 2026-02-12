using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager.Domain.Abstractions;
using System.Configuration;


namespace MoneyMindManager.Infrastructure.Repositories.SQLServer
{
    public class SQLDatabaseSettings:IDatabaseSettings
    {
        public string ConnectionString { get; } = ConfigurationManager.ConnectionStrings["MoneyMindManagerConnectionString"].ConnectionString;
    }
}
