using AccessControl.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Data.Base;

/// <summary>
/// Interface para definir los repositorios de los agregados
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> where T : IAggregate
{

}
