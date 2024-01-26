using MultiTenant.Domain.Common;
using MultiTenant.Domain.Common.ValueObjects;

namespace MultiTenant.Domain.Orders;

public sealed class Customer : Entity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    
    // relationships
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    
    // value objects
    public Address BillingAddress { get; set; } = null!;
}