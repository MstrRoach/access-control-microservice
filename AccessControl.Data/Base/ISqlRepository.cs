using AccessControl.Domain.Base;
using System.Linq.Expressions;

namespace AccessControl.Data.Base;

/// <summary>
/// Interface para los repositorios que manejan bases de datos relacionales
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ISqlRepository<T> : IRepository<T> where T : IAggregate
{
    public Task<T> Save(T aggregate);

    //public Task<IEnumerable<T>> SaveAll(IEnumerable<T> aggregates);

    public Task<T> Update(T aggregate);

    //public Task<IEnumerable<T>> UpdateAll(IEnumerable<T> aggregates);

    public Task Delete(T aggregate);

    //public Task Delete(Expression<Func<T, bool>> criteria);

    public Task<T> Get(Expression<Func<T, bool>> criteria);

    public Task<List<T>> GetAll(Expression<Func<T, bool>> criteria);

    public Task<bool> Exist(Expression<Func<T, bool>> criteria);

    public Task<int> Count(Expression<Func<T, bool>> criteria = null);
}
