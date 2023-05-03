namespace AccessControl.Domain.Enumerations;

public struct AccountStatus
{
    public int Id { get; }
    public string Name { get; }
    public string Code { get; }
    public string Description { get; }
    public int Index { get; }

    public static AccountStatus Active = new(200, "Activo", "ACT", "Usuario activo", 1);

    private AccountStatus(int id, string name, string code, string desc, int index)
    {
        Id = id;
        Name = name;
        Code = code;
        Description = desc;
        Index = index;
    }
}