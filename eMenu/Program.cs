using eMenu.Repository;
using eMenu.Entities;
using eMenu.Services;
using eMenu.AppConfiguration;
using eMenu.AppConfiguration.ServicesExtensions;
using eMenu.AppConfiguration.ApplicationExtensions;
using Serilog;
using Microsoft.EntityFrameworkCore;

var configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", optional: false)
.Build();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddSerilogConfiguration();
builder.Services.AddDbContextConfiguration(configuration);
builder.Services.AddVersioningConfiguration();
builder.Services.AddMapperConfiguration(); //presentation profile mapper
builder.Services.AddControllers();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddRepositoryConfiguration(); // DI for repository layer
builder.Services.AddBusinessLogicConfiguration(); //DI for services layer
//builder.Services.AddAuthorizationConfiguration(configuration); //1

builder.Services.AddScoped<DbContext, Context>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

app.UseSerilogConfiguration(); //use serilog

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration(); //use swagger
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

try
{
    Log.Information("Application starting...");

    app.Run();
}
catch (Exception ex)
{
    Log.Error("Application finished with error {error}", ex);
}
finally
{
    Log.Information("Application stopped");
    Log.CloseAndFlush();
}
