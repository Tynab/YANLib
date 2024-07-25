using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using YANLib.Localization;
using static Volo.Abp.Localization.LocalizableString;
using static YANLib.Permissions.YANLibPermissions;

namespace YANLib.Permissions;

public class YANLibPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context) => context.AddGroup(GroupName);
}
