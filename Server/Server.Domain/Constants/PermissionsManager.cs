using Server.Domain.Entities;

namespace Server.Domain.Constants;

public static class PermissionsManager
{
    private static readonly Dictionary<string, Permission> PermissionDictionary = new Dictionary<string, Permission>
    {
        { PermissionsTree.Permissions.View, new Permission { Name = PermissionsTree.Permissions.View, Description = "Permission to create view permissions"} },
        
        { PermissionsTree.Roles.Create, new Permission { Name = PermissionsTree.Roles.Create, Description = "Permission to create new role"} },
        { PermissionsTree.Roles.Update, new Permission { Name = PermissionsTree.Roles.Update, Description = "Permission to update role" } },
        { PermissionsTree.Roles.View, new Permission { Name = PermissionsTree.Roles.View, Description = "Permission to view roles" } },
        { PermissionsTree.Roles.Delete, new Permission { Name = PermissionsTree.Roles.Delete, Description = "Permission to delete role" } },
        
        { PermissionsTree.Users.Create, new Permission { Name = PermissionsTree.Users.Create, Description = "Permission to create new user"} },
        { PermissionsTree.Users.Update, new Permission { Name = PermissionsTree.Users.Update, Description = "Permission to update user" } },
        { PermissionsTree.Users.View, new Permission { Name = PermissionsTree.Users.View, Description = "Permission to view user" } },
        { PermissionsTree.Users.Delete, new Permission { Name = PermissionsTree.Users.Delete, Description = "Permission to delete user" } },
        
        { PermissionsTree.Categories.Create, new Permission { Name = PermissionsTree.Categories.Create, Description = "Permission to create new Category"} },
        { PermissionsTree.Categories.Update, new Permission { Name = PermissionsTree.Categories.Update, Description = "Permission to update Category" } },
        { PermissionsTree.Categories.View, new Permission { Name = PermissionsTree.Categories.View, Description = "Permission to view Category" } },
        { PermissionsTree.Categories.Delete, new Permission { Name = PermissionsTree.Categories.Delete, Description = "Permission to delete Category" } },
    };

    public static Dictionary<string, Permission> GetAllPermissions()
    {
        return PermissionDictionary;
    }

    public static Permission? GetPermission(string permissionName)
    {
        return PermissionDictionary.TryGetValue(permissionName, out var permission) 
            ? permission 
            : null;
    }
}