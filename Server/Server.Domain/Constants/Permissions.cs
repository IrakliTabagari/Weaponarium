namespace Server.Domain.Constants;

public static class Permissions
{
    public static class Private
    {
        public static class Users
        {
            public const string Create = "Private.Users.Create";
            public const string Update = "Private.Users.Update";
            public const string View = "Private.Users.View";
            public const string Delete = "Private.Users.Delete";
        }
    }
    
    public static class Public
    {
        public static class Users
        {
            public const string Create = "Public.Users.Create";
            public const string Update = "Public.Users.Update";
            public const string View = "Public.Users.View";
            public const string Delete = "Public.Users.Delete";
        }
    }
}