using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Repository;

public class ApplicationDbContext : DbContext
{
    protected ApplicationDbContext()
    {
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        /// similar use services.Addscoped........
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
