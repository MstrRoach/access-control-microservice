namespace AccessControl.Domain.Aggregates.AccountAggregate;

public record WorkRole
{
    public string BranchOfficeCode { get; private set; }
    public string DepartmentCode { get; private set; }
    public string AreaCode { get; private set; }
    public string Position { get; private set; }

    public WorkRole(string branchOfficeCode, string departmentCode, string areaCode, string position)
    {
        BranchOfficeCode = branchOfficeCode;
        DepartmentCode = departmentCode;
        AreaCode = areaCode;
        Position = position;
    }
}
