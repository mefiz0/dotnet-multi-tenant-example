namespace MultiTenant.Domain.Products.ValueObjects;

public sealed class Pricing
{
    public decimal PriceExcludingTax { get; set; }
    public decimal CostPrice { get; set; }
}