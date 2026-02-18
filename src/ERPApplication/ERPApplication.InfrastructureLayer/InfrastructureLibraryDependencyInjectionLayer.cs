using ERPApplication.InfrastructureLayer.Data;
using ERPApplication.InfrastructureLayer.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.InfrastructureLayer
{
    public static class InfrastructureLibraryDependencyInjectionLayer
    {

        public static IServiceCollection AddServicesInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<TicketRepository>();
            services.AddScoped<ERPDataContext>();
            services.AddScoped<EmployeeRepository>();
            return services;
        }
    }
}
