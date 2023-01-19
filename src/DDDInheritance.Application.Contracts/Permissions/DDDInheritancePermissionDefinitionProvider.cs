using DDDInheritance.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace DDDInheritance.Permissions;

public class DDDInheritancePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(DDDInheritancePermissions.GroupName);

        myGroup.AddPermission(DDDInheritancePermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        myGroup.AddPermission(DDDInheritancePermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(DDDInheritancePermissions.MyPermission1, L("Permission:MyPermission1"));

        var commonPermission = myGroup.AddPermission(DDDInheritancePermissions.Commons.Default, L("Permission:Commons"));
        commonPermission.AddChild(DDDInheritancePermissions.Commons.Create, L("Permission:Create"));
        commonPermission.AddChild(DDDInheritancePermissions.Commons.Edit, L("Permission:Edit"));
        commonPermission.AddChild(DDDInheritancePermissions.Commons.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DDDInheritanceResource>(name);
    }
}