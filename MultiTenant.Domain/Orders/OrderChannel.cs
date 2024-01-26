using MultiTenant.Domain.Common;

namespace MultiTenant.Domain.Orders;

public sealed class OrderChannel : Entity<int>
{
    public string Name { get; set; } = string.Empty;
}