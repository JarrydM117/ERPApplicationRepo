using ERPApplication.ApplicationLayer;
using ERPApplication.InfrastructureLayer.Data;
using ERPApplication.InfrastructureLayer;
using ERPApplication.InfrastructureLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ERPApplication.PresentationLayer.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<ERPDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetValue<string>("connection_string"));
});
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
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
