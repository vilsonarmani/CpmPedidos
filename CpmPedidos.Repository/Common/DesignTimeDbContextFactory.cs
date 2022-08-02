using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CpmPedidos.Repository;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        //we create this class because we're using different projects
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT ");

        var filename = Directory.GetCurrentDirectory() + $"/../CpmPedidos.API/appsettings{environmentName}.json";

        var configuration = new ConfigurationBuilder().AddJsonFile(filename).Build();
        var connectionstring = configuration.GetConnectionString("AppContext");
        
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        
        builder.UseSqlServer(connectionstring);
        return new ApplicationDbContext(builder.Options);

    }
}
