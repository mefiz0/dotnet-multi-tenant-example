using MultiTenant.Domain.Common;

namespace MultiTenant.Domain.Settings;

public sealed class Currency : Entity<Guid>, IAggregateRoot
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Symbol { get; set; } = string.Empty;
    public decimal ExchangeRate { get; set; }
}