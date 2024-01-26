using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Infrastructure.Identity.Entities;

namespace MultiTenant.Infrastructure.Persistence.Configuration;

public class ApplicationUserTenantConfiguration : IEntityTypeConfiguration<ApplicationUserTenant>
{
    public void Configure(EntityTypeBuilder<ApplicationUserTenant> builder)
    {
        builder
            .HasOne(i => i.User)
            .WithMany(i => i.ApplicationUserTenants)
            .HasForeignKey(i => i.UserId);

        builder
            .HasOne(i => i.Tenant)
            .WithMany()
            .HasForeignKey(i => i.TenantId);
    }
}