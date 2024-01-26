namespace MultiTenant.Domain.Tenants.Services;

public interface ITenantProvider
{
    Guid TenantId { get; }
    string? DatabaseName { get; }

    Task SetTenant();
    string? GetConnectionString();
}