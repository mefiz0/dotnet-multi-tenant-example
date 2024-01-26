using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenant.Domain.Common;
using MultiTenant.Domain.Common.ValueObjects;

namespace MultiTenant.Infrastructure.Persistence.Extensions;

internal static class OwnedNavigationBuilderExtensions
{
    public static void Configure<TEntity>(
        this OwnedNavigationBuilder<TEntity, ArchivableAuditInfo> navigationBuilder) where TEntity : class, IArchivable
    {
        navigationBuilder.Property(i => i.CreatedByUserId).HasColumnName("created_by_user");
        navigationBuilder.Property(i => i.CreatedDate).HasColumnName("created_date");
        
        navigationBuilder.Property(i => i.UpdatedByUserId).HasColumnName("updated_by_user");
        navigationBuilder.Property(i => i.UpdatedDate).HasColumnName("updated_date");

        navigationBuilder.Property(i => i.IsArchived).HasColumnName("is_archived");
        navigationBuilder.Property(i => i.ArchivedByUserId).HasColumnName("archived_by_user");
        navigationBuilder.Property(i => i.ArchivedDate).HasColumnName("archived_date");
    }
    
    public static void Configure<TEntity>(
        this OwnedNavigationBuilder<TEntity, AuditInfo> navigationBuilder) where TEntity : class, IAuditable
    {
        navigationBuilder.Property(i => i.CreatedByUserId).HasColumnName("created_by_user");
        navigationBuilder.Property(i => i.CreatedDate).HasColumnName("created_date");
        
        navigationBuilder.Property(i => i.UpdatedByUserId).HasColumnName("updated_by_user");
        navigationBuilder.Property(i => i.UpdatedDate).HasColumnName("updated_date");
    }
    
    public static void Configure<TEntity>(
        this OwnedNavigationBuilder<TEntity, Address> navigationBuilder) where TEntity : class
    {
        navigationBuilder.Property(i => i.LineOne).HasColumnName("address_line_one");
        navigationBuilder.Property(i => i.LineTwo).HasColumnName("address_line_two");
        navigationBuilder.Property(i => i.LineThree).HasColumnName("address_line_three");
        navigationBuilder.Property(i => i.PostCode).HasColumnName("address_postcode");
        navigationBuilder.Property(i => i.Country).HasColumnName("address_country");
    }
}