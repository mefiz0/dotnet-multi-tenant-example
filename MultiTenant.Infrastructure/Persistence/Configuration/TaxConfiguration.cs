using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Domain.Tenants;
using MultiTenant.Infrastructure.Persistence.Extensions;

namespace MultiTenant.Infrastructure.Persistence.Configuration;

public class TaxConfiguration : IEntityTypeConfiguration<Tax>
{
    public void Configure(EntityTypeBuilder<Tax> builder)
    {
        builder.OwnsOne(i => i.AuditInfo).Configure();
    }
}