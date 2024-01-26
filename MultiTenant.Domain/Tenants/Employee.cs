using MultiTenant.Domain.Common;
using MultiTenant.Domain.Common.ValueObjects;

namespace MultiTenant.Domain.Tenants;

public sealed class Employee : Entity<Guid>, IArchivable
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;
    
    // value objects
    public ArchivableAuditInfo AuditInfo { get; set; } = null!;
}