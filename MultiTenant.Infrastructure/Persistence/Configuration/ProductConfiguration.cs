using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Domain.Products;
using MultiTenant.Infrastructure.Persistence.Extensions;

namespace MultiTenant.Infrastructure.Persistence.Configuration;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne(i => i.Country)
            .WithMany()
            .HasForeignKey(i => i.CountryId);

        builder.HasOne(i => i.ParentProduct)
            .WithMany(i => i.Variants)
            .HasForeignKey(i => i.ParentProductId);

        builder.OwnsOne(i => i.Pricing, config =>
        {
            config.Property(i => i.PriceExcludingTax).HasColumnName("price_excluding_tax");
            config.Property(i => i.CostPrice).HasColumnName("cost_price");
        });

        builder.OwnsOne(i => i.DimensionsAndWeight, config =>
        {
            config.Property(i => i.Width).HasColumnName("width");
            config.Property(i => i.Height).HasColumnName("height");
            config.Property(i => i.Depth).HasColumnName("depth");
            config.Property(i => i.Weight).HasColumnName("weight");

            config.HasOne(i => i.DimensionUnit).WithMany().HasForeignKey(i => i.DimensionUnitId);
            config.HasOne(i => i.WeightUnit).WithMany().HasForeignKey(i => i.WeightUnitId);
        });

        builder.OwnsOne(i => i.AuditInfo).Configure();
    }
}