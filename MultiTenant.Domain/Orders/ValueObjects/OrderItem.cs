using MultiTenant.Domain.Common;

namespace MultiTenant.Domain.Orders.ValueObjects;

public sealed class OrderItem : ValueObject
{
    public Guid ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string StockKeepingUnit { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal DiscountPercentage { get; set; }
    public int Quantity { get; set; }
    
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return ProductId;
        yield return Name;
        yield return StockKeepingUnit;
        yield return Price;
        yield return DiscountPercentage;
        yield return Quantity;
    }
}