using MultiTenant.Domain.Common;

namespace MultiTenant.Domain.Tenants.ValueObjects;

public sealed class VariantTypeDefault : ValueObject
{
    public string Name { get; set; } = string.Empty;
    
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Name;
    }
}