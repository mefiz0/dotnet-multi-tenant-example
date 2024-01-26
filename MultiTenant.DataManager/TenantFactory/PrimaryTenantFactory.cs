using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MultiTenant.DataManager.Migrator;
using MultiTenant.Domain.Common.ValueObjects;
using MultiTenant.Domain.Tenants;
using MultiTenant.Infrastructure.Identity.Entities;
using MultiTenant.Infrastructure.Persistence;

namespace MultiTenant.DataManager.TenantFactory;

public class PrimaryTenantFactory(TenantDbContext context, MigrationsRunner migrationsRunner, ILogger<PrimaryTenantFactory> logger, UserManager<ApplicationUser> userManager)
{
    private readonly TenantDbContext _context = context;
    private readonly MigrationsRunner _migrationsRunner = migrationsRunner;
    private readonly ILogger<PrimaryTenantFactory> _logger = logger;
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<Tenant> CreateAsync()
    {
        var tenant = await _context.Tenants.FirstOrDefaultAsync(i => i.Name == "Example Tenant");

        if (tenant is not null)
        {
            _logger.LogInformation("Tenant already exists, skipping creation.");
            return tenant;
        }
        
        _logger.LogInformation("Creating primary tenant...");
        
        tenant = new Tenant
        {
            Name = "Example",
            RegistrationNumber = string.Empty,
            Email = "",
            PhoneNumber = "(000) 0000000",
            DatabaseName = "example",
            AuditInfo = ArchivableAuditInfo.Initialize("administrator"),
            Address = new Address
            {
                Country = "Maldives",
                LineOne = "",
                LineTwo =   "",
                LineThree = "",
                PostCode = ""
            }
        };

        await _context.Tenants.AddAsync(tenant);
        await _context.SaveChangesAsync();

        await _migrationsRunner.MigrateDatabaseAsync(tenant.DatabaseName);
        
        _logger.LogInformation("Primary tenant {tenant} created.", tenant.Name);
        
        return tenant;
    }

    public async Task SeedAdministrator(Guid tenantId)
    {
        var user = await userManager.FindByEmailAsync("admin@localhost.com");
        if (user is not null)
        {
            _logger.LogInformation("Admin already exists, skipping creation.");
            return;
        }
        
        _logger.LogInformation("Creating admin user.");

        var admin = new ApplicationUser
        {
            UserName = "admin@localhost.com",
            Email = "admin@localhost.com",
            NormalizedEmail = "admin@localhost.com".ToUpper(),
            NormalizedUserName = "admin@localhost.com".ToUpper(),
            ApplicationUserTenants = new List<ApplicationUserTenant>
            {
                new()
                {
                    TenantId = tenantId
                }
            }
        };

        await userManager.CreateAsync(admin, "Welcome@123");
        
        _logger.LogInformation("Administrator {admin} created.", "admin@localhost.com");
    }
}