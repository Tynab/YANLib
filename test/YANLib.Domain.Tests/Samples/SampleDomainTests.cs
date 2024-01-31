using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Xunit;

namespace YANLib.Samples;

public class SampleDomainTests : YANLibDomainTestBase
{
    private readonly IIdentityUserRepository _identityUserRepository;
    private readonly IdentityUserManager _identityUserManager;

    public SampleDomainTests()
    {
        _identityUserRepository = GetRequiredService<IIdentityUserRepository>();
        _identityUserManager = GetRequiredService<IdentityUserManager>();
    }

    [Fact]
    public async Task Should_Set_Email_Of_A_User()
    {
        IdentityUser adminUser;

        await WithUnitOfWorkAsync(async () =>
        {
            adminUser = await _identityUserRepository.FindByNormalizedUserNameAsync("YAN");
            _ = await _identityUserManager.SetEmailAsync(adminUser, "yamiannephilim@gmail.com");
            _ = await _identityUserRepository.UpdateAsync(adminUser);
        });

        adminUser = await _identityUserRepository.FindByNormalizedUserNameAsync("YAN");
        adminUser.Email.ShouldBe("yamiannephilim@gmail.com");
    }
}
