using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiTenant.Infrastructure.Services;
using MultiTenant.Domain.Tenants.Services;
using MultiTenant.Infrastructure.Identity;
using MultiTenant.Infrastructure.Persistence;

namespace MultiTenant.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        services.AddApplicationIdentity(configuration);

        services.AddScoped<ITenantProvider, TenantProvider>();
    }
}