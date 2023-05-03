namespace AccessControl.Domain.Aggregates.BranchOfficeAggregate;

public class BranchOfficePermission
{
    public int BranchOfficeId { get; private set; }
    public int PermissionId { get; private set; }
    public string CreatedBy { get; private set; }
    public DateTime CreatedOn { get; private set; }

    public static BranchOfficePermission Create(int branchOfficeId, int permissionId, string createdBy)
    {
        return new BranchOfficePermission
        {
            BranchOfficeId = branchOfficeId,
            PermissionId = permissionId,
            CreatedBy = createdBy,
            CreatedOn = DateTime.UtcNow
        };
    }

    /// <summary>
    /// Constructor para el ORM
    /// </summary>
    private BranchOfficePermission() { }    
}