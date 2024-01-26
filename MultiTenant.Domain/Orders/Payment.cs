using MultiTenant.Domain.Common;
using MultiTenant.Domain.Settings;

namespace MultiTenant.Domain.Orders;

public sealed class Payment : Entity<Guid>
{
    public decimal Amount { get; set; }
    public string Reference { get; set; } = string.Empty;
    
    // relationships
    public int PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; } = null!;

    public Guid CurrencyId { get; set; }
    public Currency Currency { get; set; } = null!;
}