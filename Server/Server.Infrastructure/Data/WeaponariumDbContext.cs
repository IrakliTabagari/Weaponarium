using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain.Constants;
using Server.Domain.Entities;

namespace Server.Infrastructure.Data;

public class WeaponariumDbContext
    : IdentityDbContext<
        User, 
        Role, 
        int,
        IdentityUserClaim<int>,
        UserRole, 
        IdentityUserLogin<int>,
        RoleClaim,
        IdentityUserToken<int>
    >
{
    public WeaponariumDbContext(DbContextOptions<WeaponariumDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(ConfigureUsers);
        modelBuilder.Entity<UserRole>(ConfigureUserRoles);
        modelBuilder.Entity<Role>(ConfigureRoles);
        modelBuilder.Entity<RoleClaim>(ConfigureRoleClaims);
        modelBuilder.Entity<Permission>();
    }

    #region Auth Entity Config
    public static void ConfigureUsers(EntityTypeBuilder<User> builder)
    {
        // Each User can have many entries in the UserRole join table
        builder.ToTable("Users", "Auth")
            .HasMany(e => e.UserRoles)
            .WithOne(e => e.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();
    }
    
    public static void ConfigureUserRoles(EntityTypeBuilder<UserRole> builder)
    {
        // Each User can have many entries in the UserRole join table
        builder.ToTable("UserRoles", "Auth");
    }
    
    public static void ConfigureRoles(EntityTypeBuilder<Role> builder)
    {
        // Each User can have many entries in the UserRole join table
        builder.ToTable("Roles", "Auth");
        // Each Role can have many entries in the UserRole join table
        builder.HasMany(e => e.UserRoles)
            .WithOne(e => e.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();

        // Each Role can have many associated RoleClaims
        builder.HasMany(e => e.RoleClaims)
            .WithOne(e => e.Role)
            .HasForeignKey(rc => rc.RoleId)
            .IsRequired();
    }
    
    public static void ConfigureRoleClaims(EntityTypeBuilder<RoleClaim> builder)
    {
        // Each User can have many entries in the UserRole join table
        builder.ToTable("RoleClaims", "Auth");
    }
    
    public static void ConfigurePermissions(EntityTypeBuilder<Permission> builder)
    {
        // Each User can have many entries in the UserRole join table
        builder.ToTable("Permissions", "Auth");
        
        // Data Seeding
        var permissions = PermissionsManager.GetAllPermissions().Values;
        builder.HasData(permissions);
    }

    #endregion
    
}