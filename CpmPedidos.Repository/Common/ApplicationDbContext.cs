using Microsoft.EntityFrameworkCore;
using CpmPedidos.Domain;
using System.Diagnostics;

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


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(message => Debug.WriteLine(message)) ;
    }


    protected ApplicationDbContext()
    {
        /// when set AutoDetectChangesEnabled to false the EF does not change the state of the dataset. We have to do this manually.
        /// This causes an increase in performance and implies the need to use the "Update" method because the DbContext does not detect the state change.
        /// see CidadeRepository on "Alterar" Method
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
