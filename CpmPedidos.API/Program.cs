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
        /// todas as configura��es de banco de dados est� no assembly que o meu contexto est�
        /// all the database settings are in the assembly that my context is
        assembly => assembly.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));

});

/// gest�o das classes e das interfaces de forma isolada
/// management of the classes and the interfaces in isolation
/// e.g: services.AddScoped<IFoo, Foo>();
DependencyInjection.Register(services);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
