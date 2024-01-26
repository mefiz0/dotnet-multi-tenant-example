namespace MultiTenant.Domain.Common;

public abstract class Entity<TId>
{
#pragma warning disable CS8618
    protected Entity()
    {
        // EF
    }
#pragma warning restore CS8618

    protected Entity(TId id)
    {
        Id = id;
    }

    public TId Id { get; set; }
}