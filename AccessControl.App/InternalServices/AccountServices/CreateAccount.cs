using AccessControl.App.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AccessControl.App.InternalServices.AccountServices;

public class CreateAccountCommand : IRequest<AccountCreated>
{
    [JsonIgnore]
    public Guid Id { get; } = Guid.NewGuid();
    public string InternalId { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Surname { get; set; }
    public DateTime Birthdate { get; set; }
    public int BranchOfficeId { get; set; }
    public int DepartmentId { get; set; }
    public int AreaId { get; set; }
    public string Position { get; set; }
    public DateTime EnteredOn { get; set; }

}

public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, AccountCreated>
{
    readonly RequestContext _context;

    public CreateAccountHandler(RequestContext context)
    {
        _context = context;
    }

    public async Task<AccountCreated> Handle(CreateAccountCommand request)
    {
        await Task.CompletedTask;
        return new AccountCreated
        {
            AccountId = Guid.NewGuid()
        };
    }
}

public class AccountCreated
{
    public Guid AccountId { get; set; }
}

