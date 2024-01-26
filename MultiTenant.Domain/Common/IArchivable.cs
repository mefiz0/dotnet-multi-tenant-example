using MultiTenant.Domain.Common.ValueObjects;

namespace MultiTenant.Domain.Common;

public interface IArchivable
{
    
    public ArchivableAuditInfo AuditInfo { get; set; }
}