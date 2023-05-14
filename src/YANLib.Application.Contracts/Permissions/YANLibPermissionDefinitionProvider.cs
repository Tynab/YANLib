using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using YANLib.Localization;
using static Volo.Abp.Localization.LocalizableString;

namespace YANLib.Permissions;

public class YANLibPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(YANLibPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(YANLibPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name) => Create<YANLibResource>(name);
}
