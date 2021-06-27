using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BD;
using WBL;

namespace WebApplicationCore
{
    public static class ContainerExtensions
    {

        public static IServiceCollection AddDIContainer(this IServiceCollection services)
        {

            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddTransient<ITituloService, TituloService>();
            services.AddTransient<IDepartamentoService, DepartamentoService>();
            services.AddTransient<IPuestoService, PuestoService>();


            return services;
        }
    }
}
