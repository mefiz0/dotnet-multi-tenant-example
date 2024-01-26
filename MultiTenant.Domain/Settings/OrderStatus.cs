using MultiTenant.Domain.Common;

namespace MultiTenant.Domain.Settings;

public sealed class OrderStatus : Entity<int>
{
    public string Name { get; set; } = string.Empty;
}