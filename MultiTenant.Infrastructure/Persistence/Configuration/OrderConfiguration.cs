using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Domain.Orders;
using MultiTenant.Infrastructure.Persistence.Extensions;

namespace MultiTenant.Infrastructure.Persistence.Configuration;

public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasOne(i => i.Channel).WithMany().HasForeignKey(i => i.ChannelId);
        builder.HasOne(i => i.Customer).WithMany(i => i.Orders).HasForeignKey(i => i.CustomerId);
        builder.HasOne(i => i.Payment).WithOne().HasForeignKey<Order>(i => i.PaymentId);
        builder.HasOne(i => i.OrderStatus).WithMany().HasForeignKey(i => i.StatusId);
        
        builder.OwnsOne(i => i.ShippingAddress).Configure();

        builder.OwnsMany(i => i.OrderItems, config =>
        {
            config.Property(i => i.ProductId).HasColumnName("product_id");
            config.Property(i => i.Name).HasColumnName("name");
            config.Property(i => i.StockKeepingUnit).HasColumnName("stock_keeping_unit");
            config.Property(i => i.Price).HasColumnName("price");
            config.Property(i => i.DiscountPercentage).HasColumnName("discount_percentage");
            config.Property(i => i.Quantity).HasColumnName("quantity");
        });

        builder.OwnsMany(i => i.AppliedTaxes, config =>
        {
            config.Property(i => i.TaxId).HasColumnName("tax_id");
            config.Property(i => i.Name).HasColumnName("name");
            config.Property(i => i.Rate).HasColumnName("rate");
        });
    }
}