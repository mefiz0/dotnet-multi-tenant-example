using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiTenant.Infrastructure.Identity.Entities;
using MultiTenant.Infrastructure.Persistence;

namespace MultiTenant.Infrastructure.Identity;

internal static class DependencyInjection
{
    public static void AddApplicationIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<TenantDbContext>()
            .AddDefaultTokenProviders();
    }
}