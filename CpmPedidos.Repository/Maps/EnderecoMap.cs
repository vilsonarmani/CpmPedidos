using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository;

public class EnderecoMap : BaseDomainMap<Endereco>
{
    public EnderecoMap(): base("tb_endereco") { }

    public override void Configure(EntityTypeBuilder<Endereco> builder)
    {
        base.Configure(builder);
    }
}
