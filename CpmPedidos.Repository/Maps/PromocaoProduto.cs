using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository;

public class PromocaoProdutoMap : BaseDomainMap<PromocaoProduto>
{
    public PromocaoProdutoMap(): base("tb_promocao_produto") { }

    public override void Configure(EntityTypeBuilder<PromocaoProduto> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Preco).HasColumnName("preco").HasPrecision(17,2).IsRequired();

        builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();


    }
}
