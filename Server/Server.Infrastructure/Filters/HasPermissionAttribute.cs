using Microsoft.AspNetCore.Authorization;

namespace Server.Infrastructure.Filters;

public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(string roleClaim) 
        : base(policy: roleClaim)
    { }
}