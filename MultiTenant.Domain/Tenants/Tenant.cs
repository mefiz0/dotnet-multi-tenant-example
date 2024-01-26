using MultiTenant.Domain.Common;
using MultiTenant.Domain.Common.ValueObjects;
using MultiTenant.Domain.Orders;
using MultiTenant.Domain.Products;
using MultiTenant.Domain.Settings;

namespace MultiTenant.Domain.Tenants;

public sealed class Tenant  : Entity<Guid>, IAggregateRoot, IArchivable
{
    public string Name { get; set; } = string.Empty;
    public string RegistrationNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    
    // relationships
    
    // value objects
    public ArchivableAuditInfo AuditInfo { get; set; } = null!;
    public Address Address { get; set; } = null!;
}