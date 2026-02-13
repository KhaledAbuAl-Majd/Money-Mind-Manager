using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MoneyMindManager.APIClient.Api_Client_Implementation;
using MoneyMindManager.Client.Abstractions.ApiClient;

namespace MoneyMindManager.APIClient.DependencyInjection
{
    public static class ApiClientRegistration
    {
        public static IServiceCollection AddApiClient(this IServiceCollection services)
        {
            services.AddScoped<ICurrencyApiClient, CurrencyApiClient>();
            return services;
        }
    }
}
