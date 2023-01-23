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
        var alphaPermission = myGroup.AddPermission(DDDInheritancePermissions.Alphas.Default, L("Permission:DDDInheritance:Alphas"));
        alphaPermission.AddChild(DDDInheritancePermissions.Alphas.Create, L("Permission:DDDInheritance:Create"));
        alphaPermission.AddChild(DDDInheritancePermissions.Alphas.Edit, L("Permission:DDDInheritance:Edit"));
        alphaPermission.AddChild(DDDInheritancePermissions.Alphas.Delete, L("Permission:DDDInheritance:Delete"));

        var betaPermission = myGroup.AddPermission(DDDInheritancePermissions.Betas.Default, L("Permission:DDDInheritance:Betas"));
        betaPermission.AddChild(DDDInheritancePermissions.Betas.Create, L("Permission:DDDInheritance:Create"));
        betaPermission.AddChild(DDDInheritancePermissions.Betas.Edit, L("Permission:DDDInheritance:Edit"));
        betaPermission.AddChild(DDDInheritancePermissions.Betas.Delete, L("Permission:DDDInheritance:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DDDInheritanceResource>(name);
    }
}
