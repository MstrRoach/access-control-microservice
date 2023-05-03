using AccessControl.Domain.Base;
using AccessControl.Domain.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Domain.Aggregates.BranchOfficeAggregate;

public class BranchOffice : Aggregate<BranchOffice, int>
{
    public string Name { get; private set; }
    public string Code { get; private set; }
    public Location Location { get; private set; }
    public string Description { get; private set; }
    public int Index { get; private set; }
    public bool IsEnabled { get; private set; }
    public bool IsVisible { get; private set; }
    public Audit Audit { get; private set; }

    private List<BranchOfficePermission> _permissions = new List<BranchOfficePermission>();
    public ReadOnlyCollection<BranchOfficePermission> Permissions => _permissions.AsReadOnly(); 

    public static BranchOffice Create(string name, string code, Location location, 
        string description, int index, Audit audit)
    {
        return new BranchOffice
        {
            Id = 0,
            Name = name,
            Code = code,
            Location = location,
            Description = description,
            Index = index,
            IsEnabled = true,
            IsVisible = true,
            Audit = audit
        };
    }

    /// <summary>
    /// Agrega un permiso a la sucursal
    /// </summary>
    /// <param name="permission"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void AddPermission(BranchOfficePermission permission)
    {
        if (_permissions.Exists(x => x.PermissionId == permission.PermissionId))
            return;
        _permissions.Add(permission);
    }

    /// <summary>
    /// Constructor para el ORM
    /// </summary>
    private BranchOffice() { }
}
