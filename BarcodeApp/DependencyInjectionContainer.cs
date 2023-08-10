using BarcodeApp.Data;
using BarcodeApp.Service.CheckNumbers;
using BarcodeApp.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeApp
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<IFromXLSX, FromXLSX>();
            services.AddSingleton<ICheckNumbers, CheckNumbers>();
            return services;
        }

        public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        {
            services.AddTransient<BarcodeViewModel>();
            return services;
        }
    }
}