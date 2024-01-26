using MultiTenant.Domain.Settings;

namespace MultiTenant.Domain.Products.ValueObjects;

public sealed class DimensionsAndWeight
{
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Depth { get; set; }
    public decimal Weight { get; set; }
    
    // relationships
    public int DimensionUnitId { get; set; }
    public Unit DimensionUnit { get; set; } = null!;

    public int WeightUnitId { get; set; }
    public Unit WeightUnit { get; set; } = null!;
}