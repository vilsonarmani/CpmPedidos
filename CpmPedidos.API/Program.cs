using CpmPedidos.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var services = builder.Services;

/// gestão das classes e das interfaces de forma isolada
/// management of the classes and the interfaces in isolation
/// e.g: services.AddScoped<IFoo, Foo>();
DependencyInjection.Register(services);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
