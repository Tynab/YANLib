using Volo.Abp.Authorization.Permissions;
using static YANLib.Permissions.BasePermissions;

namespace YANLib.Permissions;

public class BasePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context) => context.AddGroup(GroupName);
}
