﻿using System.Collections.Generic;
using System.Security.Claims;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;
using static Volo.Abp.Security.Claims.AbpClaimTypes;

namespace YANLib.Security;

[Dependency(ReplaceServices = true)]
public class FakeCurrentPrincipalAccessor : ThreadCurrentPrincipalAccessor
{
    protected override ClaimsPrincipal GetClaimsPrincipal() => GetPrincipal();

    private ClaimsPrincipal _principal;

    private ClaimsPrincipal GetPrincipal()
    {
        if (_principal == null)
        {
            lock (this)
            {
                _principal ??= new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new(UserId,"2e701e62-0953-4dd3-910b-dc6cc93ccb0d"),
                    new(UserName,"admin"),
                    new(Email,"admin@abp.io")
                }));
            }
        }

        return _principal;
    }
}
