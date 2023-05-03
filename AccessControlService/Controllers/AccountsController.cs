using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccessControlService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateAccount()
    {
        throw new NotImplementedException();
    }

    [HttpPost("{account:guid}/role")]
    public IActionResult AssociateRole([FromQuery] Guid account, [FromBody] object command)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{account:guid}/role/{role:int}")]
    public IActionResult RemoveRole([FromQuery] Guid account, [FromQuery] int role)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{account:guid}/permissions")]
    public IActionResult GetPermissions([FromQuery]Guid account)
    {
        throw new NotImplementedException();
    }

   
}
