using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.App.Base;

public interface IRequest<in T>
{
    Guid Id { get; }
}
