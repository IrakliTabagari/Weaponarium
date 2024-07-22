namespace Server.Domain.Constants;

public static class PermissionsTree
{
    
    public static class Permissions
    {
        public const string View = "Roles.View";
    }
    public static class Roles
    {
        public const string Create = "Roles.Create";
        public const string Update = "Roles.Update";
        public const string View = "Roles.View";
        public const string Delete = "Roles.Delete";
    }
    
    public static class Users
    {
        public const string Create = "Users.Create";
        public const string Update = "Users.Update";
        public const string View = "Users.View";
        public const string Delete = "Users.Delete";
    }

    public static class Categories
    {
        public const string Create = "Categories.Create";
        public const string Update = "Categories.Update";
        public const string Delete = "Categories.Delete";
        public const string View = "Categories.View";
    }
}