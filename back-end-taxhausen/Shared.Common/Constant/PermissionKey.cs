namespace Shared.Common.Constant;

/// <summary>
/// Defines all application permissions.
/// </summary>
public static class PermissionKey
{
    public static class Identity
    {
        public const string Login = "Identity_Login";
        public const string UserView = "Identity.User.View";
        public const string UserCreate = "Identity.User.Create";
        public const string UserUpdate = "Identity.User.Update";
        public const string UserDelete = "Identity.User.Delete";
    }

    public static class Client
    {
        public const string View = "Client.View";
        public const string Create = "Client.Create";
        public const string Update = "Client.Update";
        public const string Delete = "Client.Delete";
    }

    public static class Report
    {
        public const string View = "Report.View";
        public const string Generate = "Report.Generate";
        public const string Download = "Report.Download";
    }

    public static class Calculation
    {
        public const string Calculate = "Calculation.Calculate";
        public const string View = "Calculation.View";
    }
}