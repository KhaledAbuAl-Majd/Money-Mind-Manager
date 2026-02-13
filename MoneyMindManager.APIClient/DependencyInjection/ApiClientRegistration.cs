using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MoneyMindManager.APIClient.DependencyInjection
{
    public static class ApiClientRegistration
    {
        public static IServiceCollection AddApiClient(this IServiceCollection services)
        {
            return services;
        }
    }
}
