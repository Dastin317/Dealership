using DealershipManager.Interfaces;
using DealershipManager.Repositories;
using DealershipManager.Services;
using Microsoft.OpenApi.Models;
using SecondHandDealership.Interfaces;
using SecondHandDealership.Middleware;
using SecondHandDealership.Repositories;
using SecondHandDealership.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddScoped<ExceptionHandlingMiddleware>();

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarRepository, InMemoryCarRepository>();
builder.Services.AddScoped<ICarValidator, CarValidator>();

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository, InMemoryClientRepository>();
builder.Services.AddScoped<IClientValidator, ClientValidator>();

builder.Services.AddScoped<ISaleRepository, InMemorySaleRepository>();
builder.Services.AddScoped<ISaleService, SaleService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dealership API", Version = "v0.1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline. // middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V0.1");
        c.RoutePrefix = string.Empty; // Open Swagger UI at app root
    });
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

// This opens the default browser when the application starts in Development mode
if (builder.Environment.IsDevelopment())
{
    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
    {
        FileName = "http://localhost:5000",
        UseShellExecute = true
    });
}