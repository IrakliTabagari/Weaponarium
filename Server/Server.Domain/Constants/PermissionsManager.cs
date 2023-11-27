using Server.Domain.Entities;

namespace Server.Domain.Constants;

public static class PermissionsManager
{
    private static readonly Dictionary<string, Permission> PermissionDictionary = new Dictionary<string, Permission>
    {
        { Permissions.Private.Users.Create, new Permission { Name = Permissions.Private.Users.Create, Description = "Permission to create new private modules user"} },
        { Permissions.Private.Users.Update, new Permission { Name = Permissions.Private.Users.Update, Description = "Permission to update private modules user" } },
        { Permissions.Private.Users.View, new Permission { Name = Permissions.Private.Users.View, Description = "Permission to view private modules user" } },
        { Permissions.Private.Users.Delete, new Permission { Name = Permissions.Private.Users.Delete, Description = "Permission to delete private modules user" } },
        
        { Permissions.Public.Users.Create, new Permission { Name = Permissions.Public.Users.Create, Description = "Permission to create new public modules user"} },
        { Permissions.Public.Users.Update, new Permission { Name = Permissions.Public.Users.Update, Description = "Permission to update public modules user" } },
        { Permissions.Public.Users.View, new Permission { Name = Permissions.Public.Users.View, Description = "Permission to view public modules user" } },
        { Permissions.Public.Users.Delete, new Permission { Name = Permissions.Public.Users.Delete, Description = "Permission to delete public modules user" } },
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