using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using YANLib.Localization;
using static Volo.Abp.Localization.LocalizableString;

namespace YANLib.Permissions;

public class YANLibPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context) => context.AddGroup(YANLibPermissions.GroupName);
}
