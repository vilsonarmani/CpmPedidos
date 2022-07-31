using Microsoft.EntityFrameworkCore;
using CpmPedidos.Domain;

namespace CpmPedidos.Repository;

public class ApplicationDbContext : DbContext
{
    public DbSet<Cidade> Cidades { get; set; }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<CategoriaProduto> CategoriasProdutos { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<PromocaoProduto> PromocoesProdutos { get; set; }
    public DbSet<Combo> Combos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }


    //public virtual DbSet<Pedido> Pedidos<get; set;>


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
