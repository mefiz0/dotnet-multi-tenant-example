using MultiTenant.Domain.Common;

namespace MultiTenant.Domain.Settings;

public sealed class Country : Entity<int>, IAggregateRoot
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
}