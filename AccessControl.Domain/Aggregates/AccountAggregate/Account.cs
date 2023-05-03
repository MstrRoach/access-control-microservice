using AccessControl.Domain.Aggregates.AccountAggregate.Events;
using AccessControl.Domain.Base;
using AccessControl.Domain.Common;
using AccessControl.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Domain.Aggregates.AccountAggregate;

internal class Account : Aggregate<Account,Guid>
{
    public string InternalId { get; private set; }
    public Email Email { get; private set; }
    public Fullname Fullname { get; private set; }
    public DateTime Birthdate { get; private set; }
    public WorkRole WorkRole { get; private set; }
    public DateTime EnteredOn { get; private set; }
    public AccountStatus AccountStatus { get; private set; }
    public Audit Audit { get; private set; }

    private List<AccountRole> _accountRoles = new List<AccountRole>();
    public ReadOnlyCollection<AccountRole> AccountRoles => _accountRoles.AsReadOnly();

    /// <summary>
    /// Creacion para asegurar las invariantes
    /// </summary>
    /// <param name="internalId"></param>
    /// <param name="email"></param>
    /// <param name="fullname"></param>
    /// <param name="birthdate"></param>
    /// <param name="workRole"></param>
    /// <param name="enteredOn"></param>
    /// <param name="basicRole"></param>
    /// <returns></returns>
    public static (Account?, string?) Create(string internalId, Email email, Fullname fullname, 
        DateTime birthdate, WorkRole workRole, DateTime enteredOn, AccountRole basicRole, Audit audit)
    {
        if (string.IsNullOrEmpty(internalId))
            return (null, "Internal id can not be null");
        if(email is null)
            return (null, "Email can not be null");
        if(fullname is null)
            return (null, "Fullname can not be null");
        if(birthdate == default(DateTime))
            return (null, "Birthdate can not be null");
        if(workRole is null)
            return (null, "WorkRole can not be null");
        var account = new Account
        {
            Id = Guid.NewGuid(),
            InternalId = internalId,
            Email = email,
            Fullname = fullname,
            Birthdate = birthdate,
            WorkRole = workRole,
            EnteredOn = enteredOn,
            AccountStatus = AccountStatus.Active,
            Audit = audit
        };
        account.AddRole(basicRole);
        account.AddDomainEvent(new AccountCreatedDomainEvent(account.Id));
        return (account, null);
    }

    /// <summary>
    /// Constructor privado para orm
    /// </summary>
    private Account() { }

    /// <summary>
    /// Agrega un rol a la cuenta
    /// </summary>
    /// <param name="role"></param>
    private void AddRole(AccountRole role)
    {
        if (_accountRoles.Exists(x => x.RoleId == role.RoleId))
            return;
        _accountRoles.Add(role);
    }
}
