using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MoneyMindManager.UI.DependencyInjection
{
    public static class UIRegistrationDI
    {
        public static IServiceCollection AddUI(this IServiceCollection services)
        {
            return services;
        }
    }
}
