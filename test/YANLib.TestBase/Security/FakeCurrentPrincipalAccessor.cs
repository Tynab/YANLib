using System.Collections.Generic;
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
        new(AbpClaimTypes.UserId, "2e701e62-0953-4dd3-910b-dc6cc93ccb0d"),
        new(AbpClaimTypes.UserName, "admin"),
        new(AbpClaimTypes.Email, "admin@abp.io")
    ]));
}
