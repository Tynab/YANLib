using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace YANLib.EntityFrameworkCore.Samples;

/* This is just an example test class.
 * Normally, you don't test ABP framework code
 * Only test your custom repository methods.
 */
[Collection(YANLibTestConsts.CollectionDefinitionName)]
public class SampleRepositoryTests : YANLibEntityFrameworkCoreTestBase
{
    private readonly IRepository<IdentityUser, Guid> _appUserRepository;

    public SampleRepositoryTests()
    {
        _appUserRepository = GetRequiredService<IRepository<IdentityUser, Guid>>();
    }

    [Fact]
    public async Task Should_Query_AppUser()
    {
        /* Need to manually start Unit Of Work because
         * FirstOrDefaultAsync should be executed while db connection / context is available.
         */
        await WithUnitOfWorkAsync(async () =>
        {
            //Act
            var adminUser = await _appUserRepository
            .FirstOrDefaultAsync(u => u.UserName == "admin");

            //Assert
            adminUser.ShouldNotBeNull();
        });
    }
}
