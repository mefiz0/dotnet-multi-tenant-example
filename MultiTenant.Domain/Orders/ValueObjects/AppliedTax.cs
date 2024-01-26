using MultiTenant.Domain.Common;

namespace MultiTenant.Domain.Orders.ValueObjects;

public sealed class AppliedTax : ValueObject
{
    public Guid TaxId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return TaxId;
        yield return Name;
        yield return Rate;
    }
}