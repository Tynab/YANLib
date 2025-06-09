using YANLib.Dtos;
using YANLib.Entities;

namespace YANLib.Repositories;

public interface IProjectRepository : IYANLibRepository<ProjectDto, Project, string>
{
}
