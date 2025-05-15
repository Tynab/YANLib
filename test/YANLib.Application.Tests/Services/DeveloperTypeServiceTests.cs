using Nest;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Xunit;
using YANLib.ListQueries.v1;
using YANLib.Responses;
using YANLib.Services.v1;

namespace YANLib.Services;

[Collection(YANLibTestConsts.CollectionDefinitionName)]
public class DeveloperTypeServiceTests : YANLibApplicationTestBase<YANLibApplicationTestModule>
{
    private readonly IDeveloperTypeService _developerTypeService;

    public DeveloperTypeServiceTests() => _developerTypeService = GetRequiredService<IDeveloperTypeService>();

    [Fact]
    public async Task GetAllDeveloperTypesAsync_ShouldReturnAllDeveloperTypes()
    {
        // Arrange
        var query = new DeveloperTypeListQuery
        {
            PageNumber = 1,
            PageSize = 10,
        };

        var dto = new PagedAndSortedResultRequestDto
        {
            SkipCount = (query.PageNumber - 1) * query.PageSize,
            MaxResultCount = query.PageSize,
            Sorting = $"{nameof(ProjectResponse.Name)} {SortOrder.Ascending},{nameof(ProjectResponse.CreatedAt)} {SortOrder.Descending}"
        };

        var expectedCount = 3;

        // Act
        var result = await _developerTypeService.GetListAsync(dto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedCount, result.TotalCount);
    }
}
