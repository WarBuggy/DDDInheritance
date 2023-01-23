using DDDInheritance.Alphas;
using DDDInheritance.Betas;

namespace DDDInheritance.Permissions;

public static class DDDInheritancePermissions
{
    public const string GroupName = "DDDInheritance";

    public static class Dashboard
    {
        public const string DashboardGroup = GroupName + ".Dashboard";
        public const string Host = DashboardGroup + ".Host";
        public const string Tenant = DashboardGroup + ".Tenant";
    }

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
    public static class Alphas
    {
        public const string Default = GroupName + ".Alphas";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class Betas
    {
        public const string Default = GroupName + ".Betas";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}

