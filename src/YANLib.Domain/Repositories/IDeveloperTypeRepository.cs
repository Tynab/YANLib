using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using YANLib.Dtos;
using YANLib.Entities;

namespace YANLib.Repositories;

public interface IDeveloperTypeRepository : IRepository<DeveloperType, Guid>, ITransientDependency
{
    public ValueTask<DeveloperType?> Modify(DeveloperTypeDto dto);
}
