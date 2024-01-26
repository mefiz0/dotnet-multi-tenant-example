using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Domain.Tenants;
using MultiTenant.Infrastructure.Persistence.Extensions;

namespace MultiTenant.Infrastructure.Persistence.Configuration;

internal sealed class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.HasIndex(i => i.DatabaseName).IsUnique();

        builder.OwnsOne(i => i.AuditInfo).Configure();
        builder.OwnsOne(i => i.Address).Configure();
    }
}