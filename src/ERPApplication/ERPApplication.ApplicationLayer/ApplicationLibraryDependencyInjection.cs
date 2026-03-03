using ERPApplication.ApplicationLayer.Mapper;
using ERPApplication.ApplicationLayer.Services;
using ERPApplication.InfrastructureLayer.Data;
using ERPApplication.InfrastructureLayer.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer
{
    public static class ApplicationLibraryDependencyInjection
    {
        public static IServiceCollection AddServicesApplication(this IServiceCollection services)
        {
            services.AddScoped<EmployeeService>();
            services.AddScoped<TicketMapper>();
            services.AddScoped<TicketService>();
            services.AddScoped<OTPMapper>();
            services.AddScoped<EmployeeMapper>();
            services.AddScoped<RoleMapper>();
            services.AddScoped<AllocatedTicketMapper>();
            services.AddScoped<OTPService>();

            return services;
        }
    }
}
