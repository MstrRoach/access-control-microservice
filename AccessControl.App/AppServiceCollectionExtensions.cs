using AccessControl.App.Base;
using AccessControl.App.InternalServices.AccountServices;
using AccessControl.Domain.Aggregates.BranchOfficeAggregate;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.App;

public static class AppServiceCollectionExtensions
{
    public static IServiceCollection AddAccessControlApp(this IServiceCollection services)
    {
        services.AddTransient<IRequestHandler<CreateAccountCommand, AccountCreated>, CreateAccountHandler>();
        services.AddTransient<IRequestHandler<CreateBranchOfficeCommand, Answer<BranchOfficeCreated>>, CreateBranchOfficeHandler>();
        services.AddScoped<AccessControlServices>();
        services.AddScoped<RequestContext>();
        return services;
    }
}
