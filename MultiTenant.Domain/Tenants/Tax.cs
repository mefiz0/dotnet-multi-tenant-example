using MultiTenant.Domain.Common;
using MultiTenant.Domain.Common.ValueObjects;

namespace MultiTenant.Domain.Tenants;

public sealed class Tax : Entity<Guid>, IArchivable
{
    public string Name { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    
    // value objects
    public ArchivableAuditInfo AuditInfo { get; set; } = null!;
}