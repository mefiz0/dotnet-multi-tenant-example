using MultiTenant.Domain.Common;
using MultiTenant.Domain.Tenants;

namespace MultiTenant.Infrastructure.Identity.Entities;

public sealed class ApplicationUserTenant : Entity<int>
{
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; } = null!;

    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;
}