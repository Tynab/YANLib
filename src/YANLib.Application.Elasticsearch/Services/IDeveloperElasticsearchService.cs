using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using YANLib.ElasticsearchIndices;

namespace YANLib.Services;

public interface IDeveloperElasticsearchService : IElasticsearchService<DeveloperElasticsearchIndex, Guid>
{
    public Task<IReadOnlyCollection<DeveloperElasticsearchIndex?>> GetByIdCardAsync(string idCard, CancellationToken cancellationToken = default);
}
