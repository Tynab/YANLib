using Volo.Abp.Authorization.Permissions;
using static YANLib.Permissions.YANLibPermissions;

namespace YANLib.Permissions;

public class YANLibPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context) => context.AddGroup(GroupName);
}
