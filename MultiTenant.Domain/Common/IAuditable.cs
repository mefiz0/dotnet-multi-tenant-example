using MultiTenant.Domain.Common.ValueObjects;

namespace MultiTenant.Domain.Common;

public interface IAuditable
{
    public AuditInfo AuditInfo { get; set; }
}