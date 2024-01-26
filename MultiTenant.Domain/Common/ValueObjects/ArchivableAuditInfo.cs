namespace MultiTenant.Domain.Common.ValueObjects;

public sealed class ArchivableAuditInfo : ValueObject
{
    public string CreatedByUserId { get; set; }
    public DateTime CreatedDate { get; set; }

    public string? UpdatedByUserId { get; set; }
    public DateTime? UpdatedDate { get; set; }
    
    public bool IsArchived { get; set; } = false;
    public DateTime? ArchivedDate { get; set; }
    public string? ArchivedByUserId { get; set; }
    
    public ArchivableAuditInfo(string createdByUserId)
    {
        CreatedByUserId = createdByUserId;
        CreatedDate = DateTime.UtcNow;
    }
    
    public static ArchivableAuditInfo Initialize(string createdByUserId) => new(createdByUserId);
    
    public void LogUpdate(string updatedByUserId)
    {
        UpdatedByUserId = updatedByUserId;
        UpdatedDate = DateTime.UtcNow;
    }

    public void Archive(string archivedByUserId)
    {
        IsArchived = true;
        ArchivedDate = DateTime.UtcNow;
        ArchivedByUserId = archivedByUserId;
    }

    public void UnArchive()
    {
        IsArchived = false;
        ArchivedDate = null;
        ArchivedByUserId = null;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return CreatedByUserId;
        yield return CreatedDate;
        yield return UpdatedByUserId;
        yield return UpdatedDate;
        
        yield return IsArchived;
        yield return ArchivedDate;
        yield return ArchivedByUserId; 
    }
}