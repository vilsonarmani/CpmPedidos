using CpmPedidos.API;
using Microsoft.EntityFrameworkCore;
using CpmPedidos.Repository;
//using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var services = builder.Services;

services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        /// use this connectionstring
        builder.Configuration.GetConnectionString("AppContext"),
        /// todas as configurações de banco de dados está no assembly que o meu contexto está
        /// all the database settings are in the assembly that my context is
        assembly => assembly.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));

});

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
