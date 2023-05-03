using AccessControl.App;
using AccessControl.Domain.Aggregates.BranchOfficeAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccessControlService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BranchOfficesController : ControllerBase
{
    readonly AccessControlServices _accessControlServices;
    public BranchOfficesController(AccessControlServices accessControlServices)
    {
        _accessControlServices = accessControlServices;
    }

    /// <summary>
    /// Crea una sucursal con permisos asignados por defecto
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBranchOfficeCommand command)
    {
        var response = await _accessControlServices.Execute(command);
        return response.Match<IActionResult>(
            success => StatusCode(StatusCodes.Status201Created,success),
            error => StatusCode(StatusCodes.Status400BadRequest, error));
    }

    [HttpGet("Items")]
    public IActionResult GetBranchesEnumeration()
    {
        throw new NotImplementedException();
    }
}
