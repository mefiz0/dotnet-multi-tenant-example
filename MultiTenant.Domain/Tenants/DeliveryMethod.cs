using MultiTenant.Domain.Common;

namespace MultiTenant.Domain.Tenants;

public sealed class DeliveryMethod : Entity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public bool IsDefault { get; set; }
}