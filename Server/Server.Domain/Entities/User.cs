using Microsoft.AspNetCore.Identity;

namespace Server.Domain.Entities;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    
    public virtual ICollection<UserRole> UserRoles { get; set; }
    // public virtual ICollection<ApplicationUserLogin> Logins { get; set; }
    // public virtual ICollection<ApplicationUserToken> Tokens { get; set; }
}