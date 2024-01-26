using MultiTenant.Domain.Common;
using MultiTenant.Domain.Settings;

namespace MultiTenant.Domain.Products;

public sealed class Unit : Entity<int>
{
    public string Name { get; set; } = string.Empty;
    public decimal ConversionFactor { get; set; }
    public bool IsStandardUnit { get; set; }
    
    // relationships
    public int UnitTypeId { get; set; }
    public UnitType UnitType { get; set; } = null!;
}