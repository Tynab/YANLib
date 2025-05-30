using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using YANLib.ElasticsearchIndices;

namespace YANLib.Services;

public interface IDeveloperElasticsearchService : IElasticsearchService<DeveloperElasticsearchIndex>
{
    public Task<IReadOnlyCollection<DeveloperElasticsearchIndex?>> GetByIdCardAsync(string idCard, CancellationToken cancellationToken = default);
}
