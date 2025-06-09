using System;
using System.Threading;
using System.Threading.Tasks;
using YANLib.Dtos;
using YANLib.Entities;

namespace YANLib.Repositories;

public interface IDeveloperRepository : IYANLibRepository<DeveloperDto, Developer, Guid>
{
    public Task<(bool HasDeveloperProject, Guid OldId, Developer? Developer)> AdjustAsync(string idCard, Developer entity, CancellationToken cancellationToken = default);
}
