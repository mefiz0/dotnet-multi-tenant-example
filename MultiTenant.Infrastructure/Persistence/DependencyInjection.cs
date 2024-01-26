using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiTenant.Domain.Tenants.Services;

namespace MultiTenant.Infrastructure.Persistence;

internal static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TenantDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Tenants"),
                    pg =>
                    {
                        pg.MigrationsHistoryTable("__EFMigrationsHistory", "multi_tenant_master");
                        pg.MigrationsAssembly("MultiTenant.Migrations");
                    })
                .UseSnakeCaseNamingConvention();
        });
        
        services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
        {
            var tenantProvider = serviceProvider.GetRequiredService<ITenantProvider>();
            
            var connectionString = tenantProvider.GetConnectionString() ?? configuration.GetConnectionString("Migrations");
            var schema = "example";

            if (!string.IsNullOrEmpty(tenantProvider.DatabaseName)) schema = tenantProvider.DatabaseName;
            
            options.UseNpgsql(connectionString, pg =>
            {
                pg.MigrationsHistoryTable("__EFMigrationsHistory", schema);
                pg.MigrationsAssembly("MultiTenant.Migrations");
            }).UseSnakeCaseNamingConvention();
        });
    }
}