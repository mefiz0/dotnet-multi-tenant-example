using MultiTenant.DataManager;
using MultiTenant.DataManager.Migrator;
using MultiTenant.DataManager.TenantFactory;
using MultiTenant.Infrastructure;

try
{
    var builder = Host.CreateApplicationBuilder(args);

    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();
    
    builder.Services.AddLogging();
    
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddScoped<MigrationsRunner>();
    builder.Services.AddScoped<PrimaryTenantFactory>();

    var host = builder.Build();

    await host.ExecuteScriptsAsync();

    Console.WriteLine("Execution Complete");
}
catch (Exception e)
{
    Console.WriteLine($"Error: \n{e}");
}