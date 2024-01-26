using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MultiTenant.Infrastructure.Persistence;
using MultiTenant.Domain.Tenants.Services;

namespace MultiTenant.Infrastructure.Services;

public class TenantProvider(
    IHttpContextAccessor httpContextAccessor,
    TenantDbContext tenantDbContext,
    IConfiguration configuration) : ITenantProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly TenantDbContext _tenantDbContext = tenantDbContext;
    private readonly IConfiguration _configuration = configuration;

    public Guid TenantId { get; private set; }
    public string? DatabaseName { get; private set; } = string.Empty;

    public async Task SetTenant()
    {
        var hasTenant =
            Guid.TryParse(_httpContextAccessor.HttpContext?.User.Claims.First(i => i.Type == "TenantId").Value,
                out var tenantId);

        if (!hasTenant) throw new Exception("Access Denied");

        TenantId = tenantId;
        DatabaseName = await _tenantDbContext.Tenants
            .Where(i => i.Id == TenantId)
            .Select(i => i.DatabaseName)
            .SingleOrDefaultAsync();
    }

    public string? GetConnectionString()
    {
        var connectionString = _configuration.GetConnectionString("Default");

        return connectionString?.Replace("{{DATABASE_NAME}}", DatabaseName);
    }
}