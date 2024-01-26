using Microsoft.AspNetCore.Identity;

namespace MultiTenant.Infrastructure.Identity.Entities;

public sealed class ApplicationUser : IdentityUser<Guid>
{
    public ICollection<ApplicationUserTenant> ApplicationUserTenants { get; set; } = new List<ApplicationUserTenant>();
}