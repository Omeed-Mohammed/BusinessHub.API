using BusinessHub.Contracts.Persons.Interfaces;
using BusinessHub.Infrastructure.Persons.Repositories;
using BusinessHub.Middlewares;
using BusinessHub.Modules.Persons.Services;
using BusinessHub.Validators.Persons;
using FluentValidation;



var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(PersonService).Assembly;


var cs = builder.Configuration.GetConnectionString("DefaultConnection");



builder.Services.Scan(scan => scan
    .FromAssemblies(assembly)
    .AddClasses(c => c.Where(t => t.Name.EndsWith("Service")))
        .AsSelf()
        .WithScopedLifetime());

builder.Services.Scan(scan => scan
    .FromAssemblies(typeof(PersonRepository).Assembly)
    .AddClasses(c => c.Where(t => t.Name.EndsWith("Repository")))
        .AsImplementedInterfaces()
        .WithScopedLifetime());


// Registers all FluentValidation validators from the specified assembly
// This enables automatic validation for incoming RequestDTOs during model binding

builder.Services.AddValidatorsFromAssemblyContaining<PersonValidator>();






// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Global Exception Middleware
// Catches all unhandled exceptions across the application (Controller, Service, DAL)
// Prevents application crashes and returns a consistent JSON error response
// Eliminates the need for try/catch blocks in controllers and services

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
