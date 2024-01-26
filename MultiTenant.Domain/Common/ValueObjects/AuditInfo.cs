namespace MultiTenant.Domain.Common.ValueObjects;

public sealed class AuditInfo : ValueObject
{
    public AuditInfo(string createdByUserId)
    {
        CreatedByUserId = createdByUserId;
        CreatedDate = DateTime.UtcNow;
    }

    public string CreatedByUserId { get; set; }
    public DateTime CreatedDate { get; set; }

    public string? UpdatedByUserId { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public static AuditInfo Initialize(string createdByUserId) => new(createdByUserId);

    public void LogUpdate(string updatedByUserId)
    {
        UpdatedByUserId = updatedByUserId;
        UpdatedDate = DateTime.UtcNow;
    }
    
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return CreatedByUserId;
        yield return CreatedDate;
        yield return UpdatedByUserId;
        yield return UpdatedDate;
    }
}