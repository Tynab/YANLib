using Volo.Abp.Security.Claims;

namespace YANLib;

public class BaseAccessorService(ICurrentPrincipalAccessor currentPrincipalAccessor) : BaseAppService
{
    public Guid? UserId => currentPrincipalAccessor.Principal.Claims.FirstOrDefault(c => c.Type == AbpClaimTypes.UserId)?.Value.Parse<Guid?>();

    public string? UserName => currentPrincipalAccessor.Principal.Claims.FirstOrDefault(c => c.Type == AbpClaimTypes.UserName)?.Value;

    public string? Email => currentPrincipalAccessor.Principal.Claims.FirstOrDefault(c => c.Type == AbpClaimTypes.Email)?.Value;

    public string? PhoneNumber => currentPrincipalAccessor.Principal.Claims.FirstOrDefault(c => c.Type == AbpClaimTypes.PhoneNumber)?.Value;

    public string? Role => currentPrincipalAccessor.Principal.Claims.FirstOrDefault(c => c.Type == AbpClaimTypes.Role)?.Value;
}
