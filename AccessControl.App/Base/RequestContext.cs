using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AccessControl.App.Base;

public class RequestContext
{
    public RequestContext(IHttpContextAccessor contextAccesor)
    {
        UserId = TryGetValue(contextAccesor, ClaimTypes.NameIdentifier, out var user) ? user : Guid.Empty.ToString() ;
        Username = TryGetValue(contextAccesor, ClaimTypes.Name, out var name) ? name : "System";
    }

    private bool TryGetValue(IHttpContextAccessor contextAccesor, string claim, out string value)
    {
        value = null;
        if (contextAccesor.HttpContext is null)
            return false;
        value = contextAccesor.HttpContext.User.FindFirstValue(claim);
        return value is not null;
    }
    public string UserId { get; }
    public string Username { get; }
}
