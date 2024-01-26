using Microsoft.EntityFrameworkCore;
using MultiTenant.Infrastructure.Persistence.Configuration;
using MultiTenant.Domain.Orders;
using MultiTenant.Domain.Products;
using MultiTenant.Domain.Settings;
using MultiTenant.Domain.Tenants;
using MultiTenant.Infrastructure.Persistence.Extensions;

namespace MultiTenant.Infrastructure.Persistence;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderChannel> OrderChannels { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;
    public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Unit> Units { get; set; } = null!;

    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Currency> Currencies { get; set; } = null!;
    public DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
    public DbSet<UnitType> UnitTypes { get; set; } = null!;

    public DbSet<DeliveryMethod> DeliveryMethods { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Tax> Taxes { get; set; } = null!;
    public DbSet<VariantType> VariantTypes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new TaxConfiguration());
        
        modelBuilder.Entity<Employee>().OwnsOne(i => i.AuditInfo).Configure();
        modelBuilder.Entity<VariantType>().OwnsMany(i => i.VariantTypeDefaults);
        modelBuilder.Entity<Customer>().OwnsOne(i => i.BillingAddress).Configure();
        
        modelBuilder.Entity<Payment>(payment =>
        {
            payment.HasOne(i => i.PaymentMethod).WithMany().HasForeignKey(i => i.PaymentMethodId);
            payment.HasOne(i => i.Currency).WithMany().HasForeignKey(i => i.CurrencyId);
        });
    }
}