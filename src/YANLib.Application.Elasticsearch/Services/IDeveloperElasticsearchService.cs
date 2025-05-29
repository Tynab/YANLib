using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YANLib.ElasticsearchIndices;
using YANLib.Responses;

namespace YANLib.Services;

public interface IDeveloperElasticsearchService : IElasticsearchService<DeveloperElasticsearchIndex>
{
    public Task<IReadOnlyCollection<DeveloperElasticsearchIndex?>> GetByIdCardAsync(string idCard, CancellationToken cancellationToken = default);
}
