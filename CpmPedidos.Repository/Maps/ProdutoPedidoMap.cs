using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository;

public class ProdutoPedidoMap : BaseDomainMap<ProdutoPedido>
{
    public ProdutoPedidoMap(): base("tb_produto_pedido") { }

    public override void Configure(EntityTypeBuilder<ProdutoPedido> builder)
    {
        base.Configure(builder);
    }
}
