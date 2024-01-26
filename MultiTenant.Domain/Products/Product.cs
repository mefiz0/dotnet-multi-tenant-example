using MultiTenant.Domain.Common;
using MultiTenant.Domain.Common.ValueObjects;
using MultiTenant.Domain.Products.ValueObjects;
using MultiTenant.Domain.Settings;

namespace MultiTenant.Domain.Products;

public sealed class Product : Entity<Guid>, IAggregateRoot, IArchivable
{
    public string Name { get; set; } = string.Empty;
    public string StockKeepingUnit { get; set; } = string.Empty;
    public string Barcode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // relationships
    public int CountryId { get; set; }
    public Country Country { get; set; } = null!;

    public Guid? ParentProductId { get; set; }
    public Product? ParentProduct { get; set; }

    public ICollection<Product> Variants { get; set; } = new List<Product>();

    // value objects
    public Pricing Pricing { get; set; } = null!;
    public DimensionsAndWeight DimensionsAndWeight { get; set; } = null!;
    public ArchivableAuditInfo AuditInfo { get; set; } = null!;
}