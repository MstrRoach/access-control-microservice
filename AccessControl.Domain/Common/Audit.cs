namespace AccessControl.Domain.Common;

public record Audit
{
    public string CreatedBy { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public string LastUpdatedBy { get; private set; }
    public DateTime LastUpdatedOn { get; private set; }

    public Audit(string createdBy)
    {
        CreatedBy = createdBy;
        CreatedOn = DateTime.UtcNow;
        LastUpdatedBy = createdBy;
        LastUpdatedOn = DateTime.UtcNow;
    }

    public Audit Update(string updatedBy)
    {
        return this with { 
            LastUpdatedBy = updatedBy, 
            LastUpdatedOn = DateTime.UtcNow 
        };
    }
}