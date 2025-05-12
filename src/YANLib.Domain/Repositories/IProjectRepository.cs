using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using YANLib.Dtos;
using YANLib.Entities;

namespace YANLib.Repositories;

public interface IProjectRepository : IRepository<Project, string>, ITransientDependency
{
    public Task<Project?> Modify(ProjectDto dto);
}
