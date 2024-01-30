using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Xunit;

namespace YANLib.EntityFrameworkCore.Samples;

public class SampleRepositoryTests : YANLibEntityFrameworkCoreTestBase
{
    private readonly IRepository<IdentityUser, Guid> _appUserRepository;

    public SampleRepositoryTests() => _appUserRepository = GetRequiredService<IRepository<IdentityUser, Guid>>();

    [Fact]
    public async Task Should_Query_AppUser() => await WithUnitOfWorkAsync(async () =>
    {
        //Act
        var adminUser = await (await _appUserRepository.GetQueryableAsync()).Where(u => u.UserName == "admin").FirstOrDefaultAsync();

        //Assert
        _ = adminUser.ShouldNotBeNull();
    });
}
