using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using YANLib.Dtos;
using YANLib.Entities;

namespace YANLib.Repositories;

public interface IDeveloperRepository : IRepository<Developer, Guid>, ITransientDependency
{
    public Task<Developer?> ModifyAsync(DeveloperDto dto, CancellationToken cancellationToken = default);

    public Task<(bool HasDeveloperProject, Guid OldId, Developer? Developer)> AdjustAsync(string idCard, Developer entity, CancellationToken cancellationToken = default);
}
