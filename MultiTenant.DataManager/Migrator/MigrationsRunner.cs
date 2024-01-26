using Microsoft.EntityFrameworkCore;
using MultiTenant.Infrastructure.Persistence;

namespace MultiTenant.DataManager.Migrator;

public class MigrationsRunner(IConfiguration configuration, ILogger<MigrationsRunner> logger)
{
    private readonly IConfiguration _configuration = configuration;
    private readonly ILogger<MigrationsRunner> _logger = logger;
    
    public async Task MigrateDatabaseAsync(string databaseName)
    {
        _logger.LogInformation("Being database migrations...");
        
        var connectionString = _configuration.GetConnectionString("Default");
        connectionString = connectionString.Replace("{{DATABASE_NAME}}", databaseName);
        
        _logger.LogInformation("Generated Connection String: {connectionString}", connectionString);

        var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseNpgsql(connectionString, pg =>
        {
            pg.MigrationsHistoryTable("__EFMigrationsHistory", databaseName);
            pg.MigrationsAssembly("MultiTenant.Migrations");
        }).UseSnakeCaseNamingConvention();

        var dbContext = new ApplicationDbContext(dbContextOptions.Options);

        await dbContext.Database.MigrateAsync();
        
        _logger.LogInformation("Migration completed for database: {databaseName}", databaseName);
    }
}