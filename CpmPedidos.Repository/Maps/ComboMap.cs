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
    }
}
