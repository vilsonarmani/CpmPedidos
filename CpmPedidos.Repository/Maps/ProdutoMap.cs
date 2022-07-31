using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository;

public class ProdutoMap : BaseDomainMap<Produto>
{
    public ProdutoMap(): base("tb_produto") { }

    public override void Configure(EntityTypeBuilder<Produto> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Codigo).HasColumnName("codigo").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Descricao).HasColumnName("descricao").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Preco).HasColumnName("preco").HasPrecision(17, 2).IsRequired();

        builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();

        //1:N
        builder.Property(x => x.IdCategoria).HasColumnName("id_categoria").IsRequired();
        builder.HasOne(x => x.Categoria).WithMany(x => x.Produtos).HasForeignKey(x => x.IdCategoria);

    }
}
