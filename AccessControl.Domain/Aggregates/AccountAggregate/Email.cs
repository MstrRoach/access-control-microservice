namespace AccessControl.Domain.Aggregates.AccountAggregate;

public record Email
{
    public string Address { get; private set; }
    public string Normalized { get; private set; }

    public Email(string address)
    {
        Address = address;
        Normalized = Address.ToUpper();
    }
}
