using AccessControl.Domain.Aggregates.BranchOfficeAggregate;
using AccessControl.Domain.Base;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Data.Repositories;

internal class BranchOfficeRepository : ISqlRepository<BranchOffice>
{
    private static ConcurrentBag<BranchOffice> branchOffices = new ConcurrentBag<BranchOffice>();

    public Task<int> Count(Expression<Func<BranchOffice, bool>> criteria = null)
    {
        var predicate = criteria.Compile();
        return Task.FromResult(branchOffices.Count(predicate));
    }

    public Task Delete(BranchOffice aggregate)
    {
        
        return Task.CompletedTask;
        throw new NotImplementedException();
    }

    public Task<bool> Exist(Expression<Func<BranchOffice, bool>> criteria)
    {
        var predicate = criteria.Compile();
        return Task.FromResult(branchOffices.Any(predicate));
    }

    public Task<BranchOffice> Get(Expression<Func<BranchOffice, bool>> criteria)
    {
        var predicate = criteria.Compile();
        return Task.FromResult(branchOffices.Where(predicate).FirstOrDefault());
    }

    public Task<List<BranchOffice>> GetAll(Expression<Func<BranchOffice, bool>> criteria)
    {
        var predicate = criteria.Compile();
        return Task.FromResult(branchOffices.Where(predicate).ToList());
    }

    public Task<BranchOffice> Save(BranchOffice aggregate)
    {
        var id = branchOffices.Any() ? branchOffices.Max(x => x.Id) + 1 : 1;
        PropertyInfo property = typeof(BranchOffice).GetProperty("Id");
        property.DeclaringType.GetProperty("Id");
        property.SetValue(aggregate, id, BindingFlags.NonPublic | BindingFlags.Instance, null, null, null);
        branchOffices.Add(aggregate);
        return Task.FromResult(aggregate);
    }

    public Task<BranchOffice> Update(BranchOffice aggregate)
    {
        return Task.FromResult(aggregate);
    }
}
