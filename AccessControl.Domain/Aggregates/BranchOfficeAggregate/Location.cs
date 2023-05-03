namespace AccessControl.Domain.Aggregates.BranchOfficeAggregate;

public record Location
{
    public string Estate { get; private set; }
    public string Country { get; private set; }

    public Location(string estate, string country)
    {
        Estate = estate;
        Country = country;
    }
}
