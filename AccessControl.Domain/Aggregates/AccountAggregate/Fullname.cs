namespace AccessControl.Domain.Aggregates.AccountAggregate;

/// <summary>
/// Objeto de valor para el nombre completo del usuario
/// </summary>
public record Fullname
{
    public string Name { get; private set; }
    public string Lastname { get; private set; }
    public string Surname { get; private set; }

    public Fullname(string name, string lastname, string surname)
    {
        Name = name;
        Lastname = lastname;
        Surname = surname;
    }
}
