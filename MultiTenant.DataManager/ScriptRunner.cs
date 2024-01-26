using MultiTenant.DataManager.TenantFactory;

namespace MultiTenant.DataManager;

public static class ScriptRunner
{
    public static async Task ExecuteScriptsAsync(this IHost host)
    {
        using var scope = host.Services.CreateScope();

        // get services
        var primaryTenantFactory = scope.ServiceProvider.GetRequiredService<PrimaryTenantFactory>();
        
        // run services
        var primaryTenant = await primaryTenantFactory.CreateAsync();
        await primaryTenantFactory.SeedAdministrator(primaryTenant.Id);
    }
}