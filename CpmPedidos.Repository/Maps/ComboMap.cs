using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository;

public class ComboMap : BaseDomainMap<Combo>
{
    public ComboMap(): base("tb_combo") { }

    public override void Configure(EntityTypeBuilder<Combo> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Preco).HasColumnName("preco").HasPrecision(17, 2).IsRequired();

        builder.Property(x => x.Ativo).HasColumnName("ativo").HasMaxLength(50).IsRequired();

        //1:N
        builder.Property(x => x.IdImagem).HasColumnName("id_imagem").IsRequired();
        builder.HasOne(x => x.Imagem).WithMany().HasForeignKey(x => x.IdImagem);

        builder
            .HasMany(x => x.Produtos)
            .WithMany(x => x.Combos)
            .UsingEntity<ProdutoCombo>( //keys and table contents
                x => x.HasOne(produtoCombo => produtoCombo.Produto).WithMany().HasForeignKey(produtoCombo => produtoCombo.IdProduto), 
                x => x.HasOne(produtoCombo => produtoCombo.Combo).WithMany().HasForeignKey(produtoCombo => produtoCombo.IdCombo),
                x => //table definition
                {
                    x.ToTable("tb_produto_combo");

                    x.HasKey(produtoCombo => new { produtoCombo.IdProduto, produtoCombo.IdCombo }); // creating a composite key

                    x.Property(produtoCombo => produtoCombo.IdProduto).HasColumnName("id_produto").IsRequired();
                    x.Property(x => x.IdCombo).HasColumnName("id_combo").IsRequired();
                }
            );
    }
}
