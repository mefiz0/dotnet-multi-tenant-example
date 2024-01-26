using MultiTenant.Domain.Common;

namespace MultiTenant.Domain.Settings;

public sealed class UnitType : Entity<int>
{
    public string Name { get; set; } = string.Empty;
}