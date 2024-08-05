//using System.Linq;
//using Volo.Abp.Security.Claims;

//namespace YANLib;

//public class YANLibAccessorService : YANLibAppService
//{
//    protected ICurrentPrincipalAccessor _currentPrincipalAccessor;

//    protected YANLibAccessorService(ICurrentPrincipalAccessor currentPrincipalAccessor) => _currentPrincipalAccessor = currentPrincipalAccessor;

//    public string? UserId => _currentPrincipalAccessor.Principal.Claims.FirstOrDefault(c => c.Type == AbpClaimTypes.UserId)?.Value;

//    public string? UserName => _currentPrincipalAccessor.Principal.Claims.FirstOrDefault(c => c.Type == AbpClaimTypes.UserName)?.Value;

//    public string? Name => _currentPrincipalAccessor.Principal.Claims.FirstOrDefault(c => c.Type == AbpClaimTypes.Name)?.Value;

//    public string? Email => _currentPrincipalAccessor.Principal.Claims.FirstOrDefault(c => c.Type == AbpClaimTypes.Email)?.Value;

//    public string? PhoneNumber => _currentPrincipalAccessor.Principal.Claims.FirstOrDefault(c => c.Type == AbpClaimTypes.PhoneNumber)?.Value;

//    public string[]? Role => _currentPrincipalAccessor.Principal.Claims.FirstOrDefault(c => c.Type == AbpClaimTypes.Role)?.Value.Split(',');
//}
