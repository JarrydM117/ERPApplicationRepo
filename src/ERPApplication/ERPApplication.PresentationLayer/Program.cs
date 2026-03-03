using ERPApplication.ApplicationLayer;
using ERPApplication.InfrastructureLayer.Data;
using ERPApplication.InfrastructureLayer;
using Microsoft.EntityFrameworkCore;
using ERPApplication.PresentationLayer.Middleware;
using ERPApplication.InfrastructureLayer.ExternalServices.Email.EmailServices;
using ERPApplication.InfrastructureLayer.ExternalServices.Email.Factories;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<ERPDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetValue<string>("connection_string"));
});
builder.Configuration.AddUserSecrets<IMailboxFactory>();
builder.Configuration.AddUserSecrets<IEmailService>();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddServicesApplication();
builder.Services.AddServicesInfrastructure();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();


var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.MapControllers();
app.UseExceptionHandler(o=> { });

app.Run();
