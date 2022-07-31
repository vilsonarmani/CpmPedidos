using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository;

public class ClienteMap : BaseDomainMap<Cliente>
{
    public ClienteMap(): base("tb_cliente") { }

    public override void Configure(EntityTypeBuilder<Cliente> builder)
    {
        base.Configure(builder);
    }
}
