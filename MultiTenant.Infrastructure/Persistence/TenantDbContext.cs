using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MultiTenant.Infrastructure.Identity.Entities;
using MultiTenant.Infrastructure.Persistence.Configuration;
using MultiTenant.Domain.Tenants;

namespace MultiTenant.Infrastructure.Persistence;

public class TenantDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public TenantDbContext(DbContextOptions<TenantDbContext> options): base(options)
    {
        
    }

    public DbSet<Tenant> Tenants { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new TenantConfiguration());
        modelBuilder.ApplyConfiguration(new ApplicationUserTenantConfiguration());
    }
}