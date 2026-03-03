using ERPApplication.InfrastructureLayer.Data;
using ERPApplication.InfrastructureLayer.ExternalServices.Email.EmailServices;
using ERPApplication.InfrastructureLayer.ExternalServices.Email.Factories;
using ERPApplication.InfrastructureLayer.ExternalServices.Email.Factory;
using ERPApplication.InfrastructureLayer.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.UI.Services;
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
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<RecipientFactory>();
            services.AddScoped<OTPRepository>();
            services.AddScoped<OTPMailBox>();
            services.AddScoped<IMailboxFactory, OTPMailBox>();
            services.AddScoped<IMailboxFactory, NoticiationMailBox>();
            return services;
        }
    }
}
