using Xunit;
using YANLib.Repositories;

namespace YANLib.EntityFrameworkCore.Repositories;

[Collection(YANLibTestConsts.CollectionDefinitionName)]
public class DeveloperTypeRepositoryTests : YANLibEntityFrameworkCoreTestBase
{
    private readonly IDeveloperTypeRepository _repository;

    public DeveloperTypeRepositoryTests() => _repository = GetRequiredService<IDeveloperTypeRepository>();

    // TODO: Implement your test methods here
}
