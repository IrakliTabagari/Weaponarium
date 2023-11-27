using Microsoft.AspNetCore.Identity;

namespace Server.Domain.Entities;

public class Role : IdentityRole<int>
{
    public string Description { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
    public virtual ICollection<RoleClaim> RoleClaims { get; set; }
}