using Microsoft.AspNetCore.Identity;

namespace Server.Domain.Entities;

public class RoleClaim : IdentityRoleClaim<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual Role Role { get; set; }
}