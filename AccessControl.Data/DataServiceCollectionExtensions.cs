using AccessControl.Data.Repositories;
using AccessControl.Domain.Aggregates.BranchOfficeAggregate;
using AccessControl.Domain.Base;
using Microsoft.Extensions.DependencyInjection;

namespace AccessControl.Data;

public static class DataServiceCollectionExtensions
{
    public static IServiceCollection AddAccessControlData(this IServiceCollection services)
    {
        services.AddScoped<ISqlRepository<BranchOffice>, BranchOfficeRepository>();
        return services;
    }
}