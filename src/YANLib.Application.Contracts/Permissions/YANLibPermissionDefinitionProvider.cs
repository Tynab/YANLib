using Volo.Abp.Authorization.Permissions;

namespace YANLib.Permissions;

public class YANLibPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context) => context.AddGroup(YANLibPermissions.GroupName);
}
