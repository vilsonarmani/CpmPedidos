using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository;

public class BaseDomainMap<TDomain> : IEntityTypeConfiguration<TDomain> where TDomain : BaseDomain
{
    private readonly string _tablename;

    public BaseDomainMap(string tablename = "")
    {
        _tablename = tablename;
    }

    public virtual void Configure(EntityTypeBuilder<TDomain> builder)
    {
        if (!string.IsNullOrEmpty(_tablename)){
            builder.ToTable(_tablename);
        }
    }
}
