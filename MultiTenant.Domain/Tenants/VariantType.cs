using MultiTenant.Domain.Common;
using MultiTenant.Domain.Tenants.ValueObjects;

namespace MultiTenant.Domain.Tenants;

public sealed class VariantType : Entity<int>
{
    public string Name { get; set; } = string.Empty;
    
    // value objects
    public ICollection<VariantTypeDefault> VariantTypeDefaults { get; set; } = new List<VariantTypeDefault>();
}