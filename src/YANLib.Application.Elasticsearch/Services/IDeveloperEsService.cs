using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using YANLib.EsIndices;

namespace YANLib.Services;

public interface IDeveloperEsService : IElasticsearchService<DeveloperEsIndex, string>
{
    public Task<IReadOnlyCollection<DeveloperEsIndex?>> GetById(Guid id, CancellationToken cancellationToken = default);
}
