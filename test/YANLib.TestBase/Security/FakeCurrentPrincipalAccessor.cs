using System.Security.Claims;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;

namespace YANLib.Security;

[Dependency(ReplaceServices = true)]
public class FakeCurrentPrincipalAccessor : ThreadCurrentPrincipalAccessor
{
    protected override ClaimsPrincipal GetClaimsPrincipal() => GetPrincipal();

    private static ClaimsPrincipal GetPrincipal() => new(new ClaimsIdentity(
    [
        new(AbpClaimTypes.UserId, "42D5D099-69CF-0F09-C8A7-3A14A554C170"),
        new(AbpClaimTypes.UserName, "OtherUser"),
        new(AbpClaimTypes.Role, "OtherRole")
    ]));
}
