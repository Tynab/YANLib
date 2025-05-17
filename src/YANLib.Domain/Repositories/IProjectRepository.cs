using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using YANLib.Dtos;
using YANLib.Entities;

namespace YANLib.Domains;

public interface IProjectRepository : IRepository<Project, string>, ITransientDependency
{
    public Task<Project?> ModifyAsync(ProjectDto dto, CancellationToken cancellationToken = default);
}
