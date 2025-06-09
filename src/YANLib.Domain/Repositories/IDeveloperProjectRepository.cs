using System;
using YANLib.Dtos;
using YANLib.Entities;

namespace YANLib.Repositories;

public interface IDeveloperProjectRepository : IYANLibRepository<DeveloperProjectDto, DeveloperProject, Guid>
{
}
