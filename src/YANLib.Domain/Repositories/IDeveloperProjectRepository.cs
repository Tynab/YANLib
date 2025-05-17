using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using YANLib.Dtos;
using YANLib.Entities;

namespace YANLib.Domains;

public interface IDeveloperProjectRepository : IRepository<DeveloperProject, Guid>, ITransientDependency
{
    public Task<DeveloperProject?> Modify(DeveloperProjectDto dto, CancellationToken cancellationToken = default);
}
