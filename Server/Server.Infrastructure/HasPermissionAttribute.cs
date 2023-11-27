using Microsoft.AspNetCore.Authorization;

namespace Server.Infrastructure;

public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(string roleClaim) 
        : base(policy: roleClaim)
    { }
}