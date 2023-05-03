using AccessControl.App.Base;
using AccessControl.Domain.Base;
using AccessControl.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AccessControl.Domain.Aggregates.BranchOfficeAggregate;

public class CreateBranchOfficeCommand : IRequest<Answer<BranchOfficeCreated>>
{
    [JsonIgnore]
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Code { get; set; }
    public string Estate { get; set; }
    public string Country { get; set; }
    public string Description { get; set; }
    public int Index { get; private set; }
    public List<int> PermissionIds { get; set; }
}

public class CreateBranchOfficeHandler : IRequestHandler<CreateBranchOfficeCommand, Answer<BranchOfficeCreated>>
{
    readonly ISqlRepository<BranchOffice> _branchOfficesDb;
    readonly RequestContext _context;
    public CreateBranchOfficeHandler(ISqlRepository<BranchOffice> branchOfficesDb,
        RequestContext context)
    {
        _branchOfficesDb = branchOfficesDb;
        _context = context;
    }
    public async Task<Answer<BranchOfficeCreated>> Handle(CreateBranchOfficeCommand request)
    {
        // Si ya existe la sucursale salimos
        if(await _branchOfficesDb.Exist(x => x.Code == request.Code))
            return new Error("CreateBranchOffice:ExistingRecord", "Branch office already exist");
        // Creamos todos los objetos necesarios y la sucursal
        var location = new Location(request.Estate, request.Country);
        var audit = new Audit(_context.UserId);
        var branchOffice = BranchOffice.Create(request.Name, 
            request.Code, 
            location, 
            request.Description, 
            request.Index,
            audit);
        // Guardamos para obtener el id
        branchOffice = await _branchOfficesDb.Save(branchOffice);
        // Creamos los permisos y los agregamos a la oficina
        //foreach(var permission in request.PermissionIds.Select(x => BranchOfficePermission.Create(branchOffice.Id, x, _context.UserId)))
        //{
        //    branchOffice.AddPermission(permission);
        //}
        //// Actualizamos la base de datos
        //branchOffice = await _branchOfficesDb.Update(branchOffice);
        // Salimos
        return new BranchOfficeCreated
        {
            Id = branchOffice.Id,
            Code = branchOffice.Code,
            Location = new(branchOffice.Location.Estate, branchOffice.Location.Country),
            Permissions = branchOffice.Permissions
            .Select(x => new BranchOfficePermissionCreated(
                x.PermissionId, 
                x.CreatedBy, 
                x.CreatedOn))
            .ToList()
        };
    }
}

public class BranchOfficeCreated
{
    public int Id { get; set; }
    public string Code { get; set; }
    public LocationCreated Location { get; set; }
    public List<BranchOfficePermissionCreated> Permissions { get; set; } = new List<BranchOfficePermissionCreated>();
}

public record LocationCreated(string Estate, string Country);
public record BranchOfficePermissionCreated(int PermissionId,string CreatedBy, DateTime CreatedOn);