namespace AccessControl.Domain.Aggregates.AccountAggregate;

public class AccountRole
{
    public Guid AccountId { get; private set; }
    public int RoleId { get; private set; }
    public string CreatedBy { get; private set; }
    public DateTime CreatedOn { get; private set; }

    /// <summary>
    /// Construccion para asegurar las invariantes
    /// </summary>
    /// <param name="accountId"></param>
    /// <param name="roleId"></param>
    /// <param name="createdBy"></param>
    /// <param name="createdOn"></param>
    /// <returns></returns>
    public static AccountRole Create(Guid accountId, int roleId, string createdBy, DateTime createdOn)
    {
        return new AccountRole
        {
            AccountId = accountId,
            RoleId = roleId,
            CreatedBy = createdBy,
            CreatedOn = createdOn
        };
    }

    private AccountRole() { }
}