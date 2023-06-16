using ElectronicLibrary.DAO;
using ElectronicLibrary.DAO.Context;
using ElectronicLibrary.DAO.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
services.AddScoped<IBookRepository, BookRepository>();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Library", Version = "v1" });
});

services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var host = builder.Configuration["DB_SERVER"] ?? "localhost";
var port = builder.Configuration["DB_PORT"] ?? "5433";
var user = builder.Configuration["DB_USER"] ?? "postgres";
var password = builder.Configuration["DB_PASSWORD"] ?? "asupersecretpassword";
var database = builder.Configuration["SERVICE_NAME"] ?? "Library02";

services.AddDbContext<LibraryContext>(options =>
{
    options.EnableSensitiveDataLogging();
    options.UseNpgsql(
       $"Host={host}; Port={port}; Database={database}; Username={user}; Password={password}",

       npgsqlOptionsAction: sqlOptions =>
       {
           sqlOptions.MigrationsAssembly(typeof(LibraryContext).Assembly.FullName);
       });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    await DataInitiallizer.InitializeAsync(scope.ServiceProvider);
}

app.MapControllers();

app.Run();